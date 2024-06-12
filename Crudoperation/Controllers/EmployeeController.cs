using Crudoperation.Model.Product;
using Crudoperation.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Crudoperation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IProductService _productService;

        public EmployeeController(IProductService productService)
        {
            _productService = productService;
        }
        //[Authorize]
        [HttpGet]
        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            var res = await _productService.GetProductsAsync();
            return res;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var res = await _productService.GetProduct(id);
            if (res == null)
            {
                return NotFound();
            }
            return Ok(res);
        }
        [HttpPost]
        public async Task<IActionResult> AddProducts(Product product)
        {
            await _productService.AddProductAsync(product);
            return CreatedAtAction(nameof(GetProduct), new {id = product.Id},product);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }
            await _productService.UpdateProductAsync(product);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _productService.DeleteProductAsync(id);
            return NoContent();
        }
    }
}
