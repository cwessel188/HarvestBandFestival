using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HarvestBandFestival.Infrastructure;
using HarvestBandFestival.Models;

using AutoMapper;
using AutoMapper.QueryableExtensions;
using System.Threading.Tasks;
using HarvestBandFestival.Views.BandDirectors;
using HarvestBandFestival.Services;

namespace HarvestBandFestival.Controllers
{
    public class BandsController : Controller
    {
        // creates a generic repository
        private IGenericRepository _repo;

        // maps the generic repo to my EFRepository
        public BandsController(IGenericRepository repo)
        {
            _repo = repo;
        }

        // SERVICES allow for seperation of concerns
        // the controller never hits the database directly
        private IBandService _bandservice;

        public BandsController(IBandService service)
        {
            _bandservice = service;
        }


        // GET: Bands
        public ActionResult Index()
        {
            var bands = _repo.Query<Band>().Include(b => b.PrimaryContact);
            // var bands = _bandservice.GetBands();
            return View(bands.ToList());
        }

        // GET: Bands/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Band band = _repo.Find<Band>(id);
            // _bandservice.FindById(id);

            // this is ghetto
            band.PrimaryContact = _repo.Find<ApplicationUser>(band.PrimaryContactId);
            // band.PrimaryContact = _bandservice.FindUserByContactId(band.PrimaryContactId);

            if (band == null)
            {
                return HttpNotFound();
            }
            return View(band);
        }

        // GET: Bands/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bands/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "School,Disctrict,Division,BandSize,BandNickName,PaidStatus,DatePaid,ImageSource")] Band band)
        {
            if (ModelState.IsValid)
            {
                _repo.Add<Band>(band);
                _repo.SaveChanges();

                // _bandservice.AddBand(band);
                return RedirectToAction("Index");
            }

            return View(band);
        }

        // GET: Bands/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            BandsViewModelWithUsers vm = new BandsViewModelWithUsers();
            Band band = _repo.Find<Band>(id);
           // _bandservice.FinfbandById(id);

            // create a list of users to pass to the view
            var userList = _repo.Query<ApplicationUser>().ToList();
            // = _bandservice.GetApplicationUsers()

            SelectList s = new SelectList(userList, "Id", "FullName");

            vm.Band = band;
            vm.AppUsers = s;

            if (band == null)
            {
                return HttpNotFound();
            }
            return View(vm);
        }

        // POST: Bands/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        // [Bind(Include = "Id,School,Disctrict,Division,BandSize,BandNickName,ImageSource, PrimaryContant")] 
        public ActionResult Edit(BandsViewModelWithUsers vm)
        {
            if (ModelState.IsValid)
            {
                // cut
                var band = vm.Band;

                // don't use autoMapper for fear of overposting
                var original = _repo.Find<Band>(band.Id);
                original.School = band.School;
                original.Disctrict = band.Disctrict;
                original.Division = band.Division;
                original.BandSize = band.BandSize;
                original.BandNickName = band.BandNickName;
                // removed paidstatus and DatePaid
                original.ImageSource = band.ImageSource;
                original.PrimaryContactId = band.PrimaryContactId;

                _repo.SaveChanges();
                // _bs.UpdateBand(vm.Band)

                return RedirectToAction("Index");
            }
            return View(vm);
        }

        // GET: Bands/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Band band = _repo.Find<Band>(id);
            // bs.getBandById
            if (band == null)
            {
                return HttpNotFound();
            }
            return View(band);
        }

        // POST: Bands/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Band band = _repo.Find<Band>(id);
            _repo.Delete<Band>(band);
            _repo.SaveChanges();
            // DeleteBand()
            return RedirectToAction("Index");
        }


        // GET: Bands/EditScore/5
        public ActionResult EditScore(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var band = (_repo.Query<Band>().Include(b => b.Scores).Where(b => b.Id == id)).FirstOrDefault();
            if (band == null)
            {
                return HttpNotFound();
            }

            if (band.Scores.Count == 0 || band.Scores.Last().Year != DateTime.Now.Year )
            {
                band.Scores.Add(new Score());
                _repo.SaveChanges();
                return View(band.Scores.Last() );
            }
            else
            return View(band.Scores.Last() );

            /*
             * var score = _bandservice.GetScoreForCurrentYearById(id)
             * if score == null {
             * return HttpNotFound();
             * }
             * 
             * return View(score);
             * */
        }

        // POST: Bands/EditScore/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditScore(int id, Score vmScore)
        {
            if (ModelState.IsValid)
            {
                var band = (_repo.Query<Band>().Include(b => b.Scores).Where(b => b.Id == id)).FirstOrDefault();
                var oldScore = band.Scores.Last();
                oldScore.Auxiliary = vmScore.Auxiliary;
                oldScore.DrumMajor = vmScore.DrumMajor;
                oldScore.MusicalEffect = vmScore.MusicalEffect;
                oldScore.MusicPerformanceEnsemble = vmScore.MusicPerformanceEnsemble;
                oldScore.MusicPerformanceIndividual = vmScore.MusicPerformanceIndividual;
                oldScore.Percussion = vmScore.Percussion;
                oldScore.VisualEffect = vmScore.VisualEffect;
                oldScore.VisualPerformanceEnsemble = vmScore.VisualPerformanceEnsemble;
                oldScore.VisualPerformanceIndividual = vmScore.VisualPerformanceIndividual;
                // TODO remove business logic from controller

                //   var bandScores = from z in _repo.Query<Band>().Include(c => c.Scores) where z.Id == id select z.Scores;

               
                _repo.SaveChanges();
                // bs.UpdateCurrentScore(id, vmScore);
                return RedirectToAction("Index");
            }
            return View(vmScore);
        }

    }
}
