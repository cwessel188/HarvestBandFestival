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
using HarvestBandFestival.Services;

using AutoMapper;
using AutoMapper.QueryableExtensions;
using System.Threading.Tasks;

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
        // GET: Bands
        public ActionResult Index()
        {
            var bands = _repo.Query<Band>();
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
        public ActionResult Create([Bind(Include = "Id,School,Disctrict,Division,DirectorFirstName,DirectorLastName,PhoneNumber,Email,BandSize,BandNickName,StreetAddress,City,State,ZipCode,PaidStatus,DatePaid,ImageSource")] Band band)
        {
            if (ModelState.IsValid)
            {
                _repo.Add<Band>(band);
                _repo.SaveChanges();
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
            Band band = _repo.Find<Band>(id);
            if (band == null)
            {
                return HttpNotFound();
            }
            return View(band);
        }

        // POST: Bands/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "School,Disctrict,Division,DirectorFirstName,DirectorLastName,PhoneNumber,Email,BandSize,BandNickName,StreetAddress,City,State,ZipCode,ImageSource")] Band band)
        {
            if (ModelState.IsValid)
            {
                //TODO bandsControllerEdit using AutoMapper
                var original = _repo.Find<Band>(band.Id);
                original.School = band.School;
                original.Disctrict = band.Disctrict;
                original.Division = band.Division;
                original.DirectorFirstName = band.DirectorFirstName;
                original.DirectorLastName = band.DirectorLastName;
                original.PhoneNumber = band.PhoneNumber;
                original.Email = band.Email;
                original.BandSize = band.BandSize;
                original.BandNickName = band.BandNickName;
                original.StreetAddress = band.StreetAddress;
                original.City = band.City;
                original.State = band.State;
                original.ZipCode = band.ZipCode;
                // removed paidstatus and DatePaid
                original.ImageSource = band.ImageSource;

                _repo.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(band);
        }

        // GET: Bands/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Band band = _repo.Find<Band>(id);
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
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _repo.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
