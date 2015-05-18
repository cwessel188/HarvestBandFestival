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
using System.Security.Claims;

namespace HarvestBandFestival.Controllers
{
    public class BandDirectorsController : Controller
    {
        // dependency injeeeeeeection!
        private IGenericRepository _repo;

        public BandDirectorsController(IGenericRepository repo)
        {
            _repo = repo;
        }

        // GET: BandDirectors
        [Authorize]
        public ActionResult Index()
        {
            var Bands = _repo.Query<ApplicationUser>().ToList();
            return View(Bands);
        }

        // GET: BandDirectors/Details/5
        // routing attribute that checks for a guid
        [Authorize]
        [Route("BandDirectors/Details/{id:guid}")]
        [HttpGet, ActionName("Details")]
        public ActionResult GetDetailsByGuid(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser appUser = _repo.Find<ApplicationUser>(id);
            if (appUser == null)
            {
                return HttpNotFound();
            }
            return View(appUser);
        }

        // GET: BandDirectors by lastName
        [Authorize]
        [Route("BandDirectors/Details/{lastname}")]
        [HttpGet, ActionName("Details")]
        public ActionResult GetDetailsByLastName(string lastname)
        {
            if (lastname == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var user = (from u in _repo.Query<ApplicationUser>() where u.LastName == lastname select u).ToList();
            var id = user.First().Id;
            ApplicationUser appUser = _repo.Find<ApplicationUser>(id);
            if (appUser == null)
            {
                return HttpNotFound();
            }

            return View(appUser);

        }
        [Authorize]
        // GET: BandDirectors/Create
        public ActionResult Create()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                var user = this.User as ClaimsPrincipal; // tests for null
                if (user.HasClaim(c => c.Type == "Admin" && c.Value == "true"))
                {
                    return View();
                }
            }
            return View(SharedControllerItems.UnauthView);
        }

        // POST: BandDirectors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,StreetAddress,City,State,Zipcode,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName")] ApplicationUser applicationUser)
        {
            if (ModelState.IsValid)
            {
                _repo.Add<ApplicationUser>(applicationUser);
                _repo.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(applicationUser);
        }

        // GET: BandDirectors/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser applicationUser = _repo.Find<ApplicationUser>(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            return View(applicationUser);
        }

        // POST: BandDirectors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,StreetAddress,City,Territory,Zipcode,Email,PhoneNumber")] ApplicationUser applicationUser)
        {
            if (ModelState.IsValid)
            {
                var user = applicationUser;

                // don't use autoMapper for fear of overposting
                var original = _repo.Find<ApplicationUser>(applicationUser.Id);
                original.FirstName = applicationUser.FirstName;
                original.LastName = applicationUser.LastName;
                original.StreetAddress = applicationUser.StreetAddress;
                original.City = applicationUser.City;
                original.Territory = applicationUser.Territory;
                original.Zipcode = applicationUser.Zipcode;
                original.Email = applicationUser.Email;
                original.PhoneNumber = applicationUser.PhoneNumber;
                original.UserName = applicationUser.Email; // necessary


                _repo.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(applicationUser);
        }

        // GET: BandDirectors/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser applicationUser = _repo.Find<ApplicationUser>(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            return View(applicationUser);
        }

        //// POST: BandDirectors/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(string id)
        //{
        //    ApplicationUser applicationUser = _repo.Find<ApplicationUser>(id);
        //    _repo.Find<ApplicationUser>.Remove(applicationUser);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

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
