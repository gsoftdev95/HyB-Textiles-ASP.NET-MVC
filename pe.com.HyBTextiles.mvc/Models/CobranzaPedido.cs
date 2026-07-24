using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace pe.com.HyBTextiles.mvc.Models
{
    [Table("cobranzapedido")]
    public class CobranzaPedido
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Código")]
        [Column("codcob")]
        public int codcob { get; set; }

        [Required]
        [Display(Name = "Fecha Cobranza")]
        [Column("feccob")]
        public DateTime feccob { get; set; }

        [Required]
        [Display(Name = "Pedido")]
        [Column("codped")]
        public int codped { get; set; }

        [Required]
        [Display(Name = "Moneda")]
        [Column("codmon")]
        public int codmon { get; set; }

        [Required]
        [Display(Name = "Monto Cobrado")]
        [Column("montocob")]
        public decimal montocob { get; set; }

        [Required]
        [Display(Name = "Estado")]
        [Column("estcob")]
        public bool estcob { get; set; }


        // Relaciones
        public virtual Pedido Pedido { get; set; }
        public virtual Moneda Moneda { get; set; }
    }
}