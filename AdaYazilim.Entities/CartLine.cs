using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaYazilim.Entities
{
  public  class CartLine
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        [ForeignKey("Cart")]
        public int CartId { get; set; }
        public Cart Cart { get; set; }


        public double Price { get; set; }

        [StringLength(150)]
        public string Description { get; set; }

    }
}
