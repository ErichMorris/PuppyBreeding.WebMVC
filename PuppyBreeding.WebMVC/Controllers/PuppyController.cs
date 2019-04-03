using PuppyBreeding.Models;
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
            var model = new PuppyListItem[0];
            return View(model);
        }
        // GET
        public ActionResult Create()
        {
            return View();
        }
    }
}