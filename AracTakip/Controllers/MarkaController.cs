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
    public class MarkaController : BaseController
    {
        UnitOfWork unitOfWork = new UnitOfWork();
        // GET: Marka
        [Route("get-all-marka")]
        public ActionResult Marka()
        {
            var allMarka = unitOfWork.Marka.ToList();
            return View(allMarka);
        }
        [HttpGet]
        [Route("create-marka")]
        public ActionResult CreateMarka()
        {
            var models = unitOfWork.Model.ToList();
            return View(models);
        }
        [HttpPost]
        [Route("save-marka")]
        public ActionResult SaveMarka(string MarkaAD, string ModelID)
        {
            tbl_Marka marka = new tbl_Marka
            {
                MarkaAD = MarkaAD
            };
            unitOfWork.Marka.Add(marka);
            unitOfWork.Save();
            return View();
        }
        public ActionResult DeleteMarka(string id)
        {
            var marka = unitOfWork.Marka.Find(x => x._id == id);
            unitOfWork.Marka.Delete(marka);
            return RedirectToAction("Marka");
        }
        public ActionResult GetMarka(string id)
        {
            var marka = unitOfWork.Marka.Find(x => x._id == id);
           
                 
            return View("GetMarka", marka);
        }
        [HttpPost]
        [Route("edit-marka")]
        public ActionResult EditMarka(string id,string MarkaAD)
        {
            var marka = unitOfWork.Marka.Find(x=>x._id == id);
            marka.MarkaAD = MarkaAD;
            unitOfWork.Marka.Update(marka);
            unitOfWork.Save();
            return View();
        }
    }
}