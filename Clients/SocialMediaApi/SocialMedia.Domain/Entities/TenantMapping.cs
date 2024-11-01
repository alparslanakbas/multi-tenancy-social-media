using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Domain.Entities
{
    public class TenantMapping : BaseEntity<Guid>
    {
        public string TenantId { get; set; }
        public User User { get; set; }
        public Guid UserId { get; set; }
    }
}
