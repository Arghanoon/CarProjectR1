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

        //[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        //[Display(Name = "حاصل جمع")]
        //public string Captcha { get; set; }



        public DBSEF.CarAutomationEntities dbs = new DBSEF.CarAutomationEntities();

        public DBSEF.Person Person { get; set; }
        public DBSEF.PersonCar Car { get; set; }
        public DBSEF.PersonCarDetail Detail { get; set; }

        public string LastOilChange { get; set; }
        public string LastOilFiltersChange { get; set; }
        public string LastAirFilterChange { get; set; }
        public string LastGearBoxOilChange { get; set; }
        public string LastTiresChange { get; set; }
        public string LastTimingbeltChange { get; set; }
        public string LastOtherBeltsChange { get; set; }
        public string LastFrontBrakePadsChange { get; set; }
        public string LastRearBreakePadsChange { get; set; }

        public string Carplate_part1 { get; set; }
        public string Carplate_part2 { get; set; }
        public string Carplate_part3 { get; set; }

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
                var carplates = Car.CarPlate.Split('|');
                if (carplates.Length == 3)
                {
                    Carplate_part1 = carplates[0];
                    Carplate_part2 = carplates[1];
                    Carplate_part3 = carplates[2];
                }
                
                Detail = dbs.PersonCarDetails.FirstOrDefault(c => c.PersonCarId == Car.PersonCarsId);
                if (Detail == null)
                    Detail = new DBSEF.PersonCarDetail();
                else
                {
                    LastOilChange = Detail.LastOilChange.Date_Persian();
                    LastOilFiltersChange = Detail.LastOilFiltersChange.Date_Persian();
                    LastAirFilterChange = Detail.LastAirFilterChange.Date_Persian();
                    LastGearBoxOilChange  = Detail.LastGearBoxOilChange.Date_Persian();
                    LastTiresChange = Detail.LastTiresChange.Date_Persian();
                    LastTimingbeltChange = Detail.LastTimingbeltChange.Date_Persian();
                    LastOtherBeltsChange = Detail.LastOtherBeltsChange.Date_Persian();
                    LastFrontBrakePadsChange = Detail.LastFrontBrakePadsChange.Date_Persian();
                    LastRearBreakePadsChange = Detail.LastRearBreakePadsChange.Date_Persian();
                }
            }
            else
            {
                Car = new DBSEF.PersonCar();
                Car.CarId = carid;
            }
        }

        public PersonCarsModel(int userid, int? carid)
           : this()
        {
            var user = dbs.Users.FirstOrDefault(u => u.UserId == userid);
            Car = dbs.PersonCars.FirstOrDefault(c => c.UserId == user.UserId && c.CarId == carid);
            if (Car != null && Car.CarId != null)
            {
                var carplates = Car.CarPlate.Split('|');
                if (carplates.Length == 3)
                {
                    Carplate_part1 = carplates[0];
                    Carplate_part2 = carplates[1];
                    Carplate_part3 = carplates[2];
                }

                Detail = dbs.PersonCarDetails.FirstOrDefault(c => c.PersonCarId == Car.PersonCarsId);
                if (Detail == null)
                    Detail = new DBSEF.PersonCarDetail();
                else
                {
                    LastOilChange = Detail.LastOilChange.Date_Persian();
                    LastOilFiltersChange = Detail.LastOilFiltersChange.Date_Persian();
                    LastAirFilterChange = Detail.LastAirFilterChange.Date_Persian();
                    LastGearBoxOilChange = Detail.LastGearBoxOilChange.Date_Persian();
                    LastTiresChange = Detail.LastTiresChange.Date_Persian();
                    LastTimingbeltChange = Detail.LastTimingbeltChange.Date_Persian();
                    LastOtherBeltsChange = Detail.LastOtherBeltsChange.Date_Persian();
                    LastFrontBrakePadsChange = Detail.LastFrontBrakePadsChange.Date_Persian();
                    LastRearBreakePadsChange = Detail.LastRearBreakePadsChange.Date_Persian();
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

        public PersonCarsModel(int userid, int? carid, int? detaild)
        {
            this.Car = dbs.PersonCars.FirstOrDefault(c => c.PersonCarsId == carid);
            Car.UserId = userid;
            this.Detail = dbs.PersonCarDetails.FirstOrDefault(c => c.PersonCarDetailId == detaild);
        }

        public void Save()
        {
            if (LastOilChange.IsPersianDateTime())
            { Detail.LastOilChange = LastOilChange.Persian_ToDateTime(); }
            if (LastOilFiltersChange.IsPersianDateTime())
            { Detail.LastOilFiltersChange = LastOilFiltersChange.Persian_ToDateTime(); }
            if (LastAirFilterChange.IsPersianDateTime())
            { Detail.LastAirFilterChange = LastAirFilterChange.Persian_ToDateTime(); }
            if (LastGearBoxOilChange.IsPersianDateTime())
            { Detail.LastGearBoxOilChange = LastGearBoxOilChange.Persian_ToDateTime(); }
            if (LastTiresChange.IsPersianDateTime())
            { Detail.LastTiresChange = LastTiresChange.Persian_ToDateTime(); }
            if (LastTimingbeltChange.IsPersianDateTime())
            { Detail.LastTimingbeltChange = LastTimingbeltChange.Persian_ToDateTime(); }
            if (LastOtherBeltsChange.IsPersianDateTime())
            { Detail.LastOtherBeltsChange = LastOtherBeltsChange.Persian_ToDateTime(); }
            if (LastFrontBrakePadsChange.IsPersianDateTime())
            { Detail.LastFrontBrakePadsChange = LastFrontBrakePadsChange.Persian_ToDateTime(); }
            if (LastRearBreakePadsChange.IsPersianDateTime())
            { Detail.LastRearBreakePadsChange = LastRearBreakePadsChange.Persian_ToDateTime(); }

            if (Car.UserId == null)
                Car.UserId = Controllers.profileController.GetCurrentLoginedUser.UserId;
            //Car.CarPlate = string.Format("{0}|{1}|{2}", Carplate_part1, Carplate_part2, Carplate_part3);
            Car.CarPlate = "";
            dbs.PersonCars.Add(Car);

            Detail.PersonCar = Car;            
            dbs.PersonCarDetails.Add(Detail);

            dbs.SaveChanges();
        }
        public void Update()
        {
            if (LastOilChange.IsPersianDateTime())
            { Detail.LastOilChange = LastOilChange.Persian_ToDateTime(); }
            if (LastOilFiltersChange.IsPersianDateTime())
            { Detail.LastOilFiltersChange = LastOilFiltersChange.Persian_ToDateTime(); }
            if (LastAirFilterChange.IsPersianDateTime())
            { Detail.LastAirFilterChange = LastAirFilterChange.Persian_ToDateTime(); }
            if (LastGearBoxOilChange.IsPersianDateTime())
            { Detail.LastGearBoxOilChange = LastGearBoxOilChange.Persian_ToDateTime(); }
            if (LastTiresChange.IsPersianDateTime())
            { Detail.LastTiresChange = LastTiresChange.Persian_ToDateTime(); }
            if (LastTimingbeltChange.IsPersianDateTime())
            { Detail.LastTimingbeltChange = LastTimingbeltChange.Persian_ToDateTime(); }
            if (LastOtherBeltsChange.IsPersianDateTime())
            { Detail.LastOtherBeltsChange = LastOtherBeltsChange.Persian_ToDateTime(); }
            if (LastFrontBrakePadsChange.IsPersianDateTime())
            { Detail.LastFrontBrakePadsChange = LastFrontBrakePadsChange.Persian_ToDateTime(); }
            if (LastRearBreakePadsChange.IsPersianDateTime())
            { Detail.LastRearBreakePadsChange = LastRearBreakePadsChange.Persian_ToDateTime(); }
            
            //Car.CarPlate = string.Format("{0}|{1}|{2}", Carplate_part1, Carplate_part2, Carplate_part3);
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


            if (LastOilChange.IsNullOrWhiteSpace())
                res.Add(new ValidationResult("تاریخ آخرین تعویض روغن تعیین نشده است", new string[] { "LastOilChange" }));
            else if (!LastOilChange.IsPersianDateTime())
                res.Add(new ValidationResult("تاریخ آخرین تعویض روغن صحیح نیست", new string[] { "LastOilChange" }));

            if (LastOilFiltersChange.IsNullOrWhiteSpace())
                res.Add(new ValidationResult("تاریخ آخرین تعویض فیلتر روغن تعیین نشده است", new string[] { "LastOilFiltersChange" }));
            else if (!LastOilFiltersChange.IsPersianDateTime())
                res.Add(new ValidationResult("تاریخ آخرین تعویض فیلتر روغن صحیح نیست", new string[] { "LastOilFiltersChange" }));

            if (LastAirFilterChange.IsNullOrWhiteSpace())
                res.Add(new ValidationResult("تاریخ آخرین تعویض فیلتر تعیین نشده است", new string[] { "LastAirFilterChange" }));
            else if(!LastAirFilterChange.IsPersianDateTime())
                res.Add(new ValidationResult("تاریخ آخرین تعویض فیلتر صحیح نیست", new string[] { "LastAirFilterChange" }));

            if (LastGearBoxOilChange.IsNullOrWhiteSpace())
                res.Add(new ValidationResult("تاریخ آخرین تعویض روغن گیربکس تعیین نشده است", new string[] { "LastGearBoxOilChange" }));
            else if (!LastGearBoxOilChange.IsPersianDateTime())
                res.Add(new ValidationResult("تاریخ آخرین تعویض روغن گیربکس صحیح نیست", new string[] { "LastGearBoxOilChange" }));

            if (LastTiresChange.IsNullOrWhiteSpace())
                res.Add(new ValidationResult("تاریخ آخرین تعویض تایر تعیین نشده است", new string[] { "LastTiresChange" }));
            else if (!LastTiresChange.IsPersianDateTime())
                res.Add(new ValidationResult("تاریخ آخرین تعویض تایر صحیح نیست", new string[] { "LastTiresChange" }));

            if (LastTimingbeltChange.IsNullOrWhiteSpace())
                res.Add(new ValidationResult("تاریخ آخرین تعویض تسمه تایم تعیین نشده است", new string[] { "LastTimingbeltChange" }));
            else if (!LastTimingbeltChange.IsPersianDateTime())
                res.Add(new ValidationResult("تاریخ آخرین تعویض تسمه تایم صحیح نیست", new string[] { "LastTimingbeltChange" }));

            if (LastOtherBeltsChange.IsNullOrWhiteSpace())
                res.Add(new ValidationResult("تاریخ آخرین تعویض تسمه دینام / واترپمپ تعیین نشده است", new string[] { "LastOtherBeltsChange" }));
            else if (!LastOtherBeltsChange.IsPersianDateTime())
                res.Add(new ValidationResult("تاریخ آخرین تعویض تسمه دینام / واتر پمپ صحیح نیست", new string[] { "LastOtherBeltsChange" }));

            if (LastFrontBrakePadsChange.IsNullOrWhiteSpace())
                res.Add(new ValidationResult("تاریخ آخرین تعویض لنت ترمز های جلو تعیین نشده است", new string[] { "LastFrontBrakePadsChange" }));
            else if (!LastFrontBrakePadsChange.IsPersianDateTime())
                res.Add(new ValidationResult("تاریخ آخرین تعویض لنت ترمز های جلو پمپ صحیح نیست", new string[] { "LastFrontBrakePadsChange" }));

            if (LastRearBreakePadsChange.IsNullOrWhiteSpace())
                res.Add(new ValidationResult("تاریخ آخرین تعویض لنت ترمز های جلو تعیین نشده است", new string[] { "LastRearBreakePadsChange" }));
            else if (!LastRearBreakePadsChange.IsPersianDateTime())
                res.Add(new ValidationResult("تاریخ آخرین تعویض لنت ترمز های جلو پمپ صحیح نیست", new string[] { "LastRearBreakePadsChange" }));


            //if (Carplate_part1.IsNullOrWhiteSpace() || (!Carplate_part1.IsNullOrWhiteSpace() && !Carplate_part1.IsNumber()) || Carplate_part2.IsNullOrWhiteSpace() || Carplate_part3.IsNullOrWhiteSpace() || (!Carplate_part3.IsNullOrWhiteSpace() && !Carplate_part3.IsNumber()) || Car.CarPlateCityCode == null)
            //    res.Add(new ValidationResult("پلاک خودرو بدرستی وارد نشده است", new string[] { "Car.CarPlate" }));
            //if (Car.CarPlateCityCode == null)
            //    res.Add(new ValidationResult("نمره شهر وارد نشده است", new string[] { "Car.CarPlateCityCode" }));
            

            return res;
        }
    }
}