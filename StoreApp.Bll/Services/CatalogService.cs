using AutoMapper;
using StoreApp.Bll.Interfaces;
using StoreApp.Common.Dtos.Catalogs;
using StoreApp.Data.Interfaces;
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

        public Task DeleteCatalog(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CatalogDto>> GetAllCatalogs()
        {
            throw new NotImplementedException();
        }

        public  async Task<CatalogDto> GetCatalogByID(int id)
        {
            var catalog = await _repository.GetById(id);

            var catalogDto = _mapper.Map<CatalogDto>(catalog);

            return catalogDto;

        }

        public Task UpdateCatalog(int id, CatalogUpdateDto product)
        {
 
            throw new NotImplementedException();
            
        }
    }
}
