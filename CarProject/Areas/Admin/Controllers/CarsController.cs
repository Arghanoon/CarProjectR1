using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace CarProject.Areas.Admin.Controllers
{
    [CarProject.Areas.Admin.CLS.AuthFilter]
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

            if (Request.Form.GetValues("carImageremove") != null)
            {
                foreach (var item in Request.Form.GetValues("carImageremove"))
                {
                    if (System.IO.File.Exists(ip + "/" + item))
                        System.IO.File.Delete(ip + "/" + item);
                }
            }

            if (ViewData.ModelState.IsValid)
            {
                car.Save();
                var mp = Server.MapPath("~/Publics/CarImages/" + car.CarGeneral.CarsId.ToString());
                if (!Directory.Exists(mp))
                    Directory.CreateDirectory(mp);
                DirectoryInfo dic = new DirectoryInfo(ip);
                foreach (var item in dic.GetFiles())
                {
                    item.MoveTo(mp + "/" + item.Name);
                }

                dic.Delete(true);
            }
            return View(car);
        }


        public ActionResult Cars()
        {
            var ca = new DBSEF.CarAutomationEntities1();
            return View(ca.Cars.ToList());
        }



        public void ClearImagesTemp()
        {
            DirectoryInfo tmpdic = new DirectoryInfo(Server.MapPath("~/Publics/CarTempImages/"));
            foreach (var item in tmpdic.GetDirectories())
            {
                if (item.CreationTime < DateTime.Now.AddDays(-1))
                    item.Delete(true);
            }
        }
    }
}
