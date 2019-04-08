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
    public class FatherController : Controller
    {
        [Authorize]
        // GET: Father
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new FatherService(userId);
            var model = service.GetFathers();

            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FatherCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateFatherService();

            if (service.CreateFather(model))
            {
                TempData["SaveResult"] = "Your father was added.";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Father could not be added.");
            return View(model);
        }
        public ActionResult Details(int id)
        {
            var svc = CreateFatherService();
            var model = svc.GetFatherById(id);

            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var service = CreateFatherService();
            var detail = service.GetFatherById(id);
            var model =
                new FatherEdit
                {
                    FatherId = detail.FatherId,
                    FatherName = detail.FatherName,
                    FatherWeight = detail.FatherWeight,
                    FatherAge = detail.FatherAge
                };
            return View(model);
        }
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateFatherService();
            var model = svc.GetFatherById(id);

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, FatherEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.FatherId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateFatherService();

            if (service.UpdateFather(model))
            {
                TempData["SaveResult"] = "Your father was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your father could not be updated.");
            return View(model);
        }
        private FatherService CreateFatherService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new FatherService(userId);
            return service;
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateFatherService();

            service.DeleteFather(id);

            TempData["SaveResult"] = "Your father was deleted";

            return RedirectToAction("Index");
        }
    }
}