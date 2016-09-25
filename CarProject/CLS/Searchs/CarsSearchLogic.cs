using System;
using System.Collections;
using System.Collections.Generic;
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
            
             
            
           var result = (Contexts.Products.GroupJoin(Contexts.ProductPrices, product => new {ProductId = product.ProductId},
               ProductPrice => new {ProductId = Convert.ToInt32(ProductPrice.ProductId)},
               (product, ProductPrice_join) => new {product, ProductPrice_join})
               .SelectMany(@t => ProductPrice_join.DefaultIfEmpty(), (@t, ProductPrice) => new {@t, ProductPrice})
               .GroupJoin(Contexts.ProductStores, @t => new {ProductId = product.ProductId},
                   ProductStore => new {ProductId = Convert.ToInt32(ProductStore.ProductId)},
                   (@t, ProductStore_join) => new {@t, ProductStore_join})
               .SelectMany(@t => ProductStore_join.DefaultIfEmpty(), (@t, ProductStore) => new {@t, ProductStore})
               .GroupJoin(Contexts.Categories, @t => new {CategoryId = Convert.ToInt32(Product.CategoryId)},
                   Category => new {CategoryId = Category.CategoryId}, (@t, Category_join) => new {@t, Category_join})
               .SelectMany(@t => Category_join.DefaultIfEmpty(), (@t, Category) => new {@t, Category})
               .GroupJoin(Contexts.Categories, @t => new {CompanyId = Convert.ToInt32(Product.CompanyId)},
                   Company => new {CompanyId = Company.CompanyId}, (@t, Company_join) => new {@t, Company_join})
               .SelectMany(@t => Company_join.DefaultIfEmpty(), (@t, Company) => new {@t, Company})
               .GroupJoin(Contexts.Manufactures, @t => new {ManufactureId = Convert.ToInt32(Product.ManufactureId)},
                   Manufacture => new {ManufactureId = Manufacture.ManufactureId},
                   (@t, Manufacture_join) => new {@t, Manufacture_join})
               .SelectMany(@t => Manufacture_join.DefaultIfEmpty(), (@t, Manufacture) => new {@t, Manufacture})
               .GroupJoin(Contexts.Cars, @t => new {CarId = Convert.ToInt32(Product.CarId)}, Cars => new {CarId = Cars.CarsId},
                   (@t, Cars_join) => new {@t, Cars_join})
               .SelectMany(@t => Cars_joins.DefaultIfEmpty(), (@t, Cars) => new {@t, Cars})
               .GroupJoin(Contexts.CarModels, @t => new {CarModelId = Convert.ToInt32(Cars.CarModelId)},
                   CarModel => new {CarModelId = CarModel.CarModelId}, (@t, CarModel_join) => new {@t, CarModel_join})
               .SelectMany(@t => CarModel_join.DefaultIfEmpty(), (@t, CarModel) => new {@t, CarModel})
               .GroupJoin(Contexts.CarBrands, @t => new {CarBrandId = Convert.ToInt32(CarModel.CarBrandId)},
                   CarBrand => new {CarBrandId = CarBrand.CarBrandId}, (@t, CarBrand_join) => new {@t, CarBrand_join})
               .SelectMany(@t => CarBrand_join.DefaultIfEmpty(), (@t, CarBrand) => new {@t, CarBrand})
               .GroupJoin(Contexts.Countries, @t => new
               {
                   CountryId = Product.CountryId,
                   Column1 = Manufacture.CountryId
               }, Country => new {CountryId = Country.CountryId, Column1 = Country.CountryId},
                   (@t, Country_join) => new {@t, Country_join})
               .SelectMany(@t => Country_join.DefaultIfEmpty(), (@t, Country) => new
               {
                   ManufactureName = Manufacture.ManufactureName,
                   Product.ProductName,
                   CarBrandName = CarBrand.CarBrandName,
                   CarModelName = CarModel.CarModelName,
                   CountryLongName = Country.CountryLongName,
                   ProductPrice1 = (int?) ProductPrice.ProductPrice1,
                   CategoryName = Category.CategoryName
               })).Distinct();
            //var Resultting = (Contexts.CarBrands.Join(Contexts.CarModels, carbrand => carbrand.CarBrandId,
            //               carmodel => carmodel.CarBrandId, (carbrand, carmodel) => new { carbrand, carmodel })
            //               .Join(Contexts.Cars, @t => @t.carmodel.CarModelId, cars => cars.CarModelId, (@t, cars) => new { @t, cars })
            //               .Join(Contexts.CarGearBoxes, @t => @t.cars.CarsId, cargearbox => cargearbox.CarsId,
            //                   (@t, cargearbox) => new { @t, cargearbox })
            //               .Join(Contexts.CarEngines, @t => @t.@t.cars.CarsId, carengine => carengine.CarsId,
            //                   (@t, carengine) => new { @t, carengine })
            //               .Join(Contexts.CarPrices, @t => @t.@t.@t.cars.CarsId, carprice => carprice.CarsId,
            //                   (@t, carprice) => new { @t, carprice })
            //               .Join(Contexts.FuelConsumptions, @t => @t.@t.@t.@t.cars.CarsId, fuel => fuel.CarId, (@t, fuel) => new
            //               {
            //                   @t.@t.@t.@t.@t.carbrand.CarBrandName,
            //                   @t.@t.@t.@t.@t.carmodel.CarModelName,
            //                   @t.@t.carengine.EngineType,
            //                   @t.@t.carengine.EngineCylinderNumber,
            //                   @t.@t.@t.cargearbox.GearBoxType,
            //                   @t.@t.@t.cargearbox.GearBoxAxel,
            //                   @t.@t.@t.@t.cars.CarUsage,
            //                   @t.@t.@t.@t.cars.CarYearModel,
            //                   @t.@t.@t.@t.cars.CarBodyType,
            //                   fuel.LphCity,
            //                   fuel.LphRoad,
            //                   fuel.LphMix
            //               })).Distinct();
        }
    }
}