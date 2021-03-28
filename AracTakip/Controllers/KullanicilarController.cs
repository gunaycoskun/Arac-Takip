using AracTakipSistemi.DAL.Concrete;
using Eselfware.Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AracTakip.Controllers
{
    public class KullanicilarController : Controller
    {
        UnitOfWork unitOfWork = new UnitOfWork();
        // GET: Kullanicilar
        [Route("get-all-users")]
        public ActionResult Kullanicilar()
        {
            var kullanicilar = unitOfWork.Users.ToList();
            return View(kullanicilar);
        }
        [HttpGet]
        [Route("create-kullanicilar")]
        public ActionResult CreateUser()
        {
            return View();
        }
        [HttpPost]
        [Route("save-kullanicilar")]
        public ActionResult SaveUser(string Ad,string Password)
        {
            tbl_Users users = new tbl_Users
            {
                CreatedDate = DateTime.Now,
                KullaniciAdi = Ad,
                Parola = Password
            };
            unitOfWork.Users.Add(users);
            unitOfWork.Save();
            return View();
        }
        public ActionResult DeleteKullanicilar(string id)
        {
            var kullanici = unitOfWork.Users.Find(x => x._id == id);
            unitOfWork.Users.Delete(kullanici);
            return RedirectToAction("Kullanicilar");
        }
        public ActionResult GetKullanicilar(string id)
        {
            var kullaniciGet = unitOfWork.Users.Find(x => x._id == id);
            return View("GetKullanicilar",kullaniciGet);
        }
        [Route("update-kullanici")]
        public ActionResult UpdateKullanici(string id,string ad,string Password)
        {
            var kullaniciUpdate = unitOfWork.Users.Find(x => x._id == id);
            kullaniciUpdate.Parola = Password;
            kullaniciUpdate.KullaniciAdi = ad;
            unitOfWork.Users.Update(kullaniciUpdate);
            unitOfWork.Save();
            return RedirectToAction("Kullanicilar");
        }
    }
}