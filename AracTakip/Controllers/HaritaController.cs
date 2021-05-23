using AracTakip.Models;
using Eselfware.Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AracTakip.Controllers
{
    public class HaritaController : Controller
    {
        UnitOfWork _unitOfWork = new UnitOfWork();
        [Route("harita-getir")]
        public ActionResult Harita(string plaka, string TC)
        {
            var musteri = _unitOfWork.Musteri.Find(x => x.MusteriTC == TC)._id;
            var arac = _unitOfWork.Arac.Find(x => x.MusteriID == musteri&&x.Plaka==plaka)._id;
            var cihaz = _unitOfWork.Cihaz.Find(x => x._id == arac);
            var XDeger = cihaz.XKonum.ToString();
            var YDeger = cihaz.YKonum.ToString();
    
            return Json(cihaz._id);
            

        }
        [Route("get-harita")]
        public ActionResult GetHarita(string id)
        {
            var cihaz = _unitOfWork.Cihaz.Find(x => x._id == id);
            Locations locations = new Locations
            {
                Lat = cihaz.XKonum.ToString(),
                Long = cihaz.YKonum.ToString()
            };
            
            return View(locations);
        }


    }
}