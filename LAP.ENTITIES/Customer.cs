using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LAP.ENTITIES
{
   public class Customer
    {
        [Key]
        public int InCustomerId { get; set; }

        [Required(ErrorMessage = "Müşteri Isim alanı zorunlu")]
        [MaxLength(150, ErrorMessage = "Müşteri Isim alanı en fazla 150 karekter olabilir")]
        public string StName { get; set; }

        public float FlBalance { get; set; }

        [Required(ErrorMessage = "Açıklama alanı zorunlu")]
        [MaxLength(2000, ErrorMessage = "Açıklama alanı en fazla 2000 karekter olabilir")]
        public string StDescription { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
