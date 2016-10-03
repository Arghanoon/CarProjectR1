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
            var model = new Models.Store.CategoryModel();
            model.Category.ParentCategoryId = id;
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


        public ActionResult Products_Insert()
        {
            return View();
        }
    }

    public class StoreMVC
    {
        DBSEF.CarAutomationEntities DBS = new DBSEF.CarAutomationEntities();
        public MvcHtmlString Categories_readonly(int? pid, int level = 1, int? skipShoingId = null, string ulclass = "", string liClass = "", string aHref = "#", string aClass = "")
        {
            string res = "";

            foreach (var item in DBS.Categories.Where(c => c.ParentCategoryId == pid))
            {
                if (item.CategoryId == skipShoingId)
                    continue;

                res += string.Format("<li class=\"{0}\" >", liClass);
                {
                    var tmp = Categories_readonly(item.CategoryId, (level + 1), skipShoingId, ulclass, liClass, aHref, aClass);

                    res += string.Format("<a href=\"{0}\" class=\"{1}\" data-id=\"{2}\" data-name=\"{3}\" data-describe=\"{4}\" data-haveroot=\"{5}\" >{6}</a> {7}",
                        aHref, aClass, item.CategoryId, item.CategoryName,
                        HttpUtility.HtmlEncode(item.Description),
                        ((tmp.ToString().IsNullOrWhiteSpace()) ? 0 : 1),
                        item.CategoryName, tmp);
                }
                res += "</li>";
            }


            if (!res.IsNullOrWhiteSpace())
                res = string.Format("<ul class=\"{0}\"  data-level=\"{1}\" >{2}</ul>", ulclass, level, res);
            return new MvcHtmlString(res);
        }
        
        
        public MvcHtmlString Categories_managment(int? pid, int level = 1, string ulclass = "", string liClass = "", string aHref = "#", string aClass = "",
            string editHref="#", string editClass = "", string editOnclick = "", string editText = "",
            string removeHref = "#", string removeClass = "", string removeOnclick = "", string removeText = "")
        {
            string res = "";

            foreach (var item in DBS.Categories.Where(c => c.ParentCategoryId == pid))
            {
                res += string.Format("<li class=\"{0}\" >", liClass);
                {
                    var tmp = Categories_managment(item.CategoryId, (level + 1), ulclass, liClass, aHref, aClass,
                        editHref, editClass, editOnclick, editText,
                        removeHref, removeClass, removeOnclick, removeText);

                    res += string.Format("<a href=\"{0}\" class=\"{1}\" data-id=\"{2}\" data-name=\"{3}\" data-describe=\"{4}\" data-haveroot=\"{5}\" >{6}</a> {7} {8} {9}",
                        aHref, aClass, item.CategoryId, item.CategoryName,
                        HttpUtility.HtmlEncode(item.Description),
                        ((tmp.ToString().IsNullOrWhiteSpace()) ? 0 : 1),

                        item.CategoryName,

                        string.Format("<a href=\"{0}\" class=\"{1}\" onclick=\"{2}('{3}','{4}','{5}')\">{6}</a>",
                        editHref, editClass, editOnclick, item.CategoryId, item.CategoryName, item.Description, editText),
                        string.Format("<a href=\"{0}\" class=\"{1}\" onclick=\"{2}('{3}','{4}','{5}')\">{6}</a>",
                        removeHref, removeClass, removeOnclick, item.CategoryId, item.CategoryName, item.Description, removeText),

                        tmp);
                }
                res += "</li>";
            }


            if (!res.IsNullOrWhiteSpace())
                res = string.Format("<ul class=\"{0}\"  data-level=\"{1}\" >{2}</ul>", ulclass, level, res);
            return new MvcHtmlString(res);
        }
    }
}
