using Data;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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


                var checkUser = db.GetUserByName(user.Username);

                if (checkUser == null)
                {
                    try
                    {
                        db.Add(newUser);
                        db.Save();

                        TempData["userId"] = newUser.id;
                        return RedirectToAction("Details", "Order", TempData["userId"]);
                    }
                    catch
                    {
                        return View("~/Views/Shared/Error");
                    }
                }
                else if (checkUser.password == user.Password)
                {
                    TempData["userId"] = newUser.id;
                    return RedirectToAction("Details", "Order", new { userId = (int)newUser.id });
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


                var checkUser = db.GetUserByName(user.Username);

                if (checkUser == null)
                {
                    try
                    {
                        db.Add(newUser);
                        db.Save();
                        TempData["userId"] = newUser.id;
                        return RedirectToAction("Details", "Order", TempData["userId"]);
                    }
                    catch
                    {
                        return View("~/Views/Shared/Error");
                    }
                }
                else if (checkUser.password == user.Password)
                {
                    TempData["userId"] = newUser.id;
                    return RedirectToAction("Details", "Order", TempData["userId"]);
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