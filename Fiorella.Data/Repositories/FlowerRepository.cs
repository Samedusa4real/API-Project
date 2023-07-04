using Fiorella.Core.Entities;
using Fiorella.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiorella.Data.Repositories
{
    public class FlowerRepository : Repository<Flower>, IFlowerRepository
    {
        public FlowerRepository(FiorellaDbContext context): base(context)
        {
            
        }
    }
}
