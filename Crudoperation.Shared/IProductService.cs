using Crudoperation.Model.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crudoperation.Shared
{
    public interface IProductService
    {
        //public Task<IEnumerable<Product>> GetProductsAsync();

        //Get from Hardcoded data
        public List<Product> GetProductsAsync();
        public Task<Product> GetProduct(int id);
        public Task AddProductAsync(Product product);
        public Task UpdateProductAsync(Product product);
        public Task DeleteProductAsync(int id);
    }
}
