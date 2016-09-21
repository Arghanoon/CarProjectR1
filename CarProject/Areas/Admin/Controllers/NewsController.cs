using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using db = CarProject.DBSEF;

namespace CarProject.Areas.Admin.Controllers
{
    public class NewsController : Controller
    {
        //
        // GET: /Admin/News/

        DBSEF.CarAutomationEntities DBS = new db.CarAutomationEntities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult News_Publish()
        {
            var model = new Models.News.Newsmodel();
            return View(model);
        }
        [HttpPost]
        public ActionResult News_Publish(Models.News.Newsmodel model)
        {
            if (ModelState.IsValid)
            {
                model.Save();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult Update_Publish(int? Id)
        {
            var model = new Models.News.Newsmodel(Id);
            Session["ContentsUpdate"] = model;
            return View(model);
        }
        [HttpPost]
        public ActionResult Update_Publish(Models.News.Newsmodel model)
        {
            if (ModelState.IsValid)
            {
                var m = Session["ContentsUpdate"] as Models.News.Newsmodel;
                TryUpdateModel(m);
                m.Update();

                return RedirectToAction("Index");
            }
            return View(model);
        }

    }
}
