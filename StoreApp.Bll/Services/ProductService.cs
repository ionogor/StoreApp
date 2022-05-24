using AutoMapper;
using Azure.Storage.Blobs;
using Microsoft.EntityFrameworkCore;
using StoreApp.Bll.Interfaces;
using StoreApp.Common.Dtos.Products;
using StoreApp.Common.Exceptions;
using StoreApp.Common.Paginations;
using StoreApp.Data.Interfaces;
using StoreApp.Data.ViewModels;
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
        //private readonly BlobServiceClient _blobservice;
        private readonly IMapper _mapper;

        public ProductService(IRepository<Product> repository, IMapper mapper)
        {
            _repository= repository;
            _mapper= mapper;
           
        }



        public async Task<ProductDto> CreateProduct([FromBody] CreateProductDto product)
        {
            //var container = _blobservice.GetBlobContainerClient("photo");
            
            var newProduct = _mapper.Map<Product>(product);
            _repository.Add(newProduct);
            _repository.SaveChangeAsync();
            var productDto = _mapper.Map<ProductDto>(newProduct);
            return productDto;
        }

        public async Task<Product> DeleteProduct(int id)
        {
            var entity = await _repository.GetById(id);
            if(entity != null)
            {
                _repository.Delete(entity);
            }
            else
            {
                throw new ArgumentException("Product not exist!");
            }

            return entity;
            

        }

        public async Task<List<ProductDto>> FindProduct(string q)
        {
        
            var product = _repository.Read().ToList();
            
            var query = product.FindAll(x => x.Title.ToLower().Contains(q.ToLower())).ToList();

             var result= _mapper.Map<List<ProductDto>>(query);

            return result;
        }

        public async Task<IEnumerable<ProductDto>> GetAllProducts(PaginatedViewModel paginatedViewModel)
        {
            var productList = _repository.GetAll(paginatedViewModel);
            var productDtoList = _mapper.Map<List<ProductDto>>(productList);
            return productDtoList;
        }


        public async Task<PageRequest> GetPageProduct(int page, int IdCatalog)
        {
            var pageProductsResult = 8f;
            var count = _repository.Read().Include(x => x.Catalog).Where(x => x.CatalogId == IdCatalog).Count();
            var pageCount = Math.Ceiling(count/pageProductsResult);
              var productList = _repository.Read().Include(x=>x.Catalog).Where(x=>x.CatalogId == IdCatalog)
                .Skip((page-1)*(int)pageProductsResult)
                .Take((int)pageProductsResult).ToList();

            var listProductDto = _mapper.Map<List<ProductListDto>>(productList);

            var productListDto = new PageRequest
            {
                Pages = (int)pageCount,
                CurrentPage = page,
                ProductListDtos = listProductDto

            };

            return productListDto;

        }

        public async Task<ProductDto> GetProductById(int id)
        {

            // var productsPhoto = await _repository.GetByIdWithInclude<Product>(id, x => x.Photos);
            var productsPhoto = await _repository.Read()
                           .Include(x => x.Catalog).ThenInclude(x => x.Products).ThenInclude(x=>x.Reviews)
                           .FirstOrDefaultAsync(c => c.Id == id);

            // var products = await _repository.GetById(id);
            var productDto = _mapper.Map<ProductDto>(productsPhoto);
            return productDto;
        }

        public async Task UpdateProduct(int id, ProductUpdateDto product)
        {
            //var produs = await _repository.GetById(id);

            //if (produs.Title == product.Title)
            //{
            //    throw new EntryAlreadyExistsException("Error");
            //}

            var oneProduct = await _repository.GetById(id);
            _mapper.Map(product, oneProduct);
            _repository.Update(oneProduct);
            

        }

    
    }
}
