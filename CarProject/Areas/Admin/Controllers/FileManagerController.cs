using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

    }
}
