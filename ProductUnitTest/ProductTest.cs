using Microsoft.AspNetCore.Mvc;
using Moq;
using StoreApp.Bll.Interfaces;
using StoreApp.Common.Dtos.Products;
using StoreApp.Controllers;
using StoreApp.Domain.Entity;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace ProductUnitTest
{
    public class ProductTest
    {
        private readonly ProductController _productController;

       public List<ProductDto> listProduct = new List<ProductDto>() {

                new ProductDto{Id=1,Description="laptop1",Stock=1,SupplierId=1,Price=100,Title="laptop asus" },
                new ProductDto{Id=2,Description="laptop2",Stock=1,SupplierId=1,Price=100,Title="laptop dell" },
                new ProductDto{Id=3,Description="laptop3",Stock=1,SupplierId=1,Price=100,Title="laptop samsung" }


            };
        public ProductTest()
        {
            var mockService = new Mock<IProductService>();

         
            mockService.Setup(x => x.GetAllProducts()).ReturnsAsync(new List<ProductDto>(listProduct));
            mockService.Setup(x => x.GetProductById(It.IsAny<int>())).ReturnsAsync((int id) => listProduct.Find(x => x.Id == id));
            _productController = new ProductController(mockService.Object);
        }

        [Fact]
      public async Task Get_All_Products()
        {
            //Act 
            var result = await _productController.GetAll() as ObjectResult;
            var products = result.Value as List<ProductDto>;

            //Assert
            Assert.Equal((int)HttpStatusCode.OK,result.StatusCode);
            Assert.Equal(listProduct.Count, products.Count);
        }

        [Fact]
        public async Task Get_ProductById_If_Exists_ReturnOkResult()
        {
            //Arange
            var id = 1;
            //Act
            var result = await _productController.GetProductById(id) as ObjectResult;
            var product = result?.Value as ProductDto;

      ;
            //Assert
            Assert.Equal((int)HttpStatusCode.OK, result?.StatusCode);
            Assert.NotNull(product);

            Assert.Equal(id,product.Id);
        } 
        [Fact]

        public async Task GetProductByID_If_NotFound_ReturnBadRequest()
        {
            //Act
            int id = 20;
            //Act
            var result = await _productController.GetProductById(id) as ObjectResult;
        
            // Assert

            Assert.Equal((int)HttpStatusCode.NotFound,result.StatusCode);
            Assert.Equal($"Product with id {id} not found ", result.Value);
        }
        [Fact]
        public async Task Post_Product_Return_AddProduct()
        {
            //Act
       
            var mock = new Mock<IProductService>();
            var productDescription = "test";

            mock.Setup(x=>x.CreateProduct(It.IsAny<CreateProductDto>())).ReturnsAsync(new ProductDto()
            {
                Description = productDescription
            });
            var newProduct = new CreateProductDto();

            //Act 
            var result = await new ProductController(mock.Object).AddProduct(newProduct);

            //Assert 
            
            var createdProduct = Assert.IsType<CreatedAtActionResult>(result); // 201 code - > created respose
            Assert.NotNull(createdProduct);
            var productValue = Assert.IsType<ProductDto>(createdProduct.Value);
            Assert.Equal(productDescription, productValue.Description);
         
        }

        [Fact]

        public async Task Update_Product_ReturnOkResult()
        {

            var mock = new Mock<IProductService>();
            var productDescription = "update";

            mock.Setup(x => x.UpdateProduct(It.IsAny<int>(), It.IsAny<ProductUpdateDto>()));
            var newProduct = new ProductUpdateDto();

            //Act 
            var result = await new ProductController(mock.Object).UpdateProduct(1,newProduct);

            //Assert 

             Assert.IsType<OkResult>(result); // 201 code - > created respose
         
        }
    }
}