using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;

using dbs = CarProject.DBSEF;
using System.ComponentModel.DataAnnotations;

namespace CarProject.Areas.Admin.Models.User
{
    public class UserInfo : IValidatableObject
    {
        
        public dbs.Person Person { get; set; }

        public string Password { get; set; }
        public string PasswordConfirm { get; set; }

        public UserInfo()
        {
            Person = new dbs.Person();
            Person.User = new dbs.User();
        }

        public UserInfo(int userid)
        {
            dbs.CarAutomationEntities c = new dbs.CarAutomationEntities();

            this.Person = c.People.FirstOrDefault(p => p.UserId == userid);
        }


        public void Save()
        {
            dbs.CarAutomationEntities cdbs = new dbs.CarAutomationEntities();

            Person.User.Upass = CLS.Usefulls.MD5Passwords(Password);
            cdbs.People.Add(Person);

            cdbs.SaveChanges();
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            dbs.CarAutomationEntities dbs = new dbs.CarAutomationEntities();


            if (string.IsNullOrWhiteSpace(Person.PersonFirtstName))
                yield return new ValidationResult("نام کاربر وارد نشده است", new string[] { "Person.PersonFirtstName" });
            if (string.IsNullOrWhiteSpace(Person.PersonFirtstName))
                yield return new ValidationResult("نام خانوادگی کاربر وارد نشده است", new string[] { "Person.PersonFirtstName" });
            if (string.IsNullOrWhiteSpace(Person.PersonMobile))
                yield return new ValidationResult("موبایل کاربر وارد نشده است", new string[] { "Person.PersonMobile" });

            if(string.IsNullOrWhiteSpace(Person.User.Uname))
                yield return new ValidationResult("نام کاربری وارد نشده است", new string[] { "Person.User.Uname" });
            else if(dbs.Users.Count(u => u.Uname.ToLower() == this.Person.User.Uname.ToLower()) > 0)
                yield return new ValidationResult("نام کاربری وارد شده تکراری است", new string[] { "Person.User.Uname" });
            
            if (string.IsNullOrWhiteSpace(Password))
                yield return new ValidationResult("کلمه عبور وارد نشده است", new string[] { "Password" });
            if (string.IsNullOrWhiteSpace(PasswordConfirm))
                yield return new ValidationResult("تایید کلمه عبور وارد نشده است", new string[] { "PasswordConfirm" });

            if (!string.IsNullOrWhiteSpace(Password) && !string.IsNullOrWhiteSpace(PasswordConfirm) && PasswordConfirm != Password)
                yield return new ValidationResult("کلمه عبور وتایید آن یکسان نیستند", new string[] { "Password", "PasswordConfirm" });
        }
    }
}