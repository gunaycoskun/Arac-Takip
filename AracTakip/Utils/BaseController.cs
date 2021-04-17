using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AracTakip.Utils
{
    public class BaseController : Controller
    {
        //protected override void OnActionExecuting(ActionExecutingContext filterContext)
        //{
        //    //base.OnActionExecuting(filterContext);
        //    if (Session["AdminUser"]==null )
        //    {
        //        Response.Redirect("/Login");
        //    }
           
        //}
        // GET: Base
        public ActionResult Index()
        {
            return View();
        }
    }
}