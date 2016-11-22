using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Globalization;
using System.Net.Mail;

using System.Text.RegularExpressions;

namespace CarProject.App_extension
{
    public static class StringAddRoutes
    {
        public static bool IsNullOrWhiteSpace(this string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }

        #region Routes
        public static string BaseRouts_CarImages(this string value)
        {
            return Path.Combine("~/Publics/Gallery/CarImages/",value).Replace('\\','/');
        }
        public static string BaseRouts_CarTempImages(this string value)
        {
            return Path.Combine("~/Publics/Gallery/CarTempImages/", value).Replace('\\', '/'); ;
        }
        public static string BaseRouts_CarBrands(this string value)
        {
            return Path.Combine("~/Publics/Gallery/Brands/", value).Replace('\\', '/'); ;
        }

        public static string BaseRouts_NewsImages(this string value)
        {
            return Path.Combine("~/Publics/Gallery/NewsImages/", value).Replace('\\', '/');
        }

        public static string BaseRouts_ProductImages(this string value)
        {
            return Path.Combine("~/Publics/Gallery/ProductImages/", value).Replace('\\', '/');
        }
        public static string BaseRouts_ServicesImages(this string value)
        {
            return Path.Combine("~/Publics/Gallery/Services/", value).Replace('\\', '/');
        }
        public static string BaseRouts_ServicePacksImages(this string value)
        {
            return Path.Combine("~/Publics/Gallery/ServicePacks/", value).Replace('\\', '/');
        }
        #endregion

        public static bool ContentTypeIsImage(this string value)
        {
            string[] contentTypes = { "image/gif", "image/jpeg", "image/png", "image/gif", "image/x-icon" };

            return contentTypes.Contains(value.ToLower());
        }

        public static bool String_IsEmail(this string value)
        {
            bool result = false;

            try
            {
                MailAddress m = new MailAddress(value);
                result = true;
            }
            catch
            {
            }

            return result;
        }
        public static bool IsNumber(this string value)
        {
            return !value.IsNullOrWhiteSpace() && Regex.IsMatch(value, "^[0-9]*$");
        }
    }

    public static class DateTimeExtensions
    {
        public static string DateTime_Persian(this DateTime? value)
        {
            PersianCalendar PRS = new PersianCalendar();

            if (value == null || value.GetValueOrDefault(DateTime.MinValue) == DateTime.MinValue)
                return "";
            return string.Format("{0:0000}/{1:00}/{2:00} {3:00}:{4:00}:{5:00}", PRS.GetYear(value.GetValueOrDefault()), PRS.GetMonth(value.GetValueOrDefault()), PRS.GetDayOfMonth(value.GetValueOrDefault()), value.GetValueOrDefault().Hour, value.GetValueOrDefault().Minute, value.GetValueOrDefault().Second);
        }

        public static string DateTime_Persian(this DateTime value)
        {
            PersianCalendar PRS = new PersianCalendar();

            return string.Format("{0:0000}/{1:00}/{2:00} {3:00}:{4:00}:{5:00}", PRS.GetYear(value), PRS.GetMonth(value), PRS.GetDayOfMonth(value), value.Hour, value.Minute, value.Second);
        }
        public static string Date_Persian(this DateTime? value)
        {
            PersianCalendar PRS = new PersianCalendar();

            if (value == null || value.GetValueOrDefault(DateTime.MinValue) == DateTime.MinValue)
                return "";
            return string.Format("{0:0000}/{1:00}/{2:00}", PRS.GetYear(value.GetValueOrDefault()), PRS.GetMonth(value.GetValueOrDefault()), PRS.GetDayOfMonth(value.GetValueOrDefault()));
        }

        public static string Date_Persian(this DateTime value)
        {
            PersianCalendar PRS = new PersianCalendar();

            return string.Format("{0:0000}/{1:00}/{2:00}", PRS.GetYear(value), PRS.GetMonth(value), PRS.GetDayOfMonth(value));
        }

        public static bool IsPersianDateTime(this string value)
        {
            string ptrn = "^[0-9]{4}\\/(0[0-9]|1[0-2])\\/([0-2][0-9]|3[0-1])$";
            return Regex.IsMatch(value, ptrn);
        }
        public static DateTime? Persian_ToDateTime(this string value)
        {
            int y = 0, m = 0, d = 0;
            PersianCalendar prs = new PersianCalendar();
            var re = value.Split('/');
            if (re.Length < 3)
                return null;
            
            int.TryParse(re[0], out y);
            int.TryParse(re[1], out m);
            int.TryParse(re[2], out d);

            return (DateTime?)prs.ToDateTime(y, m, d, 0, 0, 0, 0);
        }
    }
}