using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using R.DAL.Context;

namespace AGENCE.Controllers
{
    public class DefaultController : Controller
    {
        R.DAL.Context.R_DB_Entities db = new R.DAL.Context.R_DB_Entities();
        public ActionResult Index()
        {
            ViewBag.id = (Int32)Session["id"];
            int ID = (Int32)Session["id"];
            var user = db.agencies.Where(i => i.id == ID).FirstOrDefault();

            

            return View();
        }


        public ActionResult Travel()
        {
            int ID = (Int32)Session["id"];
            var travel_list = db.travels.Where(i => i.id_agency == ID);
            return View(travel_list);
        }
        public ActionResult Create()
        {
            var m = new travel();
            int ID = (Int32)Session["id"];
            ViewBag.beginning = new SelectList(db.villes, "id", "ville_name");
            ViewBag.destination = new SelectList(db.villes, "id", "ville_name");
            return View(m);
        }

        [HttpPost]
        [ValidateAntiForgeryToken, ValidateInput(false)]
        public async Task<ActionResult> Create(travel tr)
        {
            int ID = (Int32)Session["id"];
            R.DAL.Context.travel TRAVEL = new R.DAL.Context.travel()
            {
                id_agency = ID,
                beginning = tr.beginning,
                destination = tr.destination,
                date_start = tr.date_start,
                date_arrive = tr.date_arrive,

            };

            db.travels.Add(TRAVEL);
            db.SaveChanges();

            ViewBag.beginning = new SelectList(db.villes, "id", "ville_name",tr.beginning);
            ViewBag.destination = new SelectList(db.villes, "id", "ville_name",tr.destination);
            return RedirectToAction("Travel");
        }

        public async Task<ActionResult> Edit(int? id)
        {
            
            Session["identity"] = id.Value;
            ViewBag.id = id.Value;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            travel TRAVEL = await db.travels.FindAsync(id);
            if (TRAVEL == null)
            {
                return HttpNotFound();
            }
            int ID = (Int32)Session["id"];
            if (TRAVEL.id_agency != ID)
            {
                return HttpNotFound();
            }
            ViewBag.beginning = new SelectList(db.villes, "id", "ville_name", TRAVEL.beginning);
            ViewBag.destination = new SelectList(db.villes, "id", "ville_name", TRAVEL.destination);
            return View(TRAVEL);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,id_agency,beginning,destination,date_start,date_arrive")]
        travel TRAVEL)
        {
            int ID = (Int32)Session["id"];
            int identity = (Int32)Session["identity"];
            if (ModelState.IsValid)
            {
                R.DAL.Context.travel T = new R.DAL.Context.travel()
                {
                    id = identity,
                    id_agency = ID,

                    beginning = TRAVEL.beginning,
                    destination = TRAVEL.destination,
                    date_start = TRAVEL.date_start,
                    date_arrive = TRAVEL.date_arrive,
                    

                };
                db.Entry(T).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Travel");
            }
            ViewBag.beginning = new SelectList(db.villes, "id", "ville_name", TRAVEL.beginning);
            ViewBag.destination = new SelectList(db.villes, "id", "ville_name", TRAVEL.destination);
            return View(TRAVEL);
        }

        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            travel T = await db.travels.FindAsync(id);

            if (T == null)
            {
                return HttpNotFound();
            }
            
            int ID = (Int32)Session["id"];
            if (T.id_agency!= ID)
            {
                return HttpNotFound();
            }

            travel TT = db.travels
             .Where(i => i.id == id)
             .Single();

            db.travels.Remove(TT);
            db.SaveChanges();
            return RedirectToAction("Travel");
        }






    }
}
