using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace pe.com.HyBTextiles.mvc.Models
{
    [Table("detallecompraproveedor")]
    public class DetalleCompraProveedor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Código")]
        [Column("coddco")]
        public int coddco { get; set; }

        [Required]
        [Display(Name = "Compra")]
        [Column("codcom")]
        public int codcom { get; set; }

        [Required]
        [Display(Name = "Tipo Hilo")]
        [Column("codthi")]
        public int codthi { get; set; }

        [Required]
        [Display(Name = "Unidad")]
        [Column("codund")]
        public int codund { get; set; }

        [Required]
        [Display(Name = "Cantidad")]
        [Column("candco")]
        public decimal candco { get; set; }

        [Required]
        [Display(Name = "Precio")]
        [Column("preciodco")]
        public decimal preciodco { get; set; }

        [Required]
        [Display(Name = "Estado")]
        [Column("estdco")]
        public bool estdco { get; set; }

        // Relaciones
        public virtual CompraProveedor CompraProveedor { get; set; }
        public virtual TipoHilo TipoHilo { get; set; }
        public virtual UnidadMedida UnidadMedida { get; set; }
    }
}