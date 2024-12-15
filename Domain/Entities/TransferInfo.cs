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
        public TransferInfo()
        {
            TransferTypes = new HashSet<TransferType>();
            FromCountries = new HashSet<Country>();
            ToCountries = new HashSet<Country>();
            Currencies = new HashSet<Currency>();
            TransferStatuses = new HashSet<TransferStatus>();
        }

        public byte TransferTypeId { get; set; }
        public byte FromCountryId { get; set; }
        public byte ToCountryId { get; set; }
        public byte CurrencyId { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransferDate { get; set; }
        public byte TransferStatusId { get; set; }
        public string Description { get; set; } = string.Empty;

        public virtual ICollection<TransferType> TransferTypes { get; set; }
        public virtual ICollection<Country> FromCountries { get; set; }
        public virtual ICollection<Country> ToCountries { get; set; }
        public virtual ICollection<Currency> Currencies { get; set; }
        public virtual ICollection<TransferStatus> TransferStatuses { get; set; } 
    }
}
