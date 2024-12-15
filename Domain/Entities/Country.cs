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
        public Country()
        {
            FromTransferInfos = new HashSet<TransferInfo>();
            ToTransferInfos = new HashSet<TransferInfo>();
        }

        public string NameAr { get; set; } = string.Empty;
        public string NameEn { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;

        public virtual ICollection<TransferInfo> FromTransferInfos { get; set; }
        public virtual ICollection<TransferInfo> ToTransferInfos { get; set; }
    }
}
