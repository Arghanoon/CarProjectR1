using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

using CarProject.Areas.Admin.Models.Cars;

namespace CarProject.Areas.Admin.Controllers
{
    [CarProject.Areas.Admin.CLS.AuthFilter]
    public class CarsController : Controller
    {
        //
        // GET: /Admin/Cars/

        public ActionResult Index()
        {
            for (int i = 0; i < 1000; i++)
            {
                var n = DateTime.Now.Ticks.ToString();
                var nc = new NewCar();
                nc.CarGeneral.CarsBrandName = "Brand Name " + n;
                nc.CarGeneral.CarsClass = "Car Class " + n;
                nc.CarGeneral.CarsModel = n;
                nc.Save();
            }
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
            if (SaveChange(car))
                return RedirectToAction("Cars");
            return View(car);
        }

        bool SaveChange(Models.Cars.NewCar car)
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
                if (Request.Form.GetValues("DetailedBrakeSystemItem") != null)
                {
                    foreach (var item in Request.Form.GetValues("DetailedBrakeSystemItem"))
                    {
                        car.DetailedBrakeSystem.Add(new DBSEF.DetailedBrakeSystem { DetailedName = item });
                    }
                }

                if (Request.Form.GetValues("advantage") != null)
                {
                    foreach (var item in Request.Form.GetValues("advantage"))
                    {
                        car.Advantages.Add(item);
                    }
                }

                if (Request.Form.GetValues("disadvantage") != null)
                {
                    foreach (var item in Request.Form.GetValues("disadvantage"))
                    {
                        car.Disadvantages.Add(item);
                    }
                }

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
                return true;
            }
            else
                return false;
        }
        bool UpdateChange(Models.Cars.NewCar car)
        {
            var ip = Server.MapPath("~/Publics/CarImages/" + car.CarGeneral.CarsId.ToString());
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
                if (Request.Form.GetValues("DetailedBrakeSystemItem") != null)
                {
                    foreach (var item in Request.Form.GetValues("DetailedBrakeSystemItem"))
                    {
                        car.DetailedBrakeSystem.Add(new DBSEF.DetailedBrakeSystem { DetailedName = item });
                    }
                }

                if (Request.Form.GetValues("advantage") != null)
                {
                    foreach (var item in Request.Form.GetValues("advantage"))
                    {
                        car.Advantages.Add(item);
                    }
                }

                if (Request.Form.GetValues("disadvantage") != null)
                {
                    foreach (var item in Request.Form.GetValues("disadvantage"))
                    {
                        car.Disadvantages.Add(item);
                    }
                }

                car.Save();
                
                return true;
            }
            else
                return false;
        }

        public ActionResult UpdateCar(int id)
        {
            var x = new Models.Cars.NewCar(id);
            Session["updatecar"] = x;
            return View(x);
        }
        [HttpPost]
        public ActionResult UpdateCar(Models.Cars.NewCar car)
        {
            var x = Session["updatecar"] as Models.Cars.NewCar;
            TryUpdateModel(x);
            if (UpdateChange(x))
                return RedirectToAction("Cars");
            return View(car);
        }

        [HttpPost]
        public ActionResult DeleteCar(int id)
        {
            var m = new Models.Cars.NewCar(id);
            m.Delete();
            return RedirectToAction("Cars", "Cars");
        }
        
        public ActionResult Cars(int page = 0)
        {
            ViewBag.pagecont = 40;
            var ca = new DBSEF.CarAutomationEntities();
            var cl = ca.Cars.OrderBy(c => c.CarsId).Skip(((int)ViewBag.pagecont) * page).Take((int)ViewBag.pagecont).ToList();
            return View(cl);
        }

        [HttpPost]
        public ActionResult Cars(FormCollection form)
        {
            if (form.AllKeys.Contains("simpleSearch"))
            {
                var ca = new DBSEF.CarAutomationEntities();
                string car = form["CarSearch"];
                return View(ca.Cars.Where(c => c.CarsId.ToString() == car || c.CarsBrandName.Contains(car) || c.CarsClass.Contains(car) || c.CarsModel.Contains(car)).ToList());
            }
            else
                return View();
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
