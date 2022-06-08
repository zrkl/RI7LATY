using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web;
using System.Web.Mvc;
using R.DAL.Context;


namespace RI7LATY.Controllers
{
    public class HomeController : Controller
    {
        R.DAL.Context.R_DB_Entities db = new R.DAL.Context.R_DB_Entities();

        public ActionResult value()
        {
            Session["a"] = 1;
            Session["b"] = 1;
            Session["d"] = 1;
            return RedirectToAction("Index");
        }

        public ActionResult Index()
        {


            ViewBag.id_agency = new SelectList(db.agencies, "id", "agency_name");
            ViewBag.beginning = new SelectList(db.villes, "id", "ville_name");
            ViewBag.destination = new SelectList(db.villes, "id", "ville_name");


            
            int aa = (Int32)Session["a"];
            int bb = (Int32)Session["b"];
            int dd = (Int32)Session["d"];


            
            if (bb == dd || aa==dd)
            {
                ViewBag.hide = "hidden";
                ViewBag.DATE = "";
                var list_T = db.travels.Where(b => b.beginning == 1).Where(d => d.destination == 1).Where(a => a.id_agency == 1).ToList();
                return View(Tuple.Create<travel, IEnumerable<travel>>(new travel(), list_T));
            }
            else
            {
                bb = (Int32)Session["b"];
                dd = (Int32)Session["d"];
                aa = (Int32)Session["a"];
                if (bb == 1 && dd == 1 && aa == 1)
                {
                    ViewBag.hide = "hidden";
                    ViewBag.DATE = "";
                    var list_T = db.travels.Where(b => b.beginning == 1).Where(d => d.destination == 1).Where(a => a.id_agency == 1).ToList();
                    return View(Tuple.Create<travel, IEnumerable<travel>>(new travel(), list_T));
                }
                else
                {

                    ViewBag.hide = "";
                    ViewBag.DATE = Session["date"];
                    var list_T = db.travels.Where(b => b.beginning == bb).Where(d => d.destination == dd).Where(a => a.id_agency == aa).ToList();
                    return View(Tuple.Create<travel, IEnumerable<travel>>(new travel(), list_T));
                }
            }



        }

        [HttpPost]
        [ValidateAntiForgeryToken, ValidateInput(false)]

        public async Task<ActionResult> Index(travel travel,DateTime this_date)
        {
            if (ModelState.IsValid)
            {
                
                    ViewBag.id_agency = new SelectList(db.agencies, "id", "agency_name", travel.id_agency);
                    ViewBag.beginning = new SelectList(db.villes, "id", "ville_name", travel.beginning);
                    ViewBag.destination = new SelectList(db.villes, "id", "ville_name", travel.destination);
                    Session["i"] = travel.id;
                    Session["a"] = travel.id_agency;
                    Session["b"] = travel.beginning;
                    Session["d"] = travel.destination;

                    var day = this_date.DayOfWeek;
                    var DATE = (day + "  " + this_date.Year + "/" + this_date.Month + "/" + this_date.Day).ToString();
                    Session["date"] = DATE;
                    ViewBag.DATE = DATE;
                    return RedirectToAction("Index");
                
                
            }

            return View(travel);
        }
        private R_DB_Entities DB = new R_DB_Entities();
        public async Task<ActionResult> Info()
        {
            
            int ID = (Int32)Session["a"];
            int IDt = (Int32)Session["i"];
            var info_list = DB.agencies.Where(i => i.id == ID);

            return View(info_list);
        }




    }
}