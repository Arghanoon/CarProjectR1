using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;

namespace CarProject.CLS.SearchEngine
{
    public class SearchLogic
    {
        private string SearchRequest { get; set; }
        private DBSEF.CarAutomationEntities dbs = new DBSEF.CarAutomationEntities();
        
        public SearchLogic(string searchText)
        {
            this.SearchRequest = searchText;
        }

        public IQueryable<SearchResultItems> DoSearch(SerchResultItemType searchIn = SerchResultItemType.All)
        {
            IQueryable<SearchResultItems> result = null;

            if (searchIn == SerchResultItemType.All)
            {
                result = (SearchInProducts());
                result = result.Concat(SearchInServices());
                result = result.Concat(SearchInCars());
                result = result.Concat(SearchInNews());
            }

            if (searchIn.HasFlag(SerchResultItemType.Product))
            {
                if (result == null)
                    result = SearchInProducts();
                else
                    result = result.Concat(SearchInProducts());
            }

            if (searchIn.HasFlag(SerchResultItemType.Service))
            {
                if (result == null)
                    result = SearchInServices();
                else
                    result = result.Concat(SearchInServices());
            }

            if (searchIn.HasFlag(SerchResultItemType.Car))
            {
                if (result == null)
                    result = SearchInCars();
                else
                    result = result.Concat(SearchInCars());
            }

            if (searchIn.HasFlag(SerchResultItemType.News))
            {
                if (result == null)
                    result = SearchInNews();
                else
                    result = result.Concat(SearchInNews());
            }
            
            return result;
        }
        public IQueryable<SearchResultItems> DoSearch(params SerchResultItemType[] searchIn)
        {
            IQueryable<SearchResultItems> result = null;

            
            if (searchIn.Contains(SerchResultItemType.Product))
            {
                if (result == null)
                    result = SearchInProducts();
                else
                    result = result.Concat(SearchInProducts());
            }

            if (searchIn.Contains(SerchResultItemType.Service))
            {
                if (result == null)
                    result = SearchInServices();
                else
                    result = result.Concat(SearchInServices());
            }

            if (searchIn.Contains(SerchResultItemType.Car))
            {
                if (result == null)
                    result = SearchInCars();
                else
                    result = result.Concat(SearchInCars());
            }

            if (searchIn.Contains(SerchResultItemType.News))
            {
                if (result == null)
                    result = SearchInNews();
                else
                    result = result.Concat(SearchInNews());
            }

            return result;
        }

        IQueryable<SearchResultItems> SearchInProducts(int deslen = 255)
        {
            var res = dbs.Products.Where(c => c.ProductName == SearchRequest).Select(c => new SearchResultItems
            {
                ItemType = SerchResultItemType.Product,
                Identifier = c.ProductId,
                Title = c.Category.CategoryName + " " + c.ProductName,
                Description = c.ProductSecription.Substring(0, deslen),
                MatchingRate = SearchResultItemMatchingRate.Exactly
            });

            res = res.Concat(dbs.Products.Where(c => c.ProductName.Contains(SearchRequest)).Select(c => new SearchResultItems
            {
                ItemType = SerchResultItemType.Product,
                Identifier = c.ProductId,
                Title = c.Category.CategoryName + " " + c.ProductName,
                Description = c.ProductSecription.Substring(0, deslen),
                MatchingRate = SearchResultItemMatchingRate.HaveSomeWord
            }));

            return res;
        }
        IQueryable<SearchResultItems> SearchInServices()
        {
            var res = dbs.AutoServices.Where(c => c.AutoServiceName == SearchRequest).Select(c => new SearchResultItems
            {
                ItemType = SerchResultItemType.Service,
                Identifier = c.AutoServiceId,
                Title = c.AutoServiceName,
                Description = "خدمات",
                MatchingRate = SearchResultItemMatchingRate.Exactly
            });

            res = res.Concat(dbs.AutoServices.Where(c => c.AutoServiceName.Contains(SearchRequest)).Select(c => new SearchResultItems
            {
                ItemType = SerchResultItemType.Service,
                Identifier = c.AutoServiceId,
                Title = c.AutoServiceName,
                Description = "خدمات",
                MatchingRate = SearchResultItemMatchingRate.HaveSomeWord
            }));

            return res;
        }
        IQueryable<SearchResultItems> SearchInCars(int deslen = 255)
        {
            var res = dbs.Cars.Where(c => (c.CarModel.CarBrand.CarBrandName + " " + c.CarModel.CarModelName) == SearchRequest).Select(c => new SearchResultItems
            {
                ItemType = SerchResultItemType.Car,
                Identifier = c.CarsId,
                Title = c.CarModel.CarBrand.CarBrandName + " " + c.CarModel.CarModelName,
                Description = c.CarsDescription.Substring(0, deslen),
                MatchingRate = SearchResultItemMatchingRate.Exactly
            });

            res = res.Concat(dbs.Cars.Where(c => (c.CarModel.CarBrand.CarBrandName + " " + c.CarModel.CarModelName).Contains(SearchRequest)).Select(c => new SearchResultItems
            {
                ItemType = SerchResultItemType.Car,
                Identifier = c.CarsId,
                Title = c.CarModel.CarBrand.CarBrandName + " " + c.CarModel.CarModelName,
                Description = c.CarsDescription.Substring(0, deslen),
                MatchingRate = SearchResultItemMatchingRate.Exactly
            }));

            return res;
        }
        IQueryable<SearchResultItems> SearchInNews(int deslen = 255)
        {
            var res = dbs.Contents.Where(c => (c.ContentSubject) == SearchRequest).Select(c => new SearchResultItems
            {
                ItemType = SerchResultItemType.News,
                Identifier = c.ContenstId,
                Title = c.ContentSubject,
                Description = c.ContentDescribe.Substring(0, deslen),
                MatchingRate = SearchResultItemMatchingRate.Exactly
            });

            res = res.Concat(dbs.Contents.Where(c => c.ContentSubject.Contains(SearchRequest) || c.ContentDescribe.Contains(SearchRequest) || c.ContentText.Contains(SearchRequest)).Select(c => new SearchResultItems
            {
                ItemType = SerchResultItemType.News,
                Identifier = c.ContenstId,
                Title = c.ContentSubject,
                Description = c.ContentDescribe.Substring(0, deslen),
                MatchingRate = SearchResultItemMatchingRate.Exactly
            }));

            return res;
        }

    }
    
    [Flags]
    public enum SerchResultItemType
    {
        All = 0,
        Product = 1,
        Service = 2,
        Car = 3,
        News = 4
    };
    public enum SearchResultItemMatchingRate
    {
        Exactly = 1,
        HaveSomeWord = 2,
        HaveOneWord = 3
    };

    public static class StringForEnums
    {
        public static string GetString(this SerchResultItemType value)
        {
            switch (value)
            {
                case SerchResultItemType.All:
                    return "همه";
                case SerchResultItemType.Product:
                    return "محصولات";
                case SerchResultItemType.Service:
                    return "سرویس ها";
                case SerchResultItemType.Car:
                    return "خودروها";
                case SerchResultItemType.News:
                    return "اخبار";
                default:
                    return "";
            }
        }
    }
    

    public class SearchResultItems
    {
        public SerchResultItemType ItemType { get; set; }
        public int Identifier { get; set; }
        public string Title {get;set;}
        public string Description { get; set; }
        public SearchResultItemMatchingRate MatchingRate { get; set; }

        public object GetObject()
        {
            var dbs = DBSEF.SingletoonDBS.GetInstance;

            switch (this.ItemType)
            {
                
                case SerchResultItemType.Product:
                    return dbs.Products.FirstOrDefault(p => p.ProductId == Identifier);
                case SerchResultItemType.Service:
                    return dbs.AutoServices.FirstOrDefault(asv => asv.AutoServiceId == Identifier);
                case SerchResultItemType.Car:
                    return dbs.Cars.FirstOrDefault(c => c.CarsId == Identifier);
                case SerchResultItemType.News:
                    return dbs.Contents.FirstOrDefault(c => c.ContenstId == Identifier);
                case SerchResultItemType.All:
                default:
                    return null;
            }
        }

        public int View
        {
            get
            {
                var dbs = DBSEF.SingletoonDBS.GetInstance;

                switch (ItemType)
                {
                    case SerchResultItemType.Product:
                        {
                            var x = dbs.ProductToViews.FirstOrDefault(pdv => pdv.ProductId == Identifier);
                            if (x != null)
                                return x.Viewd.GetValueOrDefault(0);
                            else
                                return 0;
                        }
                    case SerchResultItemType.Service:
                        {
                            var x = dbs.ServiceToViews.FirstOrDefault(sdv => sdv.ServiceId == Identifier);
                            if (x != null)
                                return x.Views.GetValueOrDefault(0);
                            else
                                return 0;
                        }
                    case SerchResultItemType.Car:
                        {
                            var x = dbs.CarsToViews.FirstOrDefault(ctv => ctv.CarsId == Identifier);
                            if (x != null)
                                return x.View.GetValueOrDefault(0);
                            else
                                return 0;
                        }                        
                    case SerchResultItemType.News:{
                            var x = dbs.ContentPresentations.FirstOrDefault(cp => cp.ContentId == Identifier);
                            if (x != null)
                                return x.ShowCount.GetValueOrDefault(0);
                            else
                                return 0;
                        }
                        
                    case SerchResultItemType.All: 
                    default:
                        return 0;
                }
            }
        }
    }
}