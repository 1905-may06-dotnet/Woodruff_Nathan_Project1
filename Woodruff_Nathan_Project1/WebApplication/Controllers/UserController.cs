using Data;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository db;
        public UserController(IUserRepository db)
        {
            this.db = db;
        }


        public ActionResult Logout()
        {
            return View();
        }
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        // GET: User/Details/5
        public ActionResult Details()
        {
            return View();            
        }

        // GET: User/Create
        public IActionResult Login()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(IFormCollection collection, Models.Users user)
        {
            using (Data.Entities.Context context = new Data.Entities.Context())
            {
                ViewData["Message"] = "";
                Domain.User newUser = new Domain.User();

                newUser.id = user.Id;
                newUser.username = user.Username;
                newUser.password = user.Password;
                newUser.location = user.Location;


                var existingUser = db.GetUserByName(user.Username);

                if (existingUser == null)
                {
                    try
                    {
                        db.Add(newUser);
                        db.Save();

                        //new
                        HttpContext.Session.SetInt32("userId", (int)existingUser.id);
                        TempData["userId"] = newUser.id;
                        return RedirectToRoute(new { controller = "Order", action = "Details", userId = newUser.id });
                    }
                    catch
                    {
                        return View("~/Views/Shared/Error");
                    }
                }
                else if (existingUser.password == user.Password)
                {
                    TempData["userId"] = existingUser.id;
                    return RedirectToRoute(new { controller = "Order", action = "Details", userId = existingUser.id });
                }
                else
                {
                    ViewData["Message"] = "The password you entered is incorrect";
                    
                    return View();
                }          
            }
        }


        // GET: User/Create
        public IActionResult SignUp()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp(IFormCollection collection, Models.Users user)
        {

            using (Data.Entities.Context context = new Data.Entities.Context())
            {
                ViewData["Message"] = "";
                Domain.User newUser = new Domain.User();

                newUser.id = user.Id;
                newUser.username = user.Username;
                newUser.password = user.Password;
                newUser.location = user.Location;


                var existingUser = db.GetUserByName(user.Username);

                if (existingUser == null)
                {
                    try
                    {
                        db.Add(newUser);
                        db.Save();

                        TempData["userId"] = newUser.id;
                        return RedirectToRoute(new { controller = "Order", action = "Details", userId = newUser.id });
                    }
                    catch
                    {
                        return View("~/Views/Shared/Error");
                    }
                }
                else if (existingUser.password == user.Password)
                {
                    TempData["userId"] = existingUser.id;
                    return RedirectToRoute(new { controller = "Order", action = "Details", userId = existingUser.id });
                }
                else
                {
                    ViewData["Message"] = "The password you entered is incorrect";

                    return View();
                }
            }
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: User/Edit/5
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

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: User/Delete/5
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