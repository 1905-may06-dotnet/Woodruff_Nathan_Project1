using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{

    public class OrderController : Controller
    {
        private readonly IOrdersRepository db;
        public OrderController(IOrdersRepository db)
        {
            this.db = db;
        }

        // GET: Order
        public ActionResult Index()
        {
            return View();
        }

        // GET: Order/Details/5
        Models.Orders o;
        List<Models.Orders> orderList = new List<Models.Orders>();
        public ActionResult Details(int userId)
        {
            using (Data.Entities.Context context = new Data.Entities.Context())
            {
                var orders = context.Orders.Where(q => q.UsernameId == userId).ToList();

                foreach (var order in orders)
                {
                    o = new Models.Orders();
                    o.UsernameId = order.UsernameId;
                    o.OrderTime = order.OrderTime;
                    o.PizzaId = order.PizzaId;

                    orderList.Add(o);
                }

                return View(orderList);

            }

        }

        // GET: Order/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Order/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Order/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Order/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Order/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Order/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}