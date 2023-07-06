using AutoMapper;
using Fiorella.Core.Entities;
using Fiorella.Core.Repositories;
using Fiorella.Services.Dtos.Common;
using Fiorella.Services.Dtos.SliderDtos;
using Fiorella.Services.Helpers;
using Fiorella.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiorella.Services.Implementations
{
    public class SliderService : ISliderService
    {
        private readonly ISliderRepository _sliderRepository;
        private readonly IMapper _mapper;

        public SliderService(ISliderRepository sliderRepository, IMapper mapper)
        {
            _sliderRepository = sliderRepository;
            _mapper = mapper;
        }
        public CreatedItemDto Create(SliderPostDto postDto)
        {
            var entity = _mapper.Map<Slider>(postDto);

            string rootPath = Directory.GetCurrentDirectory() + "/wwwroot";
            entity.BackgroundImageUrl = FileManager.Save(postDto.BackgroundFile, rootPath, "sliders");
            entity.SignatureImageUrl = FileManager.Save(postDto.SignatureFile, rootPath, "sliders");

            _sliderRepository.Create(entity);
            _sliderRepository.Commit(); 

            return new CreatedItemDto { Id = entity.Id };
        }

        public void Delete(int id)
        {
            var entity = _sliderRepository.Get(x=>x.Id == id);

            if (entity == null) throw new Exception();

            string rootPath = Directory.GetCurrentDirectory() + "/wwwroot";
            FileManager.Delete(rootPath, "sliders", entity.BackgroundImageUrl);
            FileManager.Delete(rootPath, "sliders", entity.SignatureImageUrl);

            _sliderRepository.Remove(entity);
            _sliderRepository.Commit();
        }

        public void Edit(int id, SliderPutDto putDto)
        {
            var entity = _sliderRepository.Get(x=>x.Id == id);

            if (entity == null) throw new Exception();

            entity.Title = putDto.Title;
            entity.Description = putDto.Description;

            string removedBgImage = null;
            string removedSgnImage = null;
            string rootPath = Directory.GetCurrentDirectory() + "/wwwroot";

            if(putDto.BackgroundFile != null)
            {
                removedBgImage = entity.BackgroundImageUrl;
                entity.BackgroundImageUrl = FileManager.Save(putDto.BackgroundFile, rootPath, "/sliders");
            }

            if (putDto.SignatureFile != null)
            {
                removedSgnImage = entity.SignatureImageUrl;
                entity.SignatureImageUrl = FileManager.Save(putDto.SignatureFile, rootPath, "/sliders");
            }

            _sliderRepository.Commit();

            if (removedBgImage != null)
                FileManager.Delete(rootPath, "/sliders", removedBgImage);

            if (removedSgnImage != null)
                FileManager.Delete(rootPath, "/sliders", removedSgnImage);
        }

        public SliderGetItemDto Get(int id) 
        {
            var entity = _sliderRepository.Get(x=>x.Id == id);

            if (entity == null) throw new Exception();

            var data = _mapper.Map<SliderGetItemDto>(entity);

            return data;
        }

        public List<SliderGetAllItemDto> GetAll()
        {
            var data = _sliderRepository.GetAll(x => true);

            return _mapper.Map<List<SliderGetAllItemDto>>(data);
        }
    }
}
