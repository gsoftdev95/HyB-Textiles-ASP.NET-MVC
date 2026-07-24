using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace pe.com.HyBTextiles.mvc.Models
{
    [Table("salidahilo")]
    public class SalidaHilo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Código")]
        [Column("codsal")]
        public int codsal { get; set; }

        [Required]
        [Display(Name = "Fecha Salida")]
        [Column("fecsal")]
        public DateTime fecsal { get; set; }

        [Required]
        [Display(Name = "Producción")]
        [Column("codpro")]
        public int codpro { get; set; }

        [Required]
        [Display(Name = "Tipo Hilo")]
        [Column("codthi")]
        public int codthi { get; set; }

        [Required]
        [Display(Name = "Unidad Medida")]
        [Column("codund")]
        public int codund { get; set; }

        [Required]
        [Display(Name = "Cantidad Salida")]
        [Column("cansal")]
        public decimal cansal { get; set; }

        [Required]
        [Display(Name = "Estado")]
        [Column("estsal")]
        public bool estsal { get; set; }


        // Relaciones
        public virtual Produccion Produccion { get; set; }
        public virtual TipoHilo TipoHilo { get; set; }
        public virtual UnidadMedida UnidadMedida { get; set; }
    }
}