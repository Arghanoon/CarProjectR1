using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


using System.Xml.Serialization;
using System.IO;

using CarProject.App_extension;

namespace CarProject.Areas.Admin.Controllers
{
    [CarProject.CLS.AuthFilter]
    public class DashBoardController : Controller
    {
        //
        // GET: /Admin/DashBoard/

        Models.Dashboard.MySerializer mserilize = new Models.Dashboard.MySerializer();
        CarProject.DBSEF.CarAutomationEntities dbsobject = new DBSEF.CarAutomationEntities();

        public ActionResult Index()
        {
            return View();
        }

        #region Mails Message
        public ActionResult MailsMessage_Signup_SendActivationcode()
        {
            var model = new Models.Dashboard.MailsMessage_Signup_SendActivationcode();
            model.Load();
            return View(model);
        }
        [HttpPost]
        public ActionResult MailsMessage_Signup_SendActivationcode(Models.Dashboard.MailsMessage_Signup_SendActivationcode model)
        {
            if (ModelState.IsValid)
            {
                model.Save();
            }
            return View(model);
        }

        public ActionResult MailsMessage_Signup_RecoveryKey()
        {
            var model = new Models.Dashboard.MailsMessage_Signup_RecoveryKey();
            model.Load();
            return View(model);
        }
        [HttpPost]
        public ActionResult MailsMessage_Signup_RecoveryKey(Models.Dashboard.MailsMessage_Signup_RecoveryKey model)
        {
            if (ModelState.IsValid)
            {
                model.Save();
            }
            return View(model);
        }


        public ActionResult MaillsMessage_MarketingHistory()
        {
            return View();
        }

        public ActionResult MaillsMessage_Marketing()
        {
            var model = new Models.Dashboard.MailsMessage_Marketing_Model();
            return View(model);
        }
        [HttpPost]
        public ActionResult MaillsMessage_Marketing(Models.Dashboard.MailsMessage_Marketing_Model model)
        {
            if (ModelState.IsValid)
            {
                model.SendMessage();
                model.SaveMessage();
                return RedirectToAction("MaillsMessage_MarketingHistory");
            }
            return View(model);
        }

        public JsonResult MailsMessage_Marketing_Emails(int? Type)
        {
            var dbs = new CarProject.DBSEF.CarAutomationEntities();
            var res = dbs.People.Where(p => p.User.UserRoleId == 2).Select(p => new { email = p.PersonEmail, name = p.PersonFirtstName + " " + p.PersonLastName, username = p.User.Uname, pid = p.PersonId });
            
            if (Type == 2)
            {
                res = dbs.People.Select(p => new { email = p.PersonEmail, name = p.PersonFirtstName + " " + p.PersonLastName, username = p.User.Uname, pid = p.PersonId });
            }
            
            return Json(res.ToList(), JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region about me and contact us
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
        #endregion

        #region Slidershows
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
        #endregion

        #region Countries and Companies and manufactures
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
            var model = new Models.Dashboard.ManufactureModel();
            return View(model);
        }
        [HttpPost]
        public ActionResult ManufactursManagment(Models.Dashboard.ManufactureModel model)
        {
            if (ModelState.IsValid)
            {
                model.Save();
                return RedirectToAction("ManufactursManagment");
            }
            return View(model);
        }
        public ActionResult ManufactursManagment_Update(int? id)
        {
            var model = new Models.Dashboard.ManufactureModel(id);
            TempData["updateSelectedManufactureModel"] = model;
            return View(model);
        }
        [HttpPost]
        public ActionResult ManufactursManagment_Update(Models.Dashboard.ManufactureModel model)
        {
            if (ModelState.IsValid)
            {
                var m = TempData["updateSelectedManufactureModel"] as Models.Dashboard.ManufactureModel;
                TryUpdateModel(m);
                m.dbs.SaveChanges();

                return RedirectToAction("ManufactursManagment");
            }
            return View(model);
        }
        #endregion

        #region MenuManager 
        public ActionResult MainMenus()
        {
            return View();
        }

        public ActionResult MainMenu_Insert()
        {
            return View();
        }
        [HttpPost]
        public ActionResult MainMenu_Insert(DBSEF.HomePageMenu model)
        {
            if (model.Subject.IsNullOrWhiteSpace())
                ModelState.AddModelError("Subject", "عنوان لینک تعیین نشده است");
            if (model.Target.IsNullOrWhiteSpace())
                ModelState.AddModelError("Target", "لینک صفحه تعیین نشده است");

            if (ModelState.IsValid)
            {
                dbsobject.HomePageMenus.Add(model);
                dbsobject.SaveChanges();

                return RedirectToAction("MainMenus");
            }

            return View(model);
        }

        public ActionResult MainMenu_Update(int? id)
        {
            var model = dbsobject.HomePageMenus.FirstOrDefault(c => c.HomePageMenuId == id);
            if (model == null)
                return RedirectToAction("MainMenus");

            return View(model);
        }
        [HttpPost]
        public ActionResult MainMenu_Update(int? id, DBSEF.HomePageMenu model)
        {
            if (model.Subject.IsNullOrWhiteSpace())
                ModelState.AddModelError("Subject", "عنوان لینک تعیین نشده است");
            if (model.Target.IsNullOrWhiteSpace())
                ModelState.AddModelError("Target", "لینک صفحه تعیین نشده است");

            if (ModelState.IsValid)
            {
                var mdl = dbsobject.HomePageMenus.FirstOrDefault(c => c.HomePageMenuId == id);
                if (mdl != null)
                {
                    TryUpdateModel(mdl);
                    dbsobject.SaveChanges();
                }

                return RedirectToAction("MainMenus");
            }

            return View(model);
        }

        public ActionResult MainMenu_delete(int? id)
        {
            var model = dbsobject.HomePageMenus.FirstOrDefault(c => c.HomePageMenuId == id);
            if (model == null)
                return RedirectToAction("MainMenus");

            return View(model);
        }
        [HttpPost, ActionName("MainMenu_delete")]
        public ActionResult MainMenu_deleteConfirmed(int? id)
        {
            var model = dbsobject.HomePageMenus.FirstOrDefault(c => c.HomePageMenuId == id);
            if (model != null)
            {
                dbsobject.HomePageMenus.Remove(model);
                dbsobject.SaveChanges();
            }

            return RedirectToAction("MainMenus");
        }

        #endregion

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
