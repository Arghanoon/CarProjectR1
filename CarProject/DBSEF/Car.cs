﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CarProject.DBSEF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    
    public partial class Car : IValidatableObject
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Car()
        {
            this.AirConditioningSystems = new HashSet<AirConditioningSystem>();
            this.AutoServices = new HashSet<AutoService>();
            this.BrakeSystems = new HashSet<BrakeSystem>();
            this.CarAirbags = new HashSet<CarAirbag>();
            this.CarAudioSystems = new HashSet<CarAudioSystem>();
            this.CarEngines = new HashSet<CarEngine>();
            this.CarGearBoxes = new HashSet<CarGearBox>();
            this.CarLightingSystems = new HashSet<CarLightingSystem>();
            this.CarPhysicalDetails = new HashSet<CarPhysicalDetail>();
            this.CarPrices = new HashSet<CarPrice>();
            this.CarSeatOptions = new HashSet<CarSeatOption>();
            this.CarSensorsSystems = new HashSet<CarSensorsSystem>();
            this.CarsInSameClasses = new HashSet<CarsInSameClass>();
            this.CarsInSameClasses1 = new HashSet<CarsInSameClass>();
            this.CarsProes = new HashSet<CarsPro>();
            this.CarsQnAs = new HashSet<CarsQnA>();
            this.CarsReviews = new HashSet<CarsReview>();
            this.CarWheels = new HashSet<CarWheel>();
            this.DetailedBrakeSystems = new HashSet<DetailedBrakeSystem>();
            this.FuelConsumptions = new HashSet<FuelConsumption>();
            this.GlassAndMirrors = new HashSet<GlassAndMirror>();
            this.Products = new HashSet<Product>();
            this.SecuritySystems = new HashSet<SecuritySystem>();
            this.SteeringSystems = new HashSet<SteeringSystem>();
            this.Users = new HashSet<User>();
        }
    
        public int CarsId { get; set; }
        [DisplayName("برند")]
        public string CarsBrandName { get; set; }
        [DisplayName("کلاس")]
        public string CarsClass { get; set; }
        [DisplayName("مدل")]
        public string CarsModel { get; set; }
        [DisplayName("امتیاز کاربران")]
        public Nullable<int> CarsUserScore { get; set; }
        [DisplayName("امتیاز وب سایت")]
        public Nullable<int> CarsClinicScore { get; set; }
        [DisplayName("قیمت")]
        public string Price { get; set; }

        public Nullable<int> CarsPicsId { get; set; }
        [DisplayName("آدرس ویدئو")]

        public string CarsVideoURL { get; set; }
        [DisplayName("توضیحات")]

        public string CarsDescription { get; set; }
        [DisplayName("کلاس خودرو")]

        public string CarClassType { get; set; }
        [DisplayName("رده")]

        public string CarCategory { get; set; }
        [DisplayName("کاربرد")]

        public string CarUsage { get; set; }

        //autocomplete and combos
        public string[] CarClassTypeItems { get { return new[] { "سدان" }; } }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AirConditioningSystem> AirConditioningSystems { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AutoService> AutoServices { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BrakeSystem> BrakeSystems { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CarAirbag> CarAirbags { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CarAudioSystem> CarAudioSystems { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CarEngine> CarEngines { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CarGearBox> CarGearBoxes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CarLightingSystem> CarLightingSystems { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CarPhysicalDetail> CarPhysicalDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CarPrice> CarPrices { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CarSeatOption> CarSeatOptions { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CarSensorsSystem> CarSensorsSystems { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CarsInSameClass> CarsInSameClasses { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CarsInSameClass> CarsInSameClasses1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CarsPro> CarsProes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CarsQnA> CarsQnAs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CarsReview> CarsReviews { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CarWheel> CarWheels { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetailedBrakeSystem> DetailedBrakeSystems { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FuelConsumption> FuelConsumptions { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GlassAndMirror> GlassAndMirrors { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product> Products { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SecuritySystem> SecuritySystems { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SteeringSystem> SteeringSystems { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<User> Users { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> res = new List<ValidationResult>();
            
            return res;
        }
    }
}
