using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace LAP.ENTITIES
{
    [DataContract]
    [Table("User")]
    public class User
    {
        [Key]
        [DataMember]
        public int InUserId { get; set; }

        [DataMember]
        public string StUserName { get; set; }

        [DataMember]
        public string StEmail { get; set; }

        [DataMember]
        public int InStatus { get; set; }

        [DataMember]
        public string StDescription { get; set; }
    }
}
