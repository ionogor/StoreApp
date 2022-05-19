using Microsoft.AspNetCore.Mvc;
using StoreApp.Bll.Interfaces;
using StoreApp.Common.Dtos.Products;
using StoreApp.Common.Exceptions;
using StoreApp.Data.ViewModels;

namespace StoreApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
       // private readonly ILogger<ProductController> _logger;
        public ProductController(IProductService productService)
        {
            _productService=productService;
            
        }

        // product/id
        [HttpGet("{id}")] 
        public async Task<IActionResult> GetProductById(int id)
        {

            var product = await _productService.GetProductById(id);

            if (product == null)
            {
                return NotFound($"Product with {id} doesn't exist");
            }

            return Ok(product);
        }

        [HttpGet] 
        public async Task<IActionResult> GetAll()
        {
            var paginatedViewModel = new PaginatedViewModel()
            {
                Page = 1,
                Count = 10
            };
            var products = await _productService.GetAllProducts(paginatedViewModel);
            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] CreateProductDto product)
        {
            var productDto = await _productService.CreateProduct(product);

            if (productDto == null)
            {
                return BadRequest("Product has not added!");
            }
            return CreatedAtAction(nameof(GetProductById), new { id = productDto.Title }, productDto);
        }

        [HttpPut("EditProduct/{id}")]
        [ApiExceptionFilter]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] ProductUpdateDto product)
        {

            await _productService.UpdateProduct(id, product);
            return Ok();
        }


        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult> DeteleProduct(int id)
        {
           return Ok( await _productService.DeleteProduct(id));
        }

        [HttpGet("/productpage/{page}")]
        public async Task<IActionResult> GetPageProduct(int page,int id)
        {
            return Ok(await _productService.GetPageProduct(page,id));
        }
    }
}
