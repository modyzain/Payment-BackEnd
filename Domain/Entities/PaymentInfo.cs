using Domain.Entities.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class PaymentInfo : IntBaseEntity
    {
        public PaymentInfo()
        {
            Currencies = new HashSet<Currency>();
            PaymentTypes = new HashSet<PaymentType>();
            PaymentStatuses = new HashSet<PaymentStatus>();
            FileInfos = new HashSet<FileInfo>();
        }

        public byte CurrencyId { get; set; }
        public byte PaymentTypeId { get; set; }
        public byte PaymentStatusId { get; set; }
        public long FileId { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }
        public string PayedFrom { get; set; } = string.Empty;
        public string PayedTo { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public virtual ICollection<Currency> Currencies { get; set; }
        public virtual ICollection<PaymentType> PaymentTypes { get; set; }
        public virtual ICollection<PaymentStatus> PaymentStatuses { get; set; }
        public  virtual ICollection<FileInfo> FileInfos { get; set; }

    }
}
