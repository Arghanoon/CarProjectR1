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
        public DBSEF.PersonCarDetail Detail { get; set; }

        public string LastOilChangeDate { get; set; }
        public string LastFiltersChangeDate { get; set; }

        public bool UpdateOrginalValues { get; set; }

        public UserCarsModel()
        {
            PCar = new DBSEF.PersonCar();
            Detail = new DBSEF.PersonCarDetail();
            UpdateOrginalValues = false;
        }

        public UserCarsModel(int? id)
        {
            PCar = DBS.PersonCars.FirstOrDefault(pc => pc.PersonCarsId == id);
        }

        public void Save()
        {
            Detail.LastOilChange = LastOilChangeDate.Persian_ToDateTime();
            Detail.LastFiltersChange = LastOilChangeDate.Persian_ToDateTime();

            PCar.PersonCarDetails.Add(Detail);
            DBS.PersonCars.Add(PCar);
            DBS.SaveChanges();
        }

        public void Update()
        {
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


            if (!UpdateOrginalValues)
            {
                if (Detail.LastFilterChangeMilage == null)
                    result.Add(new ValidationResult("کیلومت آخرین تعویض فیلتر وارد نشده است", new string[] { "Detail.LastFilterChangeMilage" }));

                if (LastFiltersChangeDate.IsNullOrWhiteSpace())
                    result.Add(new ValidationResult("تاریخ آخرین تعویض فیلتر وارد نشده است", new string[] { "LastFiltersChangeDate" }));
                else if (!LastFiltersChangeDate.IsPersianDateTime())
                    result.Add(new ValidationResult("تاریخ آخرین تعویض فیلتر وارد شده صحیح نیست", new string[] { "LastFiltersChangeDate" }));

                if (Detail.LastOilChangeMilage == null)
                    result.Add(new ValidationResult("کیلومتر آخرین تعویض روغن وارد نشده است", new string[] { "Detail.LastOilChangeMilage" }));

                if (LastOilChangeDate.IsNullOrWhiteSpace())
                    result.Add(new ValidationResult("تاریخ آخرین تعویض روغن وارد نشده است", new string[] { "LastOilChangeDate" }));
                else if (!LastOilChangeDate.IsPersianDateTime())
                    result.Add(new ValidationResult("تاریخ آخرین تعویض روغن وارد شده صحیح نیست", new string[] { "LastOilChangeDate" }));
            }
            return result;
        }
    }
}