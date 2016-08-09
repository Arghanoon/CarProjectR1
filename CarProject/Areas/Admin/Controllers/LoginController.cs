using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Cryptography;

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
                var dbs = new DBSEF.CarAutomationEntities();
                var md5 = MD5.Create();
                var pshash = System.Text.Encoding.UTF8.GetString(md5.ComputeHash(System.Text.Encoding.UTF8.GetBytes(form["password"])));
                var usr = dbs.Users.First(u => u.Uname.ToLower() == form["username"].ToLower() && u.Upass == pshash);
                if (usr != null)
                {
                    Session["useradmin"] = usr;
                    return RedirectToAction("Index", "Dashboard");
                }
            }
            return View();
        }

    }
}
