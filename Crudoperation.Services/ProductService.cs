using Crudoperation.Model.Product;
using Crudoperation.Shared;
using CrudoperationData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crudoperation.Service
{
    public class ProductService 
    {
        public Task<List<Product>> GetProductsAsync()
        {
            var products = new HardCodedData();
            return products.Products();
        }
    }
}
