using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
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

        public static MvcHtmlString input_TextBox<tm, tp>(this HtmlHelper<tm> htmlHelper, Expression<Func<tm, tp>> expression, string displayName, IDictionary<string, object> htmlAttributes, string errorClass = "error")
        {

            if (!htmlHelper.ViewData.ModelState.IsValidField(htmlHelper.NameFor(expression).ToString()))
            {
                var x = htmlAttributes.Where(m => m.Key.ToLower() == "class").FirstOrDefault().Key;
                if (string.IsNullOrWhiteSpace(x))
                    htmlAttributes.Add(new KeyValuePair<string, object>("class", errorClass));
                else
                    htmlAttributes[x] = new KeyValuePair<string, object>("class", htmlAttributes[x].ToString() + " " + errorClass);                
            }

            string res = "<section class=\"input\">";

            res += htmlHelper.LabelFor(expression, displayName);
            res += htmlHelper.TextBoxFor(expression);
            res += htmlHelper.ValidationMessageFor(expression);

            res += "</section>";
            return new MvcHtmlString(res);
        }
    }
}