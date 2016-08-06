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
        public Car CarGeneral { get; set; }
        public string[] CarClassTypeItems { get { return new string[] { "سدان" }; } }

        public CarEngine CarEngine { get; set; }
        public CarGearBox CarGearBox { get; set; }
        public CarPhysicalDetail CarPhysicalDetail { get; set; }
        public BrakeSystem BreakSystem { get; set; }
        public SecuritySystem SecuritySystem { get; set; }
        public SteeringSystem SteeringSystem { get; set; }
        public AirConditioningSystem AirConditioningSystem { get; set; }

        public List<byte[]> CarImages { get; set; }

        public NewCar()
        {
            CarGeneral = new Car();
            CarEngine = new CarEngine();
            CarGearBox = new CarGearBox();
            CarPhysicalDetail = new CarPhysicalDetail();
            BreakSystem = new BrakeSystem();
            SecuritySystem = new SecuritySystem();
            SteeringSystem = new SteeringSystem();
            AirConditioningSystem = new AirConditioningSystem();
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrWhiteSpace(CarGeneral.CarsBrandName))
                yield return new ValidationResult("این فیلد اجباری است", new string[] { "CarGeneral.CarsBrandName" });
            
        }
    }
}