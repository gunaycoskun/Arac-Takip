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
    public class MotorController : Controller
    {
        UnitOfWork unitOfWork = new UnitOfWork();
        // GET: Motor
        [Route("get-all-motor")]
        public ActionResult Motor()
        {

            var motorlar = (from motor in unitOfWork.MotorTip.ToList().DefaultIfEmpty()
                            join yakit in unitOfWork.YakitTip.ToList().DefaultIfEmpty() on motor.YakitID equals yakit._id
                            select new Motorlar
                            {   _id=motor._id,
                                Adi = motor.MotorAD?? "Motor Adı bulunamadı.",
                                Beygir=motor.MotorBeygir?? "Beygir sayısı bulunamadı.",
                                YakitAD=yakit.YakitAD?? "Yakıt Adı bulunamadı.",
                                CC=motor.MotorCC?? "CC değeri bulunamadı.",
                                Silindir=motor.Silindir?? "Silindir sayısı bulunamadı.",    
                            }).ToList();

            //var araclar = (from arac in unitOfWork.Arac.ToList().DefaultIfEmpty()
            //                 join marka in unitOfWork.Marka.ToList().DefaultIfEmpty() on arac.MarkaID equals marka._id
            //                 join model in unitOfWork.Model.ToList().DefaultIfEmpty() on marka.ModelID equals model._id
            //                 join vites in unitOfWork.Vites.ToList().DefaultIfEmpty() on model.VitesID equals vites._id
            //                 join kapi in unitOfWork.KapiTip.ToList().DefaultIfEmpty() on model.KapiID equals kapi._id
            //                 join motor in unitOfWork.MotorTip.ToList().DefaultIfEmpty() on model.MotorID equals motor._id
            //                 join yakit in unitOfWork.YakitTip.ToList().DefaultIfEmpty() on motor.YakitID equals yakit._id
            //                 select new Araclar
            //                 {
            //                     Adi = marka.MarkaAD ?? "Marka bilgisi bulunamadı." + " " + model.ModelAD ?? "Model bilgisi bulunamadı.",
            //                     KapiTipi = kapi.KapiAD ?? "Kapı bilgisi bulunamadı.",
            //                     Vites = vites.VitesAD == null ? "Vites ad bulunamadı" : vites.VitesAD + " " + vites.VitesSayisi == null ? "Vites sayısı bulunamadı." : vites.VitesSayisi + " vites",
            //                     Yakip = yakit.YakitAD ?? "Yakıt bilgisi bulunamadı."
            //                 }).ToList();



           
            return View(motorlar);
        }
        [HttpGet]
        [Route("create-motor")]
        public ActionResult CreateMotor()
        {
            return View();
        }
        [HttpPost]
        [Route("save-motor")]
        public ActionResult SaveMotor(string MotorAD, string MotorBeygir, string MotorCC, string Silindir, string Yakit)
        {
            var value = 0;
            if (MotorAD.Trim() != null)
            {
                unitOfWork.MotorTip.Add(new tbl_MotorTip
                {
                    MotorAD = MotorAD,
                    MotorBeygir = MotorBeygir,
                    YakitID = Yakit,
                    Silindir = Silindir,
                    MotorCC = MotorCC
                });
                return Json(value);
            }
            else
            {
                value = 1;
                return Json(value);
            }

        }
        public ActionResult DeleteMotor(string id)
        {
            var value = unitOfWork.MotorTip.Find(x => x._id == id);
            unitOfWork.MotorTip.Delete(value);
            unitOfWork.Save();
            return RedirectToAction("Motor");
        }
        public ActionResult GetMotor(string id)
        {
            var motor = unitOfWork.MotorTip.Find(x => x._id == id);

            return View("GetMotor", motor);

        }
        [Route("update-motor")]
        public ActionResult UpdateMotor(string MotorAD, string MotorBeygir, string MotorCC, string Silindir, string Yakit,string id)
        {
            var motor=unitOfWork.MotorTip.Find(x=>x._id==id);
            motor.MotorAD = MotorAD;
            motor.MotorBeygir = MotorBeygir;
            motor.MotorCC = MotorCC;
            motor.YakitID = Yakit;
            motor.Silindir = Silindir;
            unitOfWork.MotorTip.Update(motor);
            unitOfWork.Save();
            return RedirectToAction("Motor");
        }
    }
}