using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using CarProject.DBSEF;
using db = CarProject.DBSEF;


namespace CarProject.CLS.Searchs
{
    public class CarsSearchLogic
    {
        public CarAutomationEntities Contexts;

        public CarsSearchLogic()
        {
            Contexts = new CarAutomationEntities();
            
            
        }


        public IEnumerable GetJoinedView(SearchModel search)
        {
            return null;
            /*var watch = System.Diagnostics.Stopwatch.StartNew();
            
            var rx = Contexts.sp_cars().Select(c => new
            {
                CarBrandnamex = c.CarBrandName,
                CarModelNamex = c.CarModelName,
                CarUsagex = c.CarUsage,
                CarBodyTypex = c.CarBodyType,
                GearBoxTypex = c.GearBoxType,
                GearBoxAxelx = c.GearBoxAxel,
                EngineTypex = c.EngineType,
                EngineCylinderNumberx = (int?)c.EngineCylinderNumber,
                CarYearModelx = (int?)c.CarYearModel,
                LphCityx = (double?)c.LphCity,
                LphRoadx = (double?)c.LphRoad,
                LphMixx = (double?)c.LphMix
            });

            var list = rx.ToList();
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;

            var watch2 = System.Diagnostics.Stopwatch.StartNew();
            //Car.Join(CarModel, p => , c => , (p, c) => new {p, c}) 
            var Resultting = (Contexts.CarBrands.GroupJoin(Contexts.CarModels, CarBrand => CarBrand.CarBrandId,
                CarModel => CarModel.CarBrandId, (CarBrand, CarModel_join) => new {CarBrand, CarModel_join})
                .SelectMany(@t => @t.CarModel_join.DefaultIfEmpty(), (@t, CarModel) => new {@t, CarModel})
                .GroupJoin(Contexts.Cars, @t => @t.CarModel.CarModelId, Cars => Cars.CarModelId,
                    (@t, Cars_join) => new {@t, Cars_join})
                .SelectMany(@t => @t.Cars_join.DefaultIfEmpty(), (@t, Cars) => new {@t, Cars})
                .GroupJoin(Contexts.CarGearBoxes, @t => @t.Cars.CarsId, CarGearBox => CarGearBox.CarsId,
                    (@t, CarGearBox_join) => new {@t, CarGearBox_join})
                .SelectMany(@t => @t.CarGearBox_join.DefaultIfEmpty(), (@t, CarGearBox) => new {@t, CarGearBox})
                .GroupJoin(Contexts.CarEngines, @t => @t.@t.@t.Cars.CarsId, CarEngine => CarEngine.CarsId,
                    (@t, CarEngine_join) => new {@t, CarEngine_join})
                .SelectMany(@t => @t.CarEngine_join.DefaultIfEmpty(), (@t, CarEngine) => new {@t, CarEngine})
                .GroupJoin(Contexts.FuelConsumptions, @t => @t.@t.@t.@t.@t.Cars.CarsId,
                    FuelConsumption => FuelConsumption.CarId,
                    (@t, FuelConsumption_join) => new {@t, FuelConsumption_join})
                .SelectMany(@t => @t.FuelConsumption_join.DefaultIfEmpty(), (@t, FuelConsumption) => new
                {
                    @t.@t.@t.@t.@t.@t.@t.@t.@t.CarBrand.CarBrandName,
                    CarModelName = @t.@t.@t.@t.@t.@t.@t.@t.CarModel.CarModelName,
                    CarUsage = @t.@t.@t.@t.@t.@t.Cars.CarUsage,
                    CarBodyType = @t.@t.@t.@t.@t.@t.Cars.CarBodyType,
                    GearBoxType = @t.@t.@t.@t.CarGearBox.GearBoxType,
                    GearBoxAxel = @t.@t.@t.@t.CarGearBox.GearBoxAxel,
                    EngineType = @t.@t.CarEngine.EngineType,
                    EngineCylinderNumber = (int?) @t.@t.CarEngine.EngineCylinderNumber,
                    CarYearModel = (int?) @t.@t.@t.@t.@t.@t.Cars.CarYearModel,
                    LphCity = (double?) FuelConsumption.LphCity,
                    LphRoad = (double?) FuelConsumption.LphRoad,
                    LphMix = (double?) FuelConsumption.LphMix
                })).Distinct();
            watch2.Stop();
            var elapsedMs2 = watch2.ElapsedMilliseconds;

            var list2 = Resultting.ToList();    
            var result = Resultting;
            

            var r1 = result.ToList();
            var r2 = result.ToList();

            var r3 = r2;
            var r4 = r3;
            var r5 = r4;
            var r6 = r5;
            var r7 = r6;
            var rFinal = r7;
            r1.Clear();
            r2.Clear();
            r3.Clear();
            r4.Clear();
            r5.Clear();
            r6.Clear();
            r7.Clear();

            rFinal.Clear();
            

            //  var result = Resultting.ToList();

            if (!(search.brandname == null || search.brandname.Length == 0))
            {
                foreach (var VARIABLE in search.brandname)
                {
                    r1.AddRange(Resultting.Where(x => x.CarBrandName == VARIABLE));
                    r2.AddRange(r1);
                    r1.Clear();
                }
            }
            if (!(search.enginetype == null || search.enginetype.Length == 0))
            {
                foreach (var VARIABLE in search.enginetype)
                {
                    r2.AddRange(r1.Where(t => t.EngineType == VARIABLE));
                    r1 = r2;
                    // r1.AddRange(Resultting.Where(x => x.EngineType == VARIABLE));
                }
            }
            if (!(search.enginecylandr == null || search.enginecylandr.Length == 0))
            {
                foreach (var VARIABLE in search.enginecylandr)
                {
                    r2.AddRange(r1.Where(t => t.EngineCylinderNumber == VARIABLE));
                    r1 = r2;
                }
            }
            if (!(search.carusage == null || search.carusage.Length == 0))
            {
                foreach (var VARIABLE in search.carusage)
                {
                    r2.AddRange(r1.Where(t => t.CarUsage == VARIABLE));
                    r1 = r2;
                }
            }
            if (!(search.carbodytype == null || search.carbodytype.Length == 0))
            {
                foreach (var VARIABLE in search.carbodytype)
                {
                    r2.AddRange(r1.Where(t => t.CarBodyType == VARIABLE));
                    r1 = r2;
                }
            }
            if (!(search.gearboxtype == null || search.gearboxtype.Length == 0))
            {
                foreach (var VARIABLE in search.gearboxtype)
                {
                    r2.AddRange(r1.Where(t => t.GearBoxType == VARIABLE));
                    r1 = r2;
                }
            }
            if (!(search.gearboxaxle == null || search.gearboxaxle.Length == 0))
            {
                foreach (var VARIABLE in search.gearboxaxle)
                {
                    r2.AddRange(r1.Where(t => t.GearBoxAxel == VARIABLE));
                    r1 = r2;
                }
            }

            return r1;*/
        }

        public IEnumerable GetProductSearch(ProductSearchModel model)
        {
            var r = Contexts.Manufactures.GroupJoin(Contexts.Products, Manufacture => Manufacture.ManufactureId,
                Product => Product.ManufactureId, (Manufacture, Product_join) => new {Manufacture, Product_join})
                .SelectMany(@t => @t.Product_join.DefaultIfEmpty(), (@t, Product) => new {@t, Product})
                .GroupJoin(Contexts.Countries, @t => @t.Product.CountryId, Country => Country.CountryId,
                    (@t, Country_join) => new {@t, Country_join})
                .SelectMany(@t => @t.Country_join.DefaultIfEmpty(), (@t, Country) => new {@t, Country})
                .GroupJoin(Contexts.Categories, @t => @t.@t.@t.Product.CategoryId, Category => Category.CategoryId,
                    (@t, Category_join) => new {@t, Category_join})
                .SelectMany(@t => @t.Category_join.DefaultIfEmpty(), (@t, Category) => new {@t, Category})
                .GroupJoin(Contexts.ProductPrices, @t => @t.@t.@t.@t.@t.Product.ProductId,
                    ProductPrice => ProductPrice.ProductId, (@t, ProductPrice_join) => new {@t, ProductPrice_join})
                .SelectMany(@t => @t.ProductPrice_join.DefaultIfEmpty(), (@t, ProductPrice) => new {@t, ProductPrice})
                .GroupJoin(Contexts.ProductStores, @t => @t.@t.@t.@t.@t.@t.@t.Product.ProductId,
                    ProductStore => ProductStore.ProductId, (@t, ProductStore_join) => new {@t, ProductStore_join})
                .SelectMany(@t => @t.ProductStore_join.DefaultIfEmpty(), (@t, ProductStore) => new {@t, ProductStore})
                .GroupJoin(Contexts.Cars, @t => @t.@t.@t.@t.@t.@t.@t.@t.@t.Product.CarId, Cars => Cars.CarsId,
                    (@t, Cars_join) => new {@t, Cars_join})
                .SelectMany(@t => @t.Cars_join.DefaultIfEmpty(), (@t, Cars) => new {@t, Cars})
                .GroupJoin(Contexts.CarModels, @t => @t.Cars.CarModelId, CarModel => CarModel.CarModelId,
                    (@t, CarModel_join) => new {@t, CarModel_join})
                .SelectMany(@t => @t.CarModel_join.DefaultIfEmpty(), (@t, CarModel) => new {@t, CarModel})
                .GroupJoin(Contexts.CarBrands, @t => @t.CarModel.CarBrandId, CarBrand => CarBrand.CarBrandId,
                    (@t, CarBrand_join) => new {@t, CarBrand_join})
                .SelectMany(@t => @t.CarBrand_join.DefaultIfEmpty(), (@t, CarBrand) => new
                {
                    CarBrand.CarBrandName,
                    @t.@t.CarModel.CarModelName,
                    @t.@t.@t.@t.@t.@t.@t.@t.@t.@t.@t.@t.@t.@t.Product.ProductName,
                    @t.@t.@t.@t.@t.@t.@t.@t.ProductPrice.ProductPrice1,
                    @t.@t.@t.@t.@t.@t.@t.@t.ProductPrice.InstallPrice,
                    @t.@t.@t.@t.@t.@t.@t.@t.@t.@t.@t.@t.@t.@t.@t.Manufacture.ManufactureName,
                    @t.@t.@t.@t.@t.@t.@t.@t.@t.@t.@t.@t.Country.CountryLongName,
                    @t.@t.@t.@t.@t.@t.@t.@t.@t.@t.Category.CategoryName
                }).Distinct();

            var ReslutList = r.ToList();
            ReslutList.Clear();
            var r2 = ReslutList;
            if (!(model.BrandName == null || model.BrandName.Length == 0))
            {
                foreach (var VARIABLE in model.BrandName)
                {
                    ReslutList.AddRange(r.Where(x => x.CarBrandName == VARIABLE));
                    r2 = ReslutList;
                    ReslutList.Clear();
                }
            }
            if (!(model.BrandName == null || model.BrandName.Length == 0))
            {
                foreach (var VARIABLE in model.BrandName)
                {
                    ReslutList.AddRange(r.Where(x => x.CarBrandName == VARIABLE));
                    r2 = ReslutList;
                    ReslutList.Clear();
                }
            }
            if (!(model.BrandName == null || model.BrandName.Length == 0))
            {
                foreach (var VARIABLE in model.BrandName)
                {
                    ReslutList.AddRange(r.Where(x => x.CarBrandName == VARIABLE));
                    r2 = ReslutList;
                    ReslutList.Clear();
                }
            }
            if (!(model.BrandName == null || model.BrandName.Length == 0))
            {
                foreach (var VARIABLE in model.BrandName)
                {
                    ReslutList.AddRange(r.Where(x => x.CarBrandName == VARIABLE));
                    r2 = ReslutList;
                    ReslutList.Clear();
                }
            }
            if (!(model.BrandName == null || model.BrandName.Length == 0))
            {
                foreach (var VARIABLE in model.BrandName)
                {
                    ReslutList.AddRange(r.Where(x => x.CarBrandName == VARIABLE));
                    r2 = ReslutList;
                    ReslutList.Clear();
                }
            }
            if (!(model.BrandName == null || model.BrandName.Length == 0))
            {
                foreach (var VARIABLE in model.BrandName)
                {
                    ReslutList.AddRange(r.Where(x => x.CarBrandName == VARIABLE));
                    r2 = ReslutList;
                    ReslutList.Clear();
                }
            }
            if (!(model.BrandName == null || model.BrandName.Length == 0))
            {
                foreach (var VARIABLE in model.BrandName)
                {
                    ReslutList.AddRange(r.Where(x => x.CarBrandName == VARIABLE));
                    r2 = ReslutList;
                    ReslutList.Clear();
                }
            }
            if (!(model.BrandName == null || model.BrandName.Length == 0))
            {
                foreach (var VARIABLE in model.BrandName)
                {
                    ReslutList.AddRange(r.Where(x => x.CarBrandName == VARIABLE));
                    r2 = ReslutList;
                    ReslutList.Clear();
                }
            }
            return r;
        }

        
    }
}