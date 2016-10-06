using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Mvc;
using CarProject.App_extension;
using System.Net;

namespace CarProject.Areas.Admin.Models.Store
{


    public class StoreMVC
    {
        DBSEF.CarAutomationEntities DBS = new DBSEF.CarAutomationEntities();
        public MvcHtmlString Categories_readonly(int? pid, int level = 1, int? skipShoingId = null, string ulclass = "", string liClass = "", string aHref = "#", string aClass = "", string aOnclick = "")
        {
            string res = "";

            foreach (var item in DBS.Categories.Where(c => c.ParentCategoryId == pid))
            {
                if (item.CategoryId == skipShoingId)
                    continue;

                res += string.Format("<li class=\"{0}\" >", liClass);
                {
                    var tmp = Categories_readonly(item.CategoryId, (level + 1), skipShoingId, ulclass, liClass, aHref, aClass, aOnclick);

                    res += string.Format("<a href=\"{0}\" class=\"{1}\" data-id=\"{2}\" data-name=\"{3}\" data-describe=\"{4}\" data-haveroot=\"{5}\"  onclick=\"{6}\" >{7}</a> {8}",

                        aHref, aClass, item.CategoryId, item.CategoryName,
                        HttpUtility.HtmlEncode(item.Description),
                        ((tmp.ToString().IsNullOrWhiteSpace()) ? 0 : 1),
                        string.Format("{0}(this)", aOnclick),
                        item.CategoryName, tmp);
                }
                res += "</li>";
            }


            if (!res.IsNullOrWhiteSpace())
                res = string.Format("<ul class=\"{0}\"  data-level=\"{1}\" >{2}</ul>", ulclass, level, res);
            return new MvcHtmlString(res);
        }


        public MvcHtmlString Categories_managment(int? pid, int level = 1, string ulclass = "", string liClass = "", string aHref = "#", string aClass = "",
            string editHref = "#", string editClass = "", string editOnclick = "", string editText = "",
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