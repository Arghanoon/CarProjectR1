using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarProject.Areas.Admin.Controllers
{
    public class CarsController : Controller
    {
        //
        // GET: /Admin/Cars/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult NewCar()
        {
            var m = new Models.Cars.NewCar();
            return View(m);
        }

        [HttpPost]
        public ActionResult NewCar(Models.Cars.NewCar car)
        {
            return View(car);
        }
    }
}
