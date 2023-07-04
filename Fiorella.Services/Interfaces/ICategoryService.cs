using Fiorella.Services.Dtos.CategoryDtos;
using Fiorella.Services.Dtos.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiorella.Services.Interfaces
{
    
    public interface ICategoryService
    {
        public CreatedItemDto Create(CategoryPostDto postDto);
        public void Delete(int id);
        public void Edit(int id, CategoryPutDto putDto);
        public List<CategoryGetAllItemDto> GetAll();
        public CategoryGetItemDto Get(int id);
    }
}
