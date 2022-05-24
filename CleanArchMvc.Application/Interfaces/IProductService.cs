﻿using CleanArchMvc.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetProductsAsync();
        Task<ProductDTO> GetByIdAsync(int? id);
        //Task<ProductDTO> GetProductCategoryAsync(int? id);
        Task AddAsync(ProductDTO productDto);
        Task UpdateAsync(ProductDTO productDto);
        Task RemoveAsync(int? id);
    }
}
