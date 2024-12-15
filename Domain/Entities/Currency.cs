using Domain.Entities.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Currency : TinyBaseEntity
    {
        public Currency()
        {
            PaymentInfos = new HashSet<PaymentInfo>();
            TransferInfos = new HashSet<TransferInfo>();
        }

        public string NameAr { get; set; } = string.Empty;
        public string NameEn { get; set; } = string.Empty;
        public string Shortcut { get; set; } = string.Empty;

        public virtual ICollection<TransferInfo> TransferInfos { get; set; }
        public virtual ICollection<PaymentInfo> PaymentInfos { get; set; }
    }
}
