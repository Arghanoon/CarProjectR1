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


        public ActionResult UpdateUser(int id)
        {
            var upuser = new UserInfo(id);
            upuser.IsForUpdate = true;
            Session["userUpdate"] = upuser;
            return View(upuser);
        }
        
        [HttpPost]
        public ActionResult UpdateUser(UserInfo user)
        {
            if (ViewData.ModelState.IsValid)
            {
                var ou = Session["userUpdate"] as UserInfo;
                TryUpdateModel(ou);
                ou.Update();
                return RedirectToAction("Users", "User");
            }
            return View(user);
        }

        public ActionResult UserChangeState(int id)
        {
            try
            {
                DBSEF.CarAutomationEntities con = new DBSEF.CarAutomationEntities();
                var user = con.Users.FirstOrDefault(u => u.UserId == id);
                if (user != null)
                {
                    user.IsActive = !user.IsActive.GetValueOrDefault();
                    con.SaveChanges();
                }
            }
            catch { }
            return RedirectToAction("Users", "User");
        }
        

        public ActionResult Users()
        {
            var dbs = new DBSEF.CarAutomationEntities();
            return View(dbs.People.ToList());
        }
    }
}
