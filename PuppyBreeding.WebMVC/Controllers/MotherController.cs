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
    public class MotherController : Controller
    {
        // GET: Mother
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new MotherService(userId);
            var model = service.GetMothers();

            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MotherCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateMotherService();

            if (service.CreateMother(model))
            {
                TempData["SaveResult"] = "Your Mother was added.";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Mother could not be added.");
            return View(model);
        }
        public ActionResult Details (int id)
        {
            var svc = CreateMotherService();
            var model = svc.GetMotherById(id);
            return View(model);
        }
        private MotherService CreateMotherService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new MotherService(userId);
            return service;
        }
        public ActionResult Edit(int id)
        {
            var service = CreateMotherService();
            var detail = service.GetMotherById(id);
            var model =
                new MotherEdit
                {
                    MotherId = detail.MotherId,
                    MotherName = detail.MotherName,
                    MotherWeight = detail.MotherWeight,
                    MotherAge = detail.MotherAge
                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MotherEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.MotherId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var service = CreateMotherService();

            if (service.UpdateMother(model))
            {
                TempData["SaveResult"] = "Your mother was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your mother could not be updated.");
            return View(model);
        }
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateMotherService();
            var model = svc.GetMotherById(id);

            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateMotherService();

            service.DeleteMother(id);

            TempData["SaveResult"] = "Your mother was deleted";

            return RedirectToAction("Index");
        }
    }
}
