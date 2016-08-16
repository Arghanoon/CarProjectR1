using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using dbs = CarProject.DBSEF;

namespace CarProject.Areas.Admin.Models.Cars
{
    public class TroubleshootingClass
    {
        dbs.CarAutomationEntities dbc = new dbs.CarAutomationEntities();

        public dbs.Troubleshooting Troubleshooting { get; set; }

        public TroubleshootingClass()
        {
            Troubleshooting = new dbs.Troubleshooting();
        }

        public void Save()
        {
            dbc.Troubleshootings.Add(Troubleshooting);
            dbc.SaveChanges();
        }
    }
}