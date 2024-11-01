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
    public sealed class TweetConfiguration : BaseEntityConfiguration<Tweet>
    {
        public new void Configure(EntityTypeBuilder<Tweet> builder)
        {
            // Content Configuration
            builder.Property(x=>x.Content)
                    .IsRequired()
                    .HasMaxLength(1000);

            // UserId Configuration
            builder.Property(x => x.UserId)
                    .IsRequired();

            // Relationals
            builder.HasOne(x => x.User)
                    .WithMany(x => x.Tweets)
                    .HasForeignKey(x => x.UserId)
                    .OnDelete(DeleteBehavior.Cascade);

            base.Configure(builder);
        }
    }
}
