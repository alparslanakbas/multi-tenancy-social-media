using Microsoft.EntityFrameworkCore;
using SocialMedia.Domain.Entities;
using SocialMedia.SqlServer.EntityConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.SqlServer.Context
{
    public class TenantMappingContext(DbContextOptions<TenantMappingContext> options) : DbContext(options)
    {
        public DbSet<TenantMapping> TenantMappings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Selected defaulth schema
            modelBuilder.HasDefaultSchema("x");

            // Entities configurations
            modelBuilder.ApplyConfiguration(new FollowConfiguration());
            modelBuilder.ApplyConfiguration(new LikeConfiguration());
            modelBuilder.ApplyConfiguration(new TenantMappingConfiguration());
            modelBuilder.ApplyConfiguration(new TweetConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            

            base.OnModelCreating(modelBuilder);
        }
    }
}
