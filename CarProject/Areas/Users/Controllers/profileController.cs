using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using CarProject.App_extension;
using Newtonsoft.Json;

namespace CarProject.Areas.Users.Controllers
{
    public class profileController : Controller
    {
        //
        // GET: /Users/profile/

        [UsersCLS.UsersAuthFilter]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogoutRequest()
        {
            Session["guestUser"] = null;
            Session.Remove("guestUser");
            return Redirect("/");
        }

        public ActionResult Signup()
        {
            var model = new Models.User.UserInfo();
            return View(model);
        }
        [HttpPost]
        public ActionResult Signup(Models.User.UserInfo model)
        {
            if (ModelState.IsValid)
            {
                model.Person.User.IsActive = true;
                model.Person.User.UserRoleId = 2;
                model.Save();

                return RedirectToAction("Login");
            }
            return View(model);
        }

        public ActionResult Login()
        {
            if (Session["guestUser"] != null && Session["guestUser"] is DBSEF.User)
                return RedirectToAction("Index");
            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection form)
        {
            var error = new List<string>();

            if (form["username"].IsNullOrWhiteSpace())
                error.Add("نام کاربری تعیین نشده است");
            if (form["password"].IsNullOrWhiteSpace())
                error.Add("کمله عبور تعیین نشده است");

            if (error.Count == 0)
            {
                var dbs = new DBSEF.CarAutomationEntities();
                var username = form["username"].ToLower();
                var pass = CLS.Usefulls.MD5Passwords(form["password"]);
                var user = dbs.Users.FirstOrDefault(u => u.Uname.ToLower() == username && u.Upass == pass && u.IsActive == true && u.UserRoleId == 2);
                if (user != null)
                {
                    Session["guestUser"] = user;

                    //cart redirect
                   
                    //end redirect cart


                    if (Session["guestRedirect"] != null && Session["guestRedirect"] is System.Web.Routing.RouteData)
                    {
                        var x = ((System.Web.Routing.RouteData)Session["guestRedirect"]);
                        if (x.DataTokens.Keys.Contains("area"))
                            x.Values.Add("area", x.DataTokens["area"]);
                        else
                            x.Values.Add("area", "");
                        return RedirectToRoute(x.Values);
                    }
                    else
                        return RedirectToAction("Index");
                }
                else
                {
                    error.Add("کاربری با مشخصات وارد شده یافت نشد");
                }
            }
            

            ViewBag.loginerror = error;
            return View();
        }
    }
}
