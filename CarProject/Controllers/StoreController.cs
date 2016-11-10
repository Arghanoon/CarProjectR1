using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using CarProject.App_extension;


namespace CarProject.Controllers
{
    public class StoreController : Controller
    {
        //
        // GET: /Store/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Products(int id)
        {
            return View(id);
        }
        [HttpPost]
        public ActionResult Products(int id, FormCollection form)
        {
            ViewBag.error = new Dictionary<string, string>();
            if (form.AllKeys.Contains("SendACommentRequest"))
            {
                if (form["fullname"] == "")
                    ViewBag.error["fullname"] = "نام و نام خانوادگی تعیین نشده است";
                if (form["email"] == "")
                    ViewBag.error["email"] = "ایمیل وارد نشده است";
                else if(!form["email"].String_IsEmail())
                    ViewBag.error["email"] = "ایمیل وارد شده صحیح نیست";

                if(form["comment"] == "")
                    ViewBag.error["comment"] = "پیام وارد نشده است";

                if (((Dictionary<string, string>)ViewBag.error).Count == 0)
                {
                    var dbs = new DBSEF.CarAutomationEntities();
                    dbs.ProductComments.Add(new DBSEF.ProductComment { Comment = form["comment"], Email = form["email"], Fullname = form["fullname"], ProductId = id, datetime = DateTime.Now });
                    dbs.SaveChanges();
                    ViewBag.error["success"] = "پیام شما با موفقیت ثبت شد و پس از تایید به نمایش در خواهد آمد";
                }
            }
            return View(id);
        }
        
        [HttpPost]
        public int Products_makePopular(int id)
        {
            var dbs = new DBSEF.CarAutomationEntities();
            int res = 0;
            if (dbs.ProductToViews.Count(p => p.ProductId == id) > 0)
            {
                var x = dbs.ProductToViews.FirstOrDefault(p => p.ProductId == id);
                if (x != null)
                {
                    if (x.Favorite == null || x.Favorite <= 0)
                    { x.Favorite = 1; res = 1; }
                    else
                    { x.Favorite += 1; res = x.Favorite.Value; }
                }
            }

            dbs.SaveChanges();
            return res;
        }

        public ActionResult ProductsList(int? id)
        {
            return View(id);
        }

        public ActionResult ServiceView(int id)
        {
            return View(id);
        }
        [HttpPost]
        public int ServiceView_makePopular(int id)
        {
            var dbs = new DBSEF.CarAutomationEntities();
            int res = 0;

            var x = dbs.ServiceToViews.FirstOrDefault(p => p.ServiceId == id);
            if (x != null)
            {
                if (x.Favorite == null || x.Favorite <= 0)
                { x.Favorite = 1; res = 1; }
                else
                { x.Favorite += 1; res = x.Favorite.Value; }
            }


            dbs.SaveChanges();
            return res;
        }



        public ActionResult ServicePackView(int id)
        {
            return View(id);
        }
        [HttpPost]
        public int ServicePackView_makePopular(int id)
        {
            var dbs = new DBSEF.CarAutomationEntities();
            int res = 0;

            var x = dbs.ServicesPackToViews.FirstOrDefault(p => p.ServicesPackId == id);
            if (x != null)
            {
                if (x.Favorite == null || x.Favorite <= 0)
                { x.Favorite = 1; res = 1; }
                else
                { x.Favorite += 1; res = x.Favorite.Value; }
            }


            dbs.SaveChanges();
            return res;
        }
    }
}
