using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

using CarProject.App_extension;

namespace CarProject.Areas.Admin.Controllers
{
    [CarProject.CLS.AuthFilter]
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
            return RedirectToAction("Products_Gallery", new { id = id });
        }
        public ActionResult Products_GalleryRemove(int id, string filename)
        {
            var file = new FileInfo(Server.MapPath(filename));
            if (file.Exists)
                file.Delete();

            return RedirectToAction("Products_Gallery", new { id = id });
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

        public ActionResult Products_CostList(int? id)
        {
            return View();
        }
        [HttpPost]
        public ActionResult Products_CostList(int? id,DBSEF.ProductPrice model)
        {
            if (model.ProductPrice1 == null)
                ModelState.AddModelError("ProductPrice1", "مبلغ کالا تعیین نشده است");
            if (model.InstallPrice == null)
                ModelState.AddModelError("InstallPrice", "هزینه نصب کالا تعیین نشده است");

            if (ModelState.IsValid)
            {
                var dbs = new DBSEF.CarAutomationEntities();
                model.Date = DateTime.Now;
                dbs.ProductPrices.Add(model);
                dbs.SaveChanges();

                return RedirectToAction("Products_CostList", new { id = id });
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

        public ActionResult ProductComments()
        {
            return View();
        }
        [HttpPost]
        public int ChangeCanShowState(int? ID)
        {
            int res = 0;
            var dbs = new DBSEF.CarAutomationEntities();
            var pcm = dbs.ProductComments.FirstOrDefault(pc => pc.ProductCommentId == ID);
            if (pcm != null)
            {
                pcm.canshow = !pcm.canshow.GetValueOrDefault(false);
                res = (pcm.canshow.Value) ? 1 : 0;
                dbs.SaveChanges();
            }
            return res;
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
                model.Save();
                
                return RedirectToAction("Services");
            }
            return View(model);
        }

        public ActionResult Services_Update(int? id)
        {
            var model = new Models.Store.ServicesModel(id);
            TempData["serviceUpdateTempdDataStore"] = model;
            return View(model);
        }
        [HttpPost]
        public ActionResult Services_Update(Models.Store.ServicesModel model)
        {
            if (ModelState.IsValid)
            {
                var m = TempData["serviceUpdateTempdDataStore"] as Models.Store.ServicesModel;
                TryUpdateModel(m);
                m.Update();

                return RedirectToAction("Services");
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult JsonServicesSearch(string search)
        {
            var dbs = new DBSEF.CarAutomationEntities();
            var res = dbs.AutoServices.Where(s => s.AutoServiceName.Contains(search)).Select(c => new { id = c.AutoServiceId, name = c.AutoServiceName, price = c.Price }).ToList();
            return Json(res, JsonRequestBehavior.DenyGet);
        }

        public ActionResult Services_Gallery(int id)
        {
            ViewBag.images = new List<string>();
            string folder = id.ToString().BaseRouts_ServicesImages();
            DirectoryInfo dic = new DirectoryInfo(Server.MapPath(folder));
            if (dic.Exists)
            {
                var imgs = dic.GetFiles();
                List<string> imgPath = new List<string>();
                foreach (var item in imgs)
                {
                    imgPath.Add(Path.Combine(id.ToString(), item.Name).BaseRouts_ServicesImages());
                }
                ViewBag.images = imgPath;
            }
            return View();
        }
        [HttpPost, ActionName("Services_Gallery")]
        public ActionResult Services_GalleryPost(int id)
        {
            ViewBag.images = new List<string>();

            string folder = id.ToString().BaseRouts_ServicesImages();
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
                    imgPath.Add(Path.Combine(id.ToString(), item.Name).BaseRouts_ServicesImages());
                }
                ViewBag.images = imgPath;
            }
            return RedirectToAction("Services_Gallery", new { id = id });
        }
        public ActionResult Services_GalleryRemove(int id, string filename)
        {
            var file = new FileInfo(Server.MapPath(filename));
            if (file.Exists)
                file.Delete();

            return RedirectToAction("Services_Gallery", new { id = id });
        }

        /* Packs */

        public ActionResult ServicePacks()
        {
            return View();
        }

        public ActionResult ServicePacks_New()
        {
            var model = new Models.Store.ServicePacksModel();
            return View(model);
        }
        [HttpPost]
        public ActionResult ServicePacks_New(Models.Store.ServicePacksModel model)
        {
            if (ModelState.IsValid)
            {
                model.Save();
                return RedirectToAction("ServicePacks");
            }
            return View(model);
        }

        public ActionResult ServicePacks_Update(int? id)
        {
            var model = new Models.Store.ServicePacksModel(id);
            TempData["updateServicePacksSelected"] = model;
            return View(model);
        }
        [HttpPost]
        public ActionResult ServicePacks_Update(Models.Store.ServicePacksModel model)
        {
            if (ModelState.IsValid)
            {
                var m = TempData["updateServicePacksSelected"] as Models.Store.ServicePacksModel;
                TryUpdateModel(m);
                m.Update();

                return RedirectToAction("ServicePacks");
            }
            return View(model);
        }


        public ActionResult ServicePacks_Gallery(int id)
        {
            ViewBag.images = new List<string>();
            string folder = id.ToString().BaseRouts_ServicePacksImages();
            DirectoryInfo dic = new DirectoryInfo(Server.MapPath(folder));
            if (dic.Exists)
            {
                var imgs = dic.GetFiles();
                List<string> imgPath = new List<string>();
                foreach (var item in imgs)
                {
                    imgPath.Add(Path.Combine(id.ToString(), item.Name).BaseRouts_ServicePacksImages());
                }
                ViewBag.images = imgPath;
            }
            return View();
        }
        [HttpPost, ActionName("ServicePacks_Gallery")]
        public ActionResult ServicePacks_GalleryPost(int id)
        {
            ViewBag.images = new List<string>();

            string folder = id.ToString().BaseRouts_ServicePacksImages();
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
                    imgPath.Add(Path.Combine(id.ToString(), item.Name).BaseRouts_ServicePacksImages());
                }
                ViewBag.images = imgPath;
            }
            return RedirectToAction("ServicePacks_Gallery", new { id = id });
        }
        public ActionResult ServicePacks_GalleryRemove(int id, string filename)
        {
            var file = new FileInfo(Server.MapPath(filename));
            if (file.Exists)
                file.Delete();

            return RedirectToAction("ServicePacks_Gallery", new { id = id });
        }
        #endregion
    }
}
