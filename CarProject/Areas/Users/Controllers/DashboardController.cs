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

    }
}
