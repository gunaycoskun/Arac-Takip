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
            var araclar = unitOfWork.Arac.ToList();
            return View(araclar);
        }
        [HttpGet]
        [Route("create-arac")]
        public ActionResult CreateArac()
        {
            var markalar = unitOfWork.Marka.ToList();
            var modeller = unitOfWork.Model.ToList();
            var musteriler = unitOfWork.Musteri.ToList();
            AracVeModeller aracVeModeller = new AracVeModeller{
                markalar =markalar,
                modeller =modeller,
                musteriler=musteriler
            };
            
            return View(aracVeModeller);
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
            var markaAD = unitOfWork.Marka.Select(x => x._id == markaid).FirstOrDefault();
            return View();
        }
    }
}