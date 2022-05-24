using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Products.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchMvc.Application.Mappings
{
    public class DTOToCommandMappingProfile: Profile
    {
        public DTOToCommandMappingProfile()
        {
            CreateMap<ProductDTO, ProductCreateCommand>();
            CreateMap<ProductDTO, ProductUpdateCommand>();
        }
    }
}
