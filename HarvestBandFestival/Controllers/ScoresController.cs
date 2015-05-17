using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HarvestBandFestival.Controllers
{
    public class ScoresController : Controller
    {
        // GET: Scores
        public ActionResult Index()
        {
            return View();
        }

        // GET: Scores/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Scores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Scores/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Scores/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Scores/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Scores/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Scores/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
