using System.Collections.Generic;
using System.Threading.Tasks;
using ProductCatalogApp.API.Models;

namespace ProductCatalogApp.API.Data
{
    public interface IProductRepository
    {
        Task<Product> GetProduct(int id);
        Task<IEnumerable<Product>> GetProducts();
    }
}