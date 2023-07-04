using Fiorella.Core.Entities;
using Fiorella.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiorella.Data.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(FiorellaDbContext context):base(context)
        {
            
        }
    }
}
