using AutoMapper;
using StoreApp.Bll.Interfaces;
using StoreApp.Common.Dtos.Products;
using StoreApp.Data.Interfaces;
using StoreApp.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace StoreApp.Bll.Services
{
    public class ProductService : IProductService
    {

        private readonly IRepository<Product> _repository;
        private readonly IMapper _mapper;

        public ProductService(IRepository<Product> repository,IMapper mapper)
        {
            _repository= repository;
            _mapper= mapper;
        }

        public async Task<ProductDto> CreateProduct([FromBody] ProductDto product)
        {

          var newProduct=_mapper.Map<Product>(product);
            _repository.Add(newProduct);
            _repository.SaveChangeAsync();

            var productDto = _mapper.Map<ProductDto>(newProduct);

            return productDto;

        }

        public async Task DeleteProduct(int id)
        {
           var entity= await _repository.GetById(id);
            
           _repository.Delete(entity);
            
        }

        public async Task<IEnumerable<ProductDto>> GetAllProdducts()
        {
            var productList=await _repository.GetAll();
            var productDtoList = _mapper.Map<List<ProductDto>>(productList);
            return productDtoList;
        }

        public async Task<ProductDto> GetProductById(int id)
        {
            var product = await _repository.GetById(id);
            var productDto = _mapper.Map<ProductDto>(product);
            return productDto;
        }


        public async Task UpdateProduct(int id, ProductUpdateDto product)
        {
            var oneProduct = await _repository.GetById(id);
            _mapper.Map(product, oneProduct);
             _repository.SaveChangeAsync();

        }
    }
}
