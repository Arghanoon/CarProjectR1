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
        public db.SecuritySystem SecuritySystem { get; set; }
        public db.SteeringSystem SteeringSystem { get; set; }
        public db.AirConditioningSystem AirConditioningSystem { get; set; }
        public List<db.AirConditioningSystemDetail> AirConditioningSystemDetails { get; set; }

        public db.CarAudioSystem CarAudioSystem { get; set; }
        public db.CarSeatOption CarSeatOption { get; set; }
        public db.GlassAndMirror GlassAndMirror { get; set; }
        public List<string> List_WindscreensTypes { get { return new List<string> { "دستی", "برقی" }; } }
        public List<string> List_SideMirrorTypes { get { return new List<string> { "دستی", "برقی" }; } }
        public List<string> List_SideMirrorSystemTypes { get { return new List<string> { "ندارد", "دستی", "برقی" }; } }

        public db.CarLightingSystem CarLightingSystem { get; set; }
        public db.CarSensorsSystem CarSensorsSystem { get; set; }
        public db.CarAirbag CarAirbag { get; set; }
        public db.CarWheel CarWheel { get; set; }


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
            SecuritySystem = new db.SecuritySystem();
            SteeringSystem = new db.SteeringSystem();
            AirConditioningSystem = new db.AirConditioningSystem();
            AirConditioningSystemDetails = new List<db.AirConditioningSystemDetail>();

            CarAudioSystem = new db.CarAudioSystem();
            CarSeatOption = new db.CarSeatOption();
            GlassAndMirror = new db.GlassAndMirror();

            CarLightingSystem = new db.CarLightingSystem();
            CarSensorsSystem = new db.CarSensorsSystem();
            CarAirbag = new db.CarAirbag();
            CarWheel = new db.CarWheel();
        }
    }
}