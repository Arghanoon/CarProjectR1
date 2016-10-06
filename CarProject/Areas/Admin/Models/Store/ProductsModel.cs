﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarProject.Areas.Admin.Models.Store
{
    public class ProductsModel : IValidatableObject
    {
        public DBSEF.CarAutomationEntities dbs = new DBSEF.CarAutomationEntities();

        public DBSEF.Product Product { get; set; }
       
        [AllowHtml]
        public string HtmlReview
        {
            get { return Product.ProductReview.ProductReview1; }
            set { Product.ProductReview.ProductReview1 = value; }
        }

        public ProductsModel()
        {
            Product = new DBSEF.Product();
            Product.ProductReview = new DBSEF.ProductReview();
        }

        public ProductsModel(int? id)
        {
            Product = dbs.Products.FirstOrDefault(p => p.ProductId == id);
            if (Product == null)
                Product = new DBSEF.Product();
            
            if (Product.ProductReview == null && Product.ProductReviewId != null && Product.ProductReviewId > 0)
            {
                Product.ProductReview = dbs.ProductReviews.FirstOrDefault(r => r.ProductReviewId == Product.ProductReviewId);
            }
        }


        public void Save()
        {
            dbs.Products.Add(this.Product);
            dbs.SaveChanges();
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> result = new List<ValidationResult>();

            return result;
        }
    }
}