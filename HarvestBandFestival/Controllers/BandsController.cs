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
        public ActionResult Create([Bind(Include = "School,Disctrict,Division,BandSize,BandNickName,PaidStatus,DatePaid,ImageSource")] Band band)
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

            // create a list of users to pass to the view
            var userList = _repo.Query<ApplicationUser>().ToList();

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
        public ActionResult Edit([Bind(Include = "Id,School,Disctrict,Division,BandSize,BandNickName,ImageSource")] Band band)
        {
            if (ModelState.IsValid)
            {
                // don't use autoMapper for fear of overposting
                var original = _repo.Find<Band>(band.Id);
                original.School = band.School;
                original.Disctrict = band.Disctrict;
                original.Division = band.Division;
                original.BandSize = band.BandSize;
                original.BandNickName = band.BandNickName;
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
