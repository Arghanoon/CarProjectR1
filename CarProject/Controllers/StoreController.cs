using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarProject.Controllers
{
    public class StoreController : Controller
    {
        //
        // GET: /Store/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Products(int id)
        {
            return View(id);
        }
        
        [HttpPost]
        public int Products_makePopular(int id)
        {
            var dbs = new DBSEF.CarAutomationEntities();
            int res = 0;
            if (dbs.ProductToViews.Count(p => p.ProductId == id) > 0)
            {
                var x = dbs.ProductToViews.FirstOrDefault(p => p.ProductId == id);
                if (x != null)
                {
                    if (x.Favorite == null || x.Favorite <= 0)
                    { x.Favorite = 1; res = 1; }
                    else
                    { x.Favorite += 1; res = x.Favorite.Value; }
                }
            }

            dbs.SaveChanges();
            return res;
        }

        public ActionResult ProductsList(int? id)
        {
            return View(id);
        }
    }
}
