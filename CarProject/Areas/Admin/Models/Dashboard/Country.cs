using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

using CarProject.App_extension;

namespace CarProject.Areas.Admin.Models.Dashboard
{
    public class CountryModel : IValidatableObject
    {
        public DBSEF.CarAutomationEntities dbs = new DBSEF.CarAutomationEntities();
        public DBSEF.Country Country { get; set; }

        public CountryModel()
        {
            Country = new DBSEF.Country();
        }

        public CountryModel(int? id)
        {
            Country = dbs.Countries.FirstOrDefault(c => c.CountryId == id);
            if (Country == null)
                Country = new DBSEF.Country();
        }

        public void Save()
        {
            dbs.Countries.Add(this.Country);
            dbs.SaveChanges();
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> result = new List<ValidationResult>();

            if (Country.CountryLongName.IsNullOrWhiteSpace())
                result.Add(new ValidationResult("نام کشور وارد نشده است", new string[] { "Country.CountryLongName" }));


            if (Country.CountryShortName.IsNullOrWhiteSpace())
                result.Add(new ValidationResult("حروف اختصاری وارد نشده است", new string[] { "Country.CountryShortName" }));
            else if (dbs.Countries.Count(c => c.CountryShortName.ToLower() == Country.CountryShortName.ToLower() && c.CountryId != Country.CountryId) > 0)
                result.Add(new ValidationResult("کشوری با این مشخصه قبلا ثبت شده است", new string[] { "Country.CountryShortName" }));

            return result;
        }
    }

    public class CompanyModel : IValidatableObject
    {
        public DBSEF.CarAutomationEntities dbs = new DBSEF.CarAutomationEntities();

        public DBSEF.Company Company { get; set; }

        public CompanyModel()
        {
            Company = new DBSEF.Company();
        }

        public CompanyModel(int? Id)
        {
            Company = dbs.Companies.FirstOrDefault(c => c.CompanyId == Id);
            if (Company == null)
                Company = new DBSEF.Company();
        }

        public void Save()
        {
            dbs.Companies.Add(Company);
            dbs.SaveChanges();
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> result = new List<ValidationResult>();

            if (Company.CompanyName.IsNullOrWhiteSpace())
                result.Add(new ValidationResult("نام وارد نشده است.", new string[] { "Company.CompanyName" }));
            else if (dbs.Companies.Count(c => c.CompanyName.ToLower() == Company.CompanyName && c.CompanyId != Company.CompanyId) > 0)
                result.Add(new ValidationResult("نام وارد شده تکراری است.", new string[] { "Company.CompanyName" }));

            return result;
        }
    }

    public class ManufactureModel : IValidatableObject
    {
        public DBSEF.CarAutomationEntities dbs = new DBSEF.CarAutomationEntities();

        public DBSEF.Manufacture Manufacture { get; set; }

        public ManufactureModel()
        {
            Manufacture = new DBSEF.Manufacture();
        }

        public ManufactureModel(int? Id)
        {
            Manufacture = dbs.Manufactures.FirstOrDefault(c => c.ManufactureId == Id);
            if (Manufacture == null)
                Manufacture = new DBSEF.Manufacture();
        }

        public void Save()
        {
            dbs.Manufactures.Add(Manufacture);
            dbs.SaveChanges();
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> result = new List<ValidationResult>();

            if (Manufacture.ManufactureName.IsNullOrWhiteSpace())
                result.Add(new ValidationResult("نام وارد نشده است.", new string[] { "Manufacture.ManufactureName" }));
            else if (dbs.Manufactures.Count(m => m.ManufactureName.ToLower() == Manufacture.ManufactureName && m.ManufactureId != Manufacture.ManufactureId) > 0)
                result.Add(new ValidationResult("نام وارد شده تکراری است.", new string[] { "Manufacture.ManufactureName" }));

            return result;
        }
    }
}