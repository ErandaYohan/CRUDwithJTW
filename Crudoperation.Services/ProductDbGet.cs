using Crudoperation.Model.Product;
using Crudoperation.Models;
using Crudoperation.Shared;
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
            return await _productService.Products.FindAsync(id);
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _productService.Products.ToListAsync();
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
