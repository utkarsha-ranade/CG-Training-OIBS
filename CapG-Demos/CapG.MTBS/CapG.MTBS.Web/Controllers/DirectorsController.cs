using CapG.MTBS.Exceptions;
using CapG.MTBS.Models;
using CapG.MTBS.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CapG.MTBS.Web.Controllers
{
    public class DirectorsController : Controller
    {
        private readonly IRepository<Director> repository;
        public DirectorsController(IRepository<Director> repository)
        {
            this.repository = repository;
        }

        // GET: DirectorsController
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            var list = repository.Get();
            return View(list);
        }

        // GET: DirectorsController/Details/5
        [Authorize(Roles = "Admin")]
        public ActionResult Details(int id)
        {
            var director = repository.Get(id);
            return View(director);
        }

        // GET: DirectorsController/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: DirectorsController/Create
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Director director)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool isAdded = repository.Add(director);
                    if (isAdded)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    ModelState.AddModelError("", "Error Occured");
                    return View(director);
                }
                return View(director);
            }
            catch (MtbsException ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(director);
            }
        }

        // GET: DirectorsController/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            var director = repository.Get(id);
            return View(director);
        }

        // POST: DirectorsController/Edit/5
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Director director)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (id == director.Id)
                    {
                        Director directorEdit = new Director
                        {
                            Id = director.Id,
                            Name = director.Name
                        };
                        var isUpdated = repository.Update(directorEdit);
                        if (isUpdated)
                        {
                            TempData["Message"] = "Details Saved Successfully";
                            return RedirectToAction(nameof(Index));
                        }
                        ModelState.AddModelError("", "Error Occured");
                        return View(director);
                    }
                    ModelState.AddModelError("", "Error Occured");
                    return View(director);
                }
                ModelState.AddModelError("", "Error Occured");
                return View(director);
            }
            catch
            {
                ModelState.AddModelError("", "Error Occured");
                return View(director);
            }
        }

        // GET: DirectorsController/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            var director = repository.Get(id);
            return View(director);
        }

        // POST: DirectorsController/Delete/5
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Director director)
        {
            try
            {
                bool isDeleted = repository.Delete(id);
                if (isDeleted)
                {
                    TempData["Message"] = "Director Details Deleted Successfully";
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", "Error Occured");
                return View(director);
            }
            catch
            {
                ModelState.AddModelError("", "Error Occured");
                return View(director);
            }
        }
    }
}
