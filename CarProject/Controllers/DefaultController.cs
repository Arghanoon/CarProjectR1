using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Text;
using Newtonsoft.Json;


namespace CarProject.Controllers
{
    public class DefaultController : Controller
    {
        //
        // GET: /Default/

        public static string CaptchaStringSession { get { return (System.Web.HttpContext.Current.Session["CRNTCAPTCHA"] != null) ? System.Web.HttpContext.Current.Session["CRNTCAPTCHA"].ToString() : ""; } set { System.Web.HttpContext.Current.Session["CRNTCAPTCHA"] = value; } }
        public static bool ValidationCaptcha(string inputCaptcha) { return CaptchaStringSession == inputCaptcha; }
        public static bool ValidationRecaptcha(string response)
        {
            bool res = false;
            var wb = (HttpWebRequest)WebRequest.Create("https://www.google.com/recaptcha/api/siteverify");
            wb.Method = "POST";
            wb.ContentType = "application/x-www-form-urlencoded";
            var postdata = Encoding.UTF8.GetBytes(string.Format("secret={0}&response={1}", "6Lff2xAUAAAAALbQ20JPxj1WhsmUOhEMwuJXKF4x", response));
            wb.ContentLength = postdata.Length;

            using (var ssr = wb.GetRequestStream())
            {
                ssr.Write(postdata, 0, postdata.Length);
            }

            var resp = wb.GetResponse();
            using (var rsr = resp.GetResponseStream())
            {
                List<byte> lb = new List<byte>();
                while (true)
                {
                    int b = rsr.ReadByte();
                    if (b == -1)
                        break;
                    lb.Add((byte)b);
                }

                dynamic strres = JsonConvert.DeserializeObject(Encoding.UTF8.GetString(lb.ToArray()));
                res = strres.success;
                
            }

            return res;
        }

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
