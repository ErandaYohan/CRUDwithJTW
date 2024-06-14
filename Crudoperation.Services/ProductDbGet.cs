using Crudoperation.Model.Product;
using Crudoperation.Models;
using Crudoperation.Shared;
using CrudoperationData;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crudoperation.Services
{
    public class ProductDbGet : IProductService
    {
        private readonly AppDbContext _productService;
        public ProductDbGet(AppDbContext productService)
        {

            _productService = productService;

        }

        public async Task AddProductAsync(Product product)
        {
            await _productService.Products.AddAsync(product);
            await _productService.SaveChangesAsync();   
        }

        public async Task<Product> GetProduct(int id)
        {
            //return await _productService.Products.FindAsync(id);
            var hardcoded = new HardCodedData();
            var result = hardcoded.Products();
            //var Idvalue = new List<Product>();
            foreach(var item in result)
            {
                if(item.Id == id)
                {
                    //Product product = new Product();
                    //product.Id = item.Id;
                    //product.title = item.title;
                    //product.description = item.description;
                    //Idvalue.Add(product);
                    return new Product
                    {
                        Id = item.Id,
                        title = item.title,
                        description = item.description
                    };  
                }
                
            }
            return null;
        }

        //public async Task<IEnumerable<Product>> GetProductsAsync()
        //{
        //    return await _productService.Products.ToListAsync();
        //}

        //Get form Hardcoded data
        public List<Product> GetProductsAsync()
        {
            var hardData = new HardCodedData();
            return hardData.Products();
        }

        public async Task UpdateProductAsync(Product product)
        {
            _productService.Products.Update(product);
            await _productService.SaveChangesAsync();
        }
        public async Task DeleteProductAsync(int id)
        {
            var product = await _productService.Products.FindAsync(id);
            if(product != null)
            {
                _productService.Products.Remove(product);
                await _productService.SaveChangesAsync();
            }
        }
    }
}
