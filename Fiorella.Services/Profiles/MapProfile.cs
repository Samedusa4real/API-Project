using AutoMapper;
using Fiorella.Core.Entities;
using Fiorella.Services.Dtos.CategoryDtos;
using Fiorella.Services.Dtos.SliderDtos;
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
            var uriBuilder = new UriBuilder(httpContextAccessor.HttpContext.Request.Scheme, httpContextAccessor.HttpContext.Request.Host.Host, httpContextAccessor.HttpContext.Request.Host.Port ?? -1);
            if (uriBuilder.Uri.IsDefaultPort)
            {
                uriBuilder.Port = -1;
            }
            string baseUrl = uriBuilder.Uri.AbsoluteUri;

            // CATEGORY //
            CreateMap<CategoryPostDto, Category>();
            CreateMap<Category, CategoryGetItemDto>();
            CreateMap<Category, CategoryGetAllItemDto>();

            // SLIDER //
            CreateMap<SliderPostDto, Slider>();
            CreateMap<Slider, SliderGetItemDto>()
                .ForMember(dest => dest.BackgroundImageUrl, m => m.MapFrom(s => baseUrl + $"sliders/{s.BackgroundImageUrl}"))
                .ForMember(dest => dest.SignatureImageUrl, m => m.MapFrom(s => baseUrl + $"sliders/{s.SignatureImageUrl}"));
            CreateMap<Slider, SliderGetAllItemDto>()
                .ForMember(dest => dest.BackgroundImageUrl, m => m.MapFrom(s => baseUrl + $"sliders/{s.BackgroundImageUrl}"))
                .ForMember(dest => dest.SignatureImageUrl, m => m.MapFrom(s => baseUrl + $"sliders/{s.SignatureImageUrl}"));

        }
    }
}
