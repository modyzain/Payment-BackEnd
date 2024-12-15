using Domain.Entities.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ProfileInfo : IntBaseEntity
    {
        public ProfileInfo()
        {
            PaymentLogs = new HashSet<PaymentLog>();
        }

        public string NameAr { get; set; } = string.Empty;
        public string NameEn { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string MobileNumber { get; set; } = string.Empty;
        public byte Status { get; set; }
        public byte Gender { get; set; }
        public bool IsVerified { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<PaymentLog> PaymentLogs { get; set; }
    }
}
