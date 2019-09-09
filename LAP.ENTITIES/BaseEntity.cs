using System;
using System.Collections.Generic;
using System.Text;

namespace LAP.ENTITIES
{
   public class BaseEntity
    {
        public DateTimeOffset? DtCreateTime { get; set; }
        public DateTimeOffset? DtUpdateTime { get; set; }
        public int InStatus { get; set; }
    }
}
