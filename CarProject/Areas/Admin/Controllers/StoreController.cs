using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using CarProject.App_extension;

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

        #region CategoryManagment
        public ActionResult CategoryManagment(int? id)
        {
            var model = new Models.Store.CategoryModel(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult CategoryManagment(Models.Store.CategoryModel model)
        {
            if (ModelState.IsValid)
            {
                model.Save();
                return RedirectToAction("CategoryManagment", new { id = model.Category.ParentCategoryId });
            }
            return View(model);
        }

        public ActionResult CategoryManagment_Update(int? id)
        {
            var model = new Models.Store.CategoryModel(id);
            TempData["updateStoreCategoryModel"] = model;
            return View(model);
        }
        [HttpPost]
        public ActionResult CategoryManagment_Update(Models.Store.CategoryModel model)
        {
            if (ModelState.IsValid)
            {
                var m = TempData["updateStoreCategoryModel"] as Models.Store.CategoryModel;
                TryUpdateModel(m);
                m.DBS.SaveChanges();

                return RedirectToAction("CategoryManagment");
            }
            return View(model);
        }
        #endregion

        #region Products
        public ActionResult Products()
        {
            return View();
        }

        public ActionResult Products_Insert()
        {
            var model = new Models.Store.ProductsModel();
            return View(model: model);
        }
        [HttpPost]
        public ActionResult Products_Insert(Models.Store.ProductsModel model)
        {
            if (ModelState.IsValid)
            {
                model.Save();
                return RedirectToAction("Products_Review", new { id = model.Product.ProductId });
            }
            return View(model: model);
        }

        public ActionResult Products_Review(int? id)
        {
            var model = new Models.Store.ProductsModel(id);
            TempData["ProductReviewInsertOrUpdate"] = model;
            return View(model);
        }
        [HttpPost]
        public ActionResult Products_Review(Models.Store.ProductsModel model)
        {
            var m = TempData["ProductReviewInsertOrUpdate"] as Models.Store.ProductsModel;
            m.HtmlReview = model.HtmlReview;
            m.Save_review();
            return RedirectToAction("Products");
        }

        public ActionResult Products_Update(int? id)
        {
            var model = new Models.Store.ProductsModel(id);

            TempData["Products_Review_ChangesTemp"] = model;
            return View(model);
        } 

        #endregion
    }
}
