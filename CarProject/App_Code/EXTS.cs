using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Linq.Expressions;

namespace CarProject.App_Code
{
    public static class UsefullExtensions
    {
        public static MvcHtmlString AddClassOnErr<TM, TP>(this HtmlHelper<TM> hh, Expression<Func<TM, TP>> exp, string Class)
        {
            var state = hh.ViewData.ModelState[hh.ViewData.TemplateInfo.GetFullHtmlFieldName(ExpressionHelper.GetExpressionText(exp))];
            if (state == null || state.Errors.Count <= 0)
                return MvcHtmlString.Empty;
            else
                return new MvcHtmlString(Class);
        }
    }
}