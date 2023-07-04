using Fiorella.Core.Entities;
using Fiorella.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiorella.Data.Repositories
{
    public class AppUserRepository:Repository<AppUser>, IAppUserRepository
    {
        public AppUserRepository(FiorellaDbContext context):base(context)
        {
            
        }
    }
}
