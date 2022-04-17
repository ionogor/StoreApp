using Microsoft.AspNetCore.Mvc;
using StoreApp.Bll.Interfaces;
using StoreApp.Common.Dtos.Products;
using StoreApp.Common.Exceptions;

namespace StoreApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService=productService;
        }

        // product/id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product =await _productService.GetProductById(id);
            
            if(product == null)
            {
                return NotFound($"Product with {id} doesn't exist");
            }
            return Ok(product);
        }

        [HttpGet] // product
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetAllProducts();
            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct( [FromBody] CreateProductDto product)
        {
           var productDto = await _productService.CreateProduct(product);

            if(productDto == null)
            {
                return BadRequest("Product has not added!");
            }
            return CreatedAtAction(nameof(GetProductById), new { id = productDto.Title}, productDto);
        }

        [HttpPut("{id}")]
       // [ApiExceptionFilter]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] ProductUpdateDto product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _productService.UpdateProduct(id, product);
            return Ok();
        }
      

        [HttpDelete("{id}")]
        public async Task DeteleProduct(int id)
        {
            await _productService.DeleteProduct(id);
        }
    }
}
