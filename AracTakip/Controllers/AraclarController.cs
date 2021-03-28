using Eselfware.Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AracTakip.Controllers
{
    public class AraclarController : Controller
    {
        UnitOfWork unitOfWork = new UnitOfWork();
        // GET: Araclar
        [Route("get-all-araclar")]
        public ActionResult Araclar()
        {
            return View();
        }
        [HttpGet]
        [Route("create-arac")]
        public ActionResult CreateArac()
        {
            return View();
        }
        [HttpPost]
        [Route("save-arac")]
        public ActionResult SaveArac()
        {
            return View();
        }
    }
}