using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

using CarProject.App_extension;

namespace CarProject.Areas.Users.Models.Personality
{
    public class UserCarsModel : IValidatableObject
    {
        public DBSEF.CarAutomationEntities DBS = new DBSEF.CarAutomationEntities();

        public DBSEF.PersonCar PCar { get; set; }

        public UserCarsModel()
        {
            PCar = new DBSEF.PersonCar();
        }

        public void Save()
        {
            DBS.PersonCars.Add(PCar);
            DBS.SaveChanges();
        }
        
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> result = new List<ValidationResult>();

            if (PCar.CarId == null || PCar.CarId < 0)
                result.Add(new ValidationResult("خودرو انتخاب نشده است", new string[] { "PCar.CarId" }));
            if (PCar.CarMilage == null)
                result.Add(new ValidationResult("کارکرد خودرو تعیین نشده است", new string[] { "PCar.CarMilage" }));
            if (PCar.CarCreationDate.IsNullOrWhiteSpace())
                result.Add(new ValidationResult("سال ساخت تعیین نشده است", new string[] { "PCar.CarCreationDate" }));
            else if (!PCar.CarCreationDate.IsNumber())
                result.Add(new ValidationResult("سال ساخت باید به صورت عدد باشد", new string[] { "PCar.CarCreationDate" }));

            return result;
        }
    }
}