using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using CarProject.DBSEF;
using System.ComponentModel.DataAnnotations;

namespace CarProject.Areas.Admin.Models.Cars
{
    public class NewCar : IValidatableObject
    {
        public DBSEF.CarAutomationEntities dbs = new CarAutomationEntities();

        public string CarTempID { get; set; }

        public Car CarGeneral { get; set; }
        public string[] CarClassTypeItems { get { return new string[] { "سدان", "کوپه", "کراس آور", "شاسی بلند", "وانت" }; } }

        public CarEngine CarEngine { get; set; }
        public string[] CarEngineTypeItems { get { return new string[] { "خطی", "خورجینی", "باکسری" }; } }
        public string[] CarEngineFuelTypeItems
        {
            get
            {
                return new string[] { "بنزین", "گازوئیل", "دوگانه سوز بنزین و گاز طبیعی", "برقی", "گاز طبیعی" };
            }
        }

        public CarGearBox CarGearBox { get; set; }
        public string[] carGearBoxTypeItems { get { return new string[] { "اتوماتیک", "دستی" }; } }
        public string[] DiffSetItems { get { return new string[] { "عقب", "جلو", "جلو و عقب" }; } }

        public CarPhysicalDetail CarPhysicalDetail { get; set; }
        public FuelConsumption FuelConsumption { get; set; }
        public BrakeSystem BreakSystem { get; set; }
        public List<DetailedBrakeSystem> DetailedBrakeSystem { get; set; }
        public SecuritySystem SecuritySystem { get; set; }
        public SteeringSystem SteeringSystem { get; set; }
        public AirConditioningSystem AirConditioningSystem { get; set; }
        public List<AirConditioningSystemDetail> AirConditioningSystemDetails { get; set; }
        public CarAudioSystem CarAudioSystem { get; set; }
        public CarSeatOption CarSeatOption { get; set; }
        public GlassAndMirror GlassAndMirror { get; set; }
        public CarLightingSystem CarLightingSystem { get; set; }
        public CarSensorsSystem CarSensorsSystem { get; set; }
        public CarAirbag CarAirbag { get; set; }
        public CarWheel CarWheel { get; set; }
        public CarsPro CarsPro { get; set; }
        public CarsReview CarsReview { get; set; }
        public List<CarsReviewPoint> CarsReviewPoint { get; set; }

        

        public List<string> Advantages { get; set; }
        public List<string> Disadvantages { get; set; }

        public bool IsForUpdate { get; set; }

        public NewCar()
        {
            CarTempID = Guid.NewGuid().ToString();

            CarGeneral = new Car();
            CarEngine = new CarEngine();
            CarGearBox = new CarGearBox();
            CarPhysicalDetail = new CarPhysicalDetail();
            FuelConsumption = new DBSEF.FuelConsumption();
            DetailedBrakeSystem = new List<DBSEF.DetailedBrakeSystem>();
            BreakSystem = new BrakeSystem();
            SecuritySystem = new SecuritySystem();
            SteeringSystem = new SteeringSystem();
            CarsReviewPoint = new List<CarsReviewPoint>();
            AirConditioningSystem = new AirConditioningSystem();
            AirConditioningSystemDetails = new List<AirConditioningSystemDetail>();
            CarAudioSystem = new CarAudioSystem();
            CarSeatOption = new CarSeatOption();
            GlassAndMirror = new GlassAndMirror();
            CarLightingSystem = new CarLightingSystem();
            CarSensorsSystem = new CarSensorsSystem();
            CarAirbag = new CarAirbag();
            CarWheel = new CarWheel();
            CarsPro = new CarsPro();
            CarsReview = new CarsReview();


            Advantages = new List<string>();
            Disadvantages = new List<string>();
            IsForUpdate = false;
        }

        public NewCar(int carid)
        {
            IsForUpdate = true;

            this.CarGeneral = dbs.Cars.FirstOrDefault(c => c.CarsId == carid);
            this.CarEngine = dbs.CarEngines.FirstOrDefault(c => c.CarsId == carid);
            CarGearBox = dbs.CarGearBoxes.FirstOrDefault(c => c.CarsId == carid);
            CarPhysicalDetail = dbs.CarPhysicalDetails.FirstOrDefault(c => c.CarId == carid);
            FuelConsumption = dbs.FuelConsumptions.FirstOrDefault(c => c.CarId == carid);
            DetailedBrakeSystem = dbs.DetailedBrakeSystems.Where(c => c.CarId == carid).ToList();
            BreakSystem = dbs.BrakeSystems.FirstOrDefault(c => c.CarId == carid);
            SecuritySystem = dbs.SecuritySystems.FirstOrDefault(c => c.CarId == carid);
            SteeringSystem = dbs.SteeringSystems.FirstOrDefault(c => c.CarId == carid);
            CarsReviewPoint = dbs.CarsReviewPoints.Where(c => c.CarsId == carid).ToList();
            AirConditioningSystem = dbs.AirConditioningSystems.FirstOrDefault(c => c.CarId == carid);
            AirConditioningSystemDetails = dbs.AirConditioningSystemDetails.Where(c => c.CarsId == carid).ToList();
            CarAudioSystem = dbs.CarAudioSystems.FirstOrDefault(c => c.CarsId == carid);
            CarSeatOption = dbs.CarSeatOptions.FirstOrDefault(c => c.CarsId == carid);
            GlassAndMirror = dbs.GlassAndMirrors.FirstOrDefault(c => c.CarsId == carid);
            CarLightingSystem = dbs.CarLightingSystems.FirstOrDefault(c => c.CarsId == carid);
            CarSensorsSystem = dbs.CarSensorsSystems.FirstOrDefault(c => c.CarsId == carid);
            CarAirbag = dbs.CarAirbags.FirstOrDefault(c => c.CarsId == carid);
            CarWheel = dbs.CarWheels.FirstOrDefault(c => c.CarsId == carid);
            CarsReview = dbs.CarsReviews.FirstOrDefault(c => c.CarsId == carid);


            Advantages = dbs.CarsProes.Where(c => c.CarsProOrCro == true).Select(c => c.CarProCro).ToList();
            Disadvantages = dbs.CarsProes.Where(c => c.CarsProOrCro == false).Select(c => c.CarProCro).ToList();
        }


        public void Save()
        {
            if (IsForUpdate)
            {
                update();
                return;
            }
            dbs.Cars.Add(CarGeneral);

            CarEngine.Car = CarGeneral;
            dbs.CarEngines.Add(CarEngine);

            FuelConsumption.Car = CarGeneral;
            dbs.FuelConsumptions.Add(FuelConsumption);

            CarGearBox.Car = CarGeneral;
            dbs.CarGearBoxes.Add(CarGearBox);

            CarPhysicalDetail.Car = CarGeneral;
            dbs.CarPhysicalDetails.Add(CarPhysicalDetail);

            BreakSystem.Car = CarGeneral;
            dbs.BrakeSystems.Add(BreakSystem);

            foreach (var item in DetailedBrakeSystem)
            {
                if (!item.Equals(null))
                {
                    item.Car = CarGeneral;
                    dbs.DetailedBrakeSystems.Add(item);
                }
            }

            SecuritySystem.Car = CarGeneral;
            dbs.SecuritySystems.Add(SecuritySystem);

            SteeringSystem.Car = CarGeneral;
            dbs.SteeringSystems.Add(SteeringSystem);

            AirConditioningSystem.Car = CarGeneral;
            dbs.AirConditioningSystems.Add(AirConditioningSystem);

            foreach (var item in AirConditioningSystemDetails)
            {
                item.Car = CarGeneral;
                dbs.AirConditioningSystemDetails.Add(item);
            }

            foreach (var item in CarsReviewPoint)
            {
                item.Car = CarGeneral;
                dbs.CarsReviewPoints.Add(item);
            }

            CarAudioSystem.Car = CarGeneral;
            dbs.CarAudioSystems.Add(CarAudioSystem);

            CarSeatOption.Car = CarGeneral;
            dbs.CarSeatOptions.Add(CarSeatOption);

            GlassAndMirror.Car = CarGeneral;
            dbs.GlassAndMirrors.Add(GlassAndMirror);

            CarLightingSystem.Car = CarGeneral;
            dbs.CarLightingSystems.Add(CarLightingSystem);

            CarSensorsSystem.Car = CarGeneral;
            dbs.CarSensorsSystems.Add(CarSensorsSystem);

            CarAirbag.Car = CarGeneral;
            dbs.CarAirbags.Add(CarAirbag);

            foreach (var item in Advantages)
            {
                if (!item.Equals(null))
                {
                    dbs.CarsProes.Add(new CarsPro { Car = CarGeneral, CarsProOrCro = true, CarProCro = item });
                }
            }

            foreach (var item in Disadvantages)
            {
                dbs.CarsProes.Add(new CarsPro { Car = CarGeneral, CarsProOrCro = false, CarProCro = item });
            }

            CarsReview.Car = CarGeneral;
            dbs.CarsReviews.Add(CarsReview);

            CarWheel.Car = CarGeneral;
            dbs.CarWheels.Add(CarWheel);

            dbs.SaveChanges();
        }

        void update()
        {
            dbs.DetailedBrakeSystems.RemoveRange(dbs.DetailedBrakeSystems.Where(c => c.CarId == CarGeneral.CarsId));
            foreach (var item in DetailedBrakeSystem)
            {
                if (!item.Equals(null))
                {
                    item.Car = CarGeneral;
                    dbs.DetailedBrakeSystems.Add(item);
                }
            }

            dbs.AirConditioningSystemDetails.RemoveRange(dbs.AirConditioningSystemDetails.Where(c => c.CarsId == CarGeneral.CarsId));
            foreach (var item in AirConditioningSystemDetails)
            {
                item.Car = CarGeneral;
                dbs.AirConditioningSystemDetails.Add(item);
            }


            dbs.CarsReviewPoints.RemoveRange(dbs.CarsReviewPoints.Where(c => c.CarsId == CarGeneral.CarsId));
            foreach (var item in CarsReviewPoint)
            {
                item.Car = CarGeneral;
                dbs.CarsReviewPoints.Add(item);
            }


            dbs.CarsProes.RemoveRange(dbs.CarsProes.Where(c => c.CarsId == CarGeneral.CarsId));
            foreach (var item in Advantages)
            {
                if (!item.Equals(null))
                {
                    dbs.CarsProes.Add(new CarsPro { Car = CarGeneral, CarsProOrCro = true, CarProCro = item });
                }
            }

            foreach (var item in Disadvantages)
            {
                dbs.CarsProes.Add(new CarsPro { Car = CarGeneral, CarsProOrCro = false, CarProCro = item });
            }

            dbs.SaveChanges();
        }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrWhiteSpace(CarGeneral.CarsBrandName))
                yield return new ValidationResult("این فیلد اجباری است", new string[] { "CarGeneral.CarsBrandName" });

        }
    }
}