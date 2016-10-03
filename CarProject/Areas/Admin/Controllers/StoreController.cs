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

        public ActionResult Products_Insert()
        {
            return View();
        }
    }

    public class StoreMVC
    {
        DBSEF.CarAutomationEntities DBS = new DBSEF.CarAutomationEntities();
        public MvcHtmlString Categories(int? pid, int level = 1, string ulclass = "",string liClass = "", string aHref = "#", string aClass = "")
        {
            string res = "";

            foreach (var item in DBS.Categories.Where(c => c.ParentCategoryId == pid) )
            {
                res += string.Format("<li class=\"{0}\" >", liClass);
                {
                    var tmp = Categories(item.CategoryId, (level + 1), ulclass, liClass, aHref, aClass);
                    res += string.Format("<a href=\"{0}\" class=\"{1}\" data-id=\"{2}\" data-name=\"{3}\" data-describe=\"{4}\" >{5}</a> {6}",
                        aHref, aClass, item.CategoryId, item.CategoryName,
                        HttpUtility.HtmlEncode(item.Description), item.CategoryName, tmp);
                }
                res += "</li>";
            }


            if (!res.IsNullOrWhiteSpace())
                res = string.Format("<ul class=\"{0}\"  data-level=\"{1}\" >{2}</ul>", ulclass, level, res);
            return new MvcHtmlString(res);
        }
    }
}
