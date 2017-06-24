using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Cryptography;
using System.Text;
using CarProject.CLS;


namespace CarProject.Controllers
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


                    var pass = Usefulls.MD5Passwords(form["password"]);

                    // var pshash = System.Text.Encoding.UTF8.GetString(md5.ComputeHash(System.Text.Encoding.UTF8.GetBytes(form["password"])));

                    var username = form["username"].ToLower().ToString();

                    var usr1 = dbs.People.FirstOrDefault(u => u.PersonEmail.ToLower() == username);
                    var usr2 = dbs.People.FirstOrDefault(u => u.PersonMobile == username);
                    int? usr1Pass = 0;
                    int? usr2Pass = 0;
                    if (usr1 != null)
                    {
                        usr1Pass = usr1.UserId;
                    }
                    if (usr2 != null)
                    {
                        usr2Pass = usr2.UserId;
                    }




                    var usr = dbs.Users.FirstOrDefault(u => u.Uname.ToLower() == username && u.Upass == pass.ToLower() && u.IsActive == true);
                    if (usr == null)
                    {
                        if (usr1Pass != null)
                        {
                            usr = dbs.Users.FirstOrDefault(
                                u => u.UserId == usr1Pass && u.Upass == pass.ToLower() && u.IsActive == true);
                        }
                        else if (usr2Pass != null)
                        {
                            usr = dbs.Users.FirstOrDefault(
                                u => u.UserId == usr2Pass && u.Upass == pass.ToLower() && u.IsActive == true);

                        }
                    }
                    if (usr != null)
                    {
                        Session["user"] = usr;

                        if (usr.UserRoleId == 1)
                            return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
                        else
                            return RedirectToAction("Index", "Dashboard", new { area = "Users" });

                    }
                    else
                        ViewBag.error = "نام کاربری و یا کلمه عبور صحیح نیست";
                }
                catch (Exception ex)
                {
                    //ViewBag.error = "خطا در اتصال به دیتابیس";
                    ViewBag.error = "<br />" + ex.Message;
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
