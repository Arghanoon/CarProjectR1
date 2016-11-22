using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

using CarProject.App_extension;

namespace CarProject.Areas.Users.Models.Dashboard
{
    public class PersonCarsModel : IValidatableObject
    {
        public DBSEF.CarAutomationEntities dbs = new DBSEF.CarAutomationEntities();

        public DBSEF.Person Person { get; set; }
        public DBSEF.PersonCar Car { get; set; }
        public DBSEF.PersonCarDetail Detail { get; set; }

        public string LastOilChange { get; set; }
        public string LastFilterChange { get; set; }

        public PersonCarsModel()
        {
            Car = new DBSEF.PersonCar();
            Detail = new DBSEF.PersonCarDetail();

            var currentUser = Controllers.profileController.GetCurrentLoginedUser;
            if (currentUser != null)
                Person = dbs.People.FirstOrDefault(p => p.UserId == currentUser.UserId);
        }

        public PersonCarsModel(int? carid)
            : this()
        {
            var user = Controllers.profileController.GetCurrentLoginedUser;
            Car =dbs.PersonCars.FirstOrDefault(c => c.UserId == user.UserId && c.CarId == carid);
            if (Car != null && Car.CarId != null)
            {
                Detail = dbs.PersonCarDetails.FirstOrDefault(c => c.PersonCarId == Car.PersonCarsId);
                if (Detail == null)
                    Detail = new DBSEF.PersonCarDetail();
                else
                {
                    LastFilterChange = Detail.LastFiltersChange.Date_Persian();
                    LastOilChange = Detail.LastOilChange.Date_Persian();
                }
            }
            else
            {
                Car = new DBSEF.PersonCar();
                Car.CarId = carid;
            }
        }

        public PersonCarsModel(int? carid, int? detaild)
        {
            this.Car = dbs.PersonCars .FirstOrDefault(c => c.PersonCarsId == carid);
            this.Detail = dbs.PersonCarDetails.FirstOrDefault(c => c.PersonCarDetailId == detaild);
        }

        public void Save()
        {
            if (LastOilChange.IsPersianDateTime())
            { Detail.LastOilChange = LastOilChange.Persian_ToDateTime(); }
            if (LastFilterChange.IsPersianDateTime())
            { Detail.LastFiltersChange = LastFilterChange.Persian_ToDateTime(); }

            Car.UserId = Controllers.profileController.GetCurrentLoginedUser.UserId;
            dbs.PersonCars.Add(Car);

            Detail.PersonCar = Car;            
            dbs.PersonCarDetails.Add(Detail);

            dbs.SaveChanges();
        }
        public void Update()
        {
            if (LastOilChange.IsPersianDateTime())
            { Detail.LastOilChange = LastOilChange.Persian_ToDateTime(); }
            if (LastFilterChange.IsPersianDateTime())
            { Detail.LastFiltersChange = LastFilterChange.Persian_ToDateTime(); }

            dbs.SaveChanges();
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> res = new List<ValidationResult>();

            //CarDetail
            if (Car.CarMilage == null)
                res.Add(new ValidationResult("کارکرد خودرو تعیین نشده است", new string[] { "Car.CarMilage" }));

            if (Car.CarCreationDate.IsNullOrWhiteSpace())
                res.Add(new ValidationResult("سال ساخت خودرو وارد نشده است", new string[] { "Car.CarCreationDate" }));
            else if (!Car.CarCreationDate.IsNumber() || Car.CarCreationDate.Length > 4)
                res.Add(new ValidationResult("مقدار وارد شده صحیح نیست.سال به صورت عدد چهار رقمی باید باشد", new string[] { "Car.CarCreationDate" }));


            if (LastFilterChange.IsNullOrWhiteSpace())
                res.Add(new ValidationResult("تاریخ آخرین تعویض فیلتر تعیین نشده است", new string[] { "LastFilterChange" }));
            else if(!LastFilterChange.IsPersianDateTime())
                res.Add(new ValidationResult("تاریخ آخرین تعویض فیلتر صحیح نیست", new string[] { "LastFilterChange" }));

            if (LastOilChange.IsNullOrWhiteSpace())
                res.Add(new ValidationResult("تاریخ آخرین تعویض روغن تعیین نشده است", new string[] { "LastOilChange" }));
            else if (!LastOilChange.IsPersianDateTime())
                res.Add(new ValidationResult("تاریخ آخرین تعویض روغن صحیح نیست", new string[] { "LastOilChange" }));

            if (Car.CarPlate.IsNullOrWhiteSpace())
                res.Add(new ValidationResult("پلاک خودرو وارد نشده است", new string[] { "Car.CarPlate" }));
            if (Car.CarPlateCityCode == null)
                res.Add(new ValidationResult("نمره شهر وارد نشده است", new string[] { "Car.CarPlateCityCode" }));
            

            return res;
        }
    }
}