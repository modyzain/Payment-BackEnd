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
        public string NameAr { get; set; } = string.Empty;
        public string NameEn { get; set; } = string.Empty;
        public string Shortcut { get; set; } = string.Empty;

        public virtual required TransferInfo TransferInfo { get; set; }
        public virtual required PaymentInfo PaymentInfo { get; set; }
    }
}
