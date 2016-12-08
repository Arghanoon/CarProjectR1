using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarProject.Models.User;

using CarProject.App_extension;

namespace CarProject.Areas.Admin.Controllers
{
    [CarProject.CLS.AuthFilter]
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
            upuser.NoNeedPassword = true;
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

        public ActionResult DeleteUser(int id)
        {
            try
            {
                DBSEF.CarAutomationEntities con = new DBSEF.CarAutomationEntities();
                con.People.Remove(con.People.FirstOrDefault(p => p.UserId == id));
                con.Users.Remove(con.Users.FirstOrDefault(u => u.UserId == id));
                con.SaveChanges();
            }
            catch
            { }
            return RedirectToAction("Users", "User");
        }

        public ActionResult newUsers()
        {
            return View();
        }
        [HttpPost]
        public ActionResult newUsers(FormCollection form)
        {
            try
            {
                if (ViewData.ModelState.IsValid)
                {
                    if (form.AllKeys.Contains("userid") && form["userid"] != "" && form.AllKeys.Contains("UserRole") && form["UserRole"] != "")
                    {
                        var db = new DBSEF.CarAutomationEntities();
                        int id = int.Parse(form["userid"]);
                        var p = db.Users.FirstOrDefault(u => u.UserId == id);

                        int rlid = int.Parse(form["UserRole"]);
                        p.UserRoleId = rlid;

                        db.SaveChanges();
                    }
                }
            }
            catch
            {
            }
            return View();
        }
        

        public ActionResult Users()
        {
            var dbs = new DBSEF.CarAutomationEntities();
            return View(dbs.People.ToList());
        }
        [HttpPost]
        public ActionResult Users(FormCollection form, [Bind(Prefix="searchuser")] string searchUser)
        {
            var dbs = new DBSEF.CarAutomationEntities();
            if (!string.IsNullOrWhiteSpace(searchUser))
                return View(dbs.People.Where(u => u.User.Uname.Contains(searchUser) || u.PersonFirtstName.Contains(searchUser) || u.PersonLastName.Contains(searchUser)).ToList());
            else
                return View();
        }

        public ActionResult UsersView(string searchuser, int? Role, int? searchIn)
        {
            var dbs = new DBSEF.CarAutomationEntities();
            var res = dbs.People.AsQueryable();
            if (!searchuser.IsNullOrWhiteSpace())
            {
                switch (searchIn)
                {
                    case 1:
                        res = res.Where(p => p.User.Uname.Contains(searchuser));
                        break;
                    case 2:
                        res = res.Where(p => p.PersonFirtstName.Contains(searchuser) || p.PersonLastName.Contains(searchuser));
                        break;
                    case 3:
                        res = res.Where(p => p.PersonFirtstName.Contains(searchuser));
                        break;
                    case 4:
                        res = res.Where(p => p.PersonLastName.Contains(searchuser));
                        break;
                    case 5:
                        res = res.Where(p => p.PersonEmail.Contains(searchuser));
                        break;
                    case 6:
                        res = res.Where(p => p.PersonAddressCity.Contains(searchuser));
                        break;
                    
                    case 0:                       
                    default:
                        res = res.Where(p => p.User.Uname.Contains(searchuser) || p.PersonFirtstName.Contains(searchuser) || p.PersonLastName.Contains(searchuser));
                        break;
                }
            }
            if (Role != null && Role > 0)
                res = res.Where(p => p.User.UserRoleId == Role);
            return View(res);
        }
    }
}
