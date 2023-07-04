using AutoMapper;
using Fiorella.Core.Entities;
using Fiorella.Core.Repositories;
using Fiorella.Services.Dtos.CategoryDtos;
using Fiorella.Services.Dtos.Common;
using Fiorella.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiorella.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public CreatedItemDto Create(CategoryPostDto postDto)
        {
            if (_categoryRepository.IsExist(x => x.Name == postDto.Name))
                throw new Exception();
                
            var entity = _mapper.Map<Category>(postDto);

            _categoryRepository.Create(entity);
            _categoryRepository.Commit();

            return new CreatedItemDto { Id = entity.Id };
        }

        public void Delete(int id)
        {
            if (!_categoryRepository.IsExist(x=>x.Id == id))
                throw new Exception();

            var entity = _categoryRepository.Get(x=>x.Id == id);

            _categoryRepository.Remove(entity);
            _categoryRepository.Commit();
        }

        public void Edit(int id, CategoryPutDto putDto)
        {
            if (!_categoryRepository.IsExist(x => x.Id == id))
                throw new Exception();

            var entity = _categoryRepository.Get(x=>x.Id == id);

            if (_categoryRepository.IsExist(x=>x.Name == putDto.Name) && entity.Name != putDto.Name)
                throw new Exception();

            entity.Name = putDto.Name;
            _categoryRepository.Commit();
        }

        public CategoryGetItemDto Get(int id)
        {
            if (!_categoryRepository.IsExist(x => x.Id == id))
                throw new Exception();
            
            var entity = _categoryRepository.Get(x=>x.Id == id);

            var data = _mapper.Map<CategoryGetItemDto>(entity);

            return data;
        }

        public List<CategoryGetAllItemDto> GetAll()
        {
            var data = _categoryRepository.GetAll(x => true);

            return _mapper.Map<List<CategoryGetAllItemDto>>(data);
        }
    }
}
