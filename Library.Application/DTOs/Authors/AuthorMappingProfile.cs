using AutoMapper;
using Library.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.DTOs.Authors
{
    public class AuthorMappingProfile :Profile
    {
        public AuthorMappingProfile()
        {
            CreateMap<CreateAuthorDto, Author>()
                 .ForMember(a =>  a.AuthorGeneres,dest =>dest.MapFrom( s =>s.GenreIds.Select(g =>new AuthorGeneres (0,g ))))
                 .ReverseMap();
            CreateMap<AuthorDto, Author>()
                .ReverseMap();
        }
    }
}
