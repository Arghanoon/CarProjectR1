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

        public ActionResult CategoryManagment(int? id)
        {
            var model = new Models.Store.CategoryModel(id);
            return View(model);
        }
        public ActionResult CategoryManagment(Models.Store.CategoryModel model)
        {
            if (ModelState.IsValid)
            {
                model.Save();
                return RedirectToAction("CategoryManagment", new { id = model.Category.ParentCategoryId });
            }
            return View(model);
        }

        public ActionResult Products_Insert()
        {
            return View();
        }
    }
}
