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
    public sealed class FollowConfiguration : BaseEntityConfiguration<Follow>
    {
        public new void Configure(EntityTypeBuilder<Follow> builder)
        {
            // FollowerUserId Configuration
            builder.Property(x => x.FollowerUserId).IsRequired();

            // FollowingUserId Configuration
            builder.Property(x => x.FollowingUserId).IsRequired();

            // Relationals
            builder.HasOne(x=>x.FollowerUser)
                    .WithMany(x=> x.Followers)
                    .HasForeignKey(x=>x.FollowerUserId)
                    .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x=>x.FollowingUser)
                    .WithMany(x=>x.Followings)
                    .HasForeignKey(x=>x.FollowingUserId)
                    .OnDelete(DeleteBehavior.Cascade);     
            
            base.Configure(builder);
        }
    }
}
