using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace pe.com.HyBTextiles.mvc.Models
{
    [Table("mantenimientomaquina")]
    public class MantenimientoMaquina
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Código")]
        [Column("codmnt")]
        public int codmnt { get; set; }

        [Required]
        [Display(Name = "Máquina")]
        [Column("codmaq")]
        public int codmaq { get; set; }

        [Required]
        [Display(Name = "Fecha Mantenimiento")]
        [Column("fecmnt")]
        public DateTime fecmnt { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "Descripción")]
        [Column("descmnt")]
        public string descmnt { get; set; }

        [Display(Name = "Costo")]
        [Column("costmnt")]
        public decimal? costmnt { get; set; }

        [Required]
        [Display(Name = "Estado")]
        [Column("estmnt")]
        public bool estmnt { get; set; }

        // Relación
        public virtual Maquina Maquina { get; set; }
    }
}