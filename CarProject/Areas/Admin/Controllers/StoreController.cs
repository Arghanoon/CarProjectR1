using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

using CarProject.App_extension;

namespace CarProject.Areas.Admin.Controllers
{
    //[CarProject.CLS.AuthFilter]
    public class StoreController : Controller
    {
        //
        // GET: /Admin/Store/


        DBSEF.CarAutomationEntities dbsObject = new DBSEF.CarAutomationEntities();
        
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
            var res = dbs.Products.Where(c => c.ProductName.Contains(search)).Select(c => new { id = c.ProductId, num = c.PartNumber, name = c.ProductName, cat = c.Category.CategoryName }).ToList();
            return Json(res, JsonRequestBehavior.DenyGet);
        }
        [HttpPost]
        public ActionResult JsonProductsSearch2(string search, List<int> notinId)
        {
            var dbs = new DBSEF.CarAutomationEntities();
            if (notinId == null) { notinId = new List<int>(); }

            var res = dbs.Products.Where(c => c.ProductName.Contains(search) && !notinId.Contains(c.ProductId)).Select(c => new { id = c.ProductId, num = c.PartNumber.ToString(), name = c.ProductName, cat = c.Category.CategoryName }).ToList();
            return Json(res, JsonRequestBehavior.DenyGet);
        }

        public ActionResult ProductComments()
        {
            return View();
        }
        public ActionResult ProductCommentShow(int? id)
        {
            return View();
        }
        public ActionResult ProductCommentShow_delete(int? id)
        {
            return View();
        }
        [HttpPost]
        public ActionResult ProductCommentShow_delete(int? id,FormCollection form)
        {
            var dbs = new DBSEF.CarAutomationEntities();
            var cm = dbs.ProductComments.FirstOrDefault(c => c.ProductCommentId == id);
            if (cm != null)
            {
                dbs.ProductComments.Remove(cm);
                dbs.SaveChanges();
            }
            return RedirectToAction("ProductComments");
        }

        [HttpPost]
        public int ProductChangeCanShowState(int? ID)
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
        
        #region Product Discounts
        public ActionResult productDiscounts()
        {
            return View();
        }

        public ActionResult ProductDiscount_new()
        {
            var model = new Models.Store.ProductDiscountModel();
            return View(model);
        }
        [HttpPost]
        public ActionResult ProductDiscount_new(Models.Store.ProductDiscountModel model)
        {
            var xitems = Request.Form.GetValues("ProuductsId");
            if (xitems != null)
            {
                foreach (var item in xitems)
                {
                    int x = 0;
                    int.TryParse(item, out x);
                    if (x > 0)
                        model.Products.Add(x);
                }
            }

            if (model.Products.Count == 0)
                ModelState.AddModelError("Products", "محصولات شامل تخفیف تعیین نشده اند");

            if (ModelState.IsValid)
            {
                model.Save();
                return RedirectToAction("productDiscounts");
            }

            return View(model);
        }

        public ActionResult ProductDiscount_DeleteConfirm(int? id)
        {
            if (id == null)
                return RedirectToAction("productDiscounts");

            var model = new Models.Store.ProductDiscountModel(id);
            return View(model);
        }
        [HttpPost,ActionName("ProductDiscount_DeleteConfirm")]
        public ActionResult ProductDiscount_DeleteConfirm_Confirmed(int? id)
        {
            dbsObject.ProductDiscounts.RemoveRange(dbsObject.ProductDiscounts.Where(pdis => pdis.DiscountId == id));
            dbsObject.Discounts.RemoveRange(dbsObject.Discounts.Where(dis => dis.DiscountId == id));
            dbsObject.SaveChanges();
            return RedirectToAction("productDiscounts");
        }

        public ActionResult ProductDiscount_update(int? id)
        {
            if (id == null)
                return RedirectToAction("productDiscounts");
            var model = new Models.Store.ProductDiscountModel(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult ProductDiscount_update(int? id,Models.Store.ProductDiscountModel model)
        {

            if (id == null)
                return RedirectToAction("productDiscounts");
            var md2 = new Models.Store.ProductDiscountModel(id);
            TryUpdateModel(md2);
            md2.Products.Clear();

            var xitems = Request.Form.GetValues("ProuductsId");
            if (xitems != null)
            {
                foreach (var item in xitems)
                {
                    int x = 0;
                    int.TryParse(item, out x);
                    if (x > 0)
                        md2.Products.Add(x);
                }
            }

            if (md2.Products.Count == 0)
                ModelState.AddModelError("Products", "محصولات شامل تخفیف تعیین نشده اند");

            if (ModelState.IsValid)
            {
                md2.Update();
                return RedirectToAction("productDiscounts");
            }

            return View(md2);
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

        #region Product_Forum
        public ActionResult Product_Forum(int? id)
        {
            return View();
        }
        public ActionResult Product_Forum_Question(int? id)
        {
            return View();
        }
        [HttpPost]
        public ActionResult Product_Forum_Question(int? id, DBSEF.ProductQnA model)
        {
            if (model.Question.IsNullOrWhiteSpace())
                ViewData.ModelState.AddModelError("Question", "جوابی وارد نشده است");
            if (ModelState.IsValid)
            {
                model.QuestionType = "A";
                dbsObject.ProductQnAs.Add(model);
                dbsObject.SaveChanges();

                return RedirectToAction("Product_Forum_Question", new { id = id });
            }
            return View(model);
        }
        #endregion

        #region DeliveryType
        public ActionResult DeliveryTypes()
        {
            return View();
        }
        public ActionResult DeliveryTypes_New()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DeliveryTypes_New(DBSEF.ProductsOrServicesDeliveryType model)
        {
            var dbs = new DBSEF.CarAutomationEntities();
            if (model.Name.IsNullOrWhiteSpace())
                ModelState.AddModelError("Name", "نامی برای پلن تعیین نشده است");
            else if(dbs.ProductsOrServicesDeliveryTypes.Count(c => c.Name == model.Name) > 0)
                ModelState.AddModelError("Name", "نامی وارد شده برای پلن تکراری است");
            if (model.Hour == null)
                ModelState.AddModelError("Hour", "زمان (ساعت) تحویل /انجام تعیین نشده است");
            if (model.Price.IsNullOrWhiteSpace())
                ModelState.AddModelError("Price", "هزینه پلن تعیین نشده است");
            else if(!model.Price.IsNumber())
                ModelState.AddModelError("Price", "مقدار وارد شده صحیح نیست");

            if (ModelState.IsValid)
            {
                dbs.ProductsOrServicesDeliveryTypes.Add(model);
                dbs.SaveChanges();

                return RedirectToAction("DeliveryTypes");
            }
            return View(model);
        }

        public ActionResult DeliveryTypes_Update(int? id)
        {
            var dbs = new DBSEF.CarAutomationEntities();
            var model = dbs.ProductsOrServicesDeliveryTypes.FirstOrDefault(c => c.DeliverTypeID == id);
            if (model == null)
                return RedirectToAction("DeliveryTypes");

            return View(model);
        }
        [HttpPost]
        public ActionResult DeliveryTypes_Update(int? id, DBSEF.ProductsOrServicesDeliveryType model)
        {
            var dbs = new DBSEF.CarAutomationEntities();
            if (model.Name.IsNullOrWhiteSpace())
                ModelState.AddModelError("Name", "نامی برای پلن تعیین نشده است");
            else if (dbs.ProductsOrServicesDeliveryTypes.Count(c => c.Name == model.Name) > 0)
                ModelState.AddModelError("Name", "نامی وارد شده برای پلن تکراری است");
            if (model.Hour == null)
                ModelState.AddModelError("Hour", "زمان (ساعت) تحویل /انجام تعیین نشده است");
            if (model.Price.IsNullOrWhiteSpace())
                ModelState.AddModelError("Price", "هزینه پلن تعیین نشده است");
            else if (!model.Price.IsNumber())
                ModelState.AddModelError("Price", "مقدار وارد شده صحیح نیست");

            if (ModelState.IsValid)
            {
                var mdl = dbs.ProductsOrServicesDeliveryTypes.FirstOrDefault(c => c.DeliverTypeID == id);
                TryUpdateModel(mdl);
                dbs.SaveChanges();

                return RedirectToAction("DeliveryTypes");
            }

            return View(model);
        }
        #endregion

        #region Cart
        public ActionResult Baskets()
        {
            return View();
        }
        public ActionResult BasketsDetails(int? id)
        {
            var basket = dbsObject.Baskets.FirstOrDefault(b => b.BasketId == id);
            if (basket == null)
                return RedirectToAction("Baskets");

            return View(basket);
        }
        #endregion

        #region Inventory
        public ActionResult ProductsInventory()
        {
            return View();
        }

        public ActionResult SelectProductForIncreaseEntity()
        {
            return View();
        }

        public ActionResult SelectedProductIncreaseEntity(int? id)
        {
            var product = dbsObject.Products.FirstOrDefault(c => c.ProductId == id);
            if (product == null)
                return RedirectToAction("SelectProductForIncreaseEntity");

            return View(product);
        }
        [HttpPost]
        public ActionResult SelectedProductIncreaseEntity(int? id, FormCollection form)
        {
            var product = dbsObject.Products.FirstOrDefault(c => c.ProductId == id);
            if (product == null)
                return RedirectToAction("SelectProductForIncreaseEntity");

            if (!form.AllKeys.Contains("IncreaseCount") && form["IncreaseCount"].IsNullOrWhiteSpace())
                ModelState.AddModelError("IncreaseCount", "موجودی جدید وارد نشده است");
            else if (!form["IncreaseCount"].IsNumber())
                ModelState.AddModelError("IncreaseCount", "مقدار وارد شده صحیح نیست");

            if (ModelState.IsValid)
            {
                int newcount = 0;
                int.TryParse(form["IncreaseCount"], out newcount);
                var pso = dbsObject.ProductStores.FirstOrDefault(ps => ps.ProductId == id);
                if (pso == null)
                {
                    pso = new DBSEF.ProductStore();
                    pso.ProductId = id;
                    pso.ProductEntity = newcount;
                    dbsObject.ProductStores.Add(pso);
                }
                else
                {
                    pso.ProductEntity = newcount + pso.ProductEntity.GetValueOrDefault(0);
                }
                dbsObject.SaveChanges();

                return RedirectToAction("SelectProductForIncreaseEntity");
            }

            return View(product);
        }
        #endregion
    }
}
