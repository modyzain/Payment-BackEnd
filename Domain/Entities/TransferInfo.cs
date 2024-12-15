using Domain.Entities.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class TransferInfo : IntBaseEntity
    {
        public byte TransferTypeId { get; set; }
        public byte FromCountryId { get; set; }
        public byte ToCountryId { get; set; }
        public byte CurrencyId { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransferDate { get; set; }
        public byte TransferStatusId { get; set; }
        public string Description { get; set; } = string.Empty;

        public virtual required TransferType TransferType { get; set; }
        public virtual required Country FromCountry { get; set; }
        public virtual required Country ToCountry  { get; set; }
        public virtual required Currency Currency { get; set; }
        public virtual required TransferStatus TransferStatus { get; set; } 
    }
}
