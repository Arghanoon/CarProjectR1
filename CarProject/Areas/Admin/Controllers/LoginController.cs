using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Cryptography;
using System.Text;

namespace CarProject.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Admin/Login/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            if (form.AllKeys.Contains("username") && form.AllKeys.Contains("password"))
            {
                try
                {
                    var dbs = new DBSEF.CarAutomationEntities();


                    var pass = CLS.Usefulls.MD5Passwords(form["password"]);

                    // var pshash = System.Text.Encoding.UTF8.GetString(md5.ComputeHash(System.Text.Encoding.UTF8.GetBytes(form["password"])));

                    var username = form["username"].ToLower().ToString();



                    var usr = dbs.Users.FirstOrDefault(u => u.Uname.ToLower() == username && u.Upass == pass.ToLower() && u.IsActive == true);
                    if (usr != null)
                    {
                        Session["useradmin"] = usr;
                        if (Session["rqpage"] != null)
                            return Redirect(Session["rqpage"].ToString());
                        return RedirectToAction("Index", "Dashboard");
                    }
                    else
                        ViewBag.error = "نام کاربری و یا کلمه عبور صحیح نیست";
                }
                catch
                {
                    ViewBag.error = "خطا در اتصال به دیتابیس";
                    return View();
                }
            }
            return View();
        }


        public ActionResult Signup()
        {
            Models.User.UserInfo u = new Models.User.UserInfo();
            return View(model: u);
        }
        [HttpPost]
        public ActionResult Signup(Models.User.UserInfo user)
        {       
            ViewBag.error = new MvcHtmlString("");
            if (ViewData.ModelState.IsValid)
            {
                user.Save();
                return RedirectToAction("Index", "Login");
            }

            return View(user);
        }
    }
}
