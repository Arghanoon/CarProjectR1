using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using CarProject.App_extension;

namespace CarProject.Controllers
{
    public class NewsController : Controller
    {
        //
        // GET: /News/

        public ActionResult Index()
        {
            return View();
        }

    }

    public class NewsGroupLink
    {
        public MvcHtmlString CreateGroupLink(int? parent, string navclass = "", string linkClass = "", int datalevel = 1)
        {
            string res = "";
            var DBS = new DBSEF.CarAutomationEntities();

            foreach (DBSEF.ContentsCategory item in DBS.ContentsCategories.Where(cc => cc.ParentId == parent))
            {
                res += string.Format("<a href=\"{0}\" class=\"\">{1}</a> ");
                res += CreateGroupLink(item.ContentsCategoryId, navclass, linkClass, (datalevel + 1));
            }

            if (!res.IsNullOrWhiteSpace())
                res = string.Format("<nav class=\"{0}\" data-level=\"{1}\">{2}</nav>", navclass, datalevel, res);
            return new MvcHtmlString(res);
        }
    }
}
