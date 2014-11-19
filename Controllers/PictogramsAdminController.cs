using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SzelektivABC.Models;

namespace SzelektivABC.Controllers
{
    public class PictogramsAdminController : Controller
    {
        private ProductModelsContainer db = new ProductModelsContainer();

        // GET: PictogramsAdmin
        public ActionResult Index()
        {
            return View(db.Pictograms.ToList());
        }

        // GET: PictogramsAdmin/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pictogram pictogram = db.Pictograms.Find(id);
            if (pictogram == null)
            {
                return HttpNotFound();
            }
            return View(pictogram);
        }

        // GET: PictogramsAdmin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PictogramsAdmin/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Image")] Pictogram pictogram)
        {
            if (ModelState.IsValid)
            {
                db.Pictograms.Add(pictogram);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pictogram);
        }

        // GET: PictogramsAdmin/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pictogram pictogram = db.Pictograms.Find(id);
            if (pictogram == null)
            {
                return HttpNotFound();
            }
            return View(pictogram);
        }

        // POST: PictogramsAdmin/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Image")] Pictogram pictogram)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pictogram).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pictogram);
        }

        // GET: PictogramsAdmin/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pictogram pictogram = db.Pictograms.Find(id);
            if (pictogram == null)
            {
                return HttpNotFound();
            }
            return View(pictogram);
        }

        // POST: PictogramsAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pictogram pictogram = db.Pictograms.Find(id);
            db.Pictograms.Remove(pictogram);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
