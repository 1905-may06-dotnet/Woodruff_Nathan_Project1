using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository db;
        public UserController(IUserRepository db)
        {
            this.db = db;
        }


        // GET: User
        public ActionResult Index(Models.Users user)
        {
            return View();
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: User/Create
        public ActionResult Create(Models.Users user)
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection, Models.Users user)
        {
            using (Data.Entities.Context context = new Data.Entities.Context())
            {
                Domain.User newUser = new Domain.User();

                newUser.id = user.Id;
                newUser.username = user.Username;
                newUser.password = user.Password;
                newUser.location = user.Location;

                try
                {
                    db.Add(newUser);
                    db.Save();
                    return RedirectToAction(nameof(Create));
                }
                catch
                {
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