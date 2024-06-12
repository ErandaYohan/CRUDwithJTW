using Crudoperation.Model.Product;
using Crudoperation.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Crudoperation.Services
{
    public class ProductGetHttp 
    {
        private readonly HttpClient _httpClient;
        public ProductGetHttp(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<Product>> GetProductsAsync()
        {
            var res = await _httpClient.GetAsync("/products");
            res.EnsureSuccessStatusCode();
            var content = await res.Content.ReadAsStringAsync();
            var products = JsonSerializer.Deserialize<List<Product>>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            return products;
        }
        public async Task<Product> GetProduct(int id)
        {
            var res = await _httpClient.GetAsync($"/products/{id}");
            res.EnsureSuccessStatusCode();
            var content = await res.Content.ReadAsStringAsync();
            var products = JsonSerializer.Deserialize<Product>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            return products;
        }
    }
}
