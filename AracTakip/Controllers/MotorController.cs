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
    public class MotorController : BaseController
    {
        UnitOfWork unitOfWork = new UnitOfWork();
        // GET: Motor
        [Route("get-all-motor")]
        public ActionResult Motor()
        {
            var sessionUser = Session["User"] != null ? Session["User"].ToString() : "";
            if (sessionUser == "True")
            {
                var motorlar = (from motor in unitOfWork.MotorTip.ToList().DefaultIfEmpty()
                    join yakit in unitOfWork.YakitTip.ToList().DefaultIfEmpty() on motor.YakitID equals yakit._id
                    select new Motorlar
                    {
                        _id = motor._id,
                        Adi = motor.MotorAD ?? "Motor Adı bulunamadı.",
                        Beygir = motor.MotorBeygir ?? "Beygir sayısı bulunamadı.",
                        YakitAD = yakit.YakitAD ?? "Yakıt Adı bulunamadı.",
                        CC = motor.MotorCC ?? "CC değeri bulunamadı.",
                        Silindir = motor.Silindir ?? "Silindir sayısı bulunamadı.",
                    }).ToList();
                return View(motorlar);
            }
            else
            {
                return View("Error");
            }
        }
        [HttpGet]
        [Route("create-motor")]
        public ActionResult CreateMotor()
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
            var sessionUser = Session["User"] != null ? Session["User"].ToString() : "";
            if (sessionUser == "True")
            {
                var motor = unitOfWork.MotorTip.Find(x => x._id == id);

                return View("GetMotor", motor);
            }
            else
            {
                return View("Error");
            }

        }
        [Route("update-motor")]
        public ActionResult UpdateMotor(string MotorAD, string MotorBeygir, string MotorCC, string Silindir, string Yakit,string id)
        {
            var motor=unitOfWork.MotorTip.Find(x=>x._id == id);
            motor.MotorAD = MotorAD;
            motor.MotorBeygir = MotorBeygir;
            motor.MotorCC = MotorCC;
            motor.YakitID = Yakit;
            motor.Silindir = Silindir;
            unitOfWork.MotorTip.Update(motor);
            unitOfWork.Save();
            return Json("success");
        }
    }
}