using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

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
            return RedirectToAction("Products_Gallery", new { id = m.Product.ProductId });
        }



        public ActionResult Products_Gallery(int id)
        {
            ViewBag.images = new List<string>();
            string folder = id.ToString().BaseRouts_ProductImages();
            DirectoryInfo dic = new DirectoryInfo(Server.MapPath(folder));
            if (dic.Exists)
            {
                var imgs = dic.GetFiles();
                List<string> imgPath = new List<string>();
                foreach (var item in imgs)
                {
                    imgPath.Add(Path.Combine(id.ToString(), item.Name).BaseRouts_ProductImages());
                }
                ViewBag.images = imgPath;
            }
            return View();
        }
        [HttpPost, ActionName("Products_Gallery")]
        public ActionResult Products_GalleryPost(int id)
        {
            ViewBag.images = new List<string>();

            string folder = id.ToString().BaseRouts_ProductImages();
            DirectoryInfo dic = new DirectoryInfo(Server.MapPath(folder));

            if (ModelState.IsValid)
            {
                if (!dic.Exists)
                    dic.Create();
                long namitem = DateTime.Now.Ticks;
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    if (Request.Files[i].ContentType.ContentTypeIsImage())
                    {
                        Request.Files[i].SaveAs(Server.MapPath(Path.Combine(folder, string.Format("{0:000000}{1}", namitem++, Request.Files[i].FileName.Substring(Request.Files[i].FileName.LastIndexOf('.'))))));
                    }
                }
            }

            if (dic.Exists)
            {
                var imgs = dic.GetFiles();
                List<string> imgPath = new List<string>();
                foreach (var item in imgs)
                {
                    imgPath.Add(Path.Combine(id.ToString(), item.Name).BaseRouts_ProductImages());
                }
                ViewBag.images = imgPath;
            }
            return View();
        }
        public ActionResult Products_GalleryRemove(int id, string filename)
        {
            var file = new FileInfo(Server.MapPath(filename));
            if (file.Exists)
                file.Delete();

            return RedirectToAction("CarImagesGallery", new { id = id });
        }


        public ActionResult Products_Update(int? id)
        {
            var model = new Models.Store.ProductsModel(id);

            TempData["Products_Review_ChangesTemp"] = model;
            return View(model);
        }
        [HttpPost]
        public ActionResult Products_Update(Models.Store.ProductsModel model)
        {
            if (ModelState.IsValid)
            {
                var m = TempData["Products_Review_ChangesTemp"] as Models.Store.ProductsModel;
                TryUpdateModel(m);
                m.Update();
                return RedirectToAction("Products");
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult JsonProductsSearch(string search)
        {
            var dbs = new DBSEF.CarAutomationEntities();
            var res = dbs.Products.Where(c => c.ProductName.Contains(search)).Select(c => new { id = c.ProductId, name = c.ProductName, cat = c.Category.CategoryName }).ToList();
            return Json(res, JsonRequestBehavior.DenyGet);
        }
        #endregion

        #region Services and servicePacks
        public ActionResult Services()
        {
            return View();
        }

        public ActionResult Services_New()
        {
            var model = new Models.Store.ServicesModel();
            return View(model);
        }
        [HttpPost]
        public ActionResult Services_New(Models.Store.ServicesModel model)
        {
            if (ModelState.IsValid)
            {
                
                //return RedirectToAction("Services");
            }
            return View(model);
        }
        #endregion
    }
}
