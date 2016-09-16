using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using db = CarProject.DBSEF;

namespace CarProject.Areas.Admin.Models.Cars
{
    public class CarsModel
    {
        public db.Car Car { get; set; }
        public List<string> List_CarBodyTypes { get { return new List<string> { "سقف فلزی", "سقف جمع شو(کروک)" }; } }
        
        public db.CarEngine CarEngine { get; set; }
        public List<string> List_EngineTypes { get { return new List<string> { "V شکل", "I شکل", "باکسری" }; } }
        public List<string> List_EngineFuel { get { return new List<string> { "بنزین", "گاز", "گازوئیل", "برق" }; } }
        
        public db.CarGearBox GearBox { get; set; }
        public List<string> List_GearBoxType { get { return new List<string> { "اتوماتیک", "دستی", "تیپ ترونیک" }; } }

        public db.CarPhysicalDetail PhysicalDetail { get; set; }
        public db.BrakeSystem BrakeSystem { get; set; }
        public List<db.DetailedBrakeSystem> DetailedBrakeSystems { get; set; }

        public db.FuelConsumption FuelConsumption { get; set; }

        

        public CarsModel()
        {
            Car = new db.Car();
            Car.CarModel = new db.CarModel();
            Car.CarModel.CarBrand = new db.CarBrand();

            CarEngine = new db.CarEngine();

            GearBox = new db.CarGearBox();
            BrakeSystem = new db.BrakeSystem();
            DetailedBrakeSystems = new List<db.DetailedBrakeSystem>();

            FuelConsumption = new db.FuelConsumption();
        }
    }
}