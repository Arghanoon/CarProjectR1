using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

using CarProject.App_extension;

namespace CarProject.Areas.Admin.Models.Store
{
    public class ServicesModel : IValidatableObject
    {

        public DBSEF.CarAutomationEntities DBS = new DBSEF.CarAutomationEntities();

        public DBSEF.AutoService Service { get; set; }
        public List<int> Products { get; set; }
        public List<int> CarsId { get; set; }

        public ServicesModel()
        {
            Service = new DBSEF.AutoService();
            Products = new List<int>();
            CarsId = new List<int>();
        }

        public ServicesModel(int? id)
        {
            Service = DBS.AutoServices.FirstOrDefault(c => c.AutoServiceId == id);
            Products = Service.ProductInServices.Select(c => c.ProductId.GetValueOrDefault()).ToList();
            CarsId = Service.AutoServiceCars.Select(c => c.CarsId.GetValueOrDefault()).ToList();
        }

        public void Save()
        {
            DBS.AutoServices.Add(this.Service);

            foreach (var item in CarsId)
            {
                DBS.AutoServiceCars.Add(new DBSEF.AutoServiceCar { CarsId = item, AutoService = this.Service });
            }

            foreach (var item in Products)
            {
                DBS.ProductInServices.Add(new DBSEF.ProductInService { ProductId = item, AutoService = this.Service });
            }

            DBS.SaveChanges();
        }

        public void Update()
        {
            DBS.AutoServiceCars.RemoveRange(Service.AutoServiceCars.Where(c => !CarsId.Contains(c.CarsId.GetValueOrDefault())).ToList());
            DBS.ProductInServices.RemoveRange(Service.ProductInServices.Where(p => !Products.Contains(p.ProductId.GetValueOrDefault())).ToList());
            foreach (var item in CarsId)
            {
                if (Service.AutoServiceCars.Count(c => c.CarsId == item) <= 0)
                    Service.AutoServiceCars.Add(new DBSEF.AutoServiceCar { CarsId = item });
            }
            foreach (var item in Products)
            {
                if (Service.ProductInServices.Count(c => c.ProductId == item) <= 0)
                    Service.ProductInServices.Add(new DBSEF.ProductInService { ProductId = item });
            }
            DBS.SaveChanges();
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> result = new List<ValidationResult>();

            if (Service.AutoServiceName.IsNullOrWhiteSpace())
                result.Add(new ValidationResult("نام سرویس تعیین نشده است", new string[] { "Service.AutoServiceName" }));

            if(Service.Price.IsNullOrWhiteSpace())
                result.Add(new ValidationResult("قیمت سرویس تعیین نشده است", new string[] { "Service.Price" }));
            else if (!Service.Price.IsNumber())
                result.Add(new ValidationResult("مقدار وارد شده صحیح نیست", new string[] { "Service.Price" }));

            return result;
        }
    }
}