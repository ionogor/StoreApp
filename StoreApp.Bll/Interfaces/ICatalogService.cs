using StoreApp.Common.Dtos.Catalogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Bll.Interfaces
{
    public interface ICatalogService
    {
        Task<CatalogDto> CreateCatalog(CreateCatalogDto product);
        Task<CatalogDto> GetCatalogByID(int id);
        Task<IEnumerable<CatalogDto>> GetAllCatalogs();
        Task UpdateCatalog(int id, CatalogUpdateDto product);
        Task DeleteCatalog(int id);

    }
}
