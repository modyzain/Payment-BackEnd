using Domain.Entities.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class PaymentLog : LongBaseEntity
    {
        public PaymentLog()
        {
            ActionTypes = new HashSet<ActionType>();
            ProfileInfos = new HashSet<ProfileInfo>();
        }

        public byte ActionTypeId { get; set; }
        public int UserId { get; set; }
        public DateTime ActionDate { get; set; }
        public string Description { get; set; } = string.Empty;

        public virtual ICollection<ActionType> ActionTypes { get; set; }
        public virtual ICollection<ProfileInfo> ProfileInfos { get; set; }
    }
}
