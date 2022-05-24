using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Application.Products.Commands;
using CleanArchMvc.Application.Products.Queries;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Services
{
    public class ProductService : IProductService
    {

        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public ProductService(IMapper mapper, IMediator mediator)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDTO>> GetProductsAsync()
        {
            var productsQuery = new GetProductsQuery();

            if (productsQuery == null)
            {
                throw new Exception("Entity could not be loaded.");
            }
            else
            {
                var result = await _mediator.Send(productsQuery);
                return _mapper.Map<IEnumerable<ProductDTO>>(result);
            }
        }

        public async Task<ProductDTO> GetByIdAsync(int? id)
        {
            var productByIdQuery = new GetProductByIdQuery(id.Value);

            if (productByIdQuery == null)
            {
                throw new Exception("Entity could not be loaded.");
            }
            else
            {
                var result = await _mediator.Send(productByIdQuery);
                return _mapper.Map<ProductDTO>(result);
            }
        }

        //public async Task<ProductDTO> GetProductCategoryAsync(int? id)
        //{
        //    var productsQuery = new GetProductByIdQuery(id.Value);

        //    if (productsQuery == null)
        //    {
        //        throw new Exception("Entity could not be loaded.");
        //    }
        //    else
        //    {
        //        var result = await _mediator.Send(productsQuery);
        //        return _mapper.Map<ProductDTO>(result);
        //    }
        //}

        public async Task AddAsync(ProductDTO productDto)
        {
            var productCreateCommand = _mapper.Map<ProductCreateCommand>(productDto);
            await _mediator.Send(productCreateCommand);
        }

        public async Task UpdateAsync(ProductDTO productDto)
        {
            var productUpdateCommand = _mapper.Map<ProductUpdateCommand>(productDto);
            await _mediator.Send(productUpdateCommand);
        }

        public async Task RemoveAsync(int? id)
        {
            var productRemoveCommand = new ProductRemoveCommand(id.Value);

            if (productRemoveCommand == null)
            {
                throw new Exception("Entity could not be loaded.");
            }
            else
            {
                await _mediator.Send(productRemoveCommand);
            }
        }
    }
}
