﻿using Fiorella.Core.Entities;
using Fiorella.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiorella.Data.Repositories
{
    public class SliderRepository : Repository<Slider>, ISliderRepository
    {
        public SliderRepository(FiorellaDbContext context):base(context)
        {
            
        }
    }
}
