using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Domain.Entities
{
    public class Like : BaseEntity<Guid>
    {
        public virtual User User { get; set; }
        public Guid UserId { get; set; }

        public virtual Tweet Tweet { get; set; }
        public Guid TweetId { get; set; }
    }
}
