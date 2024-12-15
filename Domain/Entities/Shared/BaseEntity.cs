using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Shared
{
    public class LongBaseEntity : DeletedEntity
    {
        public long Id { get; set; }
    }

    public class IntBaseEntity : DeletedEntity
    {
        public int Id { get; set; }
    }

    public class TinyBaseEntity : DeletedEntity
    {
        public byte Id { get; set; }
    }
}
