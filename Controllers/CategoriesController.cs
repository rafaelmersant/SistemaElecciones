using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaElecciones.Models;

namespace SistemaElecciones.Controllers
{
    public class CategoriesController : Controller
    {
        private ApplicationDbContext _context;

        public CategoriesController()
        {
            _context = new ApplicationDbContext();
            refreshCategories();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Categories
        public ActionResult Index()
        {
            refreshCategories();
            return View();
        }

        public ActionResult New()
        {
            var category = new Category();

            refreshCategories();
            return View("Index", category);
        }

        public ActionResult Delete(int id)
        {
            var category = _context.Categories.Single(c => c.Id == id);

            _context.Categories.Remove(category);
            _context.SaveChanges();

            return RedirectToAction("Index", "Categories");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", category);
            }

            _context.Categories.Add(category);
            _context.SaveChanges();

            refreshCategories();

            return View("Index");
        }

        private void refreshCategories() {

            var categories = _context.Categories.ToList();
            ViewBag.categories = categories;
        }
    }
}