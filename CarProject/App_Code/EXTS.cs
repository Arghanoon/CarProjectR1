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


        #region inputs

        public static void AddAttribute(IDictionary<string, object> dic, string atrname, object value)
        {
            var x = dic.FirstOrDefault(an => an.Key.ToLower() == atrname.ToLower()).Key;
            if (string.IsNullOrWhiteSpace(x))
                dic.Add(atrname, value);
            else
                dic[x] = dic[x].ToString() + " " + value.ToString();
        }

        public static MvcHtmlString input_TextBox<tm, tp>(this HtmlHelper<tm> htmlHelper, Expression<Func<tm, tp>> expression, string displayName, IDictionary<string, object> htmlAttributes, string errorClass)
        {

            if (!htmlHelper.ViewData.ModelState.IsValidField(htmlHelper.NameFor(expression).ToString()))
                AddAttribute(htmlAttributes, "class", errorClass);

            AddAttribute(htmlAttributes, "placeholder", displayName);

            string res = "<section class=\"input\">";

            res += htmlHelper.LabelFor(expression, displayName);
            res += htmlHelper.TextBoxFor(expression, htmlAttributes);
            res += htmlHelper.ValidationMessageFor(expression);

            res += "</section>";
            return new MvcHtmlString(res);
        }
        public static MvcHtmlString input_TextBox<TM, TP>(this HtmlHelper<TM> htmlHelper, Expression<Func<TM, TP>> expres, string displayName, string errorClass)
        {
            return input_TextBox<TM, TP>(htmlHelper, expres, displayName, new Dictionary<string, object>(), errorClass);
        }
        public static MvcHtmlString input_TextBox<TM, TP>(this HtmlHelper<TM> htmlHelper, Expression<Func<TM, TP>> expres, string displayName)
        {
            return input_TextBox<TM, TP>(htmlHelper, expres, displayName, new Dictionary<string, object>(), "error");
        }
        public static MvcHtmlString input_TextBox<TM, TP>(this HtmlHelper<TM> htmlHelper, Expression<Func<TM, TP>> expres, string displayName, IDictionary<string, object> htmlAttributes)
        {
            return input_TextBox<TM, TP>(htmlHelper, expres, displayName, htmlAttributes, "error");
        }


        public static MvcHtmlString input_TextArea<tm, tp>(this HtmlHelper<tm> htmlHelper, Expression<Func<tm, tp>> expression, string displayName, IDictionary<string, object> htmlAttributes, string errorClass)
        {

            if (!htmlHelper.ViewData.ModelState.IsValidField(htmlHelper.NameFor(expression).ToString()))
                AddAttribute(htmlAttributes, "class", errorClass);

            AddAttribute(htmlAttributes, "placeholder", displayName);

            string res = "<section class=\"input\">";

            res += htmlHelper.LabelFor(expression, displayName);
            res += htmlHelper.TextAreaFor(expression, htmlAttributes);
            res += htmlHelper.ValidationMessageFor(expression);

            res += "</section>";
            return new MvcHtmlString(res);
        }
        public static MvcHtmlString input_TextArea<TM, TP>(this HtmlHelper<TM> htmlHelper, Expression<Func<TM, TP>> expres, string displayName, string errorClass)
        {
            return input_TextArea<TM, TP>(htmlHelper, expres, displayName, new Dictionary<string, object>(), errorClass);
        }
        public static MvcHtmlString input_TextArea<TM, TP>(this HtmlHelper<TM> htmlHelper, Expression<Func<TM, TP>> expres, string displayName)
        {
            return input_TextArea<TM, TP>(htmlHelper, expres, displayName, new Dictionary<string, object>(), "error");
        }
        public static MvcHtmlString input_TextArea<TM, TP>(this HtmlHelper<TM> htmlHelper, Expression<Func<TM, TP>> expres, string displayName, IDictionary<string, object> htmlAttributes)
        {
            return input_TextArea<TM, TP>(htmlHelper, expres, displayName, htmlAttributes, "error");
        }



        public static MvcHtmlString input_ComboBox<tm, tp>(this HtmlHelper<tm> htmlHelper, Expression<Func<tm, tp>> expression, string displayName, IList<string> Items, IDictionary<string, object> htmlAttributes, string errorClass)
        {

            if (!htmlHelper.ViewData.ModelState.IsValidField(htmlHelper.NameFor(expression).ToString()))
                AddAttribute(htmlAttributes, "class", errorClass);

            string attributes = "";
            foreach (var item in htmlAttributes)
            {
                attributes = string.Format(" {0}=\"{1}\" ", item.Key, item.Value.ToString());
            }

            string res = "<section class=\"input\">";

            res += htmlHelper.LabelFor(expression, displayName);
            res += string.Format("<select {0} {1} {2} >", htmlHelper.IdFor(expression).ToString(), htmlHelper.NameFor(expression).ToString(), attributes);
           
            res += string.Format("<option value=\"\" >{0}</option>", "--انتخاب کنید--");
            foreach (var item in Items)
            {
                res += string.Format("<option value=\"{0}\" >{0}</option>", item);
            }
            
            res += "</select>";
            res += htmlHelper.ValidationMessageFor(expression);

            res += "</section>";
            return new MvcHtmlString(res);
        }
        public static MvcHtmlString input_ComboBox<TM, TP>(this HtmlHelper<TM> htmlHelper, Expression<Func<TM, TP>> expres, string displayName, IList<string> Items, string errorClass)
        {
            return input_ComboBox<TM, TP>(htmlHelper, expres, displayName, Items, new Dictionary<string, object>(), errorClass);
        }
        public static MvcHtmlString input_ComboBox<TM, TP>(this HtmlHelper<TM> htmlHelper, Expression<Func<TM, TP>> expres, string displayName, IList<string> Items)
        {
            return input_ComboBox<TM, TP>(htmlHelper, expres, displayName, Items, new Dictionary<string, object>(), "error");
        }
        public static MvcHtmlString input_ComboBox<TM, TP>(this HtmlHelper<TM> htmlHelper, Expression<Func<TM, TP>> expres, string displayName, IList<string> Items, IDictionary<string, object> htmlAttributes)
        {
            return input_ComboBox<TM, TP>(htmlHelper, expres, displayName, Items, htmlAttributes, "error");
        }

    }

        #endregion
}