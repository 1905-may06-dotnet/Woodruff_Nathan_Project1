using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain;
using System.Diagnostics;

namespace WebApplication.Controllers
{
    public class PizzaController : Controller
    {
        private readonly IPizzaRepository db;
        public PizzaController(IPizzaRepository db)
        {
            this.db = db;
        }

        // GET: Pizzas
        Models.Pizzas p;
        List<Models.Pizzas> pizzaList = new List<Models.Pizzas>();
        public ActionResult Index()
        {
            using (Data.Entities.Context context = new Data.Entities.Context())
            {
                var pizzas = context.Pizzas.ToList();

                try
                {
                    foreach (var pizza in pizzas)
                    {
                        p = new Models.Pizzas();
                        p.Id = (int)pizza.Id;
                        p.Size = pizza.Size;
                        p.Crust = pizza.Crust;
                        p.Type = pizza.Type;
                        p.Cost = pizza.Cost;

                        pizzaList.Add(p);
                    }
                    
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                }

            }

            return View(pizzaList);
        }

        // GET: Pizzas/Details/5
        public ActionResult Details(int id)
        {
                return View();
        }

        // GET: Pizzas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pizzas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection, Models.Pizzas pizza)
        {
            using (Data.Entities.Context context = new Data.Entities.Context())
            {
                Domain.Pizza newPizza = new Pizza();

                newPizza.size = pizza.Size;
                newPizza.crust = pizza.Crust;
                newPizza.type = pizza.Type;

                newPizza.cost = newPizza.GetCost(newPizza);

                try
                {
                    db.Add(newPizza);
                    db.Save();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }

            
        }

        // GET: Pizzas/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Pizzas/Edit/5
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

        // GET: Pizzas/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Pizzas/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Models.Pizzas pizza, IFormCollection collection)
        {
            return View();
        }
    }
}