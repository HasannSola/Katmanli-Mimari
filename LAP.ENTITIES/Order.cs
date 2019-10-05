using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text;

namespace LAP.ENTITIES
{
    [DataContract]
   public class Order: BaseEntity
    {
        [Key]
        public int InOrderId { get; set; }
        [ForeignKey("Customer")]
        public int InCustomerId { get; set; }

        [Required(ErrorMessage = "Ürün alanı zorunlu")]
        [MaxLength(500, ErrorMessage = "Ürün alanı en fazla 500 karekter olabilir")]
        public string StProductName { get; set; }

        public float FlQuantity { get; set; }

        [Required(ErrorMessage = "Açıklama alanı zorunlu")]
        [MaxLength(2000, ErrorMessage = "Açıklama alanı en fazla 2000 karekter olabilir")]
        public string StDescription { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
