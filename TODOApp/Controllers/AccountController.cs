using Microsoft.AspNetCore.Mvc;
using TODOApp.Data;
using TODOApp.Models;

namespace TODOApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _db;

        public AccountController(ApplicationDbContext db)
        {
            _db = db;
        }
        public ViewResult signup()
        {
            return View();
        }
        public ViewResult Login()
        {
            return View();
        }


        public IActionResult Dashboard()
        {
            IEnumerable<Todo> objList = _db.Todo;
            return View(objList);
        }
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreatePost(Todo obj)
        {
            if (ModelState.IsValid)
            {
                _db.Todo.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Dashboard");
            }
            return View(obj);
        }
        public ViewResult Edit()
        {
            return View();
        }
        public ViewResult Delete()
        {
            return View();
        }

        public ViewResult Contact()
        {
            return View();
        }
    }
}