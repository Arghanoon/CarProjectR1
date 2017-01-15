using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarProject.Areas.Users.UsersCLS
{
    public class UsersAuthFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var filters = filterContext.ActionDescriptor.GetFilterAttributes(true);
            if (filters.Count(c => c is Users_DontAuthFilter) <= 0)
            {
                var Session = filterContext.HttpContext.Session;

                if (!filterContext.HttpContext.Request.Url.ToString().EndsWith("LogoutRequest", StringComparison.OrdinalIgnoreCase))
                    Session["guestRedirect"] = filterContext.RouteData;
                if (!(Session["guestUser"] != null && Session["guestUser"] is DBSEF.User))
                {
                    filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new { area = "Users", controller = "profile", action = "Login" }));
                }
            }
        }
    }

    public class Users_DontAuthFilter : ActionFilterAttribute
    {
    }
}