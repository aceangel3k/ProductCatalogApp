using System.Collections.Generic;
using System.Threading.Tasks;
using ProductCatalogApp.API.Models;

namespace ProductCatalogApp.API.Data
{
    public class ProductRepository : IProductRepository
    {
        public Task<Product> GetProduct(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            var products = ProductStore.Instance.Products;
            await Task.Delay(100);
            return products;
        }
    }
}