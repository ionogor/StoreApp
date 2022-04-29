﻿using StoreApp.Common.Dtos.Products;
using StoreApp.Common.Paginations;
using StoreApp.Data.Interfaces;
using StoreApp.Data.ViewModels;
using StoreApp.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Bll.Interfaces
{
    public interface IProductService
    {
        Task<ProductDto> CreateProduct(CreateProductDto product);
        Task<ProductDto> GetProductById(int id);
        Task<IEnumerable<ProductDto>> GetAllProducts(PaginatedViewModel paginatedViewModel);
        Task UpdateProduct(int id, ProductUpdateDto product);
        Task DeleteProduct(int id);
        Task<PageRequest> GetPageProduct(int id);
       

    }
}
