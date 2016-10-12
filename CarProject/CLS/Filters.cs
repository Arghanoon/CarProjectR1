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

            var usr = filterContext.HttpContext.Session["user"];

            if (usr == null || !( usr is DBSEF.User))
                filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new Dictionary<string, object>() { { "area", "" }, { "controller", "Login" }, { "action", "Index" } }));
            else if (((DBSEF.User)usr).UserRoleId != 1)
                filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new Dictionary<string, object>() { { "area", "" }, { "controller", "Login" }, { "action", "Index" } }));
        }
    }
    public class UsersAuthFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.HttpContext.Session["rqpage"] = filterContext.HttpContext.Request.Url.ToString();
            
            //MustBe Remove
            filterContext.HttpContext.Session["user"] = new DBSEF.CarAutomationEntities().Users.FirstOrDefault();

            if (filterContext.HttpContext.Session["user"] == null)
                filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new Dictionary<string, object>() { { "area", "" }, { "controller", "Login" }, { "action", "Index" } }));
        }
    }
}