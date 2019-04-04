﻿using Microsoft.AspNet.Identity;
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
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CustomerService(userId);
            var model = service.GetCustomers();

            return View(model);
        }
        // GET
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CustomerCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateCustomerService();

            if (service.CreateCustomer(model))
            {
                TempData["SaveResult"] = "Your Customer was added.";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Customer could not be added.");
            return View(model);
        }
        public ActionResult Details (int id)
        {
            var svc = CreateCustomerService();
            var model = svc.GetCustomerById(id);
            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var service = CreateCustomerService();
            var detail = service.GetCustomerById(id);
            var model =
                new CustomerEdit
                {
                    CustomerId = detail.CustomerId,
                    CustomerName = detail.CustomerName,
                    Email = detail.Email,
                    Phone = detail.Phone,
                    CustomerApproved = detail.CustomerApproved,
                    DepositPaid = detail.DepositPaid
                };
            return View(model);
        }
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateCustomerService();
            var model = svc.GetCustomerById(id);

            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateCustomerService();

            service.DeleteCustomer(id);

            TempData["SaveResult"] = "Your customer was deleted";

            return RedirectToAction("Index");
        }

        private CustomerService CreateCustomerService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CustomerService(userId);
            return service;
        }
    }
}