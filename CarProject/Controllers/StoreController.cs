using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarProject.Controllers
{
    public class StoreController : Controller
    {
        //
        // GET: /Store/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Products(int id)
        {
            return View(id);
        }

        public ActionResult ProductsList(int? id)
        {
            return View(id);
        }
    }
}
