using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using CarProject.CLS;
using CarProject.CLS.Searchs;
using CarProject.Models;
using db = CarProject.DBSEF;
using CarProject.App_extension;

namespace CarProject.Controllers
{
    public class CarsController : Controller
    {
        private const int PageSize = 20;
        //public ActionResult Index(int page = 1,string sort = "", UserSearchViewModel search)
        //
        // GET: /Cars/

        public ActionResult Index()
        {
            return View();
        }

        #region Car SinglePage
        public ActionResult Car(int id)
        {
            var model = new Areas.Admin.Models.Cars.CarsModel(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Car(int id, FormCollection form)
        {
            ViewBag.error = new Dictionary<string, string>();
            if (form.AllKeys.Contains("SendACommentRequest"))
            {
                if (form["fullname"] == "")
                    ViewBag.error["fullname"] = "نام و نام خانوادگی تعیین نشده است";
                if (form["email"] == "")
                    ViewBag.error["email"] = "ایمیل وارد نشده است";
                else if (!form["email"].String_IsEmail())
                    ViewBag.error["email"] = "ایمیل وارد شده صحیح نیست";

                if (form["comment"] == "")
                    ViewBag.error["comment"] = "پیام وارد نشده است";

                if (form["captcha"] == "")
                    ViewBag.error["captcha"] = "کد امنیتی وارد نشده است";
                else if (!DefaultController.ValidationCaptcha(form["captcha"]))
                    ViewBag.error["captcha"] = "کد امنیتی وارد شده صحیح نیست";

                if (((Dictionary<string, string>)ViewBag.error).Count == 0)
                {
                    var dbs = new DBSEF.CarAutomationEntities();
                    dbs.CarComments.Add(new DBSEF.CarComment { Comment = form["comment"], Email = form["email"], Fullname = form["fullname"], CarsId = id, datetime = DateTime.Now });
                    dbs.SaveChanges();
                    ViewBag.error["success"] = "پیام شما با موفقیت ثبت شد و پس از تایید به نمایش در خواهد آمد";
                }
            }

            var model = new Areas.Admin.Models.Cars.CarsModel(id);
            return View(model);
        }
        [HttpPost]
        public int Car_MakePopular(int id)
        {
            int res = 0;
            var dbs = new DBSEF.CarAutomationEntities();
            if (dbs.CarsToViews.Count(c => c.CarsId == id) > 0)
            {
                var crtvw = dbs.CarsToViews.FirstOrDefault(c => c.CarsId == id);
                crtvw.Favorite = (crtvw.Favorite == null) ? 1 : crtvw.Favorite += 1;
                res = crtvw.Favorite.Value;
            }
            else
            {
                dbs.CarsToViews.Add(new CarProject.DBSEF.CarsToView { CarsId = id, Favorite = 1 });
                res = 1;
            }

            dbs.SaveChanges();
            return res;
        }
        #endregion

        #region Forum
        public ActionResult CarForum(int? id)
        {
            return View();
        }
        [HttpPost]
        public ActionResult CarForum(int? id,FormCollection form)
        {
            if (form.AllKeys.Contains("newQuestion") && !string.IsNullOrWhiteSpace(form["newQuestion"]))
            {
                var dbs = new DBSEF.CarAutomationEntities();
                dbs.CarsQnAs.Add(new db.CarsQnA { CarsId = id, Question = form["newQuestion"], QuestionType = "Q" });
                dbs.SaveChanges();
                ModelState.AddModelError("success", "پرسش شما با موفقیت ثبت شد");
            }
            else
                ModelState.AddModelError("newQuestion", "پرسش وارد نشده است");
            return View();
        }
        public ActionResult Car_Forum_Question(int? id)
        {
            return View();
        }
        [HttpPost]
        public ActionResult Car_Forum_Question(int? id, DBSEF.CarsQnA model)
        {
            if (model.Question.IsNullOrWhiteSpace())
                ViewData.ModelState.AddModelError("Question", "متن پرسش وارد نشده است");
            if (ModelState.IsValid)
            {
                var dbs = new DBSEF.CarAutomationEntities();
                model.QuestionType = "Q";
                dbs.CarsQnAs.Add(model);
                dbs.SaveChanges();

                return RedirectToAction("Car_Forum_Question", new { id = id });
            }
            return View(model);
        }
        #endregion
    }
}

