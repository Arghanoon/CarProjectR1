using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using db = CarProject.DBSEF;

namespace CarProject.Areas.Admin.Models.Cars
{
    public class CarsModel
    {
        db.CarAutomationEntities DBS = new db.CarAutomationEntities();

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

        public List<string> Advantages { get; set; }
        public List<string> DisAdvatages { get; set; }

        public db.CarsReview CarsReview { get; set; }
        [AllowHtml]
        public string CarsRviewHtml { get { return this.CarsReview.Review; } set { this.CarsReview.Review = value; } }

        public CarsModel()
        {
            Car = new db.Car();

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

            Advantages = new List<string>();
            DisAdvatages = new List<string>();

            CarsReview = new db.CarsReview();
        }

        public void Save()
        {
            DBS.Cars.Add(this.Car);

            this.CarEngine.Car = this.Car;
            DBS.CarEngines.Add(this.CarEngine);

            this.GearBox.Car = this.Car;
            DBS.CarGearBoxes.Add(this.GearBox);

            this.PhysicalDetail.Car = this.Car;
            DBS.CarPhysicalDetails.Add(this.PhysicalDetail);

            this.BrakeSystem.Car = this.Car;
            DBS.BrakeSystems.Add(this.BrakeSystem);

            foreach (var item in this.DetailedBrakeSystems)
            {
                item.Car = this.Car;
                DBS.DetailedBrakeSystems.Add(item);
            }

            this.FuelConsumption.Car = this.Car;
            DBS.FuelConsumptions.Add(this.FuelConsumption);

            this.SecuritySystem.Car = this.Car;
            DBS.SecuritySystems.Add(this.SecuritySystem);

            this.SteeringSystem.Car = this.Car;
            DBS.SteeringSystems.Add(this.SteeringSystem);

            this.AirConditioningSystem.Car = this.Car;
            DBS.AirConditioningSystems.Add(this.AirConditioningSystem);

            foreach (var item in this.AirConditioningSystemDetails)
            {
                item.Car = this.Car;
                DBS.AirConditioningSystemDetails.Add(item);
            }

            this.CarAudioSystem.Car = this.Car;
            DBS.CarAudioSystems.Add(this.CarAudioSystem);

            this.CarSeatOption.Car = this.Car;
            DBS.CarSeatOptions.Add(this.CarSeatOption);

            this.GlassAndMirror.Car = this.Car;
            DBS.GlassAndMirrors.Add(this.GlassAndMirror);

            this.CarLightingSystem.Car = this.Car;
            DBS.CarLightingSystems.Add(this.CarLightingSystem);

            this.CarSensorsSystem.Car = this.Car;
            DBS.CarSensorsSystems.Add(this.CarSensorsSystem);

            this.CarAirbag.Car = this.Car;
            DBS.CarAirbags.Add(this.CarAirbag);

            this.CarWheel.Car = this.Car;
            DBS.CarWheels.Add(this.CarWheel);

            foreach (var item in Advantages)
            {
                DBS.CarsProes.Add(new db.CarsPro { CarProCro = item, CarsProOrCro = true });
            }
            foreach (var item in DisAdvatages)
            {
                DBS.CarsProes.Add(new db.CarsPro { CarProCro = item, CarsProOrCro = false });
            }

            this.CarsReview.Car = this.Car;
            DBS.CarsReviews.Add(this.CarsReview);

            DBS.SaveChanges();
        }
    }
}