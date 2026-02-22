using CapG.MTBS.Exceptions;
using CapG.MTBS.Models;
using CapG.MTBS.Models.Dtos;
using CapG.MTBS.Repositories;
using CapG.MTBS.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace CapG.MTBS.Web.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieRepository repository;
        private readonly IRepository<Director> directorRepo;
        private readonly IRepository<Actor> actorRepo;

        public MoviesController(IMovieRepository repository, IRepository<Director> directorRepo, IRepository<Actor> actorRepo)
        {
            this.repository = repository;
            this.directorRepo = directorRepo;
            this.actorRepo = actorRepo;
        }

        // GET: MoviesController
        public ActionResult Index()
        {
            var list = repository.Get();
            return View(list);
        }

        // GET: MoviesController/Details/5
        public ActionResult Details(int id)
        {
            var movieDto = repository.Get(id);
            var cast = repository.GetCast(id);
            var movie = new MovieCastViewModel
            {
                Id = movieDto.Id,
                Name = movieDto.Name,
                Genre = movieDto.Genre,
                DirectorName = movieDto.Director.Name,
                Actors = cast
            };
            return View(movie);
        }

        // GET: MoviesController/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            //var directorList = directorRepo.Get();
            //ViewBag.Directors = new SelectList(directorList, "Id", "Name");
            MovieViewModel movieVM = new MovieViewModel 
            {
                Director = new SelectList(directorRepo.Get(), "Id", "Name")
            };
            //actors
            var actorVM = actorRepo.Get().Select(a => new ActorViewModel
            {
                Id = a.Id,
                Name = a.Name,
                Selected = false
            });
            movieVM.Actors = actorVM.ToArray();
            return View(movieVM);
        }

        // POST: MoviesController/Create
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MovieViewModel movieVM)
        {
            var actorVM = actorRepo.Get().Select(a => new ActorViewModel
            {
                Id = a.Id,
                Name = a.Name,
                Selected = false
            });
            movieVM.Director = new SelectList(directorRepo.Get(), "Id", "Name");
            try
            {
                if (ModelState.IsValid)
                {
                    MovieDto movie = new MovieDto
                    {
                        Name = movieVM.Name,
                        Genre = movieVM.Genre,
                        DirectorId = movieVM.DirectorId,
                        ActorIds = movieVM.Actors.Where(a => a.Selected).Select(a => a.Id).ToArray()
                    };
                    var isAdded = repository.Add(movie);
                    if(isAdded)
                    {
                        TempData["Message"] = "Movie Added Successfully";
                        return RedirectToAction(nameof(Index));
                    }
                    ModelState.AddModelError("", "Error Occured");
                    movieVM.Actors = actorVM.ToArray();
                    return View(movieVM);
                }
                movieVM.Actors = actorVM.ToArray();
                return View(movieVM);
            }
            catch(MtbsException ex)
            {
                ModelState.AddModelError("", ex.Message);
                movieVM.Actors = actorVM.ToArray();
                return View(movieVM);
            }
        }

        // GET: MoviesController/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            var movie = repository.Get(id);
            if(movie == null)
            {
                return RedirectToAction(nameof(Index));
            }
            //viewModel
            MovieViewModel movieVM = new MovieViewModel
            {
                Id = movie.Id,
                Name = movie.Name,
                Genre = movie.Genre,
                DirectorId = movie.DirectorId,
                Director = new SelectList(directorRepo.Get(), "Id", "Name")
            };
            //actors in movie
            var actorsInMovie = repository.GetCast(id).Select(a => a.Id);
            //actors
            var actorVM = actorRepo.Get().Select(a => new ActorViewModel
            {
                Id = a.Id,
                Name = a.Name,
                Selected = actorsInMovie.Contains(a.Id) ? true : false
            });
            movieVM.Actors = actorVM.ToArray();
            return View(movieVM);
        }

        // POST: MoviesController/Edit/5
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MovieViewModel movieVM)
        {
            //actors in movie
            var actorsInMovie = repository.GetCast(id).Select(a => a.Id);
            //actors
            var actorVM = actorRepo.Get().Select(a => new ActorViewModel
            {
                Id = a.Id,
                Name = a.Name,
                Selected = actorsInMovie.Contains(a.Id) ? true : false
            });
            movieVM.Director = new SelectList(directorRepo.Get(), "Id", "Name");
            try
            {
                //ssvalidation
                //id check
                //transform dto -> vm
                //repo.update(dto)
                //T/F
                //modal dialog
                if(ModelState.IsValid)
                {
                    if(id == movieVM.Id)
                    {
                        MovieDto movie = new MovieDto
                        {
                            Id = movieVM.Id,
                            Name = movieVM.Name,
                            Genre = movieVM.Genre,
                            DirectorId = movieVM.DirectorId,
                            ActorIds = movieVM.Actors.Where(a => a.Selected)
                                        .Select(a => a.Id).ToArray()
                        };
                        var isUpdated = repository.Update(movie);
                        if(isUpdated)
                        {
                            TempData["Message"] = "Details Saved Successfully";
                            return RedirectToAction(nameof(Index));
                        }
                        //view
                        movieVM.Actors = actorVM.ToArray();
                        ModelState.AddModelError("", "Error Occured");
                        return View(movieVM);
                    }
                    //view                    
                    ModelState.AddModelError("", "IDs do not match");
                    movieVM.Actors = actorVM.ToArray();
                    return View(movieVM);
                }
                movieVM.Actors = actorVM.ToArray();
                return View(movieVM);
            }
            catch
            {                
                ModelState.AddModelError("", "Error Occured");
                movieVM.Actors = actorVM.ToArray();
                return View(movieVM); 
            }
        }

        // GET: MoviesController/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            var movie = repository.Get(id);
            if (movie == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // POST: MoviesController/Delete/5
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, MovieDto movie)
        {
            try
            {
                bool isDeleted = repository.Delete(id);
                if (isDeleted)
                {                    
                    TempData["Message"] = "Movie Deleted Successfully";                    
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", "Error Occured");
                return View(movie);
            }
            catch
            {
                ModelState.AddModelError("", "Error Occured");
                return View(movie);
            }
        }

        public ActionResult Cast()
        {
            ViewBag.Movies = new SelectList(repository.Get().Where(m => m.IsDeleted == false), "Id", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult Cast(int movieId)
        {
            var movieDto = repository.Get(movieId);
            var cast = repository.GetCast(movieId);
            var movie = new MovieCastViewModel
            {
                Id = movieDto.Id,
                Name = movieDto.Name,
                Genre = movieDto.Genre,
                DirectorName = movieDto.Director.Name,
                Actors = cast
            };
            ViewBag.Movies = new SelectList(repository.Get(), "Id", "Name");
            return View(movie);
        }
    }
}
