using CapG.MTBS.Models;
using CapG.MTBS.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace CapG.MTBS.Web.Controllers
{
    public class TicketsController : Controller
    {
        private readonly IRepository<Ticket> repository;
        private readonly IMovieRepository movieRepo;

        public TicketsController(IRepository<Ticket> repository, IMovieRepository movieRepo)
        {
            this.repository = repository;
            this.movieRepo = movieRepo;
        }
        // GET: TicketsControlle
        public ActionResult Index()
        {
            var list = repository.Get();
            return View(list);
        }

        // GET: TicketsController/Details/5
        public ActionResult Details(int id)
        {
            var ticket = repository.Get(id);
            return View(ticket);
        }

        // GET: TicketsController/Create
        public ActionResult Create()
        {
            ViewBag.Movies = new SelectList(movieRepo.Get(), "Id", "Name");
            return View();
        }

        // POST: TicketsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create(Ticket ticket)
        {
            ViewBag.Movies = new SelectList(movieRepo.Get(), "Id", "Name");
            try
            {
                //ssv
                //user id
                //repo.add
                //t/f/ex
                if (ModelState.IsValid)
                {
                    ticket.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                    bool isBooked = repository.Add(ticket);
                    if (isBooked)
                    {
                        TempData["Message"] = "Ticket Booking Request Submitted";
                        return RedirectToAction(nameof(Index));
                    }
                    ModelState.AddModelError("", "Error Occured");
                    return View(ticket);
                }
                return View(ticket);
            }
            catch
            {
                ModelState.AddModelError("", "Error Occured");
                return View(ticket);
            }
        }

        // GET: TicketsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TicketsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TicketsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TicketsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
