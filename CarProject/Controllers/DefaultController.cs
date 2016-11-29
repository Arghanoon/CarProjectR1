using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarProject.Controllers
{
    public class DefaultController : Controller
    {
        //
        // GET: /Default/

        public static string CaptchaStringSession { get { return (System.Web.HttpContext.Current.Session["CRNTCAPTCHA"] != null) ? System.Web.HttpContext.Current.Session["CRNTCAPTCHA"].ToString() : ""; } set { System.Web.HttpContext.Current.Session["CRNTCAPTCHA"] = value; } }
        public static bool ValidationCaptcha(string inputCaptcha) { return CaptchaStringSession == inputCaptcha; }

        public ActionResult Index()
        {
            CaptchaStringSession = SessionGenrator(5);
            return View();
        }

        public string CodeGenerator(int? id)
        {
            return SessionGenrator(id.GetValueOrDefault(5));
        }
        
        public static string SessionGenrator(int count)
        {
            string res = "";
            Random rnd = new Random();

            for (int i = 0; i < count; i++)
            {
                switch (rnd.Next(1, 3))
                {
                    case 1:
                        res += (char)rnd.Next(97, 123);
                        break;
                    case 2:
                        res += (char)rnd.Next(48, 58);
                        break;
                }
            }
            

            return res;
        }
    }
}
