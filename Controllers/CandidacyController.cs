using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaElecciones.Models;

namespace SistemaElecciones.Controllers
{
    public class CandidacyController : Controller
    {
        private ApplicationDbContext _context;
 
        public CandidacyController()
        {
            _context = new ApplicationDbContext();

        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Candidatura
        public ActionResult Index()
        {
            ViewBag.candidacies = _context.Candidacys.ToList();

            return View("CandidacyList", getViewModel());
        }

        public ActionResult New()
        {
            var viewModel = getViewModel();

            return View("CandidacyList", viewModel);
        }

        public ActionResult Delete(int id)
        {
            var candidacy = _context.Candidacys.Single(c => c.Id == id);
            
            _context.Candidacys.Remove(candidacy);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Candidacy candidacy)
        {
            if(!ModelState.IsValid)
            {
                var viewModel = new CandidacyViewModel
                {
                    Candidacy = candidacy,
                    Categories = _context.Categories.ToList()
                };

                return View("CandidacyList", viewModel);
            }

            _context.Candidacys.Add(candidacy);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        // Get CandidacyViewModel
        private CandidacyViewModel getViewModel()
        {
            var categories = _context.Categories.ToList();

            var viewModel = new CandidacyViewModel
            {
                Categories = categories,
                Candidacy = new Candidacy()
            };

            return viewModel;
        }
    }
}