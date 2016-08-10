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
                    MD5 md5 = System.Security.Cryptography.MD5.Create();
                    byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(form["password"]);
                    byte[] hash = md5.ComputeHash(inputBytes);
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < hash.Length; i++)
                    {

                        sb.Append(hash[i].ToString("X2"));

                    }

                    var pass = sb.ToString();

                    // var pshash = System.Text.Encoding.UTF8.GetString(md5.ComputeHash(System.Text.Encoding.UTF8.GetBytes(form["password"])));

                    var username = form["username"].ToLower().ToString();



                    var usr = dbs.Users.First(u => u.Uname.ToLower() == username && u.Upass == pass.ToLower());
                    if (usr != null)
                    {
                        Session["useradmin"] = usr;
                        return RedirectToAction("Index", "Dashboard");
                    }
                }
                catch
                {
                    ViewBag.error = "نام کاربری و یا کلمه عبور صحیح نیست";
                    return View();
                }
            }
            return View();
        }

    }
}
