using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using R.DAL.Context;


namespace AGENCE.Controllers
{
    public class LoginController : Controller
    {
        R.DAL.Context.R_DB_Entities db = new R.DAL.Context.R_DB_Entities();

        public ActionResult login()
        {
            var a = new agency();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken, ValidateInput(false)]

        public async Task<ActionResult> login(agency model)
        {
            if (ModelState.IsValid)
            {
                var user = db.agencies.Where(u => u.username == model.username && u.pass == model.pass).FirstOrDefault();
                if (user != null)
                {

                    Session["id"] = user.id;
                    Session["username"] = user.username;
                    Session["pass"] = user.pass;
                    Session["email"] = user.email;
                    Session["agency_name"] = user.agency_name;
                    Session["adresse"] = user.adresse;
                    Session["logo"] = user.logo;



                    return RedirectToAction("Travel", "Default");

                }
                if(user==null)
                {
                    ViewBag.notvalid = "user or password incorrect";

                    
                }

                
            }

            return View(model);

        }
    }
}