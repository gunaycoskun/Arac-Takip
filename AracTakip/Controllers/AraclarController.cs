using AracTakip.Models;
using AracTakip.Utils;
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
            AracVeModeller aracVeModeller = new AracVeModeller{
                markalar =markalar,
                modeller =modeller 
            };
            
            return View(aracVeModeller);
        }
        [HttpPost]
        [Route("save-arac")]
        public ActionResult SaveArac()
        {
            return View();
        }
        [Route("get-marka-model")]
        public ActionResult GetAllModels(string markaid)
        {
            var markaAD = unitOfWork.Marka.Select(x => x._id == markaid).FirstOrDefault();
            return View();
        }
    }
}