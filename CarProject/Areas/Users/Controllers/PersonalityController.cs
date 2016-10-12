using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarProject.Areas.Users.Controllers
{
    [CLS.UsersAuthFilter]
    public class PersonalityController : Controller
    {
        //
        // GET: /Users/Personality/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PersonalInformation()
        {
            var model = CarProject.Models.User.UserInfo.CreateFromSessionIfExist;
            return View(model);
        }
        [HttpPost]
        public ActionResult PersonalInformation(CarProject.Models.User.UserInfo user)
        {
            if (ModelState.IsValid)
            {
                var u = CarProject.Models.User.UserInfo.CreateFromSessionIfExist;
                TryUpdateModel(u);
                u.Update();
                return View(u);
            }
            else
                return View(user);
        }

        public ActionResult UserCars()
        {
            return View();
        }
        public ActionResult UserCars_New()
        {
            return View();
        }

    }
}
