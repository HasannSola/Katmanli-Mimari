using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace LAP.ENTITIES
{
    [DataContract]
    public class Customer : BaseEntity
    {
        [Key]
        [DataMember]
        public int InCustomerId { get; set; }

        [Required(ErrorMessage = "Müşteri Isim alanı zorunlu")]
        [MaxLength(150, ErrorMessage = "Müşteri Isim alanı en fazla 150 karekter olabilir")]
        [DataMember]
        public string StName { get; set; }

        [DataMember]
        public float FlBalance { get; set; }

        [Required(ErrorMessage = "Açıklama alanı zorunlu")]
        [MaxLength(2000, ErrorMessage = "Açıklama alanı en fazla 2000 karekter olabilir")]
        [DataMember]
        public string StDescription { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
