using AutoMapper;
using Library.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.DTOs.Categories
{
    public class CategpryMappingProfile : Profile
    {
        public CategpryMappingProfile()
        {
            CreateMap<CategoryDto, CategoryDto>()
                .ReverseMap();
            CreateMap<CreateCategoryDto, Category>();
        }
    }
}
