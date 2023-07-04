using Fiorella.Core.Entities;
using Fiorella.Data.Configs;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiorella.Data
{
    public class FiorellaDbContext : IdentityDbContext
    {
        public FiorellaDbContext(DbContextOptions<FiorellaDbContext> options) : base(options)
        {

        }

        public DbSet<AppUser> AppUsers { get; set; }

        public DbSet<Flower> Flowers { get; set; }

        public DbSet<FlowerImage> FlowerImages { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Slider> Sliders { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(CategoryConfiguration).Assembly);
            base.OnModelCreating(builder);
        }
    }
}
