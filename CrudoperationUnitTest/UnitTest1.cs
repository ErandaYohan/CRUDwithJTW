using Crudoperation.Controllers;
using Crudoperation.Model.Product;
using Crudoperation.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace CrudoperationUnitTest
{
    public class UnitTest1
    {
        private readonly Mock<IProductService> _mockProductService;
        private readonly Mock<ILogger<EmployeeController>> _mockLogger;
        private readonly EmployeeController _controller;

        public UnitTest1()
        {
            _mockProductService = new Mock<IProductService>();
            _mockLogger = new Mock<ILogger<EmployeeController>>();
            _controller = new EmployeeController(_mockProductService.Object, _mockLogger.Object);
        }
        [Fact]
        public async Task GetProductsAsync_ReturnsOkResult_WithListOfProducts()
        {
            // Arrange
            var products = new List<Product> { new Product { Id = 1, title = "Product1", description = "asdsadasd" } };
            _mockProductService.Setup(service => service.GetProductsAsync()).Returns(products);

            // Act
            var result =  _controller.GetProductsAsync();

            // Assert
            //var okResult = Assert.IsType<OkObjectResult>(result);
            var returnProducts = Assert.IsType<List<Product>>(result);
            Assert.Single(returnProducts);
        }
        [Fact]
        public async Task GetEmployeeID()
        {
            // Arrange
            var product = new Product { Id = 1, title = "Product1" };
            _mockProductService.Setup(service => service.GetProduct(1)).ReturnsAsync(product);

            // Act
            var result = await _controller.GetProduct(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnProduct = Assert.IsType<Product>(okResult.Value);
            Assert.Equal(1, returnProduct.Id);
        }
        [Fact]
        public async Task AddProducts_ReturnsCreatedAtAction()
        {
            // Arrange
            var product = new Product { Id = 1, title = "Product1" };
            _mockProductService.Setup(service => service.AddProductAsync(product)).Returns(Task.CompletedTask);

            // Act
            var result = await _controller.AddProducts(product);

            // Assert
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
            var returnProduct = Assert.IsType<Product>(createdAtActionResult.Value);
            Assert.Equal(1, returnProduct.Id);
        }

    }
}
