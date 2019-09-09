using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LAP.ENTITIES
{
   public class Order
    {
        [Key]
        public int InOrderId { get; set; }
        [ForeignKey("Customer")]
        public int InCustomerId { get; set; }
        public string StProductName { get; set; }
        public float FlQuantity { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
