using Crudoperation.Model.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudoperationData
{
    public class HardCodedData
    {
        public List<Product> Products()
        {
            var products = new List<Product>();
            products.Add(new Product()
            {
                Id = 1,
                title = "Book",
                description = "afdosfods dsfo donfs "
            });
            products.Add(new Product()
            {
                Id = 2,
                title = "Book 1",
                description = "afdosfods dsfo donfs "
            });
            products.Add(new Product()
            {
                Id = 3,
                title = "Book 2",
                description = "afdosfods dsfo donfs "
            });

            return products;
                //Task.FromResult(products);
        }
    }
}
