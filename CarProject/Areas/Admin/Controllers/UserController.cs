using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarProject.Areas.Admin.Models.User;

namespace CarProject.Areas.Admin.Controllers
{
    [CarProject.Areas.Admin.CLS.AuthFilter]
    public class UserController : Controller
    {
        public ActionResult Profile()
        {
            var usr = Session["useradmin"] as DBSEF.User;
            UserInfo ui = new UserInfo(usr.UserId);

            return View(ui);
        }

        public ActionResult NewUser()
        {
            return View(model: new UserInfo());
        }

        [HttpPost]
        public ActionResult NewUser(UserInfo user)
        {
            if (ViewData.ModelState.IsValid)
            {
                user.Save();
                return RedirectToAction("Users", "User");
            }
            else
                return View(model: new UserInfo());
        }

        public ActionResult Users()
        {
            var dbs = new DBSEF.CarAutomationEntities();
            return View(dbs.People.ToList());
        }
    }
}
