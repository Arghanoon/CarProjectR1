using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace CarProject.Areas.Admin.Models.Dashboard
{
    public class NamingModel : IValidatableObject
    {
        public DBSEF.CarAutomationEntities dbs = new DBSEF.CarAutomationEntities();
        public DBSEF.NameOfValue NameOfValueModels { get; set; }

        public NamingModel()
        {
            NameOfValueModels = new DBSEF.NameOfValue();
        }
        public NamingModel(int? id)
        {
            NameOfValueModels = dbs.NameOfValues.FirstOrDefault(c => c.NameOfvaluesId == id);
            if (NameOfValueModels == null)
                NameOfValueModels = new DBSEF.NameOfValue();
        }
        public void Save()
        {
            dbs.NameOfValues.Add(this.NameOfValueModels);
            dbs.SaveChanges();
        }

        public void update()
        {
            dbs.NameOfValues.AddOrUpdate(this.NameOfValueModels);
            dbs.SaveChanges();
        }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> result = new List<ValidationResult>();

            //if (NameOfValueModels.CountryLongName.IsNullOrWhiteSpace())
            //    result.Add(new ValidationResult("نام کشور وارد نشده است", new string[] { "Country.CountryLongName" }));


            //if (Country.CountryShortName.IsNullOrWhiteSpace())
            //    result.Add(new ValidationResult("حروف اختصاری وارد نشده است", new string[] { "Country.CountryShortName" }));
            //else if (dbs.Countries.Count(c => c.CountryShortName.ToLower() == Country.CountryShortName.ToLower() && c.CountryId != Country.CountryId) > 0)
            //    result.Add(new ValidationResult("کشوری با این مشخصه قبلا ثبت شده است", new string[] { "Country.CountryShortName" }));

            return result;
        }
    }
}