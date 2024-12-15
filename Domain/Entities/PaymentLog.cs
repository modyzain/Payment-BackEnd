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
        public byte ActionTypeId { get; set; }
        public int UserId { get; set; }
        public DateTime ActionDate { get; set; }
        public string Description { get; set; } = string.Empty;

        public virtual required ActionType ActionType { get; set; }
        public virtual required ProfileInfo ProfileInfo { get; set; }
    }
}
