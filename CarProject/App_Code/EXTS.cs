using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Linq.Expressions;
using System.Globalization;

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
            var x = dic.Where(an => an.Key.ToLower() == atrname.ToLower()).FirstOrDefault().Key;
            if (string.IsNullOrWhiteSpace(x))
                dic.Add(atrname, value);
            else
                dic[x] = dic[x].ToString() + " " + value.ToString();
        }
        public static string DicAtrsToString(IDictionary<string, object> dic)
        {
            string res = "";

            foreach (var item in dic)
            {
                res += string.Format(" {0}=\"{1}\" ", item.Key, item.Value.ToString());
            }

            return res;
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
        
        public static MvcHtmlString input_Password<tm, tp>(this HtmlHelper<tm> htmlHelper, Expression<Func<tm, tp>> expression, string displayName, IDictionary<string, object> htmlAttributes, string errorClass)
        {

            if (!htmlHelper.ViewData.ModelState.IsValidField(htmlHelper.NameFor(expression).ToString()))
                AddAttribute(htmlAttributes, "class", errorClass);

            AddAttribute(htmlAttributes, "placeholder", displayName);

            string res = "<section class=\"input\">";

            res += htmlHelper.LabelFor(expression, displayName);
            res += htmlHelper.PasswordFor(expression, htmlAttributes);
            res += htmlHelper.ValidationMessageFor(expression);

            res += "</section>";
            return new MvcHtmlString(res);
        }
        public static MvcHtmlString input_Password<TM, TP>(this HtmlHelper<TM> htmlHelper, Expression<Func<TM, TP>> expres, string displayName, string errorClass)
        {
            return input_Password<TM, TP>(htmlHelper, expres, displayName, new Dictionary<string, object>(), errorClass);
        }
        public static MvcHtmlString input_Password<TM, TP>(this HtmlHelper<TM> htmlHelper, Expression<Func<TM, TP>> expres, string displayName)
        {
            return input_Password<TM, TP>(htmlHelper, expres, displayName, new Dictionary<string, object>(), "error");
        }
        public static MvcHtmlString input_Password<TM, TP>(this HtmlHelper<TM> htmlHelper, Expression<Func<TM, TP>> expres, string displayName, IDictionary<string, object> htmlAttributes)
        {
            return input_Password<TM, TP>(htmlHelper, expres, displayName, htmlAttributes, "error");
        }

        public static MvcHtmlString input_Password2<tm, tp>(this HtmlHelper<tm> htmlHelper, Expression<Func<tm, tp>> expression, string displayName, IDictionary<string, object> htmlAttributes, string errorClass)
        {

            if (!htmlHelper.ViewData.ModelState.IsValidField(htmlHelper.NameFor(expression).ToString()))
                AddAttribute(htmlAttributes, "class", errorClass);

            AddAttribute(htmlAttributes, "placeholder", displayName);

            string res = "<section class=\"input\">";

            res += htmlHelper.LabelFor(expression, displayName);
            res += string.Format("<input type=\"password\" name=\"{0}\" id=\"{1}\" value=\"{2}\" />", htmlHelper.NameFor(expression), htmlHelper.IdFor(expression), htmlHelper.ValueFor(expression));
            res += htmlHelper.ValidationMessageFor(expression);

            res += "</section>";
            return new MvcHtmlString(res);
        }
        public static MvcHtmlString input_Password2<TM, TP>(this HtmlHelper<TM> htmlHelper, Expression<Func<TM, TP>> expres, string displayName, string errorClass)
        {
            return input_Password2<TM, TP>(htmlHelper, expres, displayName, new Dictionary<string, object>(), errorClass);
        }
        public static MvcHtmlString input_Password2<TM, TP>(this HtmlHelper<TM> htmlHelper, Expression<Func<TM, TP>> expres, string displayName)
        {
            return input_Password2<TM, TP>(htmlHelper, expres, displayName, new Dictionary<string, object>(), "error");
        }
        public static MvcHtmlString input_Password2<TM, TP>(this HtmlHelper<TM> htmlHelper, Expression<Func<TM, TP>> expres, string displayName, IDictionary<string, object> htmlAttributes)
        {
            return input_Password2<TM, TP>(htmlHelper, expres, displayName, htmlAttributes, "error");
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

            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem { Text = "--انتخاب کنید--", Value = "", Selected = true });

            foreach (var item in Items)
            {
                items.Add(new SelectListItem { Text = item, Value = item });
            }

            string res = "<section class=\"input\">";

            res += htmlHelper.LabelFor(expression, displayName);
            res += htmlHelper.DropDownListFor(expression, items, htmlAttributes);

            /*res += string.Format("<select {0} {1} {2} >", htmlHelper.IdFor(expression).ToString(), htmlHelper.NameFor(expression).ToString(), attributes);
           
            res += string.Format("<option value=\"\" >{0}</option>", "--انتخاب کنید--");
            foreach (var item in Items)
            {
                res += string.Format("<option value=\"{0}\" >{0}</option>", item);
            }
            
            res += "</select>";*/

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

        public static MvcHtmlString input_ComboBox<tm, tp>(this HtmlHelper<tm> htmlHelper, Expression<Func<tm, tp>> expression, string displayName, IDictionary<int,string> Items, IDictionary<string, object> htmlAttributes, string errorClass)
        {

            if (!htmlHelper.ViewData.ModelState.IsValidField(htmlHelper.NameFor(expression).ToString()))
                AddAttribute(htmlAttributes, "class", errorClass);

            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem { Text = "--انتخاب کنید--", Value = "", Selected = true });

            foreach (var item in Items)
            {
                items.Add(new SelectListItem { Text = item.Value, Value = item.Key.ToString() });
            }

            string res = "<section class=\"input\">";

            res += htmlHelper.LabelFor(expression, displayName);
            res += htmlHelper.DropDownListFor(expression, items, htmlAttributes);

            /*res += string.Format("<select {0} {1} {2} >", htmlHelper.IdFor(expression).ToString(), htmlHelper.NameFor(expression).ToString(), attributes);
           
            res += string.Format("<option value=\"\" >{0}</option>", "--انتخاب کنید--");
            foreach (var item in Items)
            {
                res += string.Format("<option value=\"{0}\" >{0}</option>", item);
            }
            
            res += "</select>";*/

            res += htmlHelper.ValidationMessageFor(expression);

            res += "</section>";
            return new MvcHtmlString(res);
        }
        public static MvcHtmlString input_ComboBox<TM, TP>(this HtmlHelper<TM> htmlHelper, Expression<Func<TM, TP>> expres, string displayName, IDictionary<int, string> Items, string errorClass)
        {
            return input_ComboBox<TM, TP>(htmlHelper, expres, displayName, Items, new Dictionary<string, object>(), errorClass);
        }
        public static MvcHtmlString input_ComboBox<TM, TP>(this HtmlHelper<TM> htmlHelper, Expression<Func<TM, TP>> expres, string displayName, IDictionary<int, string> Items)
        {
            return input_ComboBox<TM, TP>(htmlHelper, expres, displayName, Items, new Dictionary<string, object>(), "error");
        }
        public static MvcHtmlString input_ComboBox<TM, TP>(this HtmlHelper<TM> htmlHelper, Expression<Func<TM, TP>> expres, string displayName, IDictionary<int, string> Items, IDictionary<string, object> htmlAttributes)
        {
            return input_ComboBox<TM, TP>(htmlHelper, expres, displayName, Items, htmlAttributes, "error");
        }

        public static MvcHtmlString input_CheckBox<tm>(this HtmlHelper<tm> htmlHelper, Expression<Func<tm, bool?>> expression, string displayName, IDictionary<string, object> htmlAttributes, string errorClass)
        {
            if (!htmlHelper.ViewData.ModelState.IsValidField(htmlHelper.NameFor(expression).ToString()))
                AddAttribute(htmlAttributes, "class", errorClass);



            string res = "<section class=\"input\">";

            res += htmlHelper.LabelFor(expression, displayName);

            res += htmlHelper.CheckBox(htmlHelper.NameFor(expression).ToString(), htmlAttributes);

            res += htmlHelper.ValidationMessageFor(expression);

            res += "</section>";
            return new MvcHtmlString(res);
        }
        public static MvcHtmlString input_CheckBox<TM>(this HtmlHelper<TM> htmlHelper, Expression<Func<TM, bool?>> expres, string displayName, string errorClass)
        {
            return input_CheckBox<TM>(htmlHelper, expres, displayName, new Dictionary<string, object>(), errorClass);
        }
        public static MvcHtmlString input_CheckBox<TM>(this HtmlHelper<TM> htmlHelper, Expression<Func<TM, bool?>> expres, string displayName)
        {
            return input_CheckBox<TM>(htmlHelper, expres, displayName, new Dictionary<string, object>(), "error");
        }
        public static MvcHtmlString input_CheckBox<TM>(this HtmlHelper<TM> htmlHelper, Expression<Func<TM, bool?>> expres, string displayName, IDictionary<string, object> htmlAttributes)
        {
            return input_CheckBox<TM>(htmlHelper, expres, displayName, htmlAttributes, "error");
        }


        public static MvcHtmlString input_Rating<tm, tp>(this HtmlHelper<tm> htmlHelper, Expression<Func<tm, tp>> expression, string displayName, IDictionary<string, object> htmlAttributes, string errorClass)
        {

            if (!htmlHelper.ViewData.ModelState.IsValidField(htmlHelper.NameFor(expression).ToString()))
                AddAttribute(htmlAttributes, "class", errorClass);

            string cls = DicAtrsToString(htmlAttributes);

            string res = "<section class=\"input\">";

            res += htmlHelper.LabelFor(expression, displayName);
            {
                res += string.Format("<section class=\"input rating {0}\" >", cls);
                {
                    res += htmlHelper.TextBoxFor(expression, new Dictionary<string, object>() { { "onKeyPress", "return floatNumber(event);" }, { "maxlength", "5" }, { "readonly", "readonly" } });
                    res += "<section class=\"ratingSection\" onClick=\"ratint_Onclick(event)\" onMouseMove=\"ratint_OnMouseMove(event)\"> " +
                                "<section class=\"ratingSectionSlider\" ></section> " +
                                "<section class=\"ratingSectionFakeSlider\" ></section> " +
                           "</section>";
                }
                res += "</section>";
            }
            res += htmlHelper.ValidationMessageFor(expression);

            res += "</section>";
            return new MvcHtmlString(res);
        }
        public static MvcHtmlString input_Rating<TM, TP>(this HtmlHelper<TM> htmlHelper, Expression<Func<TM, TP>> expres, string displayName, string errorClass)
        {
            return input_Rating<TM, TP>(htmlHelper, expres, displayName, new Dictionary<string, object>(), errorClass);
        }
        public static MvcHtmlString input_Rating<TM, TP>(this HtmlHelper<TM> htmlHelper, Expression<Func<TM, TP>> expres, string displayName)
        {
            return input_Rating<TM, TP>(htmlHelper, expres, displayName, new Dictionary<string, object>(), "error");
        }
        public static MvcHtmlString input_Rating<TM, TP>(this HtmlHelper<TM> htmlHelper, Expression<Func<TM, TP>> expres, string displayName, IDictionary<string, object> htmlAttributes)
        {
            return input_Rating<TM, TP>(htmlHelper, expres, displayName, htmlAttributes, "error");
        }


        public static MvcHtmlString input_SearchBox<tm, tp>(this HtmlHelper<tm> htmlHelper, Expression<Func<tm, tp>> expression, string displayName, IDictionary<string, object> htmlAttributes, string errorClass, string buttonOnclick)
        {

            if (!htmlHelper.ViewData.ModelState.IsValidField(htmlHelper.NameFor(expression).ToString()))
                AddAttribute(htmlAttributes, "class", errorClass);

            AddAttribute(htmlAttributes, "placeholder", displayName);

            string res = "<section class=\"input\">";

            res += "<section>";
            res += htmlHelper.LabelFor(expression, displayName);
            res += htmlHelper.HiddenFor(expression, htmlAttributes);
            res += "</section>";

            res += "<section class=\"label\">";
            res += string.Format("<section id=\"{0}\" ></section>", input_SearchBox_ID(htmlHelper, expression));
            res += string.Format("<a href=\"javascript: void()\" onclick=\"{0}\" class=\"gia-search inbutton button\"></a>", buttonOnclick);
            res += "</section>";


            res += htmlHelper.ValidationMessageFor(expression);

            res += "</section>";
            return new MvcHtmlString(res);
        }
        public static MvcHtmlString input_SearchBox<TM, TP>(this HtmlHelper<TM> htmlHelper, Expression<Func<TM, TP>> expres, string displayName, string errorClass, string buttonOnclick)
        {
            return input_SearchBox<TM, TP>(htmlHelper, expres, displayName, new Dictionary<string, object>(), errorClass, buttonOnclick);
        }
        public static MvcHtmlString input_SearchBox<TM, TP>(this HtmlHelper<TM> htmlHelper, Expression<Func<TM, TP>> expres, string displayName, string buttonOnclick)
        {
            return input_SearchBox<TM, TP>(htmlHelper, expres, displayName, new Dictionary<string, object>(), "error", buttonOnclick);
        }
        public static MvcHtmlString input_SearchBox<TM, TP>(this HtmlHelper<TM> htmlHelper, Expression<Func<TM, TP>> expres, string displayName, IDictionary<string, object> htmlAttributes, string buttonOnclick)
        {
            return input_SearchBox<TM, TP>(htmlHelper, expres, displayName, htmlAttributes, "error", buttonOnclick);
        }

        public static MvcHtmlString input_SearchBox_ID<TM, TP>(this HtmlHelper<TM> htmlHelper, Expression<Func<TM, TP>> expres)
        {
            var x = htmlHelper.IdFor(expres).ToString();
            x = "txt_" + x;

            return new MvcHtmlString(x);
        }

        #endregion


        #region Display
        public static MvcHtmlString Display_Rating<tm, tp>(this HtmlHelper<tm> htmlHelper, Expression<Func<tm, tp>> expression, string displayName, IDictionary<string, object> htmlAttributes, string errorClass)
        {

            if (!htmlHelper.ViewData.ModelState.IsValidField(htmlHelper.NameFor(expression).ToString()))
                AddAttribute(htmlAttributes, "class", errorClass);

            string cls = DicAtrsToString(htmlAttributes);

            string res = "<section class=\"input\">";

            res += htmlHelper.LabelFor(expression, displayName);
            {
                res += string.Format("<section class=\"input rating {0}\" >", cls);
                {
                    res += "<section class=\"ratingSection\" data-value=\"" + htmlHelper.ValueFor(expression).ToString() + "\" > " +
                                "<section class=\"ratingSectionSlider\" ></section> " +
                           "</section>";
                }
                res += "</section>";
            }
            res += htmlHelper.ValidationMessageFor(expression);

            res += "</section>";
            return new MvcHtmlString(res);
        }
        public static MvcHtmlString Display_Rating<TM, TP>(this HtmlHelper<TM> htmlHelper, Expression<Func<TM, TP>> expres, string displayName, string errorClass)
        {
            return Display_Rating<TM, TP>(htmlHelper, expres, displayName, new Dictionary<string, object>(), errorClass);
        }
        public static MvcHtmlString Display_Rating<TM, TP>(this HtmlHelper<TM> htmlHelper, Expression<Func<TM, TP>> expres, string displayName)
        {
            return Display_Rating<TM, TP>(htmlHelper, expres, displayName, new Dictionary<string, object>(), "error");
        }
        public static MvcHtmlString Display_Rating<TM, TP>(this HtmlHelper<TM> htmlHelper, Expression<Func<TM, TP>> expres, string displayName, IDictionary<string, object> htmlAttributes)
        {
            return Display_Rating<TM, TP>(htmlHelper, expres, displayName, htmlAttributes, "error");
        }
        #endregion


        #region DateAndTime
        public static MvcHtmlString ToPersianDateString(this DateTime value)
        {
            try
            {
                PersianCalendar p = new PersianCalendar();
                return new MvcHtmlString(string.Format("{0:0000}/{1:00}/{2:00}", p.GetYear(value), p.GetMonth(value), p.GetDayOfMonth(value)));
            }
            catch
            {
                return new MvcHtmlString("");
            }
        }

        public static MvcHtmlString ToPersianDateString_LongTime(this DateTime value)
        {
            try
            {
                PersianCalendar p = new PersianCalendar();
                return new MvcHtmlString(string.Format("{0:0000}/{1:00}/{2:00} - {3:00}:{4:00}:{5:00}", p.GetYear(value), p.GetMonth(value), p.GetDayOfMonth(value),
                    value.Hour, value.Minute, value.Second));
            }
            catch
            {
                return new MvcHtmlString("");
            }
        }

        #endregion

        #region Usefull Extension
        public static string YesNoString(this bool? value)
        {
            return (value.GetValueOrDefault()) ? "بله" : "خیر";
        }
        #endregion
    }


}