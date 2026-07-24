using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace pe.com.HyBTextiles.mvc.Models
{
    [Table("estadopedido")]
    public class EstadoPedido
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Código")]
        [Column("codest")]
        public int codest { get; set; }


        [Required]
        [StringLength(50)]
        [Display(Name = "Estado Pedido")]
        [Column("nomest")]
        public string nomest { get; set; }


        [Required]
        [Display(Name = "Estado")]
        [Column("estest")]
        public bool estest { get; set; }
    }
}