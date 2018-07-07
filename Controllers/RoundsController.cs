using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaElecciones.Models;


namespace SistemaElecciones.Controllers
{
    public class RoundsController : Controller
    {
        private ApplicationDbContext _context;

        public RoundsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Ronda
        public ActionResult Index()
        {

            ViewBag.rounds = _context.Rounds.ToList();

            var viewModel = new RoundViewModel
            {
                Round = new Round(),
                Categories = _context.Categories.ToList(),
                Candidacies = _context.Candidacys.ToList()
            };

            return View("Rounds", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Round round)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new RoundViewModel
                {
                    Categories = _context.Categories.ToList(),
                    Round = round
                };
            }

            _context.Rounds.Add(round);
            _context.SaveChanges();

            //Prepare details for candidates
            var lastRound = _context.Rounds.OrderByDescending(r => r.Id).FirstOrDefault();
            var candidates = _context.Candidates
                .Where(r => r.CandidacyId == lastRound.CandidacyId && r.Period == lastRound.Period)
                .ToList();

            foreach(var c in candidates) {

                var roundDetail = new RoundDetail();

                roundDetail.IdHeader = lastRound.Id;
                roundDetail.CandidateId = c.Id;
                roundDetail.Votes = 0;

                _context.RoundsDetail.Add(roundDetail);
            }

            _context.SaveChanges();
            
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var round = _context.Rounds.Single(r => r.Id == id);

            _context.Rounds.Remove(round);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Close(int id)
        {
            var round = _context.Rounds.Single(r => r.Id == id);

            round.Closed = true;
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult AvailableRounds()
        {
            var rounds = _context.Rounds
                .Where(r => r.Closed == false)
                .OrderByDescending(r => r.Id)
                .ToList();

            var viewModel = new AvailableRoundsViewModel
            {
                Rounds = rounds,
                Categories = _context.Categories.ToList(),
                Candidacies = _context.Candidacys.ToList()
            };

            //Test sound
            //System.Media.SoundPlayer mplayer = new System.Media.SoundPlayer();
            //mplayer.SoundLocation = Server.MapPath("/Sound/bellsound.wav");
            //mplayer.Load();
            //mplayer.Play();
            //mplayer.Dispose();
            //end sound

            return View("AvailableRounds", viewModel);
        }

        public ActionResult CandidatesForRound(int id)
        {
            
            var roundDetails = _context.RoundsDetail
                .Where(r => r.IdHeader == id)
                .ToList();

            int[] ids = new int[roundDetails.Count];
            int index = 0;

            foreach (var roundDetail in roundDetails)
            {
                ids[index] = roundDetail.CandidateId;
                index++;
            }

            var candidates = _context.Candidates
                .Where(c => ids.Contains(c.Id))
                .ToList();

            var viewModel = new RoundCandidatesViewModel
            {
                Candidates = candidates,
                RoundId = id
            };

            return View("CandidatesForRound", viewModel);
        }

        public ActionResult VoteGiven(int roundId, int candidateId)
        {
            ViewBag.roundId = roundId;
            
            var candidate = _context.Candidates.Single(c => c.Id == candidateId);
            ViewBag.photoCandidate = candidate.photoUrl;

            var roundDetail = _context.RoundsDetail.Single(r => r.IdHeader == roundId && r.CandidateId == candidateId);
            roundDetail.Votes = roundDetail.Votes + 1;
            
            _context.SaveChanges();

            return View("VoteGiven");
        }

        public ActionResult ResultsForRound(int id)
        {
            var viewModel = new RoundDetailsCandidatesViewModel
            {
                RoundDetails = _context.RoundsDetail.Where(r => r.IdHeader == id).ToList(),
                Candidates = _context.Candidates.ToList()
            };

            return View("ResultsForRound", viewModel);
        }
    }
}