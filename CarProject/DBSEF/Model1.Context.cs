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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Entities : DbContext
    {
        public Entities()
            : base("name=Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AirConditioningSystem> AirConditioningSystems { get; set; }
        public virtual DbSet<AutoService> AutoServices { get; set; }
        public virtual DbSet<AutoServicePack> AutoServicePacks { get; set; }
        public virtual DbSet<AutoService1> AutoServices1 { get; set; }
        public virtual DbSet<Basket> Baskets { get; set; }
        public virtual DbSet<BrakeSystem> BrakeSystems { get; set; }
        public virtual DbSet<CarAirbag> CarAirbags { get; set; }
        public virtual DbSet<CarAudioSystem> CarAudioSystems { get; set; }
        public virtual DbSet<CarEngine> CarEngines { get; set; }
        public virtual DbSet<CarGearBox> CarGearBoxes { get; set; }
        public virtual DbSet<CarLightingSystem> CarLightingSystems { get; set; }
        public virtual DbSet<CarPhysicalDetail> CarPhysicalDetails { get; set; }
        public virtual DbSet<CarPrice> CarPrices { get; set; }
        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<CarSeatOption> CarSeatOptions { get; set; }
        public virtual DbSet<CarSensorsSystem> CarSensorsSystems { get; set; }
        public virtual DbSet<CarsInSameClass> CarsInSameClasses { get; set; }
        public virtual DbSet<CarsPro> CarsProes { get; set; }
        public virtual DbSet<CarsQnA> CarsQnAs { get; set; }
        public virtual DbSet<CarsReview> CarsReviews { get; set; }
        public virtual DbSet<CarWheel> CarWheels { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<DetailedBrakeSystem> DetailedBrakeSystems { get; set; }
        public virtual DbSet<Discount> Discounts { get; set; }
        public virtual DbSet<FuelConsumption> FuelConsumptions { get; set; }
        public virtual DbSet<GlassAndMirror> GlassAndMirrors { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<PersonProduct> PersonProducts { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductDiscount> ProductDiscounts { get; set; }
        public virtual DbSet<ProductPrice> ProductPrices { get; set; }
        public virtual DbSet<ProductStore> ProductStores { get; set; }
        public virtual DbSet<SecuritySystem> SecuritySystems { get; set; }
        public virtual DbSet<SteeringSystem> SteeringSystems { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TodaysSpecial> TodaysSpecials { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
    }
}
