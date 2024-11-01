using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SocialMedia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.SqlServer.EntityConfiguration
{
    public sealed class LikeConfiguration : BaseEntityConfiguration<Like>
    {
        public new void Configure(EntityTypeBuilder<Like> builder)
        {
            // UserId Configuration
            builder.Property(x => x.UserId).IsRequired();

            // TweetId Configuration
            builder.Property(x => x.TweetId).IsRequired();

            // Relationals
            builder.HasOne(x => x.User)
                    .WithMany(x => x.Likes)
                    .HasForeignKey(x => x.UserId)
                    .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Tweet)
                    .WithMany(x=>x.Likes)
                    .HasForeignKey(x=>x.TweetId)
                    .OnDelete(DeleteBehavior.Cascade);

            base.Configure(builder);
        }
    }
}
