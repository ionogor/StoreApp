using AutoMapper;
using StoreApp.Bll.Interfaces;
using StoreApp.Common.Dtos.Catalogs;
using StoreApp.Common.Dtos.Products;
using StoreApp.Data.Interfaces;
using StoreApp.Data.ViewModels;
using StoreApp.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Bll.Services
{
    public class CatalogService : ICatalogService
    {
        private readonly IRepository<Catalog> _repository;
        private readonly IMapper _mapper;

        public CatalogService(IRepository<Catalog> repository,IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }
        public async Task<CatalogDto> CreateCatalog(CreateCatalogDto catalogDto)
        {
           var catalog =  _mapper.Map<Catalog>(catalogDto);

            var newCatalogDto = _mapper.Map<CatalogDto>(catalog);

            _repository.Add(catalog);
            _repository.SaveChangeAsync();

            return newCatalogDto;
        }

        public async Task DeleteCatalog(int id)
        {
            var entity = await _repository.GetById(id);

            _repository.Delete(entity);

        }

        public async Task<IEnumerable<CatalogDto>> GetAllCatalogs(PaginatedViewModel paginatedView)
        {
           var catalogs = _repository.GetAll(paginatedView);

            var catalogsDto = _mapper.Map<List<CatalogDto>>(catalogs);

            return catalogsDto;
        }

        public  async Task<CatalogDto> GetCatalogByID(int id)
        {
            var catalog = await _repository.GetByIdWithInclude<Catalog>(id, catalog => catalog.Products);

            var catalogDto = _mapper.Map<CatalogDto>(catalog);

            return catalogDto;

        }

      
        public async Task UpdateCatalog(int id, CatalogUpdateDto catalog)
        {

            var catalogs =await _repository.GetById(id);
           
            _mapper.Map(catalog, catalogs);

            _repository.Update(catalogs);


        }
    }
}
