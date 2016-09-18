using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace CarProject.App_Code
{
    public static class StringAddRoutes
    {
        public static bool IsNullOrWhiteSpace(this string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }

        public static string BaseRouts_CarImages(this string value)
        {
            return Path.Combine("~/Publics/CarImages/",value).Replace('\\','/');
        }
        public static string BaseRouts_CarTempImages(this string value)
        {
            return Path.Combine("~/Publics/CarTempImages/", value).Replace('\\', '/'); ;
        }
        public static string BaseRouts_CarBrands(this string value)
        {
            return Path.Combine("~/Publics/Brands/", value).Replace('\\', '/'); ;
        }


        public static bool ContentTypeIsImage(this string value)
        {
            string[] contentTypes = { "image/gif", "image/jpeg", "image/png", "image/gif", "image/x-icon" };

            return contentTypes.Contains(value.ToLower());
        }
    }
}