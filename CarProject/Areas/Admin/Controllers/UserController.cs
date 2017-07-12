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




        DBSEF.CarAutomationEntities DBSObject = new DBSEF.CarAutomationEntities();
        #region PersonCars
        public ActionResult PersonCars(int? id)
        {
            return View(model: id);
        }

        public ActionResult PersonCarsDeleteConfirm(int? id, int? carId)
        {
            var dbs = new DBSEF.CarAutomationEntities();
            var personcar = dbs.PersonCars.FirstOrDefault(pc => pc.PersonCarsId == carId);
            if (personcar == null)
                return RedirectToAction("PersonCars", new { id = id });
            return View(personcar);
        }
        [HttpPost]
        public ActionResult PersonCarsDeleteConfirm(DBSEF.PersonCar model, int? id)
        {
            var dbs = new DBSEF.CarAutomationEntities();
            var personcar = dbs.PersonCars.FirstOrDefault(pc => pc.PersonCarsId == model.PersonCarsId);

            dbs.PersonCarDetails.RemoveRange(dbs.PersonCarDetails.Where(pcd => pcd.PersonCarId == model.PersonCarsId));
            dbs.PersonCars.Remove(personcar);
            dbs.SaveChanges();

            return RedirectToAction("PersonCars", new { id = id });
        }

        public ActionResult PersonCarCurrentMillage(int? id, int? carId)
        {
            var dbs = new DBSEF.CarAutomationEntities();
            var PersonCar = dbs.PersonCars.FirstOrDefault(c => c.PersonCarsId == carId);

            return View(PersonCar);
        }
        [HttpPost]
        public ActionResult PersonCarCurrentMillage(int? id, int? carId, DBSEF.PersonCar model)
        {
            var dbs = new DBSEF.CarAutomationEntities();
            var PersonCar = dbs.PersonCars.FirstOrDefault(c => c.PersonCarsId == carId);


            if (model.CarMilage == null)
                ModelState.AddModelError("CarMilage", "کیلوتر تعیین نشده است");
            else
                PersonCar.CarMilage = model.CarMilage;

            if (ModelState.IsValid)
            {
                dbs.SaveChanges();
                return RedirectToAction("PersonCars", new { id = id });
            }

            return View(PersonCar);
        }

        public ActionResult InsertPersonCar(int? id,int? carId)
        {
            var m = new CarProject.Areas.Users.Models.Dashboard.PersonCarsModel(userid: id.Value, carid: carId);
            return View(m);
        }
        [HttpPost]
        public ActionResult InsertPersonCar(int?id ,CarProject.Areas.Users.Models.Dashboard.PersonCarsModel model)
        {
            if (ModelState.IsValid)
            {
                //update

                if (model.Car.PersonCarsId > 0 && model.Detail.PersonCarDetailId > 0)
                {
                    var mdl = new CarProject.Areas.Users.Models.Dashboard.PersonCarsModel(userid: id.Value, carid: model.Car.PersonCarsId, detaild: model.Detail.PersonCarDetailId);
                    TryUpdateModel(mdl);
                    mdl.Update();
                }
                else
                {
                    model.Car.UserId = id;
                    model.Save();
                }
                ModelState.AddModelError("Success", "اطلاعات خودروی شما با موفقیت ثبت شد");
                return RedirectToAction("PersonCars", new { id = id });
            }
            return View(model);
        }

        [HttpPost]
        public JsonResult RetriveCarByBrands(int? id)
        {
            var xres = DBSObject.Cars.Where(c => c.CarModel.CarBrandId == id).Select(c => new { id = c.CarsId, name = c.CarModel.CarModelName });
            return Json(xres, JsonRequestBehavior.DenyGet);
        }
        #endregion
    }
}
