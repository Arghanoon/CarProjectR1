using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

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
            var ip = Server.MapPath("~/Publics/CarTempImages/" + car.CarTempID);
            if (!Directory.Exists(ip))
                Directory.CreateDirectory(ip);

            foreach (var item in Request.Files.GetMultiple("carImage"))
            {
                item.SaveAs(ip + "/" + item.FileName);
            }

            if (ViewData.ModelState.IsValid)
            {
                
            }
            return View(car);
        }
    }
}
