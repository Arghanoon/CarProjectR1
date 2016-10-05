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
        [HttpPost]
        public ActionResult ContactUsMessages_Delete(int id)
        {
            var db = new DBSEF.CarAutomationEntities();
            db.ContactUsMessages.Remove(db.ContactUsMessages.SingleOrDefault(cum => cum.MessagID == id));
            db.SaveChanges();
            return RedirectToAction("ContactUsMessages");
        }

        public ActionResult ContactUsMessagesShow(int id)
        {
            var db = new DBSEF.CarAutomationEntities();
            var model = db.ContactUsMessages.SingleOrDefault(m => m.MessagID == id);

            model.Seen = DateTime.Now;
            db.SaveChanges();

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

        public ActionResult SlideShower_Update(int Id)
        {
            var model = new Models.Dashboard.SlideShowModel(Id);
            if (model == null)
                return RedirectToAction("SlideShower_Slides");
            TempData["SlideshowUpdateObjectSelect"] = model;
            return View(model);
        }
        [HttpPost]
        public ActionResult SlideShower_Update(Models.Dashboard.SlideShowModel model)
        {
            if (ModelState.IsValid)
            {
                var m = TempData["SlideshowUpdateObjectSelect"] as Models.Dashboard.SlideShowModel;
                TryUpdateModel(m);
                m.Update();
                return RedirectToAction("SlideShower_Slides");
            }
            return View(model);
        }


        public ActionResult CountryManagment()
        {
            var model = new Models.Dashboard.CountryModel();
            return View(model);
        }
        [HttpPost]
        public ActionResult CountryManagment(Models.Dashboard.CountryModel model)
        {
            if (ModelState.IsValid)
            {
                model.Save();
                return RedirectToAction("CountryManagment");
            }
            return View(model);
        }
        public ActionResult CountryManagment_Update(int? id)
        {
            var model = new Models.Dashboard.CountryModel(id);
            if (model == null)
                return RedirectToAction("CountryManagment");
            TempData["countryUpdateSelectedItem"] = model;
            return View(model);
        }
        [HttpPost]
        public ActionResult CountryManagment_Update(Models.Dashboard.CountryModel model)
        {
            if (ModelState.IsValid)
            {
                var m = TempData["countryUpdateSelectedItem"] as Models.Dashboard.CountryModel;
                TryUpdateModel(m);
                m.dbs.SaveChanges();

                return RedirectToAction("CountryManagment");
            }
            return View(model);
        }


        public ActionResult CompaniesManagment()
        {
            var model = new Models.Dashboard.CompanyModel();
            return View(model);
        }
        [HttpPost]
        public ActionResult CompaniesManagment(Models.Dashboard.CompanyModel model)
        {
            if (ModelState.IsValid)
            {
                model.Save();
                return RedirectToAction("CompaniesManagment");
            }
            return View(model);
        }
        public ActionResult CompaniesManagment_Update(int? id)
        {
            var model = new Models.Dashboard.CompanyModel(id);
            TempData["updateSelectedCompany"] = model;
            return View(model);
        }
        [HttpPost]
        public ActionResult CompaniesManagment_Update(Models.Dashboard.CompanyModel model)
        {
            if (ModelState.IsValid)
            {
                var m = TempData["updateSelectedCompany"] as Models.Dashboard.CompanyModel;
                TryUpdateModel(m);
                m.dbs.SaveChanges();

                return RedirectToAction("CompaniesManagment");
            }
            return View(model);
        }



        public ActionResult ManufactursManagment()
        {
            var model = new Models.Dashboard.CompanyModel();
            return View(model);
        }
        [HttpPost]
        public ActionResult ManufactursManagment(Models.Dashboard.CompanyModel model)
        {
            if (ModelState.IsValid)
            {
                model.Save();
                return RedirectToAction("CompaniesManagment");
            }
            return View(model);
        }
        public ActionResult ManufactursManagment_Update(int? id)
        {
            var model = new Models.Dashboard.CompanyModel(id);
            TempData["updateSelectedCompany"] = model;
            return View(model);
        }
        [HttpPost]
        public ActionResult ManufactursManagment_Update(Models.Dashboard.CompanyModel model)
        {
            if (ModelState.IsValid)
            {
                var m = TempData["updateSelectedCompany"] as Models.Dashboard.CompanyModel;
                TryUpdateModel(m);
                m.dbs.SaveChanges();

                return RedirectToAction("CompaniesManagment");
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
