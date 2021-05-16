using AracTakipSistemi.DAL.Concrete;
using Eselfware.Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AracTakip.Controllers
{
    public class MusteriController : Controller
    {
        UnitOfWork unitOfWork = new UnitOfWork();
        // GET: Musteri
        [Route("get-all-musteri")]
        public ActionResult Musteri()
        {
            var sessionUser = Session["User"] != null ? Session["User"].ToString() : "";
            if (sessionUser=="True")
            {
                var allMusteri = unitOfWork.Musteri.ToList();
                return View(allMusteri); 
            }
            else
            {
                return View("Error");
            }
        }
      
        public ActionResult DeleteMusteri(string id)
        {
            var delteItem = unitOfWork.Musteri.Find(x => x._id == id);
            unitOfWork.Musteri.Delete(delteItem);
            return RedirectToAction("Musteri");
        }
        [HttpGet]
        [Route("add-musteri")]
        public ActionResult AddMusteri()
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
        [Route("add-musteri-ajax")]
        public ActionResult AddMusteriAjax(string TC, string AdSoyad, string Email, string Tel)
        {
            var deger = 0;
            if (Email.Contains('@') == true)
            {
                tbl_Musteri musteri = new tbl_Musteri
                {
                    MusteriAdSoyad = AdSoyad,
                    MusteriEMail = Email,
                    MusteriTC = TC,
                    MusteriTel = Tel
                };
                unitOfWork.Musteri.Add(musteri);
                unitOfWork.Save();
                deger = 1;
            }
            return Json(deger);
        }

        public ActionResult GetMusteri(string id)
        {
            var sessionUser = Session["User"] != null ? Session["User"].ToString() : "";
            if (sessionUser=="True")
            {
                var musteri = unitOfWork.Musteri.Find(x => x._id == id);
                return View("GetMusteri", musteri); 
            }
            else
            {
                return View("Error");
            }
        }
        [HttpPost]
        [Route("update-musteri-ajax")]
        public ActionResult UpdateMusteri(string id,string TC, string AdSoyad, string Email, string Tel)
        {
            var deger = 0;
            if (TC!=null  && AdSoyad!=null && Email!=null && Tel!=null)
            {
                var musteri = unitOfWork.Musteri.Find(x => x._id == id);
                musteri.MusteriAdSoyad = AdSoyad;
                musteri.MusteriEMail = Email;
                musteri.MusteriTel = Tel;
                musteri.MusteriTC = TC;
                unitOfWork.Musteri.Update(musteri);
                unitOfWork.Save();
                deger = 1;
            }
            return Json(deger);
        }
    }
}