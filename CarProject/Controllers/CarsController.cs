using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using CarProject.CLS;
using CarProject.CLS.Searchs;
using CarProject.Models;
using db = CarProject.DBSEF;

namespace CarProject.Controllers
{
    public class CarsController : Controller
    {
        private const int PageSize = 20;
        //public ActionResult Index(int page = 1,string sort = "", UserSearchViewModel search)
        //
        // GET: /Cars/
        public db.CarAutomationEntities CAE = new db.CarAutomationEntities();
        public db.CarBrand c = new db.CarBrand();
        [HttpGet]
        public ActionResult Index()
        {
            CarProject.CLS.Searchs.CarsSearchLogic cs = new CarsSearchLogic();
            string[] carbrandname = new[] {"Acura", "Chevrolet"};
            string[] gearboxaxel = new[] {"4WD"};
            int[] gearboxcylandr = new[] {3, 4};
            SearchModel sm = new SearchModel();
            sm.brandname = carbrandname;
            sm.gearboxaxle = gearboxaxel;
            
            var s = cs.GetJoinedView(sm);
            var model = new SearchClass();
            var dbs = new DBSEF.CarAutomationEntities();
            var list = dbs.CarBrands.ToArray();
            var checkBoxListItems = new List<CheckBoxListItem>();
            foreach (var genre in list)
            {
                checkBoxListItems.Add(new CheckBoxListItem()
                {
                    ID = genre.CarBrandId,
                    Display = genre.CarBrandName,
                    IsChecked = false //On the add view, no genres are selected by default
                });
            }
            model.BrandName = checkBoxListItems;
            return View(model);
        }

        [HttpGet]
        public ActionResult add()
        {
            return add();
        }

        [HttpPost]
       
        public ActionResult Index(string[] CarBrands)
        {

            //var GenreLst = new List<string>();
            //var GenreQry = from d in c.CarBrandName select c.CarBrandName;
            //GenreLst.AddRange(GenreQry.Distinct());
            //ViewBag.searchresult = new SelectList(GenreLst);
            var cars = from m in CAE.CarBrands select m;
            //for (int i = 0; i < CarBrands.Length; i++)
            //{
            //    if (!string.IsNullOrEmpty(CarBrands[i]))
            //    {
            //        cars = cars.Where(x => x.CarBrandName == CarBrands[i]);
            //    }
            //}


            for (int i = 0; i < CarBrands.Length; i++)
            {
                cars = cars.Where(x => x.CarBrandName == CarBrands[i]);
            }
            var CarList = from n in CAE.Cars select n;

            return View();

        }

        public ActionResult Car(int id)
        {

            return View();
        }

        public class tst
        {
            public string username { get; set; }
            public string fullname { get; set; }
        }

        public class tstcol : System.Collections.ObjectModel.ObservableCollection<tst>
        {
            public tstcol()
            {
                for (int i = 0; i < 100; i++)
                {
                    this.Add(new tst {username = "Username" + i.ToString(), fullname = "Fullname " + i.ToString()});
                }
            }
        }

        public List<db.CarBrand> BindBrand()
        {
            List<db.CarBrand> _objcountry = new List<db.CarBrand>();
            return _objcountry;
        }

        public ActionResult SearchView()
        {
            var model = new SearchClass();
            var dbs = new DBSEF.CarAutomationEntities();
            var list = dbs.CarBrands.ToArray();
            var checkBoxListItems = new List<CheckBoxListItem>();
            foreach (var genre in list)
            {
                checkBoxListItems.Add(new CheckBoxListItem()
                {
                    ID = genre.CarBrandId,
                    Display = genre.CarBrandName,
                    IsChecked = false //On the add view, no genres are selected by default
                });
            }
            model.BrandName = checkBoxListItems;
            return View(model);
        }
    }
}

