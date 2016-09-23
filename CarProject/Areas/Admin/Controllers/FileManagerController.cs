using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using CarProject.App_extension;

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
        [HttpPost]
        public void RenameRequest(string address, string newname)
        {
            var file = new FileInfo(Server.MapPath(address));
            if (file.Attributes == FileAttributes.Directory && Directory.Exists(file.FullName))
                Directory.Move(file.FullName, file.FullName.Replace(file.Name, newname));
            else if (file.Exists)
                file.MoveTo(file.FullName.Replace(file.Name, newname));
            
        }
        [HttpPost]
        public void CreateNewDir(string current, string dir)
        {
            if (dir.IsNullOrWhiteSpace())
                return;
            var rtdirel = "~/Publics/Filemanager";
            if (current != null && !current.IsNullOrWhiteSpace())
                rtdirel = Path.Combine(rtdirel, current).Replace('\\', '/');

            rtdirel = Path.Combine(rtdirel, dir).Replace('\\', '/');

            DirectoryInfo dirinf = new DirectoryInfo(Server.MapPath(rtdirel));
            if (!dirinf.Exists)
                dirinf.Create(Directory.GetAccessControl(Server.MapPath("~/Publics/Filemanager")));
        }

        [HttpPost]
        public void UploadFile(string current)
        {
            if (Request.Files.AllKeys.Contains("file"))
            {
                var rtdirel = "~/Publics/Filemanager";
                if (current != null && !current.IsNullOrWhiteSpace())
                    rtdirel = Path.Combine(rtdirel, current).Replace('\\', '/');
                var dir = new DirectoryInfo(Server.MapPath(rtdirel));

                Request.Files["file"].SaveAs(Path.Combine(dir.FullName, Request.Files["file"].FileName));
            }
        }
    }
}
