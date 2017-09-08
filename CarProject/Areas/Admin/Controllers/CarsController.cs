using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

using CarProject.App_extension;
using CarProject.CLS.MailsServers;
using Quartz;
using Quartz.Impl;
using Quartz.Impl.Calendar;

namespace CarProject.Areas.Admin.Controllers
{
    [CarProject.CLS.AuthFilter]
    public class CarsController : Controller
    {
        //
        // GET: /Admin/Cars/

        DBSEF.CarAutomationEntities dbs = new DBSEF.CarAutomationEntities();

        public ActionResult Index()
        {
            return View();
        }

        #region manipulate car
        [HttpPost]
        public ActionResult DeleteCar(int? CarsID)
        {
            Models.Cars.CarsModel.DeleteCar(CarsID);
            return RedirectToAction("Index");
        }

        public ActionResult NewCar()
        {
            IScheduler scheduler = StdSchedulerFactory.GetDefaultScheduler();
            scheduler.Start();
            var onsunday = DailyTimeIntervalScheduleBuilder.Create()
                .OnDaysOfTheWeek(new DayOfWeek[] { DayOfWeek.Sunday });

            IJobDetail job = JobBuilder.Create<UserCarChecker>().Build();
            ITrigger trigger = TriggerBuilder.Create()
                .StartAt(DateTimeOffset.Now)
                .WithSchedule(onsunday)
                .Build();

            scheduler.ScheduleJob(job, trigger);
            var model = new Models.Cars.CarsModel();
            return View(model);
        }
        [HttpPost]
        public ActionResult NewCar(Models.Cars.CarsModel model)
        {

            if (ModelState.IsValid)
            {
                model.Save();
                return RedirectToAction("CarImagesGallery", new { id = model.Car.CarsId });
            }

            return View(model);
        }

        public ActionResult CarImagesGallery(int id)
        {
            ViewBag.images = new List<string>();
            string folder = id.ToString().BaseRouts_CarImages();
            DirectoryInfo dic = new DirectoryInfo(Server.MapPath(folder));
            if (dic.Exists)
            {
                var imgs = dic.GetFiles();
                List<string> imgPath = new List<string>();
                foreach (var item in imgs)
                {
                    imgPath.Add(Path.Combine(id.ToString(), item.Name).BaseRouts_CarImages());
                }
                ViewBag.images = imgPath;
            }
            return View();
        }
        [HttpPost, ActionName("CarImagesGallery")]
        public ActionResult CarImagesGalleryPost(int id)
        {
            ViewBag.images = new List<string>();
            
            string folder = id.ToString().BaseRouts_CarImages();
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
                    imgPath.Add(Path.Combine(id.ToString(), item.Name).BaseRouts_CarImages());
                }
                ViewBag.images = imgPath;
            }
            return RedirectToAction("CarImagesGallery", new { id = id });
        }
        public ActionResult CarImageGalleryRemove(int id, string filename)
        {
            var file = new FileInfo(Server.MapPath(filename));
            if (file.Exists)
                file.Delete();

            return RedirectToAction("CarImagesGallery", new { id = id });
        }

        
        public ActionResult UpdateCar(int? id)
        {
            if (id != null && id > 0)
            {
                Models.Cars.CarsModel model = new Models.Cars.CarsModel(id);
                Session["updateCarModel"] = model;
                return View(model);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult UpdateCar(Models.Cars.CarsModel model)
        {
            if (ModelState.IsValid)
            {
                if (Session["updateCarModel"] != null && Session["updateCarModel"] is Models.Cars.CarsModel)
                {
                    var mdl = Session["updateCarModel"] as Models.Cars.CarsModel;
                    TryUpdateModel(mdl);
                    mdl.Update();
                    return RedirectToAction("Index");
                }
                
            }
            return View(model);
        }

        public ActionResult Cars_CostList(int? id)
        {
            return View();
        }
        [HttpPost]
        public ActionResult Cars_CostList(int? id, DBSEF.CarPrice model)
        {
            if (model.Price == null)
                ModelState.AddModelError("Price", "مبلغ کالا تعیین نشده است");
            

            if (ModelState.IsValid)
            {
                var dbs = new DBSEF.CarAutomationEntities();
                model.Date = DateTime.Now;
                dbs.CarPrices.Add(model);
                dbs.SaveChanges();

                return RedirectToAction("Cars_CostList", new { id = id });
            }

            return View(model);
        }


        [HttpGet]
        public ActionResult Brands(int? id)
        {
            ViewBag.error = new List<string>();
            var model = dbs.CarBrands.FirstOrDefault(b => b.CarBrandId == id);
            if (model == null)
                model = new DBSEF.CarBrand();
            return View(model);
        }
        [HttpPost]
        public ActionResult Brands(DBSEF.CarBrand model)
        {
            if (this.ModelState.IsValid)
            {
                var erros = new List<string>();

                if (string.IsNullOrWhiteSpace(model.CarBrandName))
                    erros.Add("نام وارد نشده است");
                else if ((model.CarBrandId == null || model.CarBrandId <= 0) &&  dbs.CarBrands.Count(b => b.CarBrandName.ToLower() == model.CarBrandName.ToLower()) > 0)
                    erros.Add("نام وارد شده تکراری است");
                else if ((model.CarBrandId != null && model.CarBrandId > 0) && dbs.CarBrands.Count(b => b.CarBrandName.ToLower() == model.CarBrandName.ToLower() && b.CarBrandId != model.CarBrandId) > 0)
                    erros.Add("نام وارد شده تکراری است");

                if (Request.Files.Count > 0 && Request.Files.AllKeys.Contains("brandLogo") && Request.Files["brandLogo"].ContentLength > 0)
                {
                    var f = Request.Files["brandLogo"];

                    if (!f.ContentType.ContentTypeIsImage())
                        erros.Add("فایل انتخاب شده تصویر نیست");
                    if (f.ContentLength > (200 * 1024))
                        erros.Add("حجم تصویر بیشتر از 200 کیلوبایت است");
                }

                if (erros.Count <= 0)
                {
                    if (model.CarBrandId != null && model.CarBrandId > 0)
                    {
                        var m = dbs.CarBrands.FirstOrDefault(b => b.CarBrandId == model.CarBrandId);
                        if (m != null)
                            TryUpdateModel(m);
                    }
                    else
                        dbs.CarBrands.Add(model);

                    dbs.SaveChanges();

                    if (Request.Files.Count > 0 && Request.Files.AllKeys.Contains("brandLogo") && Request.Files["brandLogo"].ContentLength > 0)
                    {
                        var f = Request.Files["brandLogo"];
                        var p = Server.MapPath((model.CarBrandId.ToString() + f.FileName.Substring(f.FileName.LastIndexOf("."))).BaseRouts_CarBrands());

                        var oldfiles = System.IO.Directory.GetFiles(Server.MapPath("".BaseRouts_CarBrands()), model.CarBrandId.ToString() + ".*");
                        foreach (var item in oldfiles)
                        {
                            System.IO.File.Delete(item);
                        }

                        f.SaveAs(p);
                    }
                    return RedirectToAction("Brands", new { id = "" });
                }
                else
                {
                    ViewBag.error = erros;
                    return View(model);
                }

            }
            return View(model);
        }


        [HttpPost,OverrideActionFilters]
        public JsonResult CarsSearch(string search)
        {
            if (search == null)
                search = "";
            var x = dbs.Cars.Where(c =>
                c.CarModel.CarBrand.CarBrandName.Contains(search) ||
                c.CarModel.CarModelName.Contains(search)).Select(c => new { id = c.CarsId, brand = c.CarModel.CarBrand.CarBrandName, model = c.CarModel.CarModelName }).ToList();
            return Json(x);
        }
        #endregion

        #region CarComments
        public ActionResult CarComments()
        {
            return View();
        }
        public ActionResult CarCommentShow(int? id)
        {
            var model = dbs.CarComments.FirstOrDefault(cc => cc.CarCommentsId == id);
            if(model == null)
                return RedirectToAction("CarComments");
            return View(model);
        }
        [HttpPost]
        public ActionResult CarCommentShow(int? id,DBSEF.CarComment model)
        {
            var mdl = dbs.CarComments.FirstOrDefault(cc => cc.CarCommentsId == id);
            if (mdl != null)
            {
                TryUpdateModel(mdl);
                mdl.ResponseDateTime = DateTime.Now;
                dbs.SaveChanges();
                return RedirectToAction("CarComments");
            }
            return View(model);
        }

        public ActionResult CarCommentShow_delete(int? id)
        {
            return View();
        }
        [HttpPost]
        public ActionResult CarCommentShow_delete(int? id, FormCollection form)
        {
            var dbs = new DBSEF.CarAutomationEntities();
            var cm = dbs.CarComments.FirstOrDefault(c => c.CarCommentsId == id);
            if (cm != null)
            {
                dbs.CarComments.Remove(cm);
                dbs.SaveChanges();
            }
            return RedirectToAction("CarComments");
        }
        [HttpPost]
        public int CarChangeCanShowState(int? ID)
        {
            int res = 0;
            var dbs = new DBSEF.CarAutomationEntities();
            var ccm = dbs.CarComments.FirstOrDefault(cc => cc.CarCommentsId == ID);
            if (ccm != null)
            {
                ccm.canshow = !ccm.canshow.GetValueOrDefault(false);
                res = (ccm.canshow.Value) ? 1 : 0;
                dbs.SaveChanges();
            }
            return res;
        }
        #endregion

        #region CarUserComments
        public ActionResult CarUserComments()
        {
            return View();
        }

        public ActionResult CarUserComments_ShowAndReply(int? id)
        {
            var comment = dbs.CarUserComments.FirstOrDefault(c => c.CarUserCommentsId == id);
            if (comment == null)
                return RedirectToAction("CarUserComments");

            return View(model: comment);
        }
        [HttpPost]
        public ActionResult CarUserComments_ShowAndReply(int? id, string comment)
        {
            var mdlcomment = dbs.CarUserComments.FirstOrDefault(c => c.CarUserCommentsId == id);
            if (mdlcomment == null)
                return RedirectToAction("CarUserComments");

            if (comment.IsNullOrWhiteSpace())
                ModelState.AddModelError("comment", "پیام نمیتواند خالی باشد");
            
            if (ModelState.IsValid)
            {
                var newitem  = dbs.CarUserComments.Add(new DBSEF.CarUserComment
                {
                    Comment = comment,
                    DateTime = DateTime.Now,
                    CarId = mdlcomment.CarId,
                    RootCarUserCommentsId = id
                });
                dbs.SaveChanges();

                return RedirectToAction("CarUserComments_ShowAndReply", new { id = newitem.CarUserCommentsId });
            }

            return View(model: mdlcomment);
        }
        #endregion

        #region Car_Forum
        public ActionResult Car_Forum(int? id)
        {
            return View();
        }
        public ActionResult Car_Forum_Question(int? id)
        {
            return View();
        }
        [HttpPost]
        public ActionResult Car_Forum_Question(int? id,DBSEF.CarsQnA model)
        {
            if (model.Question.IsNullOrWhiteSpace())
                ViewData.ModelState.AddModelError("Question", "جوابی وارد نشده است");
            if (ModelState.IsValid)
            {
                model.QuestionType = "A";
                dbs.CarsQnAs.Add(model);
                dbs.SaveChanges();
                
                return RedirectToAction("Car_Forum_Question", new { id = id });
            }
            return View(model);
        }
        #endregion
    }
}
