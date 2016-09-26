using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
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
            //Car.Join(CarModel, p => , c => , (p, c) => new {p, c}) 
            var Resultting = (Contexts.CarBrands.Join(Contexts.CarModels, carbrand => carbrand.CarBrandId,
                carmodel => carmodel.CarBrandId, (carbrand, carmodel) => new { carbrand, carmodel })
                .Join(Contexts.Cars, @t => @t.carmodel.CarModelId, cars => cars.CarModelId, (@t, cars) => new { @t, cars })
                .Join(Contexts.CarGearBoxes, @t => @t.cars.CarsId, cargearbox => cargearbox.CarsId,
                    (@t, cargearbox) => new { @t, cargearbox })
                .Join(Contexts.CarEngines, @t => @t.@t.cars.CarsId, carengine => carengine.CarsId,
                    (@t, carengine) => new { @t, carengine })
                .Join(Contexts.CarPrices, @t => @t.@t.@t.cars.CarsId, carprice => carprice.CarsId,
                    (@t, carprice) => new { @t, carprice })
                .Join(Contexts.FuelConsumptions, @t => @t.@t.@t.@t.cars.CarsId, fuel => fuel.CarId, (@t, fuel) => new
                {
                    @t.@t.@t.@t.@t.carbrand.CarBrandName,
                    @t.@t.@t.@t.@t.carmodel.CarModelName,
                    @t.@t.carengine.EngineType,
                    @t.@t.carengine.EngineCylinderNumber,
                    @t.@t.@t.cargearbox.GearBoxType,
                    @t.@t.@t.cargearbox.GearBoxAxel,
                    @t.@t.@t.@t.cars.CarUsage,
                    @t.@t.@t.@t.cars.CarYearModel,
                    @t.@t.@t.@t.cars.CarBodyType,
                    fuel.LphCity,
                    fuel.LphRoad,
                    fuel.LphMix
                })).Distinct();

            var result = Resultting;
            var r1 = result.ToList();
            var r2 = r1;
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
                    r2 = r1;
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

            return r1;
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