using System;
using System.Runtime.Serialization;

namespace LAP.ENTITIES
{
    [DataContract]
    public class BaseEntity : Entity
    {
        public DateTimeOffset? DtCreateTime { get; set; }
        public DateTimeOffset? DtUpdateTime { get; set; }
        [DataMember]
        public int InStatus { get; set; }
    }
}
