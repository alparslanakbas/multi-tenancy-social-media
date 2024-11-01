using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialMedia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.SqlServer.EntityConfiguration
{
    public sealed class UserConfiguration : BaseEntityConfiguration<User>
    {
        public new void Configure(EntityTypeBuilder<User> builder)
        {
            // UserName Configuration
            builder.Property(x => x.UserName)
                    .IsRequired()
                    .HasMaxLength(50);

            // Password Configuration
            builder.Property(x => x.Password)
                    .IsRequired();

            // Email Configuration
            builder.Property(x=>x.EmailAddress)
                    .IsRequired()
                    .HasMaxLength(50);

            base.Configure(builder);
        }
    }
}
