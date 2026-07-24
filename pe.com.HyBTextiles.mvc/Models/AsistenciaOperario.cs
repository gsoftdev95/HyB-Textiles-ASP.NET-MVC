using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace pe.com.HyBTextiles.mvc.Models
{
    [Table("asistenciaoperario")]
    public class AsistenciaOperario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Código")]
        [Column("codasi")]
        public int codasi { get; set; }

        [Required]
        [Display(Name = "Operario")]
        [Column("codope")]
        public int codope { get; set; }

        [Required]
        [Display(Name = "Turno")]
        [Column("codtur")]
        public int codtur { get; set; }

        [Required]
        [Display(Name = "Fecha Asistencia")]
        [Column("fecasi")]
        public DateTime fecasi { get; set; }

        [Display(Name = "Hora Ingreso")]
        [Column("horaingasi")]
        public TimeSpan? horaingasi { get; set; }

        [Display(Name = "Hora Salida")]
        [Column("horasaliasi")]
        public TimeSpan? horasaliasi { get; set; }

        [Required]
        [Display(Name = "Estado")]
        [Column("estasi")]
        public bool estasi { get; set; }


        // Relaciones
        public virtual Operario Operario { get; set; }
        public virtual Turno Turno { get; set; }
    }
}