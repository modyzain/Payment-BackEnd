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
        public byte CurrencyId { get; set; }
        public byte PaymentTypeId { get; set; }
        public byte PaymentStatusId { get; set; }
        public long FileId { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }
        public string PayedFrom { get; set; } = string.Empty;
        public string PayedTo { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public virtual required Currency Currency { get; set; }
        public virtual required PaymentType PaymentType { get; set; }
        public virtual required PaymentStatus PaymentStatus { get; set; }
        public  virtual required FileInfo FileInfo { get; set; }

    }
}
