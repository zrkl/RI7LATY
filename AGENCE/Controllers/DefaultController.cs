using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AGENCE.Controllers
{
    public class DefaultController : Controller
    {
        R.DAL.Context.R_DB_Entities db = new R.DAL.Context.R_DB_Entities();
        public ActionResult Index()
        {
            ViewBag.id = (Int32)Session["id"];
            var ID = (Int32)Session["id"];
            var user = db.agencies.Where(i => i.id == ID).FirstOrDefault();
            
            



            return View();
        }
    }
}