using AracTakipSistemi.DAL.Concrete;
using Eselfware.Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AracTakip.Controllers
{
    public class CihazController : Controller
    {
        UnitOfWork unitOfWork = new UnitOfWork();
        // GET: Cihaz
        [Route("get-all-cihaz")]
        [AllowAnonymous]
        public ActionResult Cihaz()
        {
            var values = unitOfWork.Cihaz.ToList();
            return View(values);
        }

        [Route("create-cihaz-get")]
        public ActionResult CreateCihaz()
        {
            return View();
        }

        [Route("create-cihaz-post")]
        public ActionResult CreateCihazPost(string CihazAd,string CihazIP, string CihazPort)
        {
            tbl_Cihaz cihaz = new tbl_Cihaz
            {
                CihazAd=CihazAd,
                CihazIP=CihazIP,
                CihazPort=CihazPort
            };
            unitOfWork.Cihaz.Add(cihaz);
            unitOfWork.Save();

            return Json("1");
        }
        public ActionResult DeleteCihaz(string id)
        {
           unitOfWork.Cihaz.RemoveRange(unitOfWork.Cihaz.Where(x => x._id == id));

            return RedirectToAction("Cihaz");
        }

        public ActionResult GetCihaz(string id)
        {
            var cihaz = unitOfWork.Cihaz.Find(x => x._id == id);
           
            return View("GetCihaz", cihaz);
        }
        [Route("update-cihaz")]
        public ActionResult UpdateCihaz(tbl_Cihaz c)
        {
            var cihaz = unitOfWork.Cihaz.Find(x=>x._id==c._id);
            cihaz.CihazAd = c.CihazAd;
            cihaz.CihazIP = c.CihazIP;
            cihaz.CihazPort = c.CihazPort;
            unitOfWork.Cihaz.Update(cihaz);
            unitOfWork.Save();
            return RedirectToAction("Cihaz");
        }
    }
}