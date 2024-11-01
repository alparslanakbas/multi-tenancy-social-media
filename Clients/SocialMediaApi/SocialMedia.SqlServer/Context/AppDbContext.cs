using Microsoft.EntityFrameworkCore;
using SocialMedia.Domain.Entities;
using SocialMedia.SqlServer.EntityConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XBuddy.Models.Helpers;

namespace SocialMedia.SqlServer.Context
{
    public class AppDbContext
        (DbContextOptions<AppDbContext> options, GetTenantIdDelegate getTenantIdDelegate, IServiceProvider serviceProvider) 
        : DbContext(options)
    {
        public DbSet<AuditLog> AuditLogs { get; set; }
        public DbSet<Follow> Follows { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Tweet> Tweets { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("x");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BaseEntityConfiguration<>).Assembly);

            // Global query filter
            //var userId = Guid.Parse(getTenantIdDelegate(serviceProvider));
            //modelBuilder.Entity<User>().HasQueryFilter(i=>i.Id == userId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
