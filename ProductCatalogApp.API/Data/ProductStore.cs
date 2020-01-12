using System;
using System.Collections.Generic;
using ProductCatalogApp.API.Models;

namespace ProductCatalogApp.API.Data
{
    public sealed class ProductStore
    {
        static ProductStore _instance;
        public static ProductStore Instance
        {
            get { return _instance ?? (_instance = new ProductStore()); }
        }
        private ProductStore()
        {
            Products = new List<Product>();
            Products.Add(new Product
            {
                Id = 1,
                Name = "Macbook Pro",
                Description = "Latest Model of Apple's flagship portable workstation",
                Quantity = 7,
                Created = DateTime.Now
            });
            Products.Add(new Product
            {
                Id = 1,
                Name = "Bose Headphones",
                Description = "Bose famous noise-cancelling headphones",
                Quantity = 50,
                Created = DateTime.Now
            });
            Products.Add(new Product
            {
                Id = 1,
                Name = "Motorola RAZR",
                Description = "Latest android flip phone",
                Quantity = 10,
                Created = DateTime.Now
            });
        }
        public List<Product> Products { get; set; }
    }
}