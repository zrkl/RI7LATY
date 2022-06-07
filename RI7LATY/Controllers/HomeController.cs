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

        public ActionResult value()
        {
            Session["a"] = 1;
            Session["b"] = 1;
            Session["d"] = 1;
            return RedirectToAction("Index");
        } 

        public ActionResult Index()
        {


            //ViewBag.id_agency = new SelectList(db.agencies, "id", "agency_name");
            //ViewBag.beginning = new SelectList(db.villes, "id", "ville_name");
            //ViewBag.destination = new SelectList(db.villes, "id", "ville_name");



            //int aa=(Int32)Session["a"];
            //int bb=(Int32)Session["b"];
            //int dd=(Int32)Session["d"]; 
            //if (bb == dd || dd==aa)
            //{
            //    ViewBag.hide = "hidden";
            //    var list_T = db.travels.Where(b => b.beginning == 1).Where(d => d.destination == 1).Where(a => a.id_agency == 1).ToList();
            //    return View(Tuple.Create<travel, IEnumerable<travel>>(new travel(), list_T));
            //}
            //else
            //{
            //     bb = (Int32)Session["b"];
            //     dd = (Int32)Session["d"];
            //     aa = (Int32)Session["a"];
            //    if (bb == 1 && dd == 1 && aa == 1)
            //    {
            //        ViewBag.hide = "hidden";
            //        var list_T = db.travels.Where(b => b.beginning == 1).Where(d => d.destination == 1).Where(a => a.id_agency == 1).ToList();
            //        return View(Tuple.Create<travel, IEnumerable<travel>>(new travel(), list_T));
            //    }
            //    else
            //    {

            //        ViewBag.hide = "";
            //        var list_T = db.travels.Where(b => b.beginning == (Int32)Session["b"]).Where(d => d.destination == (Int32)Session["d"]).Where(a => a.id_agency == (Int32)Session["a"]).ToList();
            //        return View(Tuple.Create<travel, IEnumerable<travel>>(new travel(), list_T));
            //    }
            //}

            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken, ValidateInput(false)]

        public async Task<ActionResult> Index(travel travel)
        {
            if (ModelState.IsValid)
            {
                ViewBag.id_agency = new SelectList(db.agencies, "id", "agency_name", travel.id_agency);
                ViewBag.beginning = new SelectList(db.villes, "id", "ville_name", travel.beginning);
                ViewBag.destination = new SelectList(db.villes, "id", "ville_name", travel.destination);

                Session["a"] = travel.id_agency;
                Session["b"] = travel.beginning;
                Session["d"] = travel.destination;

                return RedirectToAction("Index") ;
            }
            
            return View(travel);
        }

        

    }
}