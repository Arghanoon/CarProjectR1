

// This file was automatically generated.
// Do not make changes directly to this file - edit the template instead.
// 
// The following connection settings were used to generate this file
// 
//     Connection String Name: "connection"
//     Connection String:      "Data Source=.;Initial Catalog=RideProj;Integrated Security=True"

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;

namespace MyDatabase
{
    // ************************************************************************
    // Database context
    public partial class MyDbContext : DbContext
    {
        public IDbSet<BuyConfirm> BuyConfirm { get; set; } // BuyConfirm
        public IDbSet<BuyProduct> BuyProduct { get; set; } // BuyProduct
        public IDbSet<Cars> Cars { get; set; } // Cars
        public IDbSet<Category> Category { get; set; } // Category
        public IDbSet<Degree> Degree { get; set; } // Degree
        public IDbSet<PermissionCode> PermissionCode { get; set; } // PermissionCode
        public IDbSet<Product> Product { get; set; } // Product
        public IDbSet<ProductDetail> ProductDetail { get; set; } // ProductDetail
        public IDbSet<ProductRequest> ProductRequest { get; set; } // ProductRequest
        public IDbSet<ProductResponse> ProductResponse { get; set; } // ProductResponse
        public IDbSet<Section> Section { get; set; } // Section
        public IDbSet<Store> Store { get; set; } // Store
        public IDbSet<User> User { get; set; } // User
        public IDbSet<WorkConfirmation> WorkConfirmation { get; set; } // WorkConfirmation
        public IDbSet<Works> Works { get; set; } // Works
        public IDbSet<WorkShop> WorkShop { get; set; } // WorkShop
        public IDbSet<WorkShopDo> WorkShopDo { get; set; } // WorkShopDo
        public IDbSet<WorkSubmit> WorkSubmit { get; set; } // WorkSubmit

        static MyDbContext()
        {
            Database.SetInitializer<MyDbContext>(null);
        }

        public MyDbContext()
            : base("Name=connection")
        {
        }

        public MyDbContext(string connectionString) : base(connectionString)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new BuyConfirmConfiguration());
            modelBuilder.Configurations.Add(new BuyProductConfiguration());
            modelBuilder.Configurations.Add(new CarsConfiguration());
            modelBuilder.Configurations.Add(new CategoryConfiguration());
            modelBuilder.Configurations.Add(new DegreeConfiguration());
            modelBuilder.Configurations.Add(new PermissionCodeConfiguration());
            modelBuilder.Configurations.Add(new ProductConfiguration());
            modelBuilder.Configurations.Add(new ProductDetailConfiguration());
            modelBuilder.Configurations.Add(new ProductRequestConfiguration());
            modelBuilder.Configurations.Add(new ProductResponseConfiguration());
            modelBuilder.Configurations.Add(new SectionConfiguration());
            modelBuilder.Configurations.Add(new StoreConfiguration());
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new WorkConfirmationConfiguration());
            modelBuilder.Configurations.Add(new WorksConfiguration());
            modelBuilder.Configurations.Add(new WorkShopConfiguration());
            modelBuilder.Configurations.Add(new WorkShopDoConfiguration());
            modelBuilder.Configurations.Add(new WorkSubmitConfiguration());
        }
    }

    // ************************************************************************
    // POCO classes

    // BuyConfirm
    public partial class BuyConfirm   
    {
		public static int Count()
        {
            return MyDbContext.db.BuyConfirm.Count();
        }
		public static BuyConfirm GetById(int id)
        {
            return MyDbContext.db.BuyConfirm.FirstOrDefault(x => x.BuyConfirmId == id);
        }
		public static bool Delete(int id)
        { 
            try
            {
                MyDbContext.db.BuyConfirm.Remove(GetById(id));

                MyDbContext.db.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                Bussiness.BaseClass.log(ex);
                return false;
            }
        }
		public static int AddOrUpdate(BuyConfirm item)
        {
            var newItem = GetById(item.BuyConfirmId) ?? new BuyConfirm();

			newItem.BuyConfirmId = item.BuyConfirmId;
			newItem.BuyNumber = item.BuyNumber;
			newItem.SpectorId = item.SpectorId;
			newItem.Spector2Id = item.Spector2Id;
			newItem.Spector3Id = item.Spector3Id;
			newItem.Spector4Id = item.Spector4Id;
			newItem.Spector5Id = item.Spector5Id;
			newItem.Spector6Id = item.Spector6Id;
			newItem.Spector7Id = item.Spector7Id;
			newItem.Date = item.Date;
            try
            {
                if (newItem.BuyConfirmId == 0) MyDbContext.db.BuyConfirm.Add(newItem);

                MyDbContext.db.SaveChanges();

                return newItem.BuyConfirmId;
            }
            catch (Exception ex)
            {
                Bussiness.BaseClass.log(ex);
                return -1;
            }
        }
        public static List<BuyConfirm> Search(BuyConfirm search)
        {
            var result = from x in MyDbContext.db.BuyConfirm
                         where 
						 (search.BuyConfirmId == 0 || 
						 x.BuyConfirmId == search.BuyConfirmId) &&
						 (search.BuyNumber == null || 
						 x.BuyNumber == search.BuyNumber) &&
						 (search.SpectorId == null || 
						 x.SpectorId == search.SpectorId) &&
						 (search.Spector2Id == null || 
						 x.Spector2Id == search.Spector2Id) &&
						 (search.Spector3Id == null || 
						 x.Spector3Id == search.Spector3Id) &&
						 (search.Spector4Id == null || 
						 x.Spector4Id == search.Spector4Id) &&
						 (search.Spector5Id == null || 
						 x.Spector5Id == search.Spector5Id) &&
						 (search.Spector6Id == null || 
						 x.Spector6Id == search.Spector6Id) &&
						 (search.Spector7Id == null || 
						 x.Spector7Id == search.Spector7Id) &&
						 (search.Date == null || 
						 x.Date == search.Date) &&
true
                         select x; 
            return result.ToList();
        }

        public int BuyConfirmId { get; set; } // BuyConfirmId (Primary key)
        public int? BuyNumber { get; set; } // BuyNumber
        public int? SpectorId { get; set; } // SpectorId
        public int? Spector2Id { get; set; } // Spector2Id
        public int? Spector3Id { get; set; } // Spector3Id
        public int? Spector4Id { get; set; } // Spector4Id
        public int? Spector5Id { get; set; } // Spector5Id
        public int? Spector6Id { get; set; } // Spector6Id
        public int? Spector7Id { get; set; } // Spector7Id
        public DateTime? Date { get; set; } // Date

        // Reverse navigation
        public virtual ICollection<BuyProduct> BuyProduct { get; set; } // BuyProduct.FK_BuyProduct_BuyConfirm;

        // Foreign keys
        public virtual User User6 { get; set; } //  SpectorId - FK_BuyConfirm_User
        public virtual User User { get; set; } //  Spector2Id - FK_BuyConfirm_User1
        public virtual User User1 { get; set; } //  Spector3Id - FK_BuyConfirm_User2
        public virtual User User2 { get; set; } //  Spector4Id - FK_BuyConfirm_User3
        public virtual User User3 { get; set; } //  Spector5Id - FK_BuyConfirm_User4
        public virtual User User4 { get; set; } //  Spector6Id - FK_BuyConfirm_User5
        public virtual User User5 { get; set; } //  Spector7Id - FK_BuyConfirm_User6

        public BuyConfirm()
        {
            BuyProduct = new List<BuyProduct>();
        }
    }

    // BuyProduct
    public partial class BuyProduct   
    {
		public static int Count()
        {
            return MyDbContext.db.BuyProduct.Count();
        }
		public static BuyProduct GetById(int id)
        {
            return MyDbContext.db.BuyProduct.FirstOrDefault(x => x.BuyProductId == id);
        }
		public static bool Delete(int id)
        { 
            try
            {
                MyDbContext.db.BuyProduct.Remove(GetById(id));

                MyDbContext.db.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                Bussiness.BaseClass.log(ex);
                return false;
            }
        }
		public static int AddOrUpdate(BuyProduct item)
        {
            var newItem = GetById(item.BuyProductId) ?? new BuyProduct();

			newItem.BuyProductId = item.BuyProductId;
			newItem.ProductId = item.ProductId;
			newItem.BuyerId = item.BuyerId;
			newItem.BuyCount = item.BuyCount;
			newItem.BuyNumber = item.BuyNumber;
			newItem.Date = item.Date;
			newItem.IsConfirmed = item.IsConfirmed;
			newItem.ConfirmId = item.ConfirmId;
            try
            {
                if (newItem.BuyProductId == 0) MyDbContext.db.BuyProduct.Add(newItem);

                MyDbContext.db.SaveChanges();

                return newItem.BuyProductId;
            }
            catch (Exception ex)
            {
                Bussiness.BaseClass.log(ex);
                return -1;
            }
        }
        public static List<BuyProduct> Search(BuyProduct search)
        {
            var result = from x in MyDbContext.db.BuyProduct
                         where 
						 (search.BuyProductId == 0 || 
						 x.BuyProductId == search.BuyProductId) &&
						 (search.ProductId == null || 
						 x.ProductId == search.ProductId) &&
						 (search.BuyerId == null || 
						 x.BuyerId == search.BuyerId) &&
						 (search.BuyCount == null || 
						 x.BuyCount == search.BuyCount) &&
						 (search.BuyNumber == null || 
						 x.BuyNumber == search.BuyNumber) &&
						 (search.Date == null || 
						 x.Date == search.Date) &&
						 (search.IsConfirmed == null || 
						 x.IsConfirmed == search.IsConfirmed) &&
						 (search.ConfirmId == null || 
						 x.ConfirmId == search.ConfirmId) &&
true
                         select x; 
            return result.ToList();
        }

        public int BuyProductId { get; set; } // BuyProductId (Primary key)
        public int? ProductId { get; set; } // ProductId
        public int? BuyerId { get; set; } // BuyerId
        public int? BuyCount { get; set; } // BuyCount
        public int? BuyNumber { get; set; } // BuyNumber
        public DateTime? Date { get; set; } // Date
        public bool? IsConfirmed { get; set; } // IsConfirmed
        public int? ConfirmId { get; set; } // ConfirmId

        // Foreign keys
        public virtual Product Product { get; set; } //  ProductId - FK_BuyProduct_Product
        public virtual User User { get; set; } //  BuyerId - FK_BuyProduct_User
        public virtual BuyConfirm BuyConfirm { get; set; } //  ConfirmId - FK_BuyProduct_BuyConfirm
    }

    // Cars
    public partial class Cars   
    {
		public static int Count()
        {
            return MyDbContext.db.Cars.Count();
        }
		public static Cars GetById(int id)
        {
            return MyDbContext.db.Cars.FirstOrDefault(x => x.CarsId == id);
        }
		public static bool Delete(int id)
        { 
            try
            {
                MyDbContext.db.Cars.Remove(GetById(id));

                MyDbContext.db.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                Bussiness.BaseClass.log(ex);
                return false;
            }
        }
		public static int AddOrUpdate(Cars item)
        {
            var newItem = GetById(item.CarsId) ?? new Cars();

			newItem.CarsId = item.CarsId;
			newItem.CarName = item.CarName;
			newItem.CarNumber = item.CarNumber;
			newItem.IsActive = item.IsActive;
            try
            {
                if (newItem.CarsId == 0) MyDbContext.db.Cars.Add(newItem);

                MyDbContext.db.SaveChanges();

                return newItem.CarsId;
            }
            catch (Exception ex)
            {
                Bussiness.BaseClass.log(ex);
                return -1;
            }
        }
        public static List<Cars> Search(Cars search)
        {
            var result = from x in MyDbContext.db.Cars
                         where 
						 (search.CarsId == 0 || 
						 x.CarsId == search.CarsId) &&
						 (search.CarName == null || 
						 x.CarName.Contains(search.CarName)) &&
						 (search.CarNumber == null || 
						 x.CarNumber == search.CarNumber) &&
						 (search.IsActive == null || 
						 x.IsActive == search.IsActive) &&
true
                         select x; 
            return result.ToList();
        }

        public int CarsId { get; set; } // CarsId (Primary key)
        public string CarName { get; set; } // CarName
        public int? CarNumber { get; set; } // CarNumber
        public bool? IsActive { get; set; } // IsActive

        // Reverse navigation
        public virtual ICollection<Works> Works { get; set; } // Works.FK_Works_Cars;

        public Cars()
        {
            Works = new List<Works>();
        }
    }

    // Category
    public partial class Category   
    {
		public static int Count()
        {
            return MyDbContext.db.Category.Count();
        }
		public static Category GetById(int id)
        {
            return MyDbContext.db.Category.FirstOrDefault(x => x.CategoryId == id);
        }
		public static bool Delete(int id)
        { 
            try
            {
                MyDbContext.db.Category.Remove(GetById(id));

                MyDbContext.db.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                Bussiness.BaseClass.log(ex);
                return false;
            }
        }
		public static int AddOrUpdate(Category item)
        {
            var newItem = GetById(item.CategoryId) ?? new Category();

			newItem.CategoryId = item.CategoryId;
			newItem.CategoryName = item.CategoryName;
            try
            {
                if (newItem.CategoryId == 0) MyDbContext.db.Category.Add(newItem);

                MyDbContext.db.SaveChanges();

                return newItem.CategoryId;
            }
            catch (Exception ex)
            {
                Bussiness.BaseClass.log(ex);
                return -1;
            }
        }
        public static List<Category> Search(Category search)
        {
            var result = from x in MyDbContext.db.Category
                         where 
						 (search.CategoryId == 0 || 
						 x.CategoryId == search.CategoryId) &&
						 (search.CategoryName == null || 
						 x.CategoryName.Contains(search.CategoryName)) &&
true
                         select x; 
            return result.ToList();
        }

        public int CategoryId { get; set; } // CategoryId (Primary key)
        public string CategoryName { get; set; } // CategoryName

        // Reverse navigation
        public virtual ICollection<Product> Product { get; set; } // Product.FK_Product_Category;

        public Category()
        {
            Product = new List<Product>();
        }
    }

    // Degree
    public partial class Degree   
    {
		public static int Count()
        {
            return MyDbContext.db.Degree.Count();
        }
		public static Degree GetById(int id)
        {
            return MyDbContext.db.Degree.FirstOrDefault(x => x.DegreeId == id);
        }
		public static bool Delete(int id)
        { 
            try
            {
                MyDbContext.db.Degree.Remove(GetById(id));

                MyDbContext.db.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                Bussiness.BaseClass.log(ex);
                return false;
            }
        }
		public static int AddOrUpdate(Degree item)
        {
            var newItem = GetById(item.DegreeId) ?? new Degree();

			newItem.DegreeId = item.DegreeId;
			newItem.DegreeName = item.DegreeName;
            try
            {
                if (newItem.DegreeId == 0) MyDbContext.db.Degree.Add(newItem);

                MyDbContext.db.SaveChanges();

                return newItem.DegreeId;
            }
            catch (Exception ex)
            {
                Bussiness.BaseClass.log(ex);
                return -1;
            }
        }
        public static List<Degree> Search(Degree search)
        {
            var result = from x in MyDbContext.db.Degree
                         where 
						 (search.DegreeId == 0 || 
						 x.DegreeId == search.DegreeId) &&
						 (search.DegreeName == null || 
						 x.DegreeName.Contains(search.DegreeName)) &&
true
                         select x; 
            return result.ToList();
        }

        public int DegreeId { get; set; } // DegreeId (Primary key)
        public string DegreeName { get; set; } // DegreeName

        // Reverse navigation
        public virtual ICollection<User> User { get; set; } // User.FK_User_Degree;

        public Degree()
        {
            User = new List<User>();
        }
    }

    // PermissionCode
    public partial class PermissionCode   
    {
		public static int Count()
        {
            return MyDbContext.db.PermissionCode.Count();
        }
		public static PermissionCode GetById(int id)
        {
            return MyDbContext.db.PermissionCode.FirstOrDefault(x => x.PermissionCodeId == id);
        }
		public static bool Delete(int id)
        { 
            try
            {
                MyDbContext.db.PermissionCode.Remove(GetById(id));

                MyDbContext.db.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                Bussiness.BaseClass.log(ex);
                return false;
            }
        }
		public static int AddOrUpdate(PermissionCode item)
        {
            var newItem = GetById(item.PermissionCodeId) ?? new PermissionCode();

			newItem.PermissionCodeId = item.PermissionCodeId;
			newItem.Permission = item.Permission;
            try
            {
                if (newItem.PermissionCodeId == 0) MyDbContext.db.PermissionCode.Add(newItem);

                MyDbContext.db.SaveChanges();

                return newItem.PermissionCodeId;
            }
            catch (Exception ex)
            {
                Bussiness.BaseClass.log(ex);
                return -1;
            }
        }
        public static List<PermissionCode> Search(PermissionCode search)
        {
            var result = from x in MyDbContext.db.PermissionCode
                         where 
						 (search.PermissionCodeId == 0 || 
						 x.PermissionCodeId == search.PermissionCodeId) &&
						 (search.Permission == null || 
						 x.Permission.Contains(search.Permission)) &&
true
                         select x; 
            return result.ToList();
        }

        public int PermissionCodeId { get; set; } // PermissionCodeId (Primary key)
        public string Permission { get; set; } // Permission

        // Reverse navigation
        public virtual ICollection<User> User { get; set; } // User.FK_User_PermissionCode;

        public PermissionCode()
        {
            User = new List<User>();
        }
    }

    // Product
    public partial class Product   
    {
		public static int Count()
        {
            return MyDbContext.db.Product.Count();
        }
		public static Product GetById(int id)
        {
            return MyDbContext.db.Product.FirstOrDefault(x => x.ProductId == id);
        }
		public static bool Delete(int id)
        { 
            try
            {
                MyDbContext.db.Product.Remove(GetById(id));

                MyDbContext.db.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                Bussiness.BaseClass.log(ex);
                return false;
            }
        }
		public static int AddOrUpdate(Product item)
        {
            var newItem = GetById(item.ProductId) ?? new Product();

			newItem.ProductId = item.ProductId;
			newItem.ProductName = item.ProductName;
			newItem.Price = item.Price;
			newItem.CategoryId = item.CategoryId;
			newItem.ProductNumber = item.ProductNumber;
            try
            {
                if (newItem.ProductId == 0) MyDbContext.db.Product.Add(newItem);

                MyDbContext.db.SaveChanges();

                return newItem.ProductId;
            }
            catch (Exception ex)
            {
                Bussiness.BaseClass.log(ex);
                return -1;
            }
        }
        public static List<Product> Search(Product search)
        {
            var result = from x in MyDbContext.db.Product
                         where 
						 (search.ProductId == 0 || 
						 x.ProductId == search.ProductId) &&
						 (search.ProductName == null || 
						 x.ProductName.Contains(search.ProductName)) &&
						 (search.Price == null || 
						 x.Price == search.Price) &&
						 (search.CategoryId == null || 
						 x.CategoryId == search.CategoryId) &&
						 (search.ProductNumber == null || 
						 x.ProductNumber == search.ProductNumber) &&
true
                         select x; 
            return result.ToList();
        }

        public int ProductId { get; set; } // ProductId (Primary key)
        public string ProductName { get; set; } // ProductName
        public int? Price { get; set; } // Price
        public int? CategoryId { get; set; } // CategoryId
        public int? ProductNumber { get; set; } // ProductNumber

        // Reverse navigation
        public virtual ICollection<BuyProduct> BuyProduct { get; set; } // BuyProduct.FK_BuyProduct_Product;
        public virtual ICollection<ProductDetail> ProductDetail { get; set; } // ProductDetail.FK_ProductDetail_Product;
        public virtual ICollection<ProductRequest> ProductRequest { get; set; } // ProductRequest.FK_ProductRequest_Product;
        public virtual ICollection<Store> Store { get; set; } // Store.FK_Store_Product;

        // Foreign keys
        public virtual Category Category { get; set; } //  CategoryId - FK_Product_Category

        public Product()
        {
            BuyProduct = new List<BuyProduct>();
            ProductDetail = new List<ProductDetail>();
            ProductRequest = new List<ProductRequest>();
            Store = new List<Store>();
        }
    }

    // ProductDetail
    public partial class ProductDetail   
    {
		public static int Count()
        {
            return MyDbContext.db.ProductDetail.Count();
        }
		public static ProductDetail GetById(int id)
        {
            return MyDbContext.db.ProductDetail.FirstOrDefault(x => x.ProductDetailId == id);
        }
		public static bool Delete(int id)
        { 
            try
            {
                MyDbContext.db.ProductDetail.Remove(GetById(id));

                MyDbContext.db.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                Bussiness.BaseClass.log(ex);
                return false;
            }
        }
		public static int AddOrUpdate(ProductDetail item)
        {
            var newItem = GetById(item.ProductDetailId) ?? new ProductDetail();

			newItem.ProductDetailId = item.ProductDetailId;
			newItem.ProductType = item.ProductType;
			newItem.Date = item.Date;
			newItem.ProductId = item.ProductId;
            try
            {
                if (newItem.ProductDetailId == 0) MyDbContext.db.ProductDetail.Add(newItem);

                MyDbContext.db.SaveChanges();

                return newItem.ProductDetailId;
            }
            catch (Exception ex)
            {
                Bussiness.BaseClass.log(ex);
                return -1;
            }
        }
        public static List<ProductDetail> Search(ProductDetail search)
        {
            var result = from x in MyDbContext.db.ProductDetail
                         where 
						 (search.ProductDetailId == 0 || 
						 x.ProductDetailId == search.ProductDetailId) &&
						 (search.ProductType == null || 
						 x.ProductType == search.ProductType) &&
						 (search.Date == null || 
						 x.Date == search.Date) &&
						 (search.ProductId == null || 
						 x.ProductId == search.ProductId) &&
true
                         select x; 
            return result.ToList();
        }

        public int ProductDetailId { get; set; } // ProductDetailId (Primary key)
        public bool? ProductType { get; set; } // ProductType
        public DateTime? Date { get; set; } // Date
        public int? ProductId { get; set; } // ProductId

        // Foreign keys
        public virtual Product Product { get; set; } //  ProductId - FK_ProductDetail_Product
    }

    // ProductRequest
    public partial class ProductRequest   
    {
		public static int Count()
        {
            return MyDbContext.db.ProductRequest.Count();
        }
		public static ProductRequest GetById(int id)
        {
            return MyDbContext.db.ProductRequest.FirstOrDefault(x => x.ProductRequestId == id);
        }
		public static bool Delete(int id)
        { 
            try
            {
                MyDbContext.db.ProductRequest.Remove(GetById(id));

                MyDbContext.db.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                Bussiness.BaseClass.log(ex);
                return false;
            }
        }
		public static int AddOrUpdate(ProductRequest item)
        {
            var newItem = GetById(item.ProductRequestId) ?? new ProductRequest();

			newItem.ProductRequestId = item.ProductRequestId;
			newItem.ProductId = item.ProductId;
			newItem.ProductNumber = item.ProductNumber;
			newItem.SpectorId = item.SpectorId;
			newItem.Date = item.Date;
			newItem.WorksId = item.WorksId;
			newItem.WorkShopId = item.WorkShopId;
            try
            {
                if (newItem.ProductRequestId == 0) MyDbContext.db.ProductRequest.Add(newItem);

                MyDbContext.db.SaveChanges();

                return newItem.ProductRequestId;
            }
            catch (Exception ex)
            {
                Bussiness.BaseClass.log(ex);
                return -1;
            }
        }
        public static List<ProductRequest> Search(ProductRequest search)
        {
            var result = from x in MyDbContext.db.ProductRequest
                         where 
						 (search.ProductRequestId == 0 || 
						 x.ProductRequestId == search.ProductRequestId) &&
						 (search.ProductId == null || 
						 x.ProductId == search.ProductId) &&
						 (search.ProductNumber == null || 
						 x.ProductNumber == search.ProductNumber) &&
						 (search.SpectorId == null || 
						 x.SpectorId == search.SpectorId) &&
						 (search.Date == null || 
						 x.Date == search.Date) &&
						 (search.WorksId == null || 
						 x.WorksId == search.WorksId) &&
						 (search.WorkShopId == null || 
						 x.WorkShopId == search.WorkShopId) &&
true
                         select x; 
            return result.ToList();
        }

        public int ProductRequestId { get; set; } // ProductRequestId (Primary key)
        public int? ProductId { get; set; } // ProductId
        public int? ProductNumber { get; set; } // ProductNumber
        public int? SpectorId { get; set; } // SpectorId
        public DateTime? Date { get; set; } // Date
        public int? WorksId { get; set; } // WorksId
        public int? WorkShopId { get; set; } // WorkShopId

        // Reverse navigation
        public virtual ICollection<ProductResponse> ProductResponse { get; set; } // ProductResponse.FK_ProductResponse_ProductRequest;

        // Foreign keys
        public virtual Product Product { get; set; } //  ProductId - FK_ProductRequest_Product
        public virtual User User { get; set; } //  SpectorId - FK_ProductRequest_User
        public virtual Works Works { get; set; } //  WorksId - FK_ProductRequest_Works
        public virtual WorkShop WorkShop { get; set; } //  WorkShopId - FK_ProductRequest_WorkShop

        public ProductRequest()
        {
            ProductResponse = new List<ProductResponse>();
        }
    }

    // ProductResponse
    public partial class ProductResponse   
    {
		public static int Count()
        {
            return MyDbContext.db.ProductResponse.Count();
        }
		public static ProductResponse GetById(int id)
        {
            return MyDbContext.db.ProductResponse.FirstOrDefault(x => x.ProductResponseId == id);
        }
		public static bool Delete(int id)
        { 
            try
            {
                MyDbContext.db.ProductResponse.Remove(GetById(id));

                MyDbContext.db.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                Bussiness.BaseClass.log(ex);
                return false;
            }
        }
		public static int AddOrUpdate(ProductResponse item)
        {
            var newItem = GetById(item.ProductResponseId) ?? new ProductResponse();

			newItem.ProductResponseId = item.ProductResponseId;
			newItem.ProductRequestId = item.ProductRequestId;
			newItem.Spector = item.Spector;
			newItem.IsOk = item.IsOk;
            try
            {
                if (newItem.ProductResponseId == 0) MyDbContext.db.ProductResponse.Add(newItem);

                MyDbContext.db.SaveChanges();

                return newItem.ProductResponseId;
            }
            catch (Exception ex)
            {
                Bussiness.BaseClass.log(ex);
                return -1;
            }
        }
        public static List<ProductResponse> Search(ProductResponse search)
        {
            var result = from x in MyDbContext.db.ProductResponse
                         where 
						 (search.ProductResponseId == 0 || 
						 x.ProductResponseId == search.ProductResponseId) &&
						 (search.ProductRequestId == null || 
						 x.ProductRequestId == search.ProductRequestId) &&
						 (search.Spector == null || 
						 x.Spector == search.Spector) &&
						 (search.IsOk == null || 
						 x.IsOk == search.IsOk) &&
true
                         select x; 
            return result.ToList();
        }

        public int ProductResponseId { get; set; } // ProductResponseId (Primary key)
        public int? ProductRequestId { get; set; } // ProductRequestId
        public int? Spector { get; set; } // Spector
        public bool? IsOk { get; set; } // IsOk

        // Foreign keys
        public virtual ProductRequest ProductRequest { get; set; } //  ProductRequestId - FK_ProductResponse_ProductRequest
        public virtual User User { get; set; } //  Spector - FK_ProductResponse_User
    }

    // Section
    public partial class Section   
    {
		public static int Count()
        {
            return MyDbContext.db.Section.Count();
        }
		public static Section GetById(int id)
        {
            return MyDbContext.db.Section.FirstOrDefault(x => x.SectionId == id);
        }
		public static bool Delete(int id)
        { 
            try
            {
                MyDbContext.db.Section.Remove(GetById(id));

                MyDbContext.db.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                Bussiness.BaseClass.log(ex);
                return false;
            }
        }
		public static int AddOrUpdate(Section item)
        {
            var newItem = GetById(item.SectionId) ?? new Section();

			newItem.SectionId = item.SectionId;
			newItem.SectionName = item.SectionName;
            try
            {
                if (newItem.SectionId == 0) MyDbContext.db.Section.Add(newItem);

                MyDbContext.db.SaveChanges();

                return newItem.SectionId;
            }
            catch (Exception ex)
            {
                Bussiness.BaseClass.log(ex);
                return -1;
            }
        }
        public static List<Section> Search(Section search)
        {
            var result = from x in MyDbContext.db.Section
                         where 
						 (search.SectionId == 0 || 
						 x.SectionId == search.SectionId) &&
						 (search.SectionName == null || 
						 x.SectionName.Contains(search.SectionName)) &&
true
                         select x; 
            return result.ToList();
        }

        public int SectionId { get; set; } // SectionId (Primary key)
        public string SectionName { get; set; } // SectionName

        // Reverse navigation
        public virtual ICollection<User> User { get; set; } // User.FK_User_Section;
        public virtual ICollection<Works> Works { get; set; } // Works.FK_Works_Section;

        public Section()
        {
            User = new List<User>();
            Works = new List<Works>();
        }
    }

    // Store
    public partial class Store   
    {
		public static int Count()
        {
            return MyDbContext.db.Store.Count();
        }
		public static Store GetById(int id)
        {
            return MyDbContext.db.Store.FirstOrDefault(x => x.StoreId == id);
        }
		public static bool Delete(int id)
        { 
            try
            {
                MyDbContext.db.Store.Remove(GetById(id));

                MyDbContext.db.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                Bussiness.BaseClass.log(ex);
                return false;
            }
        }
		public static int AddOrUpdate(Store item)
        {
            var newItem = GetById(item.StoreId) ?? new Store();

			newItem.StoreId = item.StoreId;
			newItem.ProuctId = item.ProuctId;
			newItem.Entity = item.Entity;
            try
            {
                if (newItem.StoreId == 0) MyDbContext.db.Store.Add(newItem);

                MyDbContext.db.SaveChanges();

                return newItem.StoreId;
            }
            catch (Exception ex)
            {
                Bussiness.BaseClass.log(ex);
                return -1;
            }
        }
        public static List<Store> Search(Store search)
        {
            var result = from x in MyDbContext.db.Store
                         where 
						 (search.StoreId == 0 || 
						 x.StoreId == search.StoreId) &&
						 (search.ProuctId == null || 
						 x.ProuctId == search.ProuctId) &&
						 (search.Entity == null || 
						 x.Entity == search.Entity) &&
true
                         select x; 
            return result.ToList();
        }

        public int StoreId { get; set; } // StoreId (Primary key)
        public int? ProuctId { get; set; } // ProuctId
        public int? Entity { get; set; } // Entity

        // Foreign keys
        public virtual Product Product { get; set; } //  ProuctId - FK_Store_Product
    }

    // User
    public partial class User   
    {
		public static int Count()
        {
            return MyDbContext.db.User.Count();
        }
		public static User GetById(int id)
        {
            return MyDbContext.db.User.FirstOrDefault(x => x.UserId == id);
        }
		public static bool Delete(int id)
        { 
            try
            {
                MyDbContext.db.User.Remove(GetById(id));

                MyDbContext.db.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                Bussiness.BaseClass.log(ex);
                return false;
            }
        }
		public static int AddOrUpdate(User item)
        {
            var newItem = GetById(item.UserId) ?? new User();

			newItem.UserId = item.UserId;
			newItem.UserName = item.UserName;
			newItem.FirstName = item.FirstName;
			newItem.LastName = item.LastName;
			newItem.MobileNumber = item.MobileNumber;
			newItem.Address = item.Address;
			newItem.HomePhone = item.HomePhone;
			newItem.DegId = item.DegId;
			newItem.Title = item.Title;
			newItem.Password = item.Password;
			newItem.Email = item.Email;
			newItem.SectionId = item.SectionId;
			newItem.WorkShopId = item.WorkShopId;
			newItem.PermissionId = item.PermissionId;
            try
            {
                if (newItem.UserId == 0) MyDbContext.db.User.Add(newItem);

                MyDbContext.db.SaveChanges();

                return newItem.UserId;
            }
            catch (Exception ex)
            {
                Bussiness.BaseClass.log(ex);
                return -1;
            }
        }
        public static List<User> Search(User search)
        {
            var result = from x in MyDbContext.db.User
                         where 
						 (search.UserId == 0 || 
						 x.UserId == search.UserId) &&
						 (search.UserName == null || 
						 x.UserName.Contains(search.UserName)) &&
						 (search.FirstName == null || 
						 x.FirstName.Contains(search.FirstName)) &&
						 (search.LastName == null || 
						 x.LastName.Contains(search.LastName)) &&
						 (search.MobileNumber == null || 
						 x.MobileNumber.Contains(search.MobileNumber)) &&
						 (search.Address == null || 
						 x.Address.Contains(search.Address)) &&
						 (search.HomePhone == null || 
						 x.HomePhone.Contains(search.HomePhone)) &&
						 (search.DegId == null || 
						 x.DegId == search.DegId) &&
						 (search.Title == null || 
						 x.Title.Contains(search.Title)) &&
						 (search.Password == null || 
						 x.Password.Contains(search.Password)) &&
						 (search.Email == null || 
						 x.Email.Contains(search.Email)) &&
						 (search.SectionId == null || 
						 x.SectionId == search.SectionId) &&
						 (search.WorkShopId == null || 
						 x.WorkShopId == search.WorkShopId) &&
						 (search.PermissionId == null || 
						 x.PermissionId == search.PermissionId) &&
true
                         select x; 
            return result.ToList();
        }

        public int UserId { get; set; } // UserId (Primary key)
        public string UserName { get; set; } // UserName
        public string FirstName { get; set; } // FirstName
        public string LastName { get; set; } // LastName
        public string MobileNumber { get; set; } // MobileNumber
        public string Address { get; set; } // Address
        public string HomePhone { get; set; } // HomePhone
        public int? DegId { get; set; } // DegId
        public string Title { get; set; } // Title
        public string Password { get; set; } // Password
        public string Email { get; set; } // Email
        public int? SectionId { get; set; } // SectionId
        public int? WorkShopId { get; set; } // WorkShopId
        public int? PermissionId { get; set; } // PermissionId

        // Reverse navigation
        public virtual ICollection<BuyConfirm> BuyConfirm { get; set; } // BuyConfirm.FK_BuyConfirm_User1;
        public virtual ICollection<BuyConfirm> BuyConfirm1 { get; set; } // BuyConfirm.FK_BuyConfirm_User2;
        public virtual ICollection<BuyConfirm> BuyConfirm2 { get; set; } // BuyConfirm.FK_BuyConfirm_User3;
        public virtual ICollection<BuyConfirm> BuyConfirm3 { get; set; } // BuyConfirm.FK_BuyConfirm_User4;
        public virtual ICollection<BuyConfirm> BuyConfirm4 { get; set; } // BuyConfirm.FK_BuyConfirm_User5;
        public virtual ICollection<BuyConfirm> BuyConfirm5 { get; set; } // BuyConfirm.FK_BuyConfirm_User6;
        public virtual ICollection<BuyConfirm> BuyConfirm6 { get; set; } // BuyConfirm.FK_BuyConfirm_User;
        public virtual ICollection<BuyProduct> BuyProduct { get; set; } // BuyProduct.FK_BuyProduct_User;
        public virtual ICollection<ProductRequest> ProductRequest { get; set; } // ProductRequest.FK_ProductRequest_User;
        public virtual ICollection<ProductResponse> ProductResponse { get; set; } // ProductResponse.FK_ProductResponse_User;
        public virtual ICollection<WorkConfirmation> WorkConfirmation { get; set; } // WorkConfirmation.FK_WorkConfirmation_User;
        public virtual ICollection<Works> Works { get; set; } // Works.FK_Works_User;
        public virtual ICollection<Works> Works1 { get; set; } // Works.FK_Works_User1;
        public virtual ICollection<WorkShopDo> WorkShopDo { get; set; } // WorkShopDo.FK_WorkShopDo_User1;
        public virtual ICollection<WorkShopDo> WorkShopDo1 { get; set; } // WorkShopDo.FK_WorkShopDo_User;

        // Foreign keys
        public virtual Degree Degree { get; set; } //  DegId - FK_User_Degree
        public virtual Section Section { get; set; } //  SectionId - FK_User_Section
        public virtual WorkShop WorkShop { get; set; } //  WorkShopId - FK_User_WorkShop
        public virtual PermissionCode PermissionCode { get; set; } //  PermissionId - FK_User_PermissionCode

        public User()
        {
            BuyConfirm = new List<BuyConfirm>();
            BuyConfirm1 = new List<BuyConfirm>();
            BuyConfirm2 = new List<BuyConfirm>();
            BuyConfirm3 = new List<BuyConfirm>();
            BuyConfirm4 = new List<BuyConfirm>();
            BuyConfirm5 = new List<BuyConfirm>();
            BuyConfirm6 = new List<BuyConfirm>();
            BuyProduct = new List<BuyProduct>();
            ProductRequest = new List<ProductRequest>();
            ProductResponse = new List<ProductResponse>();
            WorkConfirmation = new List<WorkConfirmation>();
            Works = new List<Works>();
            Works1 = new List<Works>();
            WorkShopDo = new List<WorkShopDo>();
            WorkShopDo1 = new List<WorkShopDo>();
        }
    }

    // WorkConfirmation
    public partial class WorkConfirmation   
    {
		public static int Count()
        {
            return MyDbContext.db.WorkConfirmation.Count();
        }
		public static WorkConfirmation GetById(int id)
        {
            return MyDbContext.db.WorkConfirmation.FirstOrDefault(x => x.WorkConfirmationId == id);
        }
		public static bool Delete(int id)
        { 
            try
            {
                MyDbContext.db.WorkConfirmation.Remove(GetById(id));

                MyDbContext.db.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                Bussiness.BaseClass.log(ex);
                return false;
            }
        }
		public static int AddOrUpdate(WorkConfirmation item)
        {
            var newItem = GetById(item.WorkConfirmationId) ?? new WorkConfirmation();

			newItem.WorkConfirmationId = item.WorkConfirmationId;
			newItem.WorkId = item.WorkId;
			newItem.IsDone = item.IsDone;
			newItem.SpectorId = item.SpectorId;
            try
            {
                if (newItem.WorkConfirmationId == 0) MyDbContext.db.WorkConfirmation.Add(newItem);

                MyDbContext.db.SaveChanges();

                return newItem.WorkConfirmationId;
            }
            catch (Exception ex)
            {
                Bussiness.BaseClass.log(ex);
                return -1;
            }
        }
        public static List<WorkConfirmation> Search(WorkConfirmation search)
        {
            var result = from x in MyDbContext.db.WorkConfirmation
                         where 
						 (search.WorkConfirmationId == 0 || 
						 x.WorkConfirmationId == search.WorkConfirmationId) &&
						 (search.WorkId == null || 
						 x.WorkId == search.WorkId) &&
						 (search.IsDone == null || 
						 x.IsDone == search.IsDone) &&
						 (search.SpectorId == null || 
						 x.SpectorId == search.SpectorId) &&
true
                         select x; 
            return result.ToList();
        }

        public int WorkConfirmationId { get; set; } // WorkConfirmationId (Primary key)
        public int? WorkId { get; set; } // WorkId
        public bool? IsDone { get; set; } // IsDone
        public int? SpectorId { get; set; } // SpectorId

        // Foreign keys
        public virtual Works Works { get; set; } //  WorkId - FK_WorkConfirmation_Works
        public virtual User User { get; set; } //  SpectorId - FK_WorkConfirmation_User
    }

    // Works
    public partial class Works   
    {
		public static int Count()
        {
            return MyDbContext.db.Works.Count();
        }
		public static Works GetById(int id)
        {
            return MyDbContext.db.Works.FirstOrDefault(x => x.WorksId == id);
        }
		public static bool Delete(int id)
        { 
            try
            {
                MyDbContext.db.Works.Remove(GetById(id));

                MyDbContext.db.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                Bussiness.BaseClass.log(ex);
                return false;
            }
        }
		public static int AddOrUpdate(Works item)
        {
            var newItem = GetById(item.WorksId) ?? new Works();

			newItem.WorksId = item.WorksId;
			newItem.WorkDate = item.WorkDate;
			newItem.WorkType = item.WorkType;
			newItem.WorkPlace = item.WorkPlace;
			newItem.SectionId = item.SectionId;
			newItem.CarId = item.CarId;
			newItem.Details = item.Details;
			newItem.AttemptsId = item.AttemptsId;
			newItem.ReceiverId = item.ReceiverId;
			newItem.IsSubmited = item.IsSubmited;
			newItem.WorksNumber = item.WorksNumber;
            try
            {
                if (newItem.WorksId == 0) MyDbContext.db.Works.Add(newItem);

                MyDbContext.db.SaveChanges();

                return newItem.WorksId;
            }
            catch (Exception ex)
            {
                Bussiness.BaseClass.log(ex);
                return -1;
            }
        }
        public static List<Works> Search(Works search)
        {
            var result = from x in MyDbContext.db.Works
                         where 
						 (search.WorksId == 0 || 
						 x.WorksId == search.WorksId) &&
						 (search.WorkDate == null || 
						 x.WorkDate == search.WorkDate) &&
						 (search.WorkType == null || 
						 x.WorkType == search.WorkType) &&
						 (search.WorkPlace == null || 
						 x.WorkPlace == search.WorkPlace) &&
						 (search.SectionId == null || 
						 x.SectionId == search.SectionId) &&
						 (search.CarId == null || 
						 x.CarId == search.CarId) &&
						 (search.Details == null || 
						 x.Details.Contains(search.Details)) &&
						 (search.AttemptsId == null || 
						 x.AttemptsId == search.AttemptsId) &&
						 (search.ReceiverId == null || 
						 x.ReceiverId == search.ReceiverId) &&
						 (search.IsSubmited == null || 
						 x.IsSubmited == search.IsSubmited) &&
						 (search.WorksNumber == 0 || 
						 x.WorksNumber == search.WorksNumber) &&
true
                         select x; 
            return result.ToList();
        }

        public int WorksId { get; set; } // WorksId (Primary key)
        public DateTime? WorkDate { get; set; } // WorkDate
        public bool? WorkType { get; set; } // WorkType
        public bool? WorkPlace { get; set; } // WorkPlace
        public int? SectionId { get; set; } // SectionId
        public int? CarId { get; set; } // CarId
        public string Details { get; set; } // Details
        public int? AttemptsId { get; set; } // AttemptsId
        public int? ReceiverId { get; set; } // ReceiverId
        public bool? IsSubmited { get; set; } // IsSubmited
        public int WorksNumber { get; set; } // WorksNumber

        // Reverse navigation
        public virtual ICollection<ProductRequest> ProductRequest { get; set; } // ProductRequest.FK_ProductRequest_Works;
        public virtual ICollection<WorkConfirmation> WorkConfirmation { get; set; } // WorkConfirmation.FK_WorkConfirmation_Works;
        public virtual ICollection<WorkShopDo> WorkShopDo { get; set; } // WorkShopDo.FK_WorkShopDo_Works;
        public virtual ICollection<WorkSubmit> WorkSubmit { get; set; } // WorkSubmit.FK_WorkSubmit_Works;

        // Foreign keys
        public virtual Section Section { get; set; } //  SectionId - FK_Works_Section
        public virtual Cars Cars { get; set; } //  CarId - FK_Works_Cars
        public virtual User User { get; set; } //  AttemptsId - FK_Works_User
        public virtual User User1 { get; set; } //  ReceiverId - FK_Works_User1

        public Works()
        {
            ProductRequest = new List<ProductRequest>();
            WorkConfirmation = new List<WorkConfirmation>();
            WorkShopDo = new List<WorkShopDo>();
            WorkSubmit = new List<WorkSubmit>();
        }
    }

    // WorkShop
    public partial class WorkShop   
    {
		public static int Count()
        {
            return MyDbContext.db.WorkShop.Count();
        }
		public static WorkShop GetById(int id)
        {
            return MyDbContext.db.WorkShop.FirstOrDefault(x => x.WorkShopId == id);
        }
		public static bool Delete(int id)
        { 
            try
            {
                MyDbContext.db.WorkShop.Remove(GetById(id));

                MyDbContext.db.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                Bussiness.BaseClass.log(ex);
                return false;
            }
        }
		public static int AddOrUpdate(WorkShop item)
        {
            var newItem = GetById(item.WorkShopId) ?? new WorkShop();

			newItem.WorkShopId = item.WorkShopId;
			newItem.WorkShopName = item.WorkShopName;
            try
            {
                if (newItem.WorkShopId == 0) MyDbContext.db.WorkShop.Add(newItem);

                MyDbContext.db.SaveChanges();

                return newItem.WorkShopId;
            }
            catch (Exception ex)
            {
                Bussiness.BaseClass.log(ex);
                return -1;
            }
        }
        public static List<WorkShop> Search(WorkShop search)
        {
            var result = from x in MyDbContext.db.WorkShop
                         where 
						 (search.WorkShopId == 0 || 
						 x.WorkShopId == search.WorkShopId) &&
						 (search.WorkShopName == null || 
						 x.WorkShopName.Contains(search.WorkShopName)) &&
true
                         select x; 
            return result.ToList();
        }

        public int WorkShopId { get; set; } // WorkShopId (Primary key)
        public string WorkShopName { get; set; } // WorkShopName

        // Reverse navigation
        public virtual ICollection<ProductRequest> ProductRequest { get; set; } // ProductRequest.FK_ProductRequest_WorkShop;
        public virtual ICollection<User> User { get; set; } // User.FK_User_WorkShop;
        public virtual ICollection<WorkShopDo> WorkShopDo { get; set; } // WorkShopDo.FK_WorkShopDo_WorkShop;

        public WorkShop()
        {
            ProductRequest = new List<ProductRequest>();
            User = new List<User>();
            WorkShopDo = new List<WorkShopDo>();
        }
    }

    // WorkShopDo
    public partial class WorkShopDo   
    {
		public static int Count()
        {
            return MyDbContext.db.WorkShopDo.Count();
        }
		public static WorkShopDo GetById(int id)
        {
            return MyDbContext.db.WorkShopDo.FirstOrDefault(x => x.WorkShopDoId == id);
        }
		public static bool Delete(int id)
        { 
            try
            {
                MyDbContext.db.WorkShopDo.Remove(GetById(id));

                MyDbContext.db.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                Bussiness.BaseClass.log(ex);
                return false;
            }
        }
		public static int AddOrUpdate(WorkShopDo item)
        {
            var newItem = GetById(item.WorkShopDoId) ?? new WorkShopDo();

			newItem.WorkShopDoId = item.WorkShopDoId;
			newItem.WorkShopId = item.WorkShopId;
			newItem.VisitorId = item.VisitorId;
			newItem.FinalVisitorId = item.FinalVisitorId;
			newItem.DateIn = item.DateIn;
			newItem.DateOut = item.DateOut;
			newItem.WorkId = item.WorkId;
            try
            {
                if (newItem.WorkShopDoId == 0) MyDbContext.db.WorkShopDo.Add(newItem);

                MyDbContext.db.SaveChanges();

                return newItem.WorkShopDoId;
            }
            catch (Exception ex)
            {
                Bussiness.BaseClass.log(ex);
                return -1;
            }
        }
        public static List<WorkShopDo> Search(WorkShopDo search)
        {
            var result = from x in MyDbContext.db.WorkShopDo
                         where 
						 (search.WorkShopDoId == 0 || 
						 x.WorkShopDoId == search.WorkShopDoId) &&
						 (search.WorkShopId == null || 
						 x.WorkShopId == search.WorkShopId) &&
						 (search.VisitorId == null || 
						 x.VisitorId == search.VisitorId) &&
						 (search.FinalVisitorId == null || 
						 x.FinalVisitorId == search.FinalVisitorId) &&
						 (search.DateIn == null || 
						 x.DateIn == search.DateIn) &&
						 (search.DateOut == null || 
						 x.DateOut == search.DateOut) &&
						 (search.WorkId == null || 
						 x.WorkId == search.WorkId) &&
true
                         select x; 
            return result.ToList();
        }

        public int WorkShopDoId { get; set; } // WorkShopDoId (Primary key)
        public int? WorkShopId { get; set; } // WorkShopId
        public int? VisitorId { get; set; } // VisitorId
        public int? FinalVisitorId { get; set; } // FinalVisitorId
        public DateTime? DateIn { get; set; } // DateIn
        public DateTime? DateOut { get; set; } // DateOut
        public int? WorkId { get; set; } // WorkId

        // Foreign keys
        public virtual WorkShop WorkShop { get; set; } //  WorkShopId - FK_WorkShopDo_WorkShop
        public virtual User User1 { get; set; } //  VisitorId - FK_WorkShopDo_User
        public virtual User User { get; set; } //  FinalVisitorId - FK_WorkShopDo_User1
        public virtual Works Works { get; set; } //  WorkId - FK_WorkShopDo_Works
    }

    // WorkSubmit
    public partial class WorkSubmit   
    {
		public static int Count()
        {
            return MyDbContext.db.WorkSubmit.Count();
        }
		public static WorkSubmit GetById(int id)
        {
            return MyDbContext.db.WorkSubmit.FirstOrDefault(x => x.WorkSubmitId == id);
        }
		public static bool Delete(int id)
        { 
            try
            {
                MyDbContext.db.WorkSubmit.Remove(GetById(id));

                MyDbContext.db.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                Bussiness.BaseClass.log(ex);
                return false;
            }
        }
		public static int AddOrUpdate(WorkSubmit item)
        {
            var newItem = GetById(item.WorkSubmitId) ?? new WorkSubmit();

			newItem.WorkSubmitId = item.WorkSubmitId;
			newItem.WorksId = item.WorksId;
			newItem.IsSubmited = item.IsSubmited;
            try
            {
                if (newItem.WorkSubmitId == 0) MyDbContext.db.WorkSubmit.Add(newItem);

                MyDbContext.db.SaveChanges();

                return newItem.WorkSubmitId;
            }
            catch (Exception ex)
            {
                Bussiness.BaseClass.log(ex);
                return -1;
            }
        }
        public static List<WorkSubmit> Search(WorkSubmit search)
        {
            var result = from x in MyDbContext.db.WorkSubmit
                         where 
						 (search.WorkSubmitId == 0 || 
						 x.WorkSubmitId == search.WorkSubmitId) &&
						 (search.WorksId == null || 
						 x.WorksId == search.WorksId) &&
						 (search.IsSubmited == null || 
						 x.IsSubmited == search.IsSubmited) &&
true
                         select x; 
            return result.ToList();
        }

        public int WorkSubmitId { get; set; } // WorkSubmitId (Primary key)
        public int? WorksId { get; set; } // WorksId
        public bool? IsSubmited { get; set; } // IsSubmited

        // Foreign keys
        public virtual Works Works { get; set; } //  WorksId - FK_WorkSubmit_Works
    }


    // ************************************************************************
    // POCO Configuration

    // BuyConfirm
    public partial class BuyConfirmConfiguration : EntityTypeConfiguration<BuyConfirm>
    {
        public BuyConfirmConfiguration()
        {
            ToTable("dbo.BuyConfirm");
            HasKey(x => x.BuyConfirmId);

            Property(x => x.BuyConfirmId).HasColumnName("BuyConfirmId").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.BuyNumber).HasColumnName("BuyNumber").IsOptional();
            Property(x => x.SpectorId).HasColumnName("SpectorId").IsOptional();
            Property(x => x.Spector2Id).HasColumnName("Spector2Id").IsOptional();
            Property(x => x.Spector3Id).HasColumnName("Spector3Id").IsOptional();
            Property(x => x.Spector4Id).HasColumnName("Spector4Id").IsOptional();
            Property(x => x.Spector5Id).HasColumnName("Spector5Id").IsOptional();
            Property(x => x.Spector6Id).HasColumnName("Spector6Id").IsOptional();
            Property(x => x.Spector7Id).HasColumnName("Spector7Id").IsOptional();
            Property(x => x.Date).HasColumnName("Date").IsOptional();

            // Foreign keys
            HasOptional(a => a.User6).WithMany(b => b.BuyConfirm6).HasForeignKey(c => c.SpectorId); // FK_BuyConfirm_User
            HasOptional(a => a.User).WithMany(b => b.BuyConfirm).HasForeignKey(c => c.Spector2Id); // FK_BuyConfirm_User1
            HasOptional(a => a.User1).WithMany(b => b.BuyConfirm1).HasForeignKey(c => c.Spector3Id); // FK_BuyConfirm_User2
            HasOptional(a => a.User2).WithMany(b => b.BuyConfirm2).HasForeignKey(c => c.Spector4Id); // FK_BuyConfirm_User3
            HasOptional(a => a.User3).WithMany(b => b.BuyConfirm3).HasForeignKey(c => c.Spector5Id); // FK_BuyConfirm_User4
            HasOptional(a => a.User4).WithMany(b => b.BuyConfirm4).HasForeignKey(c => c.Spector6Id); // FK_BuyConfirm_User5
            HasOptional(a => a.User5).WithMany(b => b.BuyConfirm5).HasForeignKey(c => c.Spector7Id); // FK_BuyConfirm_User6
        }
    }

    // BuyProduct
    public partial class BuyProductConfiguration : EntityTypeConfiguration<BuyProduct>
    {
        public BuyProductConfiguration()
        {
            ToTable("dbo.BuyProduct");
            HasKey(x => x.BuyProductId);

            Property(x => x.BuyProductId).HasColumnName("BuyProductId").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.ProductId).HasColumnName("ProductId").IsOptional();
            Property(x => x.BuyerId).HasColumnName("BuyerId").IsOptional();
            Property(x => x.BuyCount).HasColumnName("BuyCount").IsOptional();
            Property(x => x.BuyNumber).HasColumnName("BuyNumber").IsOptional();
            Property(x => x.Date).HasColumnName("Date").IsOptional();
            Property(x => x.IsConfirmed).HasColumnName("IsConfirmed").IsOptional();
            Property(x => x.ConfirmId).HasColumnName("ConfirmId").IsOptional();

            // Foreign keys
            HasOptional(a => a.Product).WithMany(b => b.BuyProduct).HasForeignKey(c => c.ProductId); // FK_BuyProduct_Product
            HasOptional(a => a.User).WithMany(b => b.BuyProduct).HasForeignKey(c => c.BuyerId); // FK_BuyProduct_User
            HasOptional(a => a.BuyConfirm).WithMany(b => b.BuyProduct).HasForeignKey(c => c.ConfirmId); // FK_BuyProduct_BuyConfirm
        }
    }

    // Cars
    public partial class CarsConfiguration : EntityTypeConfiguration<Cars>
    {
        public CarsConfiguration()
        {
            ToTable("dbo.Cars");
            HasKey(x => x.CarsId);

            Property(x => x.CarsId).HasColumnName("CarsId").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.CarName).HasColumnName("CarName").IsOptional().HasMaxLength(50);
            Property(x => x.CarNumber).HasColumnName("CarNumber").IsOptional();
            Property(x => x.IsActive).HasColumnName("IsActive").IsOptional();
        }
    }

    // Category
    public partial class CategoryConfiguration : EntityTypeConfiguration<Category>
    {
        public CategoryConfiguration()
        {
            ToTable("dbo.Category");
            HasKey(x => x.CategoryId);

            Property(x => x.CategoryId).HasColumnName("CategoryId").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.CategoryName).HasColumnName("CategoryName").IsOptional().HasMaxLength(50);
        }
    }

    // Degree
    public partial class DegreeConfiguration : EntityTypeConfiguration<Degree>
    {
        public DegreeConfiguration()
        {
            ToTable("dbo.Degree");
            HasKey(x => x.DegreeId);

            Property(x => x.DegreeId).HasColumnName("DegreeId").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.DegreeName).HasColumnName("DegreeName").IsOptional().HasMaxLength(50);
        }
    }

    // PermissionCode
    public partial class PermissionCodeConfiguration : EntityTypeConfiguration<PermissionCode>
    {
        public PermissionCodeConfiguration()
        {
            ToTable("dbo.PermissionCode");
            HasKey(x => x.PermissionCodeId);

            Property(x => x.PermissionCodeId).HasColumnName("PermissionCodeId").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Permission).HasColumnName("Permission").IsOptional().HasMaxLength(50);
        }
    }

    // Product
    public partial class ProductConfiguration : EntityTypeConfiguration<Product>
    {
        public ProductConfiguration()
        {
            ToTable("dbo.Product");
            HasKey(x => x.ProductId);

            Property(x => x.ProductId).HasColumnName("ProductId").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.ProductName).HasColumnName("ProductName").IsOptional().HasMaxLength(50);
            Property(x => x.Price).HasColumnName("Price").IsOptional();
            Property(x => x.CategoryId).HasColumnName("CategoryId").IsOptional();
            Property(x => x.ProductNumber).HasColumnName("ProductNumber").IsOptional();

            // Foreign keys
            HasOptional(a => a.Category).WithMany(b => b.Product).HasForeignKey(c => c.CategoryId); // FK_Product_Category
        }
    }

    // ProductDetail
    public partial class ProductDetailConfiguration : EntityTypeConfiguration<ProductDetail>
    {
        public ProductDetailConfiguration()
        {
            ToTable("dbo.ProductDetail");
            HasKey(x => x.ProductDetailId);

            Property(x => x.ProductDetailId).HasColumnName("ProductDetailId").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.ProductType).HasColumnName("ProductType").IsOptional();
            Property(x => x.Date).HasColumnName("Date").IsOptional();
            Property(x => x.ProductId).HasColumnName("ProductId").IsOptional();

            // Foreign keys
            HasOptional(a => a.Product).WithMany(b => b.ProductDetail).HasForeignKey(c => c.ProductId); // FK_ProductDetail_Product
        }
    }

    // ProductRequest
    public partial class ProductRequestConfiguration : EntityTypeConfiguration<ProductRequest>
    {
        public ProductRequestConfiguration()
        {
            ToTable("dbo.ProductRequest");
            HasKey(x => x.ProductRequestId);

            Property(x => x.ProductRequestId).HasColumnName("ProductRequestId").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.ProductId).HasColumnName("ProductId").IsOptional();
            Property(x => x.ProductNumber).HasColumnName("ProductNumber").IsOptional();
            Property(x => x.SpectorId).HasColumnName("SpectorId").IsOptional();
            Property(x => x.Date).HasColumnName("Date").IsOptional();
            Property(x => x.WorksId).HasColumnName("WorksId").IsOptional();
            Property(x => x.WorkShopId).HasColumnName("WorkShopId").IsOptional();

            // Foreign keys
            HasOptional(a => a.Product).WithMany(b => b.ProductRequest).HasForeignKey(c => c.ProductId); // FK_ProductRequest_Product
            HasOptional(a => a.User).WithMany(b => b.ProductRequest).HasForeignKey(c => c.SpectorId); // FK_ProductRequest_User
            HasOptional(a => a.Works).WithMany(b => b.ProductRequest).HasForeignKey(c => c.WorksId); // FK_ProductRequest_Works
            HasOptional(a => a.WorkShop).WithMany(b => b.ProductRequest).HasForeignKey(c => c.WorkShopId); // FK_ProductRequest_WorkShop
        }
    }

    // ProductResponse
    public partial class ProductResponseConfiguration : EntityTypeConfiguration<ProductResponse>
    {
        public ProductResponseConfiguration()
        {
            ToTable("dbo.ProductResponse");
            HasKey(x => x.ProductResponseId);

            Property(x => x.ProductResponseId).HasColumnName("ProductResponseId").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.ProductRequestId).HasColumnName("ProductRequestId").IsOptional();
            Property(x => x.Spector).HasColumnName("Spector").IsOptional();
            Property(x => x.IsOk).HasColumnName("IsOk").IsOptional();

            // Foreign keys
            HasOptional(a => a.ProductRequest).WithMany(b => b.ProductResponse).HasForeignKey(c => c.ProductRequestId); // FK_ProductResponse_ProductRequest
            HasOptional(a => a.User).WithMany(b => b.ProductResponse).HasForeignKey(c => c.Spector); // FK_ProductResponse_User
        }
    }

    // Section
    public partial class SectionConfiguration : EntityTypeConfiguration<Section>
    {
        public SectionConfiguration()
        {
            ToTable("dbo.Section");
            HasKey(x => x.SectionId);

            Property(x => x.SectionId).HasColumnName("SectionId").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.SectionName).HasColumnName("SectionName").IsOptional().HasMaxLength(50);
        }
    }

    // Store
    public partial class StoreConfiguration : EntityTypeConfiguration<Store>
    {
        public StoreConfiguration()
        {
            ToTable("dbo.Store");
            HasKey(x => x.StoreId);

            Property(x => x.StoreId).HasColumnName("StoreId").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.ProuctId).HasColumnName("ProuctId").IsOptional();
            Property(x => x.Entity).HasColumnName("Entity").IsOptional();

            // Foreign keys
            HasOptional(a => a.Product).WithMany(b => b.Store).HasForeignKey(c => c.ProuctId); // FK_Store_Product
        }
    }

    // User
    public partial class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            ToTable("dbo.User");
            HasKey(x => x.UserId);

            Property(x => x.UserId).HasColumnName("UserId").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.UserName).HasColumnName("UserName").IsOptional().HasMaxLength(50);
            Property(x => x.FirstName).HasColumnName("FirstName").IsOptional().HasMaxLength(50);
            Property(x => x.LastName).HasColumnName("LastName").IsOptional().HasMaxLength(50);
            Property(x => x.MobileNumber).HasColumnName("MobileNumber").IsOptional().HasMaxLength(50);
            Property(x => x.Address).HasColumnName("Address").IsOptional();
            Property(x => x.HomePhone).HasColumnName("HomePhone").IsOptional().HasMaxLength(50);
            Property(x => x.DegId).HasColumnName("DegId").IsOptional();
            Property(x => x.Title).HasColumnName("Title").IsOptional().HasMaxLength(50);
            Property(x => x.Password).HasColumnName("Password").IsOptional().HasMaxLength(50);
            Property(x => x.Email).HasColumnName("Email").IsOptional().HasMaxLength(50);
            Property(x => x.SectionId).HasColumnName("SectionId").IsOptional();
            Property(x => x.WorkShopId).HasColumnName("WorkShopId").IsOptional();
            Property(x => x.PermissionId).HasColumnName("PermissionId").IsOptional();

            // Foreign keys
            HasOptional(a => a.Degree).WithMany(b => b.User).HasForeignKey(c => c.DegId); // FK_User_Degree
            HasOptional(a => a.Section).WithMany(b => b.User).HasForeignKey(c => c.SectionId); // FK_User_Section
            HasOptional(a => a.WorkShop).WithMany(b => b.User).HasForeignKey(c => c.WorkShopId); // FK_User_WorkShop
            HasOptional(a => a.PermissionCode).WithMany(b => b.User).HasForeignKey(c => c.PermissionId); // FK_User_PermissionCode
        }
    }

    // WorkConfirmation
    public partial class WorkConfirmationConfiguration : EntityTypeConfiguration<WorkConfirmation>
    {
        public WorkConfirmationConfiguration()
        {
            ToTable("dbo.WorkConfirmation");
            HasKey(x => x.WorkConfirmationId);

            Property(x => x.WorkConfirmationId).HasColumnName("WorkConfirmationId").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.WorkId).HasColumnName("WorkId").IsOptional();
            Property(x => x.IsDone).HasColumnName("IsDone").IsOptional();
            Property(x => x.SpectorId).HasColumnName("SpectorId").IsOptional();

            // Foreign keys
            HasOptional(a => a.Works).WithMany(b => b.WorkConfirmation).HasForeignKey(c => c.WorkId); // FK_WorkConfirmation_Works
            HasOptional(a => a.User).WithMany(b => b.WorkConfirmation).HasForeignKey(c => c.SpectorId); // FK_WorkConfirmation_User
        }
    }

    // Works
    public partial class WorksConfiguration : EntityTypeConfiguration<Works>
    {
        public WorksConfiguration()
        {
            ToTable("dbo.Works");
            HasKey(x => x.WorksId);

            Property(x => x.WorksId).HasColumnName("WorksId").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.WorkDate).HasColumnName("WorkDate").IsOptional();
            Property(x => x.WorkType).HasColumnName("WorkType").IsOptional();
            Property(x => x.WorkPlace).HasColumnName("WorkPlace").IsOptional();
            Property(x => x.SectionId).HasColumnName("SectionId").IsOptional();
            Property(x => x.CarId).HasColumnName("CarId").IsOptional();
            Property(x => x.Details).HasColumnName("Details").IsOptional();
            Property(x => x.AttemptsId).HasColumnName("AttemptsId").IsOptional();
            Property(x => x.ReceiverId).HasColumnName("ReceiverId").IsOptional();
            Property(x => x.IsSubmited).HasColumnName("IsSubmited").IsOptional();
            Property(x => x.WorksNumber).HasColumnName("WorksNumber").IsRequired();

            // Foreign keys
            HasOptional(a => a.Section).WithMany(b => b.Works).HasForeignKey(c => c.SectionId); // FK_Works_Section
            HasOptional(a => a.Cars).WithMany(b => b.Works).HasForeignKey(c => c.CarId); // FK_Works_Cars
            HasOptional(a => a.User).WithMany(b => b.Works).HasForeignKey(c => c.AttemptsId); // FK_Works_User
            HasOptional(a => a.User1).WithMany(b => b.Works1).HasForeignKey(c => c.ReceiverId); // FK_Works_User1
        }
    }

    // WorkShop
    public partial class WorkShopConfiguration : EntityTypeConfiguration<WorkShop>
    {
        public WorkShopConfiguration()
        {
            ToTable("dbo.WorkShop");
            HasKey(x => x.WorkShopId);

            Property(x => x.WorkShopId).HasColumnName("WorkShopId").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.WorkShopName).HasColumnName("WorkShopName").IsOptional().HasMaxLength(50);
        }
    }

    // WorkShopDo
    public partial class WorkShopDoConfiguration : EntityTypeConfiguration<WorkShopDo>
    {
        public WorkShopDoConfiguration()
        {
            ToTable("dbo.WorkShopDo");
            HasKey(x => x.WorkShopDoId);

            Property(x => x.WorkShopDoId).HasColumnName("WorkShopDoId").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.WorkShopId).HasColumnName("WorkShopId").IsOptional();
            Property(x => x.VisitorId).HasColumnName("VisitorId").IsOptional();
            Property(x => x.FinalVisitorId).HasColumnName("FinalVisitorId").IsOptional();
            Property(x => x.DateIn).HasColumnName("DateIn").IsOptional();
            Property(x => x.DateOut).HasColumnName("DateOut").IsOptional();
            Property(x => x.WorkId).HasColumnName("WorkId").IsOptional();

            // Foreign keys
            HasOptional(a => a.WorkShop).WithMany(b => b.WorkShopDo).HasForeignKey(c => c.WorkShopId); // FK_WorkShopDo_WorkShop
            HasOptional(a => a.User1).WithMany(b => b.WorkShopDo1).HasForeignKey(c => c.VisitorId); // FK_WorkShopDo_User
            HasOptional(a => a.User).WithMany(b => b.WorkShopDo).HasForeignKey(c => c.FinalVisitorId); // FK_WorkShopDo_User1
            HasOptional(a => a.Works).WithMany(b => b.WorkShopDo).HasForeignKey(c => c.WorkId); // FK_WorkShopDo_Works
        }
    }

    // WorkSubmit
    public partial class WorkSubmitConfiguration : EntityTypeConfiguration<WorkSubmit>
    {
        public WorkSubmitConfiguration()
        {
            ToTable("dbo.WorkSubmit");
            HasKey(x => x.WorkSubmitId);

            Property(x => x.WorkSubmitId).HasColumnName("WorkSubmitId").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.WorksId).HasColumnName("WorksId").IsOptional();
            Property(x => x.IsSubmited).HasColumnName("IsSubmited").IsOptional();

            // Foreign keys
            HasOptional(a => a.Works).WithMany(b => b.WorkSubmit).HasForeignKey(c => c.WorksId); // FK_WorkSubmit_Works
        }
    }

}

