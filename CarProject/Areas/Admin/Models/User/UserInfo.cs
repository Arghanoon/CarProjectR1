using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using dbs = CarProject.DBSEF;

namespace CarProject.Areas.Admin.Models.User
{
    public class UserInfo
    {
        public dbs.User User { get; set; }
        public dbs.Person Person { get; set; }

        public string Password { get; set; }
        public string PasswordConfig { get; set; }

        public UserInfo()
        {
            User = new dbs.User();
            Person = new dbs.Person();
        }

        public UserInfo(int userid)
        {
            dbs.CarAutomationEntities c = new dbs.CarAutomationEntities();

            this.User = c.Users.FirstOrDefault(u => u.UserId == userid);
            this.Person = c.People.FirstOrDefault(p => p.UserId == userid);
        }
    }
}