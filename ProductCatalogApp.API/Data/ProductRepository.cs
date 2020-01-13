using System.Collections.Generic;
using System.Linq;
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

        public async Task<Product> Add(Product product)
        {
            ProductStore.Instance.Products.Add(product);
            await Task.Delay(100);
            return product;
        }

        public async Task<bool> ProductExists(string name)
        {
            await Task.Delay(100);
            if (ProductStore.Instance.Products.Any(x => x.Name.ToLower() == name.ToLower())) 
            {
                return true;
            }
            return false;
        }
    }
}