using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using db = CarProject.DBSEF;
using CarProject.App_extension;

namespace CarProject.Areas.Admin.Models.Cars
{
    public class CarsModel : IValidatableObject
    {
        db.CarAutomationEntities DBS = new db.CarAutomationEntities();

        public db.Car Car { get; set; }
        public List<string> List_CarType { get { return new List<string> { "هاچ بک", "سدان", "کوپه", "SUV", "کراس اوور", "وانت" }; } }
        public List<string> List_CarClass { get { return new List<string> { "بسیار کوچک", "کامپکت کوچک", "کامپکت متوسط", "کامپکت بزرگ", "کوچک", "متوسط", "بزرگ", "لوکس کوچک", "لوکس متوسط", "لوکس بزرگ", "سوپر لوکس", "اسپرت", "سوپر اسپرت", "کروکی", "رودسر", "ون", "SUV کوچک", "SUV متوسط", "SUV بزرگ", "SUV فول سایز", "SUV اسپرت" }; } }

        //      public List<string> CarClass { get { return new List<string> { }; } }

        public db.CarDetail CarDetail { get; set; }

        public List<string> List_CarUsage { get { return new List<string> { "شهری", "خانوادگی", "ترکیبی", "آفرود" }; } }

        public List<string> List_YesOrNo { get { return new List<string> { "بله", "خیر" }; } }

        public List<string> List_CarBodyTypes { get { return new List<string> { "سقف فلزی", "سقف جمع شو(کروک)" }; } }

        public db.CarEngine CarEngine { get; set; }
        public List<string> List_EngineTypes { get { return new List<string> { "خورجینی", "خطی", "باکسری" }; } }
        public List<string> List_EngineFuel { get { return new List<string> { "بنزین", "گاز", "گازوئیل", "هیبرید" }; } }

        public db.CarGearBox GearBox { get; set; }
        public List<string> List_GearBoxType { get { return new List<string> { "اتوماتیک", "دستی" }; } }
        public List<string> List_gearBoxAxel { get { return new List<string> { "جلو", "عقب", "AWD", "4WD" }; } }

        public List<string> List_HandBrake { get { return new List<string> { "دستی", "برقی", "پدالی" }; } }
        public List<string> List_SeatOption { get { return new List<string> { "دستی", "برقی" }; } }
        public db.CarPhysicalDetail PhysicalDetail { get; set; }
        public db.BrakeSystem BrakeSystem { get; set; }
        public List<db.DetailedBrakeSystem> DetailedBrakeSystems { get; set; }

        public db.FuelConsumption FuelConsumption { get; set; }
        public db.SecuritySystem SecuritySystem { get; set; }
        public db.SteeringSystem SteeringSystem { get; set; }
        public db.AirConditioningSystem AirConditioningSystem { get; set; }
        public List<db.AirConditioningSystemDetail> AirConditioningSystemDetails { get; set; }
        public List<db.CarsPro> Pros { get; set; }
        public List<db.CarsPro> Cros { get; set; }
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
            CarDetail = new db.CarDetail();
            
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
            Pros = new List<db.CarsPro>();
            Cros = new List<db.CarsPro>();
            Advantages = new List<string>();
            DisAdvatages = new List<string>();

            CarsReview = new db.CarsReview();
        }

        public CarsModel(int? CarsId)
        {
            Car = DBS.Cars.FirstOrDefault(c => c.CarsId == CarsId);

            CarDetail = DBS.CarDetails.FirstOrDefault(c => c.CarsId == CarsId);

            CarEngine = DBS.CarEngines.FirstOrDefault(c => c.CarsId == CarsId);

            GearBox = DBS.CarGearBoxes.FirstOrDefault(c => c.CarsId == CarsId);
            BrakeSystem = DBS.BrakeSystems.FirstOrDefault(c => c.CarId == CarsId);
            DetailedBrakeSystems = DBS.DetailedBrakeSystems.Where(c => c.CarId == CarsId).ToList();

            FuelConsumption = DBS.FuelConsumptions.FirstOrDefault(c => c.CarId == CarsId);
            SecuritySystem = DBS.SecuritySystems.FirstOrDefault(c => c.CarId == CarsId);
            SteeringSystem = DBS.SteeringSystems.FirstOrDefault(c => c.CarId == CarsId);
            AirConditioningSystem = DBS.AirConditioningSystems.FirstOrDefault(c => c.CarId == CarsId);
            AirConditioningSystemDetails = DBS.AirConditioningSystemDetails.Where(c => c.CarsId == CarsId).ToList();

            CarAudioSystem = DBS.CarAudioSystems.FirstOrDefault(c => c.CarsId == CarsId);
            CarSeatOption = DBS.CarSeatOptions.FirstOrDefault(c => c.CarsId == CarsId);
            GlassAndMirror = DBS.GlassAndMirrors.FirstOrDefault(c => c.CarsId == CarsId);

            CarLightingSystem = DBS.CarLightingSystems.FirstOrDefault(c => c.CarsId == CarsId);
            CarSensorsSystem = DBS.CarSensorsSystems.FirstOrDefault(c => c.CarsId == CarsId);
            CarAirbag = DBS.CarAirbags.FirstOrDefault(c => c.CarsId == CarsId);
            CarWheel = DBS.CarWheels.FirstOrDefault(c => c.CarsId == CarsId);

            Pros = DBS.CarsProes.Where(c => c.CarsId == CarsId).ToList();
            Cros = DBS.CarsProes.Where(c => c.CarsId == CarsId).ToList();

            

            Advantages = DBS.CarsProes.Where(c => c.CarsProOrCro == true).Select(c => c.CarProCro).ToList();
            DisAdvatages = DBS.CarsProes.Where(c => c.CarsProOrCro == false).Select(c => c.CarProCro).ToList();


            CarsReview = DBS.CarsReviews.FirstOrDefault(c => c.CarsId == CarsId);
        }

        public void Save()
        {
            DBS.Cars.Add(this.Car);

            CarDetail.Car = this.Car;
            DBS.CarDetails.Add(CarDetail);

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
                
                DBS.CarsProes.Add(new db.CarsPro { CarProCro = item, CarsProOrCro = true,CarsId = this.Car.CarsId});
            }
            foreach (var item in DisAdvatages)
            {
                DBS.CarsProes.Add(new db.CarsPro { CarProCro = item, CarsProOrCro = false, CarsId = this.Car.CarsId });
            }

            this.CarsReview.Car = this.Car;
            DBS.CarsReviews.Add(this.CarsReview);

            DBS.SaveChanges();
        }
        public void Update()
        {
            DBS.SaveChanges();
        }

        public static void DeleteCar(int? CarsId)
        {
            var DBS = new db.CarAutomationEntities();

            DBS.CarDetails.Remove(DBS.CarDetails.FirstOrDefault(c => c.CarsId == CarsId));

            DBS.CarsQnAs.RemoveRange(DBS.CarsQnAs.Where(cqs => cqs.CarsId == CarsId));

            DBS.CarEngines.Remove(DBS.CarEngines.FirstOrDefault(c => c.CarsId == CarsId));

            DBS.CarGearBoxes.Remove(DBS.CarGearBoxes.FirstOrDefault(c => c.CarsId == CarsId));

            DBS.CarPhysicalDetails.Remove(DBS.CarPhysicalDetails.FirstOrDefault(c => c.CarId == CarsId));

            DBS.BrakeSystems.Remove(DBS.BrakeSystems.FirstOrDefault(c => c.CarId == CarsId));

            DBS.DetailedBrakeSystems.RemoveRange(DBS.DetailedBrakeSystems.Where(c => c.CarId == CarsId));

            DBS.FuelConsumptions.Remove(DBS.FuelConsumptions.FirstOrDefault(c => c.CarId == CarsId));

            DBS.SecuritySystems.Remove(DBS.SecuritySystems.FirstOrDefault(c => c.CarId == CarsId));

            DBS.SteeringSystems.Remove(DBS.SteeringSystems.FirstOrDefault(c => c.CarId == CarsId));

            DBS.AirConditioningSystems.Remove(DBS.AirConditioningSystems.FirstOrDefault(c => c.CarId == CarsId));

            DBS.AirConditioningSystemDetails.RemoveRange(DBS.AirConditioningSystemDetails.Where(c => c.CarsId == CarsId));

            DBS.CarAudioSystems.Remove(DBS.CarAudioSystems.FirstOrDefault(c => c.CarsId == CarsId));

            DBS.CarSeatOptions.Remove(DBS.CarSeatOptions.FirstOrDefault(c => c.CarsId == CarsId));

            DBS.GlassAndMirrors.Remove(DBS.GlassAndMirrors.FirstOrDefault(c => c.CarsId == CarsId));

            DBS.CarLightingSystems.Remove(DBS.CarLightingSystems.FirstOrDefault(c => c.CarsId == CarsId));

            DBS.CarSensorsSystems.Remove(DBS.CarSensorsSystems.FirstOrDefault(c => c.CarsId == CarsId));

            DBS.CarAirbags.Remove(DBS.CarAirbags.FirstOrDefault(c => c.CarsId == c.CarsId));

            DBS.CarWheels.Remove(DBS.CarWheels.FirstOrDefault(c => c.CarsId == c.CarsId));

            DBS.CarsProes.RemoveRange(DBS.CarsProes.Where(c => c.CarsId == CarsId));

            DBS.CarsReviews.Remove(DBS.CarsReviews.FirstOrDefault(c => c.CarsId == CarsId));

            DBS.Cars.Remove(DBS.Cars.FirstOrDefault(c => c.CarsId == CarsId));

            DBS.SaveChanges();
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Car.CarModel.CarBrandId == null)
                yield return new ValidationResult("برند تعیین نشده است", new string[] { "Car.CarModel.CarBrandId" });
            if (Car.CarModel.CarModelName.IsNullOrWhiteSpace())
                yield return new ValidationResult("مدل تعیین نشده است", new string[] { "Car.CarModel.CarModelName" });
        }
    }
}