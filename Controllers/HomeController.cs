using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SzelektivABC.Models;

namespace SzelektivABC.Controllers
{
    public class HomeController : Controller
    {
        private ProductModelsContainer db = new ProductModelsContainer();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string searchValue)
        {
            var item = db.Items.FirstOrDefault((x) => x.Name.ToLower().Equals(searchValue.ToLower()));

            if (item != null)
                return RedirectToAction("Details", "Home", new { id = item.Id });
            else
            {
                item = db.Items.FirstOrDefault((x) => x.Description.ToLower().Contains(searchValue.ToLower()));

                if (item != null)
                    return RedirectToAction("Details", "Home", new { id = item.Id });
                else
                    return RedirectToAction("List");
            }
        }

        public ActionResult Details(int? id)
        {
            var item = db.Items.FirstOrDefault((x) => x.Id == id);

            return View(item);
        }

        public ActionResult List()
        {
            return View(db.Items.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}