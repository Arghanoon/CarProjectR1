﻿using System;
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
            
            var Session = filterContext.HttpContext.Session;
            Session["guestRedirect"] = filterContext.RouteData;
            if (!(Session["guestUser"] != null && Session["guestUser"] is DBSEF.User))
            {
                filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new { area = "Users", controller = "profile", action = "Login" }));
            }
        }
    }
}