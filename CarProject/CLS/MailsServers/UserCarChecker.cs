using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarProject.App_extension;
using Newtonsoft.Json;
using System.Net.Mail;
using System.IO;
using Quartz;
using CarProject.Areas.Users.Models.Dashboard;

namespace CarProject.CLS.MailsServers
{
    public class UserCarChecker : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            var dbs = new DBSEF.CarAutomationEntities();
            var People = dbs.PersonCars.Where(c => c.UserId != null).ToList();
            foreach (var personCar in People)
            {
                var PersonCarDetail = dbs.PersonCarDetails.Where(p => p.PersonCarId == personCar.PersonCarsId).ToList();
                if (PersonCarDetail.Any())
                {
                    foreach (var personCarDetail in PersonCarDetail)
                    {
                        var Person = dbs.People.Where(t => t.UserId == personCar.UserId).ToList();
                        if (Person.Any())
                        {
                            var email = Person[0].PersonEmail.ToString();
                            CLS.MailsServers.Mail_noreply m = new CLS.MailsServers.Mail_noreply();

                            var dt = new DateTime();
                            dt = DateTime.Today;
                            if (personCarDetail.LastAirFilterChange.Value < dt.AddMonths(-2))
                            {
                                m.SendPersoncarDetailMail(new CarProject.Models.User.UserInfo(personCar.UserId.Value), " فیلتر هوا ");
                            }
                            if (personCarDetail.LastFrontBrakePadsChange.Value < dt.AddMonths(-6))
                            {
                                m.SendPersoncarDetailMail(new CarProject.Models.User.UserInfo(personCar.UserId.Value), " لنت ترمز چرخ های جلو ");
                            }
                            if (personCarDetail.LastGearBoxOilChange.Value < dt.AddYears(-1))
                            {
                                m.SendPersoncarDetailMail(new CarProject.Models.User.UserInfo(personCar.UserId.Value), " روغن گیربکس ");
                            }
                            if (personCarDetail.LastOilChange.Value < dt.AddMonths(-6))
                            {
                                m.SendPersoncarDetailMail(new CarProject.Models.User.UserInfo(personCar.UserId.Value), " روغن موتور ");
                            }
                            if (personCarDetail.LastOilFiltersChange.Value < dt.AddMonths(-6))
                            {
                                m.SendPersoncarDetailMail(new CarProject.Models.User.UserInfo(personCar.UserId.Value), " فیلتر روغن ");
                            }
                            if (personCarDetail.LastOtherBeltsChange.Value < dt.AddYears(-1))
                            {
                                m.SendPersoncarDetailMail(new CarProject.Models.User.UserInfo(personCar.UserId.Value), " تسمه دینام ");
                            }
                            if (personCarDetail.LastTiresChange.Value < dt.AddYears(-2))
                            {
                                m.SendPersoncarDetailMail(new CarProject.Models.User.UserInfo(personCar.UserId.Value), " تایر های اتومبیل ");
                            }
                            if (personCarDetail.LastTimingbeltChange.Value < dt.AddMonths(-2))
                            {
                                m.SendPersoncarDetailMail(new CarProject.Models.User.UserInfo(personCar.UserId.Value), " تسمه تایم ");
                            }
                            if (personCarDetail.LastRearBreakePadsChange.Value < dt.AddMonths(-2))
                            {
                                m.SendPersoncarDetailMail(new CarProject.Models.User.UserInfo(personCar.UserId.Value), " لنت ترمز چرخ عقب ");
                            }
                            // m.SendUserRecoveryMail(new CarProject.Models.User.UserInfo(people.UserId.Value), Url, Request);

                        }
                    }
                }

            }
        }

    }
}