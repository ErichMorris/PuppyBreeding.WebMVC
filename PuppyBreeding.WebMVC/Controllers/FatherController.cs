using PuppyBreeding.Models;
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
            var model = new FatherListItem[0];
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FatherCreate model)
        {
            if (ModelState.IsValid)
            {

            }
            return View(model);
        }
    }
}