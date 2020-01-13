using System;
using System.ComponentModel.DataAnnotations;

namespace ProductCatalogApp.API.Dtos
{
    public class ProductForCreateDto
    {
        [Required]
        public string Name { get; set; }
        
        [Required]
        [RegularExpression("([1-9][0-9]*)")]
        public int Quantity { get; set; }
        public string PhotoUrl { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }

        public ProductForCreateDto()
        {
            Created = DateTime.Now;
        }
    }
}