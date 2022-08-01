using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TODOApp.Data;
using TODOApp.Models;

namespace TODOApp.Controllers
{
    [Authorize]
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
        public IActionResult Edit(int? id)

        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Todo.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditPost(Todo obj)
        {
            if (ModelState.IsValid)
            {
                _db.Todo.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Dashboard");
            }
            return View(obj);
        }

        public IActionResult Delete(int? id) 

        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Todo.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Todo.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Todo.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Dashboard");
        }

        public ViewResult Contact()
        {
            return View();
        }
    }
}