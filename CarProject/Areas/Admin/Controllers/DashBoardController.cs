using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


using System.Xml.Serialization;
using System.IO;

namespace CarProject.Areas.Admin.Controllers
{
    //[CarProject.CLS.AuthFilter]
    public class DashBoardController : Controller
    {
        //
        // GET: /Admin/DashBoard/

        Models.Dashboard.MySerializer mserilize = new Models.Dashboard.MySerializer();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AboutMe()
        {
            var model = new Models.Dashboard.AboutMe();
            var xm = mserilize.LoadXml(Server.MapPath(model.FileLocation), model.GetType());
            if (xm != null)
                model = (Models.Dashboard.AboutMe)xm;
            return View(model);
        }
        [HttpPost]
        public ActionResult AboutMe(Models.Dashboard.AboutMe model)
        {
            if (ModelState.IsValid)
            {
                mserilize.SaveXml(Server.MapPath(model.FileLocation), model);
            }
            return View(model);
        }

        public ActionResult ContactUs()
        {
            var model = new Models.Dashboard.ContactUs();
            var xm = mserilize.LoadXml(Server.MapPath(model.FileLocation), model.GetType());
            if (xm != null)
                model = (Models.Dashboard.ContactUs)xm;
            return View(model);
        }
        [HttpPost]
        public ActionResult ContactUs(Models.Dashboard.ContactUs model)
        {
            if (ModelState.IsValid)
            {
                mserilize.SaveXml(Server.MapPath(model.FileLocation), model);
            }
            return View(model);
        }

        public ActionResult SlideShower_Slides()
        {
            return View();
        }

        public ActionResult SlideShower_Insert()
        {
            var model = new Models.Dashboard.SlideShowModel();
            return View(model);
        }
        [HttpPost]
        public ActionResult SlideShower_Insert(Models.Dashboard.SlideShowModel model)
        {
            if (ModelState.IsValid)
            {
                model.Save();
                return RedirectToAction("SlideShower_Slides");
            }
            return View(model);
        }


        [HttpPost]
        public ActionResult topNavPostBack(FormCollection form)
        {
            if (form.AllKeys.Contains("userLogout"))
            {
                Session["useradmin"] = null;
                Session.Remove("useradmin");
                return RedirectToAction("Index", "Home", new { area = "" });
            }
            else
                return RedirectToAction("Index");
        }


    }
}
