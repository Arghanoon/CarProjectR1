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
            var model = Models.User.UserInfo.CreateFromSessionIfExist;
            return View(model);
        }
        [HttpPost]
        public ActionResult PersonalInformation(Models.User.UserInfo user)
        {
            if (ModelState.IsValid)
            {
                var u = Models.User.UserInfo.CreateFromSessionIfExist;
                TryUpdateModel(u);
                u.Update();
                return View(u);
            }
            else
                return View(user);
        }

    }
}
