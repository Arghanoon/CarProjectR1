using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using CarProject.App_Code;

namespace CarProject.Areas.Admin.Controllers
{
    public class FileManagerController : Controller
    {
        //
        // GET: /Admin/FileManager/

        public ActionResult Index(string path)
        {
            return View(model: path);
        }


        public JsonResult GetImages(string path)
        {
            var rtdirel = "~/Publics/Filemanager";
            if (path != null && !path.IsNullOrWhiteSpace())
                rtdirel = Path.Combine(rtdirel, path).Replace('\\', '/');
            
            var dic = new DirectoryInfo(Server.MapPath(rtdirel));
            List<dynamic> dirs = new List<dynamic>();
            List<dynamic> images = new List<dynamic>();
            foreach (var item in dic.GetDirectories())
            {
                dirs.Add(new { name = item.Name, path = Url.Content(Path.Combine(rtdirel, item.Name).Replace('\\', '/')) });
            }
            foreach (var item in dic.GetFiles())
            {
                images.Add(new { name = item.Name, path = Url.Content(Path.Combine(rtdirel, item.Name).Replace('\\', '/')) });
            }
            return Json(new { DIR = dirs, IMGS = images }, JsonRequestBehavior.AllowGet);
        }
    }
}
