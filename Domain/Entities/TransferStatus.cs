using Domain.Entities.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class TransferStatus : TinyBaseEntity
    {
        public TransferStatus()
        {
            TransferInfos =  new HashSet<TransferInfo>();
        }

        public string NameAr { get; set; } = string.Empty;
        public string NameEn { get; set; } = string.Empty;

        public virtual ICollection<TransferInfo> TransferInfos { get; set; }
    }
}
