using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Domain.Entities
{
    public class Follow : BaseEntity<Guid>
    {
        public Guid FollowerUserId { get; set; }
        public Guid FollowingUserId { get; set; }

        public virtual User FollowerUser { get; set; }
        public virtual User FollowingUser { get; set; }

    }
}
