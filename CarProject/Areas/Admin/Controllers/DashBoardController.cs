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

        public ActionResult ContactUsMessages()
        {
            return View();
        }

        public ActionResult ContactUsMessagesShow(int id)
        {
            var db = new DBSEF.CarAutomationEntities();
            var model = db.ContactUsMessages.SingleOrDefault(m => m.MessagID == id);

            model.Seen = DateTime.Now;
            db.SaveChanges();

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
