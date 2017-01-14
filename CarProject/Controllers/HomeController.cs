using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarProject.DBSEF;

using System.Net;
using System.Net.Mail;


namespace CarProject.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            
            //DBSEF.CarAutomationEntities ca = new DBSEF.CarAutomationEntities();
            //if (!ca.Database.Exists())
            //{
            //    ca.Database.CreateIfNotExists();
            //    DBSEF.Person p = new DBSEF.Person();
            //    p.PersonFirtstName = "Administrator";
            //    p.PersonLastName = "Administrator";
            //    p.User = new DBSEF.User { Uname = "Admin", Upass = CarProject.CLS.Usefulls.MD5Passwords("12341qaz!QAZ"), IsActive = true };
            //    DBSEF.UserRole UR = new UserRole();
            //    UR.UserRole1 = "Admin";
            //    ca.UserRoles.Add(UR);
            //    ca.People.Add(p);
            //    ca.SaveChanges();

            //}
            //return RedirectToAction("Index", "Store");
            return View();
        }

        public ActionResult ContectUs()
        {
            ViewBag.success = "";
            var model = new Models.Home.ContactUsMessageModel();
            return View(model);
        }
        [HttpPost]
        public ActionResult ContectUs(Models.Home.ContactUsMessageModel model)
        {
            ViewBag.success = "";
            if (ModelState.IsValid)
            {
                model.Save();
                ViewBag.success = "پیام شما ثبت گردید";
            }
            return View(model);
        }

        public ActionResult AboutUs()
        {
            ViewBag.error = new List<string>();
            return View();
        }

        public ActionResult Search(FormCollection form)
        {
            return View();
        }

        

        public ActionResult EmailTest()
        {
            


            SmtpClient smtp = new SmtpClient("mail.khodroclinic.com");
            smtp.Credentials = new NetworkCredential("noreply@khodroclinic.com", "testPasSS234234@#pas");

            MailMessage msg = new MailMessage();
            msg.From = new MailAddress("noreply@khodroclinic.com");
            msg.To.Add(new MailAddress("jakiobiueche@emeil.ir"));
            msg.Body = "پیام تست تست ستست";

            smtp.Send(msg);
            return View();

        }

    }
}
