using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialMedia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.SqlServer.EntityConfiguration
{
    public sealed class TenantMappingConfiguration : BaseEntityConfiguration<TenantMapping>
    {
        public new void Configure(EntityTypeBuilder<TenantMapping> builder)
        {
            // TenantId Configuration
            builder.Property(x => x.TenantId).IsRequired();

            // UserId Configuration
            builder.Property(x=>x.UserId).IsRequired();

            // Relationals
            builder.HasOne(x => x.User)
                    .WithOne(x => x.TenantMapping)
                    .HasForeignKey<TenantMapping>(x => x.UserId)
                    .OnDelete(DeleteBehavior.Cascade);

            base.Configure(builder);
        }
    }
}
