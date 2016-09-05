using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarProject.CLS
{
    public class AuthFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.HttpContext.Session["rqpage"] = filterContext.HttpContext.Request.Url.ToString();

            if (filterContext.HttpContext.Session["useradmin"] == null)
                filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new Dictionary<string, object>() { { "area", "" }, { "controller", "Login" }, { "action", "Index" } }));
        }
    }
}