using AracTakip.Utils;
using AracTakipSistemi.Repository.Seeder;
using Eselfware.Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AracTakip.Controllers
{
    public class HomeController : Controller
    {
        
        UnitOfWork _unitOfWork = new UnitOfWork();
        [Route("Login")]
        public ActionResult Index()
        {
            
            return View();
        }

        //[HttpPost]
        [Route("About")]
        public ActionResult About()
        {


            return View();
        }
        [Route("Contact")]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [Route("PanelGiris")]
        [AllowAnonymous]
       public ActionResult AdminPanel(string Kullanici, string Parola)
        {
           
            var deger = "1";
            if (_unitOfWork.Kullanici.Any(x => x.KullaniciAdi == Kullanici && x.Parola == Parola))
            {
                Session.Add("User", true);
                DataSeeder.Seed(_unitOfWork);
                
                return Json(deger);
            }
            else
            {
                deger = "0";
                return View(deger);
            }


        }

       [Route("cikis-islemi")]
       public ActionResult Cikis()
       {
           Session.Clear();
           return Json("");
       }
       
    }
}