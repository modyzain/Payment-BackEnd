using Domain.Entities.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Country : TinyBaseEntity
    {
        public string NameAr { get; set; } = string.Empty;
        public string NameEn { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;

        public virtual required TransferInfo FromTransferInfo { get; set; }
        public virtual required TransferInfo ToTransferInfo { get; set; }
    }
}
