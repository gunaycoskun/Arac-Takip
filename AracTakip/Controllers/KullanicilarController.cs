using AracTakip.Utils;
using AracTakipSistemi.DAL.Concrete;
using Eselfware.Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AracTakip.Controllers
{
    public class KullanicilarController : BaseController
    {
        UnitOfWork unitOfWork = new UnitOfWork();
        // GET: Kullanicilar
        [Route("get-all-users")]
        public ActionResult Kullanicilar()
        {
            var sessionUser = Session["User"] != null ? Session["User"].ToString() : "";
            if (sessionUser == "True")
            {
                var kullanicilar = unitOfWork.Kullanici.ToList();
                return View(kullanicilar);
            }
            else
            {
                return View("Error");
            }
        }
        [HttpGet]
        [Route("create-kullanicilar")]
        public ActionResult CreateUser()
        {
            var sessionUser = Session["User"] != null ? Session["User"].ToString() : "";
            if (sessionUser == "True")
            {
                return View();
            }
            else
            {
                return View("Error");
            }
        }
        [HttpPost]
        [Route("save-kullanicilar")]
        public ActionResult SaveUser(string Ad,string Password)
        {
            tbl_Kullanicilar users = new tbl_Kullanicilar
            {
                OlusturulmaTarihi = DateTime.Now,
                KullaniciAdi = Ad,
                Parola = Password
            };
            unitOfWork.Kullanici.Add(users);
            unitOfWork.Save();
            return Json("success");
        }
        public ActionResult DeleteKullanicilar(string id)
        {
            var kullanici = unitOfWork.Kullanici.Find(x => x._id == id);
            unitOfWork.Kullanici.Delete(kullanici);
            return RedirectToAction("Kullanicilar");
        }
        public ActionResult GetKullanicilar(string id)
        {
            var sessionUser = Session["User"] != null ? Session["User"].ToString() : "";
            if (sessionUser == "True")
            {
                var kullaniciGet = unitOfWork.Kullanici.Find(x => x._id == id);
                return View("GetKullanicilar", kullaniciGet);
            }
            else
            {
                return View("Error");
            }
        }
        [Route("update-kullanici")]
        public ActionResult UpdateKullanici(string id,string ad,string Password)
        {
            var kullaniciUpdate = unitOfWork.Kullanici.Find(x => x._id == id);
            kullaniciUpdate.Parola = Password;
            kullaniciUpdate.KullaniciAdi = ad;
            unitOfWork.Kullanici.Update(kullaniciUpdate);
            unitOfWork.Save();
            return Json("success");
        }
    }
}