using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarProject.Areas.Admin.Controllers.Store
{
    public class CategoriesController : Controller
    {
        //
        // GET: /Admin/Categories/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult New(int? id)
        {
            Models.Store.Categories model = new Models.Store.Categories();
            if (id != null && id > 0)
                model.CateGory.ParentCategoryId = id;

            return View(model);
        }


        [HttpPost]
        public ActionResult New(Models.Store.Categories model,FormCollection form)
        {
            if (ViewData.ModelState.IsValid)
            {
                if (form.AllKeys.Contains("saveAndFinish"))
                {
                    model.Save();
                    return RedirectToAction("Index");
                }
                if (form.AllKeys.Contains("saveAndAddAgainToThisfather"))
                {
                    model.Save();
                    return RedirectToAction("New", "Categories", new { id = model.CateGory.ParentCategoryId });
                }
                if (form.AllKeys.Contains("saveAndAddAgainThisWillBefather"))
                {
                    model.Save();
                    return RedirectToAction("New", "Categories", new { id = model.CateGory.CategoryId });
                }
            }
            return View(model);
        }
        
    }

    public class CategoriesTools
    {
        public MvcHtmlString CreateTreeView(int? parentID, DBSEF.CarAutomationEntities dc, string JSfunnection = "")
        {
            string res = "";

            res += "<ul>";
            foreach (var item in dc.Categories.Where(c => c.ParentCategoryId == parentID))
            {
                res += "<li>";

                if (dc.Categories.Count(c => c.ParentCategoryId == item.CategoryId) > 0)
                {
                    res += string.Format("<a href=\"javascript: void();\"  onClick=\"{0}\" data-id=\"{1}\" data-name=\"{2}\" data-description=\"{3}\"  >{4}</a>", JSfunnection, item.CategoryId, item.CategoryName, item.Description, item.CategoryName);
                    res += CreateTreeView(item.CategoryId, dc, JSfunnection).ToString();
                }
                else
                {
                    res += string.Format("<section  onClick=\"{0}\" data-id=\"{1}\" data-name=\"{2}\" data-description=\"{3}\"  >{4}</section>", JSfunnection, item.CategoryId, item.CategoryName, item.Description, item.CategoryName);
                }

                res += "</li>";
            }
            res += "</ul>";


            return new MvcHtmlString(res);
        }

    }
}
