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
                Name = "Macbook Pro",
                Description = "Latest Model of Apple's Flagship Portable Workstation",
                PhotoUrl = "/assets/macbookpro.jpg",
                Quantity = 7,
                Created = DateTime.Now
            });
            Products.Add(new Product
            {
                Name = "Bose QuietComfort XX Headphones",
                Description = "Bose Noise Cancelling Wireless Headphones",
                PhotoUrl = "/assets/bose-headphones.jpg",
                Quantity = 50,
                Created = DateTime.Now
            });
            Products.Add(new Product
            {
                Name = "Motorola Razr",
                Description = "The Old is New Again",
                PhotoUrl = "/assets/motorola-razr.png",
                Quantity = 10,
                Created = DateTime.Now
            });
        }
        public List<Product> Products { get; set; }
    }
}