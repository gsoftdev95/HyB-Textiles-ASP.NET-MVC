using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace pe.com.HyBTextiles.mvc.Models
{
    [Table("ingresohilo")]
    public class IngresoHilo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Código")]
        [Column("coding")]
        public int coding { get; set; }

        [Required]
        [Display(Name = "Fecha Ingreso")]
        [Column("fecing")]
        public DateTime fecing { get; set; }

        [Required]
        [Display(Name = "Tipo Hilo")]
        [Column("codthi")]
        public int codthi { get; set; }

        [Required]
        [Display(Name = "Almacén")]
        [Column("codalm")]
        public int codalm { get; set; }

        [Required]
        [Display(Name = "Unidad Medida")]
        [Column("codund")]
        public int codund { get; set; }

        [Display(Name = "Compra")]
        [Column("codcom")]
        public int? codcom { get; set; }

        [Required]
        [Display(Name = "Cantidad Ingreso")]
        [Column("caning")]
        public decimal caning { get; set; }

        [Required]
        [Display(Name = "Estado")]
        [Column("esting")]
        public bool esting { get; set; }


        // Relaciones
        public virtual TipoHilo TipoHilo { get; set; }
        public virtual Almacen Almacen { get; set; }
        public virtual UnidadMedida UnidadMedida { get; set; }
        public virtual CompraProveedor CompraProveedor { get; set; }
    }
}