using Fiorella.Services.Dtos.CategoryDtos;
using Fiorella.Services.Dtos.Common;
using Fiorella.Services.Dtos.SliderDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiorella.Services.Interfaces
{
    public interface ISliderService
    {
        public CreatedItemDto Create(SliderPostDto postDto);
        public void Delete(int id);
        public void Edit(int id, SliderPutDto putDto);
        public List<SliderGetAllItemDto> GetAll();
        public SliderGetItemDto Get(int id);
    }
}
