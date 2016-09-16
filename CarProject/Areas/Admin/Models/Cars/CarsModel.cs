using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using db = CarProject.DBSEF;

namespace CarProject.Areas.Admin.Models.Cars
{
    public class CarsModel
    {
        public db.CarBrand CarBrand { get; set; }
        public db.CarModel CarModel { get; set; }


        public CarsModel()
        {
            CarBrand = new db.CarBrand();
            CarModel = new db.CarModel();
        }
    }
}