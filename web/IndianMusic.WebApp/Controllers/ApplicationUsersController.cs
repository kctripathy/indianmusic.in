using IndianMusic.WebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.CodeDom;

namespace IndianMusic.WebApp.Controllers
{
    public class ApplicationUsersController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public ApplicationUsersController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        // GET: ApplicationUsersController
        public ActionResult Index()
        {
            var users = _userManager.Users.ToList(); // You can also use ToListAsync if needed
            return View(users);
        }

        // GET: ApplicationUsersController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ApplicationUsersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ApplicationUsersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ApplicationUsersController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ApplicationUsersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ApplicationUsersController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ApplicationUsersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
