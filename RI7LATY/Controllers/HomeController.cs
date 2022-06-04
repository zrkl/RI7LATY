using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using R.DAL.Context;
 

namespace RI7LATY.Controllers
{
    public class HomeController : Controller
    {
        R.DAL.Context.R_DB_Entities db = new R.DAL.Context.R_DB_Entities();
        public ActionResult Index()
        {

            var m = new travel();
            ViewBag.agency = new SelectList(db.agencies, "id", "agency_name");

            ViewBag.beginning = new SelectList(db.villes, "id", "ville_name");
            ViewBag.destination = new SelectList(db.villes, "id", "ville_name");
            return View(m);
        }

        [HttpPost]
        [ValidateAntiForgeryToken, ValidateInput(false)]

        public async Task<ActionResult> Index(travel travel)
        {
            if (ModelState.IsValid)
            {
                ViewBag.agency = new SelectList(db.agencies, "id", "agency_name", travel.agency);

                ViewBag.beginning = new SelectList(db.villes, "id", "ville_name", travel.beginning);
                ViewBag.destination = new SelectList(db.villes, "id", "ville_name", travel.destination);

                
                Session["b"] = travel.beginning;
                Session["d"] = travel.destination;
                return RedirectToAction("search") ;
            }
            
            return View(travel);
        }
        
        public ActionResult Search()
        {
            var bb = (Int32)Session["b"];
            var dd = (Int32)Session["d"];
            var list_travel = db.travels.Where(b => b.beginning == bb).Where(d => d.destination == dd);
            return View(list_travel);
            //return View();
        }

    }
}