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
            var userId = Guid.Parse(User.Identity.GetUserId());
            var fatherService = new FatherService(userId);
            var fatherList = fatherService.GetFathers();
            ViewBag.FatherId = new SelectList(fatherList, "FatherId", "FatherName");
            var motherService = new MotherService(userId);
            var motherList = motherService.GetMothers();
            ViewBag.MotherId = new SelectList(motherList, "MotherId", "MotherName");
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
            var model = svc.GetPuppyById(id);
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreatePuppyService();
            var detail = service.GetPuppyById(id);
            var model =
                new PuppyEdit
                {
                    PuppyId = detail.PuppyId,
                    PuppyName = detail.PuppyName,
                    MotherId = detail.MotherId,
                    MotherName = detail.MotherName,
                    FatherId = detail.FatherId,
                    FatherName = detail.FatherName,
                    Weight = detail.Weight,
                    Age = detail.Age,
                    Gender = detail.Gender,
                    Price = detail.Price
                };
            return View(model);
        }
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreatePuppyService();
            var model = svc.GetPuppyById(id);

            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreatePuppyService();

            service.DeletePuppy(id);

            TempData["SaveResult"] = "Your puppy was deleted";

            return RedirectToAction("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PuppyEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.PuppyId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreatePuppyService();

            if (service.UpdatePuppy(model))
            {
                TempData["SaveResult"] = "Your puppy was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your puppy could not be updated.");
            return View(model);
        }
        private PuppyService CreatePuppyService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PuppyService(userId);
            return service;
        }

        private FatherService CreateFatherService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new FatherService(userId);
            return service;
        }
        private MotherService CreateMotherService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new MotherService(userId);
            return service;
        }
    }
}