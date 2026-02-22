using CapG.MTBS.Exceptions;
using CapG.MTBS.Models;
using CapG.MTBS.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CapG.MTBS.Web.Controllers
{
    public class ActorsController : Controller
    {
        private readonly IRepository<Actor> repository;

        public ActorsController(IRepository<Actor> repository)
        {
            this.repository = repository;
        }

        // GET: ActorsController
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            var list = repository.Get();
            return View(list);
        }

        // GET: ActorsController/Details/5
        [Authorize(Roles = "Admin")]
        public ActionResult Details(int id)
        {
            var details = repository.Get(id);
            return View(details);
        }

        // GET: ActorsController/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: ActorsController/Create
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Actor actor)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (actor.DateOfBirth >= System.DateTime.Today)
                    {
                        ModelState.AddModelError("", "Select A Past Date");
                        return View(actor);
                    }

                    bool isAdded = repository.Add(actor);
                    if (isAdded)
                    {
                        TempData["Message"] = "Actor Details Added Successfully";
                        return RedirectToAction(nameof(Index));
                    }
                    ModelState.AddModelError("", "Error Occured");
                    return View(actor);
                }
                return View(actor);
            }
            catch(MtbsException ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(actor);
            }
        }

        // GET: ActorsController/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            var actor = repository.Get(id);
            return View(actor);
        }

        // POST: ActorsController/Edit/5
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Actor actor)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if(id == actor.Id)
                    {
                        Actor actorEdit = new Actor
                        {
                            Id = actor.Id,
                            Name = actor.Name,
                            Gender = actor.Gender,
                            DateOfBirth = actor.DateOfBirth
                        };
                        var isUpdated = repository.Update(actorEdit);
                        if (isUpdated)
                        {
                            TempData["Message"] = "Details Saved Successfully";
                            return RedirectToAction(nameof(Index));
                        }
                        ModelState.AddModelError("", "Error Occured");
                        return View(actor);
                    }
                    ModelState.AddModelError("", "Error Occured");
                    return View(actor);
                }
                ModelState.AddModelError("", "Error Occured");
                return View(actor);
            }
            catch
            {
                ModelState.AddModelError("", "Error Occured");
                return View(actor);
            }
        }

        // GET: ActorsController/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            var actor = repository.Get(id);
            if (actor == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(actor);
        }

        // POST: ActorsController/Delete/5
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Actor actor)
        {
            try
            {
                bool isDeleted = repository.Delete(id);
                if (isDeleted)
                {
                    TempData["Message"] = "Actor Details Deleted Successfully";
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", "Error Occured");
                return View(actor);
            }
            catch
            {
                ModelState.AddModelError("", "Error Occured");
                return View(actor);
            }
        }
    }
}
