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

        

        public List<string> Advantages { get; set; }
        public List<string> Disadvantages { get; set; }

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
        }


        public void Save()
        {
            DBSEF.CarAutomationEntities ca = new CarAutomationEntities();
            ca.Cars.Add(CarGeneral);

            CarEngine.Car = CarGeneral;
            ca.CarEngines.Add(CarEngine);

            FuelConsumption.Car = CarGeneral;
            ca.FuelConsumptions.Add(FuelConsumption);

            CarGearBox.Car = CarGeneral;
            ca.CarGearBoxes.Add(CarGearBox);

            CarPhysicalDetail.Car = CarGeneral;
            ca.CarPhysicalDetails.Add(CarPhysicalDetail);

            BreakSystem.Car = CarGeneral;
            ca.BrakeSystems.Add(BreakSystem);

            foreach (var item in DetailedBrakeSystem)
            {
                if (!item.Equals(null))
                {
                    item.Car = CarGeneral;
                    ca.DetailedBrakeSystems.Add(item);
                }
            }

            SecuritySystem.Car = CarGeneral;
            ca.SecuritySystems.Add(SecuritySystem);

            SteeringSystem.Car = CarGeneral;
            ca.SteeringSystems.Add(SteeringSystem);

            AirConditioningSystem.Car = CarGeneral;
            ca.AirConditioningSystems.Add(AirConditioningSystem);

            foreach (var item in AirConditioningSystemDetails)
            {
                item.Car = CarGeneral;
                ca.AirConditioningSystemDetails.Add(item);
            }

            CarAudioSystem.Car = CarGeneral;
            ca.CarAudioSystems.Add(CarAudioSystem);

            CarSeatOption.Car = CarGeneral;
            ca.CarSeatOptions.Add(CarSeatOption);

            GlassAndMirror.Car = CarGeneral;
            ca.GlassAndMirrors.Add(GlassAndMirror);

            CarLightingSystem.Car = CarGeneral;
            ca.CarLightingSystems.Add(CarLightingSystem);

            CarSensorsSystem.Car = CarGeneral;
            ca.CarSensorsSystems.Add(CarSensorsSystem);

            CarAirbag.Car = CarGeneral;
            ca.CarAirbags.Add(CarAirbag);

            foreach (var item in Advantages)
            {
                if (!item.Equals(null))
                {
                    ca.CarsProes.Add(new CarsPro { Car = CarGeneral, CarsProOrCro = true, CarProCro = item });
                }
            }

            foreach (var item in Disadvantages)
            {
                ca.CarsProes.Add(new CarsPro { Car = CarGeneral, CarsProOrCro = false, CarProCro = item });
            }

            CarsReview.Car = CarGeneral;
            ca.CarsReviews.Add(CarsReview);

            CarWheel.Car = CarGeneral;
            ca.CarWheels.Add(CarWheel);

            ca.SaveChanges();
        }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrWhiteSpace(CarGeneral.CarsBrandName))
                yield return new ValidationResult("این فیلد اجباری است", new string[] { "CarGeneral.CarsBrandName" });

        }
    }
}