using Domain.Entities.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class FileInfo : LongBaseEntity
    {
        public string FilePath { get; set; } = string.Empty;
        public string FileName { get; set; } = string.Empty;
        public int FileSize { get; set; }

        public virtual required PaymentInfo PaymentInfo { get; set; }
    }
}
