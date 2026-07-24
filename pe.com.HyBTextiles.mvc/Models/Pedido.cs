using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace pe.com.HyBTextiles.mvc.Models
{
    [Table("pedido")]
    public class Pedido
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Código")]
        [Column("codped")]
        public int codped { get; set; }

        [Required]
        [Display(Name = "Fecha Pedido")]
        [Column("fecped")]
        public DateTime fecped { get; set; }

        [Required]
        [Display(Name = "Cliente")]
        [Column("codcli")]
        public int codcli { get; set; }

        [Required]
        [Display(Name = "Estado")]
        [Column("codest")]
        public int codest { get; set; }

        [Required]
        [Display(Name = "Usuario")]
        [Column("codusu")]
        public int codusu { get; set; }

        [Required]
        [Display(Name = "Moneda")]
        [Column("codmon")]
        public int codmon { get; set; }

        [Required]
        [Display(Name = "Total Pedido")]
        [Column("totped")]
        public decimal totped { get; set; }

        [Required]
        [Display(Name = "Estado")]
        [Column("estped")]
        public bool estped { get; set; }

        // Relaciones
        public virtual Cliente Cliente { get; set; }
        public virtual EstadoPedido EstadoPedido { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual Moneda Moneda { get; set; }
    }
}