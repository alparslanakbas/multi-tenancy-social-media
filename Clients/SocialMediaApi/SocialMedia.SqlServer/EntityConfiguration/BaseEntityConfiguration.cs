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
    public abstract class BaseEntityConfiguration<TBaseEntity> : IEntityTypeConfiguration<TBaseEntity> where TBaseEntity : BaseEntity<Guid>
    {
        public void Configure(EntityTypeBuilder<TBaseEntity> builder)
        {
            // Id Configuration
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd().HasDefaultValueSql("newsequentialid()");

            // CreatedDate Configuration
            builder.Property(x => x.CreatedDate).IsRequired();

            // ModifiedDate Configuration
            builder.Property(x => x.ModifiedDate).IsRequired(false);
        }
    }
}
