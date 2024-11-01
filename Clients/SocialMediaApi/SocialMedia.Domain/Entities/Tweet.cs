using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Domain.Entities
{
    public class Tweet : BaseEntity<Guid>
    {
        public string Content { get; set; }
        public virtual User User { get; set; }
        public Guid UserId { get; set; }
        public virtual ICollection<Like> Likes { get; set; }
    }
}
