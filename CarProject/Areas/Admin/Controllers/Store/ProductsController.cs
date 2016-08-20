using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using db = CarProject.DBSEF;

namespace CarProject.Areas.Admin.Controllers.Store
{
    public class ProductsController : Controller
    {
        //
        // GET: /Admin/Products/

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult New()
        {
            var model = new Models.Store.Products();
            return View(model);
        }

        [HttpPost]
        public ActionResult New(Models.Store.Products model)
        {
            if (ViewData.ModelState.IsValid)
            {
                model.Save();
                return RedirectToAction("Index");
            }
            return View(model);
        }
        
        public ActionResult CarSearch(string search)
        {
            db.CarAutomationEntities con = new db.CarAutomationEntities();
            var x = con.Cars.Where(c => c.CarsId.ToString() == search || c.CarsBrandName.Contains(search) || c.CarsModel.Contains(search)).Select(c => new { id = c.CarsId, brand = c.CarsBrandName, model = c.CarsModel });
            return Json(x, JsonRequestBehavior.DenyGet);
        }

    }
}
