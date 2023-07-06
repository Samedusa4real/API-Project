using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiorella.Services.Dtos.SliderDtos
{
    public class SliderGetItemDto
    {
        public string SignatureImageUrl { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string BackgroundImageUrl { get; set; }
    }
}
