using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using CarProject.App_extension;

namespace CarProject.Areas.Users.UsersCLS.Notifications
{

    public class UserCarsNotifications
    {
        private DBSEF.Person Person { get; set; }
        private DBSEF.CarAutomationEntities DBS { get; set; }

        public class UserCarsNotificationItem
        {
            public DBSEF.PersonCar PersonCar { get; set; }
            public string Subject { get; set; }
            public string Message { get; set; }
        }
        
        public UserCarsNotifications()
        {
            Person = Controllers.profileController.GetCurrentLoginPerson;
            DBS = new DBSEF.CarAutomationEntities();
        }

        public List<UserCarsNotificationItem> Notifications
        {
            get
            {
                UserCarsNotifications es = new UserCarsNotifications();
                var res = new List<UserCarsNotificationItem>();
                try
                {
                    Person = Controllers.profileController.GetCurrentLoginPerson;
                    var personcars = DBS.PersonCars.Where(c => c.UserId == this.Person.UserId);
                if (personcars.Any())
                {
                    foreach (var item in personcars)
                    {
                        var carOrginalDetails = item.Car.CarDetails.FirstOrDefault(c => c.CarsId == item.CarId);
                        var usercardetails = item.PersonCarDetails.FirstOrDefault(c => c.PersonCarId == item.PersonCarsId);

                        if ((item.CarMilage - usercardetails.LastAirFilterChangeMilage) > carOrginalDetails.AirFilterChangeMilage)
                            res.Add(new UserCarsNotificationItem { PersonCar = item, Subject = "فیلتر هوا", Message = "فیلتر هوا بیشتر از کلیومتر معین شده استفاده شده است." });
                        if (usercardetails.LastAirFilterChange.Value.AddMonths(carOrginalDetails.AirFilterChangeDate.Value) <= DateTime.Now)
                            res.Add(new UserCarsNotificationItem { PersonCar = item, Subject = "فیلتر هوا", Message = "فیلتر هوا بیشتر از زمان معین شده استفاده شده است." });


                        if ((item.CarMilage - usercardetails.LastFrontBrakePadsChangeMilage) > carOrginalDetails.FrontBrakePadsChangeMilage)
                            res.Add(new UserCarsNotificationItem { PersonCar = item, Subject = "لنت ترمزهای جلو", Message = "لنت ترمزهای جلو بیشتر از کلیومتر معین شده استفاده شده است." });
                        if ((usercardetails.LastFrontBrakePadsChange.Value.AddMonths(carOrginalDetails.FrontBrakePadsChangeDate.Value)) <= DateTime.Now) 
                            res.Add(new UserCarsNotificationItem { PersonCar = item, Subject = "لنت ترمزهای جلو", Message = "لنت ترمزهای جلو بیشتر از زمان معین شده استفاده شده است." });


                        if ((item.CarMilage - usercardetails.LastGearBoxOilChangeMilage) > carOrginalDetails.GearBoxOilChangeMilage)
                            res.Add(new UserCarsNotificationItem { PersonCar = item, Subject = "روغن گیربکس", Message = "روغن گیربکس بیشتر از کلیومتر معین شده استفاده شده است." });
                        if ((usercardetails.LastGearBoxOilChange.Value.AddMonths(carOrginalDetails.GearBoxOilChangeDate.Value)) <= DateTime.Now) 
                            res.Add(new UserCarsNotificationItem { PersonCar = item, Subject = "روغن گیربکس", Message = "روغن گیربکس بیشتر از زمان معین شده استفاده شده است." });

                        if ((item.CarMilage - usercardetails.LastOilChangeMilage) > carOrginalDetails.OilChangeMilage)
                            res.Add(new UserCarsNotificationItem { PersonCar = item, Subject = "روغن موتور", Message = "روغن موتور بیشتر از کلیومتر معین شده استفاده شده است." });
                        if ((usercardetails.LastOilChange.Value.AddMonths(carOrginalDetails.OilChangeDate.Value)) <= DateTime.Now) 
                            res.Add(new UserCarsNotificationItem { PersonCar = item, Subject = "روغن موتور", Message = "روغن موتور بیشتر از زمان معین شده استفاده شده است." });

                        if ((item.CarMilage - usercardetails.LastOilFilterChangeMilage) > carOrginalDetails.OilFilterChangeMilage)
                            res.Add(new UserCarsNotificationItem { PersonCar = item, Subject = "فیلتر روغن موتور", Message = "فیلتر روغن موتور بیشتر از کلیومتر معین شده استفاده شده است." });
                        if ((usercardetails.LastOilFiltersChange.Value.AddMonths(carOrginalDetails.OilFiltersChangeDate.Value)) <= DateTime.Now)
                            res.Add(new UserCarsNotificationItem { PersonCar = item, Subject = "فیلتر روغن موتور", Message = "فیلتر روغن موتور بیشتر از زمان معین شده استفاده شده است." });

                        if ((item.CarMilage - usercardetails.LastOtherBeltsChangeMilage) > carOrginalDetails.OtherBeltsChangeMilage)
                            res.Add(new UserCarsNotificationItem { PersonCar = item, Subject = "تسمه دینام / واتر پمپ", Message = "تسمه دینام / واتر پمپ بیشتر از کلیومتر معین شده استفاده شده است." });
                        if (usercardetails.LastOtherBeltsChange.Value.AddMonths(carOrginalDetails.OtherBeltsChangeDate.Value) <= DateTime.Now) 
                            res.Add(new UserCarsNotificationItem { PersonCar = item, Subject = "تسمه دینام / واتر پمپ", Message = "تسمه دینام / واتر پمپ بیشتر از زمان معین شده استفاده شده است." });

                        if ((item.CarMilage - usercardetails.LastRearBrakePadsChangeMilage) > carOrginalDetails.RearBrakePadsChangeMilage)
                            res.Add(new UserCarsNotificationItem { PersonCar = item, Subject = "لنت ترمزهای عقب", Message = "لنت ترمزهای عقب بیشتر از کلیومتر معین شده استفاده شده است." });
                        if (usercardetails.LastRearBreakePadsChange.Value.AddMonths(carOrginalDetails.RearBreakePadsChangeDate.Value) <= DateTime.Now) 
                            res.Add(new UserCarsNotificationItem { PersonCar = item, Subject = "لنت ترمزهای عقب", Message = "لنت ترمزهای عقب بیشتر از زمان معین شده استفاده شده است." });

                        if ((item.CarMilage - usercardetails.LastTimingbeltChangeMilage) > carOrginalDetails.TimingbeltChangeMilage)
                            res.Add(new UserCarsNotificationItem { PersonCar = item, Subject = "تسمه تایم", Message = "تسمه تایم بیشتر از کلیومتر معین شده استفاده شده است." });
                        if (usercardetails.LastTimingbeltChange.Value.AddMonths(carOrginalDetails.TimingbeltChangeDate.Value) <= DateTime.Now) 
                            res.Add(new UserCarsNotificationItem { PersonCar = item, Subject = "تسمه تایم", Message = "تسمه تایم بیشتر از زمان معین شده استفاده شده است." });

                        if ((item.CarMilage - usercardetails.LastTiresChangeMilage) > carOrginalDetails.TiresChangeMilage)
                            res.Add(new UserCarsNotificationItem { PersonCar = item, Subject = "تایرها", Message = "تایرها بیشتر از کلیومتر معین شده استفاده شده است." });
                        if (usercardetails.LastTiresChange.Value.AddMonths(carOrginalDetails.TiresChangeDate.Value) <= DateTime.Now) 
                            res.Add(new UserCarsNotificationItem { PersonCar = item, Subject = "تایرها", Message = "تایرها بیشتر از زمان معین شده استفاده شده است." });

                        
                    }
                }

                }
                catch (Exception)
                {

                    throw;
                }

                return res;
            }
        }
    }
}