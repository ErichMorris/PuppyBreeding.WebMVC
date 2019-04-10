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
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new OrderService(userId);
            var model = service.GetOrders();
            return View(model);
        }
        public ActionResult Create()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var puppyService = new PuppyService(userId);
            var puppyList = puppyService.GetPuppies();
            ViewBag.PuppyId = new SelectList(puppyList, "PuppyId", "PuppyName");
            var customerService = new CustomerService(userId);
            var customerList = customerService.GetCustomers();
            ViewBag.CustomerId = new SelectList(customerList, "CustomerId", "CustomerName");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrderCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateOrderService();

            if (service.CreateOrder(model))
            {
                TempData["SaveResult"] = "Your order was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Order could not be created.");

            return View(model);
        }
        public ActionResult Details(int id)
        {
            var svc = CreateOrderService();
            var model = svc.GetOrderById(id);

            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var service = CreateOrderService();
            var detail = service.GetOrderById(id);
            var model =
                new OrderEdit
                {
                    OrderId = detail.OrderId,
                    PuppyId = detail.PuppyId,
                    CustomerId = detail.CustomerId,
                    Price = detail.Price,
                    CustomerApproved = detail.CustomerApproved,
                    DepositPaid = detail.DepositPaid,
                    PriceInFullPaid = detail.PriceInFullPaid
    };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, OrderEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.OrderId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateOrderService();

            if (service.UpdateOrder(model))
            {
                TempData["SaveResult"] = "Your order was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your order could not be updated.");
            return View(model);
        }
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateOrderService();
            var model = svc.GetOrderById(id);

            return View(model);
        }

        private OrderService CreateOrderService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new OrderService(userId);
            return service;
        }
        private PuppyService CreatePuppyService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PuppyService(userId);
            return service;
        }
        private CustomerService CreateCustomerService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CustomerService(userId);
            return service;
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateOrderService();

            service.DeleteOrder(id);

            TempData["SaveResult"] = "Your order was deleted";

            return RedirectToAction("Index");
        }
    }
}