using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using db = CarProject.DBSEF;

namespace CarProject.Areas.Admin.Controllers.Store
{
    [CLS.AuthFilter]
    public class ProductsController : Controller
    {
        //
        // GET: /Admin/Products/

        public ActionResult Index(FormCollection form)
        {
            if (form.AllKeys.Contains("deleteId"))
            {
                int i = 0;
                int.TryParse(form["deleteId"], out i);

                if (i > 0)
                {
                    var dx = new Models.Store.Products(i);
                    dx.Delete();
                }
            }
            return View();
        }

        public ActionResult ShowDetails(int? id)
        {
            var x = new Models.Store.Products(id);
            if (!x.IsNull())
            {
                return View(x);
            }
            return RedirectToAction("Index");
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

        public ActionResult Update(int? id)
        {
            var xmodel = new Models.Store.Products(id);
            Session["productUpdate"] = xmodel;
            return View(xmodel);
        }

        [HttpPost]
        public ActionResult Update(Models.Store.Products model)
        {
            if (ViewData.ModelState.IsValid)
            {
                var xmodel = Session["productUpdate"] as Models.Store.Products;
                TryUpdateModel(xmodel);
                xmodel.Update();
                return RedirectToAction("Index");
            }
            return View(model);
        }

    }
}
