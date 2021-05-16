using AracTakip.Models;
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
    public class AraclarController : BaseController
    {
        UnitOfWork unitOfWork = new UnitOfWork();
        // GET: Araclar
        [Route("get-all-araclar")]
        public ActionResult Araclar()
        {
            var sessionUser = Session["User"] != null ? Session["User"].ToString() : "";
            if (sessionUser == "True")
            {
                var araclar = unitOfWork.Arac.ToList();
                return View(araclar);
            }

            else
            {
                return View("Error");
            }
        }
        [HttpGet]
        [Route("create-arac")]
        public ActionResult CreateArac()
        {
            var sessionUser = Session["User"] != null ? Session["User"].ToString() : "";
            if (sessionUser == "True")
            {
                var markalar = unitOfWork.Marka.ToList();
                var modeller = unitOfWork.Model.ToList();
                var musteriler = unitOfWork.Musteri.ToList();
                AracVeModeller aracVeModeller = new AracVeModeller
                {
                    markalar = markalar,
                    modeller = modeller,
                    musteriler = musteriler
                };
                return View(aracVeModeller);
            }
            else
            {
                return View("Error");
            }
        }
        [HttpPost]
        [Route("save-arac")]
        public ActionResult SaveArac(string plaka,string sasi,string renk,string marka, string model, string musteri,string yil)
        {
            var deger = 0;

            try
            {
                tbl_Arac arac = new tbl_Arac
                {
                    MarkaID = marka,
                    ModelID = model,
                    MusteriID = musteri,
                    Plaka = plaka,
                    Renk = renk,
                    SasiNo = sasi,
                    Yil = yil
                };
                unitOfWork.Arac.Add(arac);
                unitOfWork.Save();
                var id = unitOfWork.Arac.Find(x => x.Plaka == plaka && x.SasiNo == sasi)._id;
                tbl_Cihaz cihaz = new tbl_Cihaz
                {
                    CihazAd = plaka,
                    _id = id

                };
                unitOfWork.Cihaz.Add(cihaz);
                unitOfWork.Save();
                deger = 1;
                return Json(deger);
            }
            catch (Exception)
            {

                return Json(deger);
            }
           
        }
        [Route("get-marka-model")]
        public ActionResult GetAllModels(string markaid)
        {
            var sessionUser = Session["User"] != null ? Session["User"].ToString() : "";
            if (sessionUser == "True")
            {
                var markaAD = unitOfWork.Marka.Select(x => x._id == markaid).FirstOrDefault();
                return View();
            }
            else
            {
                return View("Error");
            }
        }
     
        public ActionResult DeleteArac(string id)
        {
            var arac=unitOfWork.Arac.Find(x => x._id == id);
            var cihaz = unitOfWork.Cihaz.Find(x => x._id == id);
            unitOfWork.Arac.Delete(arac);
            unitOfWork.Cihaz.Delete(cihaz);
            unitOfWork.Save();
            return RedirectToAction("Araclar");
        }
        public ActionResult GetArac(string id)
        {
            var arac = unitOfWork.Arac.Find(x => x._id == id);
            var markalar = unitOfWork.Marka.ToList();
            var modeller = unitOfWork.Model.ToList();
            var musteriler = unitOfWork.Musteri.ToList();
            AracGuncelleme guncelleme = new AracGuncelleme
            {       
                markalar = markalar,
                modeller = modeller,
                musteriler = musteriler,
                MarkaID=arac.MarkaID,
                ModelID=arac.ModelID,
                MusteriID=arac.MusteriID,
                Plaka=arac.Plaka,
                Renk=arac.Renk,
                SasiNo=arac.SasiNo,
                Yil=arac.Yil,
                _id=arac._id
                
            };

            return View(guncelleme);
        }
        [Route("update-arac")]
        public ActionResult UpdateArac(string plaka, string sasi, string renk, string marka, string model, string musteri, string yil,string id)
        {
            var cihaz = unitOfWork.Cihaz.Find(x => x._id == id);
            cihaz.CihazAd = plaka;
            unitOfWork.Cihaz.Update(cihaz);
            var arac = unitOfWork.Arac.Find(x => x._id == id);
            arac.Yil = yil;
            arac.SasiNo = sasi;
            arac.Renk = renk;
            arac.Plaka = plaka;
            arac.MusteriID = musteri;
            arac.ModelID = model;
            arac.MarkaID = marka;
            unitOfWork.Arac.Update(arac);
            unitOfWork.Save();
            return Json("1");
        }
    }
}