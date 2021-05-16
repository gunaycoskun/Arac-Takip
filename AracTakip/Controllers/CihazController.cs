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
    public class CihazController : BaseController
    {
        UnitOfWork unitOfWork = new UnitOfWork();
        // GET: Cihaz
        [Route("get-all-cihaz")]
        [AllowAnonymous]
        public ActionResult Cihaz()
        {
            var sessionUser = Session["User"] != null ? Session["User"].ToString() : "";
            if (sessionUser == "True")
            {
                var values = unitOfWork.Cihaz.ToList();
                return View(values);
            }
            else
            {
                return View("Error");
            }
        }

        [Route("create-cihaz-get")]
        public ActionResult CreateCihaz()
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
            var sessionUser = Session["User"] != null ? Session["User"].ToString() : "";
            if (sessionUser == "True")
            {
                var cihaz = unitOfWork.Cihaz.Find(x => x._id == id);
                return View("GetCihaz", cihaz);
            }
            else
            {
                return View("Error");
            }
        }
        [Route("update-cihaz")]
        public ActionResult UpdateCihaz(string id,string ip,string port)
        {
            var cihaz = unitOfWork.Cihaz.Find(x=>x._id == id);

            cihaz.CihazIP = ip;
            cihaz.CihazPort = port;
            unitOfWork.Cihaz.Update(cihaz);
            unitOfWork.Save();
            return Json("Cihaz");
        }
    }
}