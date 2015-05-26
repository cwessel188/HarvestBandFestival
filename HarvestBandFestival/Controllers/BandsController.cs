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
            var bands = _bandservice.GetBands();
            return View(bands.ToList());
        }

        // GET: Bands/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Band band = _bandservice.FindById(id);

            band.PrimaryContact = _bandservice.FindUserByContactId(band.PrimaryContactId);

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
                _bandservice.AddBand(band);
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
            Band band = _bandservice.FindById(id);

            // create a list of users to pass to the view
            var userList = _bandservice.GetApplicationUsers();

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
                _bandservice.UpdateBand(vm.Band);

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
            Band band = _bandservice.FindById(id);
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
            _bandservice.DeleteBandById(id);
            return RedirectToAction("Index");
        }


        // GET: Bands/EditScore/5
        public ActionResult EditScore(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

             var score = _bandservice.GetScoreForCurrentYearById(id);
             if (score == null) {
             return HttpNotFound();
             }
              
             return View(score);
             
        }

        // POST: Bands/EditScore/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditScore(int id, Score vmScore)
        {
            if (ModelState.IsValid)
            {
                _bandservice.UpdateCurrentScore(id, vmScore);
                return RedirectToAction("Index");
            }
            return View(vmScore);
        }

    }
}
