using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarProject.Areas.Users.Controllers
{
    [UsersCLS.UsersAuthFilter]
    public class DashboardController : Controller
    {
        //
        // GET: /Users/Dashboard/

        public ActionResult Index()
        {
            return View();
        }

        #region shoping and baskets
        public ActionResult ShoppingHistory()
        {
            return View();
        }

        public ActionResult BasketDetails(int? id)
        {
            var User = Session["guestUser"] as DBSEF.User;
            var dbs = new CarProject.DBSEF.CarAutomationEntities();
            var model = dbs.Baskets.FirstOrDefault(c => c.BasketId == id && c.UserId == User.UserId);
            if (model == null)
                return RedirectToAction("ShoppingHistory");
            return View(model);
        }
        #endregion


        #region PersonCars
        public ActionResult PersonCars()
        {
            return View();
        }

        public ActionResult PersonCarsDeleteConfirm(int? id)
        {
            var dbs = new DBSEF.CarAutomationEntities();
            var personcar = dbs.PersonCars.FirstOrDefault(pc => pc.PersonCarsId == id);
            if (personcar == null)
                return RedirectToAction("PersonCars");
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

            return RedirectToAction("PersonCars");
        }

        public ActionResult InsertPersonCar(int? id)
        {
            var m = new Models.Dashboard.PersonCarsModel(id);
            return View(m);
        }
        [HttpPost]
        public ActionResult InsertPersonCar(Models.Dashboard.PersonCarsModel model)
        {
            if(ModelState.IsValid)
            {
                //update

                if (model.Car.PersonCarsId != null && model.Car.PersonCarsId > 0 && model.Detail.PersonCarDetailId != null && model.Detail.PersonCarDetailId > 0)
                {
                    var mdl = new Models.Dashboard.PersonCarsModel(model.Car.PersonCarsId, model.Detail.PersonCarDetailId);
                    TryUpdateModel(mdl);
                    mdl.Update();
                }
                else
                {
                    model.Save();
                }
                ModelState.AddModelError("Success", "اطلاعات خودروی شما با موفقیت ثبت شد");
            }
            return View(model);
        }
        #endregion

    }
}
