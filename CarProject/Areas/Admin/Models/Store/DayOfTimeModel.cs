using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CarProject.Areas.Admin.Models.Store
{
    public class DayOfTimeModel
    {
        public DBSEF.CarAutomationEntities DBS = new DBSEF.CarAutomationEntities();
        public DBSEF.DaysOfWeek DaysOfWeek { get; set; }

        public DayOfTimeModel()
        {
            DaysOfWeek = new DBSEF.DaysOfWeek();
        }
        public DayOfTimeModel(int? id)
        {
            DaysOfWeek = DBS.DaysOfWeeks.FirstOrDefault(c => c.DaysOfWeekId == id);
            if (DaysOfWeek == null)
                DaysOfWeek = new DBSEF.DaysOfWeek();
        }
        public void Update()
        {
            
            DBS.Entry(DaysOfWeek).State = EntityState.Modified;
            DBS.SaveChanges();
        }

        public void Save()
        {
            DBS.DaysOfWeeks.Add(this.DaysOfWeek);
            DBS.SaveChanges();
        }
    }
}