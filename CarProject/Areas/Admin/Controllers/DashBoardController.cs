using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarProject.Areas.Admin.Controllers
{
    //[CarProject.Areas.Admin.CLS.AuthFilter]
    public class DashBoardController : Controller
    {
        //
        // GET: /Admin/DashBoard/
        public ActionResult Index()
        {
            return View();
        }



        [HttpPost]
        public ActionResult topNavPostBack(FormCollection form)
        {
            if (form.AllKeys.Contains("userLogout"))
            {
                Session["useradmin"] = "";
                return RedirectToAction("Index", "Home", new { area = "" });
            }
            else
                return RedirectToAction("Index");
        }
    }
}
