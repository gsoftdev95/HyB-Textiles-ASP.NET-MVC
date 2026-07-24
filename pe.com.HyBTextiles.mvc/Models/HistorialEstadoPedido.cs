using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace pe.com.HyBTextiles.mvc.Models
{
    [Table("historialestadopedido")]
    public class HistorialEstadoPedido
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Código")]
        [Column("codhis")]
        public int codhis { get; set; }

        [Required]
        [Display(Name = "Pedido")]
        [Column("codped")]
        public int codped { get; set; }

        [Required]
        [Display(Name = "Estado Pedido")]
        [Column("codest")]
        public int codest { get; set; }

        [Required]
        [Display(Name = "Usuario")]
        [Column("codusu")]
        public int codusu { get; set; }

        [Required]
        [Display(Name = "Fecha Historial")]
        [Column("fechis")]
        public DateTime fechis { get; set; }

        [Required]
        [Display(Name = "Estado")]
        [Column("esthis")]
        public bool esthis { get; set; }

        // Relaciones
        public virtual Pedido Pedido { get; set; }
        public virtual EstadoPedido EstadoPedido { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}