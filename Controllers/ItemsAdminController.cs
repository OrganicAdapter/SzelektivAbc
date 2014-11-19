using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SzelektivABC.Models;
using SzelektivABC.ViewModels;

namespace SzelektivABC.Controllers
{
    public class ItemsAdminController : Controller
    {
        private ProductModelsContainer db = new ProductModelsContainer();

        // GET: ItemsAdmin
        public ActionResult Index()
        {
            return View(db.Items.ToList());
        }

        // GET: ItemsAdmin/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // GET: ItemsAdmin/Create
        public ActionResult Create()
        {
            var viewModel = new ItemsViewModel()
            {
                Item = new Item(),
                AllPictograms = db.Pictograms.ToList().Select((x) => new SelectListItem()
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                })
            };

            return View(viewModel);
        }

        // POST: ItemsAdmin/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ItemsViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var pictograms = viewModel.SelectedPictograms.Select((x) => db.Pictograms.First((i) => i.Id == x)).ToList();

                foreach (var pict in pictograms)
                {
                    if (viewModel.Item.Pictograms.FirstOrDefault((x) => x.Id == pict.Id) == null)
                        viewModel.Item.Pictograms.Add(pict);
                }

                db.Items.Add(viewModel.Item);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(viewModel);
        }

        // GET: ItemsAdmin/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Include((x) => x.Pictograms).First((x) => x.Id == id);
            if (item == null)
            {
                return HttpNotFound();
            }

            var viewModel = new ItemsViewModel()
            {
                Item = item,
                AllPictograms = db.Pictograms.ToList().Select((x) => new SelectListItem()
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                })
            };

            return View(viewModel);
        }

         //POST: ItemsAdmin/Edit/5
         //To protect from overposting attacks, please enable the specific properties you want to bind to, for 
         //more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ItemsViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var item = db.Items.First((x) => x.Id == viewModel.Item.Id);
                item.Name = viewModel.Item.Name;
                item.Description = viewModel.Item.Description;
                item.Image = viewModel.Item.Image;

                var pictograms = viewModel.SelectedPictograms.Select((x) => db.Pictograms.First((i) => i.Id == x)).ToList();
                var removable = new List<Pictogram>();

                foreach (var pict in item.Pictograms)
                {
                    if (pictograms.FirstOrDefault((x) => x.Id == pict.Id) == null)
                        removable.Add(pict);
                }
                foreach (var pict in removable)
                {
                    item.Pictograms.Remove(pict);
                }
                foreach (var pict in pictograms)
                {
                    if (item.Pictograms.FirstOrDefault((x) => x.Id == pict.Id) == null)
                        item.Pictograms.Add(pict);
                }

                db.Entry(item).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(viewModel);
        }

        // GET: ItemsAdmin/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: ItemsAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Item item = db.Items.Find(id);
            db.Items.Remove(item);
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
