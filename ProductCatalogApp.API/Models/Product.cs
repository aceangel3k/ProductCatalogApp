using System;

namespace ProductCatalogApp.API.Models
{
    public class Product
    {
        public string Name { get; set; }
        public string PhotoUrl { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
    }
}