using AracTakip.Models;
using AracTakipSistemi.DAL.Concrete;
using Eselfware.Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AracTakip.Controllers
{
    public class ModelController : Controller
    {
        UnitOfWork unitOfWork = new UnitOfWork();
        // GET: Model
        [Route("get-all-model")]
        public ActionResult Model()
        {
            var modeller = (from model in unitOfWork.Model.ToList()
                            join motor in unitOfWork.MotorTip.ToList().DefaultIfEmpty() on model.MotorID equals motor._id
                            join kapi in unitOfWork.KapiTip.ToList().DefaultIfEmpty() on model.KapiID equals kapi._id
                            join kasa in unitOfWork.KasaTip.ToList().DefaultIfEmpty() on model.KasaID equals kasa._id
                            join vites in unitOfWork.Vites.ToList().DefaultIfEmpty() on model.VitesID equals vites._id
                            select new Modeller
                            {
                                _id = model._id,
                                KapiAD = kapi.KapiAD?? "Kapı Tipi bulunamadı",
                                KasaAD=kasa.KasaAD?? "Kasa Tipi bulunamadı",
                                ModelAD=model.ModelAD?? "Model bulunamadı",
                                MotorAD=motor.MotorAD?? "Motor bulunamadı",
                                VitesAD=vites.VitesAD+" "+vites.VitesSayisi?? "Vites Tipi bulunamadı"


                            }).ToList();
            return View(modeller);
        }
        [HttpGet]
        [Route("create-model")]
        public ActionResult CreateModel()
        {
            var motors = unitOfWork.MotorTip.ToList();
            return View(motors);
        }
        [HttpPost]
        [Route("save-model")]
        public ActionResult SaveModel(string ModelAD, string KapiSelect, string KasaSelect, string Vites, string Motor)
        {

            tbl_Model model = new tbl_Model
            {
                KapiID=KapiSelect,
                KasaID=KasaSelect,
                ModelAD=ModelAD,
                VitesID= Vites,
                MotorID= Motor
            };
            unitOfWork.Model.Add(model);
            unitOfWork.Save();

            return RedirectToAction("Model");
        }
        public ActionResult DeleteModel(string id)
        {
           var value= unitOfWork.Model.Find(x => x._id==id);
            unitOfWork.Model.Delete(value);
            unitOfWork.Save();
            return RedirectToAction("Model");
        }
        public ActionResult GetModel(string id)
        {
            var motor = unitOfWork.MotorTip.ToList();
            var model = unitOfWork.Model.Find(x => x._id == id);
            ModelAndMotors modelAndMotors = new ModelAndMotors
            {
                KapiID = model.KapiID,
                KasaID = model.KasaID,
                ModelAD = model.ModelAD,
                VitesID = model.VitesID,
                MotorID = model.MotorID,
                _id = id,
                motors=motor
            };
            return View("GetModel", modelAndMotors);
        }
        [Route("update-model")]
        public ActionResult UpdateModel(string id, string ModelAD, string KapiSelect, string KasaSelect, string Vites, string Motor)
        {
            var model=unitOfWork.Model.Find(x => x._id == id);
            model.VitesID = Vites;
            model.MotorID = Motor;
            model.ModelAD = ModelAD;
            model.KasaID = KasaSelect;
            model.KapiID = KapiSelect;
            unitOfWork.Model.Update(model);
            unitOfWork.Save();
            return RedirectToAction("Model");
        }
        [Route("select-motor")]
        public ActionResult MotoruGetir(string id)
        {
            var motor=unitOfWork.MotorTip.Find(x => x._id == id);
            return View(motor);
        }
    }
}