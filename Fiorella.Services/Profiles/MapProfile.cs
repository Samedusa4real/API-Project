using AutoMapper;
using Fiorella.Core.Entities;
using Fiorella.Services.Dtos.CategoryDtos;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiorella.Services.Profiles
{
    public class MapProfile:Profile
    {
        public MapProfile(IHttpContextAccessor httpContextAccessor)
        {
            // CATEGORY//
            CreateMap<CategoryPostDto, Category>();
            CreateMap<Category, CategoryGetItemDto>();
            CreateMap<Category, CategoryGetAllItemDto>();

        }
    }
}
