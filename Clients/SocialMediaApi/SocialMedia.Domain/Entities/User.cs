using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Domain.Entities
{
    public class User : BaseEntity<Guid>
    {
        public string UserName { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Follow> Followers { get; set; }
        public virtual ICollection<Follow> Followings { get; set; }
        public virtual ICollection<Like> Likes { get; set; }
        public virtual ICollection<Tweet> Tweets { get; set; }
        public virtual TenantMapping TenantMapping { get; set; }


    }
}
