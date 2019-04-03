using Microsoft.AspNet.Identity;
using PuppyBreeding.Models;
using PuppyBreeding.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PuppyBreeding.WebMVC.Controllers
{
    [Authorize]
    public class PuppyController : Controller
    {
        // GET: Puppy
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PuppyService(userId);
            var model = service.GetPuppies();
            return View(model);
        }
        // GET
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PuppyCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreatePuppyService();

            if (service.CreatePuppy(model))
            {
                TempData["SaveResult"] = "Your puppy was added";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Puppy could not be added.");
            return View(model);
        }
        public ActionResult Details(int id)
        {
            var svc = CreatePuppyService();
            var model = svc.GetPuppiesById(id);

            return View(model);
        }


        private PuppyService CreatePuppyService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PuppyService(userId);
            return service;
        }
    }
}