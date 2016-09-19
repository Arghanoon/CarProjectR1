using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using CarProject.DBSEF;

namespace CarProject.CLS
{
    public class SearchClass
    {
        [Display(Name = "برند خودرو")]
        public List<CheckBoxListItem> BrandName { get; set; }
        public int brandId { get; set; }
        [Display(Name = "کلاس خودرو")]
        public string CarClassType { get; set; }
        [Display(Name = "دسته بندی خودرو")]
        public string CarCategory { get; set; }
        [Display(Name = "مورد استفاده خودرو")]
        public string CarUsage { get; set; }
        [Display(Name = "نوع گیربکس خودرو")]
        public string GearBoxType { get; set; }
        [Display(Name = "محور متحرک گیربکس خودرو")]
        public string GearBoxAxel { get; set; }
        public List<Car> Car { get; set; }
        public Int32 Page { get; set; }
        public Int32 PageSize { get; set; }
        public String Sort { get; set; }
        public String SortDir { get; set; }

        public SearchClass()
        {
            BrandName = new List<CheckBoxListItem>();
        }


        public IEnumerable<CarBrand> GetAllBrands()
        {
            using (CarAutomationEntities context = new CarAutomationEntities())
            {
                return context.CarBrands.Select(x => new CarBrand());
            }
        } 
    }

    public class CarBrandListModel
    {
        public List<CarBrand> CarBrandList { get; set; }
    }

    public class CarBrandList
    {
        public int CarBrandId { get; set; }
        public int CarModelId { get; set; }
        public string CarBrandNam { get; set; }
    }
    public class CheckBoxListItem
    {
        public int ID { get; set; }
        public string Display { get; set; }
        public bool IsChecked { get; set; }
    }

}