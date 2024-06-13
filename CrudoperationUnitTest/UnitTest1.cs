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
    }
    }
