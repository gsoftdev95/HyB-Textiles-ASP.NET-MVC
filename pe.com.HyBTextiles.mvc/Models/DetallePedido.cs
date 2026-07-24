using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace pe.com.HyBTextiles.mvc.Models
{
    [Table("detallepedido")]
    public class DetallePedido
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Código")]
        [Column("coddet")]
        public int coddet { get; set; }

        [Required]
        [Display(Name = "Pedido")]
        [Column("codped")]
        public int codped { get; set; }

        [Required]
        [Display(Name = "Tipo Tejido")]
        [Column("codtte")]
        public int codtte { get; set; }

        [Required]
        [Display(Name = "Unidad Medida")]
        [Column("codund")]
        public int codund { get; set; }

        [Required]
        [Display(Name = "Cantidad")]
        [Column("candet")]
        public decimal candet { get; set; }

        [Required]
        [Display(Name = "Precio")]
        [Column("preciodet")]
        public decimal preciodet { get; set; }

        [Required]
        [Display(Name = "Estado")]
        [Column("estdet")]
        public bool estdet { get; set; }


        // Relaciones
        public virtual Pedido Pedido { get; set; }
        public virtual TipoTejido TipoTejido { get; set; }
        public virtual UnidadMedida UnidadMedida { get; set; }
    }
}