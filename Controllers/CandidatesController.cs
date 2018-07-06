using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using SistemaElecciones.Models;
using System.Data.Entity;

namespace SistemaElecciones.Controllers
{
    public class CandidatesController : Controller
    {

        private ApplicationDbContext _context;

        public CandidatesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose(); 
        }

        // GET: Candidato
        
        public ActionResult Index()
        {
            ViewBag.Message = "";
            ViewBag.candidates = _context.Candidates.ToList().OrderByDescending(r => r.Id);

            var viewModal = new CandidateViewModel
            {
                Candidacies = _context.Candidacys.ToList(),
                Candidate = new Candidate()
            };

            return View("Candidates", viewModal);
        }

        [HttpPost]
        public ActionResult Save(Candidate candidate, HttpPostedFileBase file)
        {
            try
            {
                ViewBag.candidates = _context.Candidates.ToList();

                if (file != null && file.ContentLength > 0)
                {
                    string filename = Path.GetFileName(file.FileName);
                    string filepath = Path.Combine(Server.MapPath("~/Photos"), filename);
                    file.SaveAs(filepath);

                    candidate.photoUrl = filename;
                }

                if (!ModelState.IsValid && string.IsNullOrEmpty(candidate.photoUrl) )
                {
                    var viewModel = new CandidateViewModel
                    {
                        Candidacies = _context.Candidacys.ToList(),
                        Candidate = candidate
                    };

                    return View("Candidates", viewModel);
                }

                if (candidate.Id == 0)
                {
                    _context.Candidates.Add(candidate);
                }
                else
                {
                    var candidateInDb = _context.Candidates.Single(c => c.Id == candidate.Id);
                    candidateInDb.Name = candidate.Name;
                    candidateInDb.CandidacyId = candidate.CandidacyId;
                    candidateInDb.Period = candidate.Period;
                    candidateInDb.photoUrl = candidate.photoUrl;
                }
                
                _context.SaveChanges();

                ViewBag.Message = "";

            }
            catch(Exception ex)
            {
                ViewBag.Message = ex.Message;
            }

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            
            ViewBag.candidates = _context.Candidates.ToList().OrderByDescending(r => r.Id);

            var candidate = _context.Candidates.Single(c => c.Id == id);

            var viewModel = new CandidateViewModel
            {
                Candidate = candidate,
                Candidacies = _context.Candidacys.ToList()
            };
            
            return View("Candidates", viewModel);
        }

        public ActionResult Delete(int id)
        {
            var candidate = _context.Candidates.Single(c => c.Id == id);

            _context.Candidates.Remove(candidate);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}