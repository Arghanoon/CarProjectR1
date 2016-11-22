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

        public ActionResult ShoppingHistory()
        {
            return View();
        }

        public ActionResult BasketDetails(int? id)
        {
            if (id == null)
                return RedirectToAction("ShoppingHistory");

            var User = Session["guestUser"] as DBSEF.User;
            

            return View();
        }



        #region PersonCars
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
