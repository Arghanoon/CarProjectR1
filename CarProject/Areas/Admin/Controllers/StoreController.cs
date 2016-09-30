using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarProject.Areas.Admin.Controllers
{
    public class StoreController : Controller
    {
        //
        // GET: /Admin/Store/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CategoryManagment()
        {
            return View();
        }

        public ActionResult Products_Insert()
        {
            return View();
        }
    }
}
