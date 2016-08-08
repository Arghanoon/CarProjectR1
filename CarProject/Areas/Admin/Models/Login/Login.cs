using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using CarProject.DBSEF;

namespace CarProject.Areas.Admin.Models.Login
{
    public class Login : Controller
    {
        public string UserId { get; set; }
        public User UserGeneral { get; set; }
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        public string GetUserPassword(string loginName)
        {
            using (DBSEF.CarAutomationEntities1 db = new CarAutomationEntities1())
            {
                var user = db.Users.Where(o => o.Uname.ToLower().Equals(loginName));
                if (user.Any())
                {
                    return user.FirstOrDefault().Upass;
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        //[HttpPost]
        //public ActionResult LogInpage(DBSEF.User ULV, string returnUrl)
        //{
        //    if (ModelState.IsValid)
        //    {

        //        string password = GetUserPassword(ULV.Uname);

        //        if (string.IsNullOrEmpty(password))
        //            ModelState.AddModelError("", "The user login or password provided is incorrect.");
        //        else
        //        {
        //            if (ULV.Upass.Equals(password))
        //            {
        //                FormsAuthentication.SetAuthCookie(ULV.Uname, false);
        //                return RedirectToAction("Welcome", "Home");
        //            }
        //            else
        //            {
        //                ModelState.AddModelError("", "The password provided is incorrect.");
        //            }
        //        }
        //    }
        //}


    }
}