using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace CarProject.App_Code
{
    public static class StringAddRoutes
    {
        public static string BaseRouts_CarImages(this string value)
        {
            return Path.Combine("~/Publics/CarImages/",value);
        }
        public static string BaseRouts_CarTempImages(this string value)
        {
            return Path.Combine("~/Publics/CarTempImages/", value);
        }
    }
}