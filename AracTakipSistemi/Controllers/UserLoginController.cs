using Eselfware.Repository.UnitOfWork;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AracTakipSistemi.Controllers
{
    public class UserLoginController : Controller
    {
        // GET: UserLogin
        [Route("ajax-login")]
        public ActionResult Login(string KullaniciAd, string Sifre)
        {
            UnitOfWork unitOfWork = new UnitOfWork();
            var deger = "0";
            var kullanici = unitOfWork.Users.Find(x => x.KullaniciAdi == KullaniciAd && x.Parola == Sifre);
            if (kullanici == null)
            {
                return Content(JsonConvert.SerializeObject(deger), "application/json");
            }
            else
            {
                deger = "1";
                return Content(JsonConvert.SerializeObject(deger), "application/json");
            }

        }
    }
}