using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarProject.Areas.Users.Controllers
{
    public class DashboardController : Controller
    {
        //
        // GET: /Users/Dashboard/

        public ActionResult Index()
        {
            return View();
        }

    }
}
