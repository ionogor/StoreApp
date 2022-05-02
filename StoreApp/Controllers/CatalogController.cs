using Microsoft.AspNetCore.Mvc;
using StoreApp.Bll.Interfaces;
using StoreApp.Common.Dtos.Catalogs;
using StoreApp.Data.ViewModels;
// TODO: add authorization attributes
namespace StoreApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CatalogController : ControllerBase
    {
        private readonly ICatalogService _catalogService;
        private readonly ILogger<CatalogController> _logger;
        public CatalogController(ICatalogService catalogService, ILogger<CatalogController> logger)
        {
            _catalogService = catalogService;
            _logger = logger;

        }

        [HttpPost]
        public async Task<ActionResult> AddCatalog([FromBody] CreateCatalogDto catalogDto)
        {
            await _catalogService.CreateCatalog(catalogDto);

            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var catalog = await _catalogService.GetCatalogByID(id);
            if (catalog == null)
            {
                return NotFound();
            }
            return Ok(catalog);
        }

        [HttpGet]
        public async Task<ActionResult> GetCatalog([FromQuery] PaginatedViewModel paginatedModel)
        {
            var catalogs = await _catalogService.GetAllCatalogs(paginatedModel);
            return Ok(catalogs);
        }

      
    }
}
