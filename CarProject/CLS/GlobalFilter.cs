using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarProject.CLS
{
    public class GlobalFilter : System.Web.Mvc.ActionFilterAttribute
    {
        public override void OnActionExecuting(System.Web.Mvc.ActionExecutingContext filterContext)
        {
            //filterContext.HttpContext.Response.Write(filterContext.HttpContext.Request.Url.ToString());
        }
    }
}