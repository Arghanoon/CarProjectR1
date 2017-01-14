using System.Web.Mvc;

namespace CarProject.Areas.Users
{
    public class UsersAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Users";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Users_default",
                "Users/{controller}/{action}/{id}",
                new { controller = "profile", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "CarProject.Areas.Users.Controllers" }
            );
        }
    }
}
