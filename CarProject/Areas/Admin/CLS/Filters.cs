using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarProject.Areas.Admin.CLS
{
    public class AuthFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //if (filterContext.HttpContext.Session["useradmin"] == null)
            //    filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new Dictionary<string, object>() { { "area", "Admin" }, { "controller", "Login" }, { "action", "Index" } }));
        }
    }
}