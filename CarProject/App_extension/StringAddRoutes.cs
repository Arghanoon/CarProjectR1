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
    }
}