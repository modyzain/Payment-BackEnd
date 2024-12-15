using Domain.Entities.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class PaymentType : TinyBaseEntity
    {
        public PaymentType()
        {
            PaymentInfos = new HashSet<PaymentInfo>();
        }

        public string NameAr { get; set; } = string.Empty;
        public string NameEn { get; set; } = string.Empty;

        public virtual ICollection<PaymentInfo> PaymentInfos { get; set; }
    }
}
