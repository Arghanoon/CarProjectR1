using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

using CarProject.App_extension;

namespace CarProject.Areas.Admin.Models.Store
{
    public class ServicePacksModel : IValidatableObject
    {
        public DBSEF.CarAutomationEntities DBS = new DBSEF.CarAutomationEntities();

        public DBSEF.AutoServicePack ServicePack { get; set; }
        public List<int> ServicesIds { get; set; }


        public ServicePacksModel()
        {
            ServicePack = new DBSEF.AutoServicePack();
            ServicesIds = new List<int>();
        }

        public void Save()
        {
            foreach (var item in this.ServicesIds)
            {
                this.ServicePack.AutoServices.Add(new DBSEF.AutoService1 { AutoServiceId = item });
            }
            DBS.AutoServicePacks.Add(this.ServicePack);
            DBS.SaveChanges();
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> result = new List<ValidationResult>();

            if (this.ServicePack.AutoServicePackName.IsNullOrWhiteSpace())
                result.Add(new ValidationResult("نام پک تعیین نشده است", new string[] { "ServicePack.AutoServicePackName" }));
            if (this.ServicePack.PackPrice.IsNullOrWhiteSpace())
                result.Add(new ValidationResult("قیمت پک تعیین نشده است", new string[] { "ServicePack.PackPrice" }));
            else if (!this.ServicePack.PackPrice.IsNumber())
                result.Add(new ValidationResult("مقدار وارد شده صحیح نیست", new string[] { "ServicePack.PackPrice" }));
            if (ServicesIds.Count <= 0)
                result.Add(new ValidationResult("هیچ سرویسی برای پک تعیین نشده است", new string[] { "ServicesIds" }));
            return result;
        }
    }
}