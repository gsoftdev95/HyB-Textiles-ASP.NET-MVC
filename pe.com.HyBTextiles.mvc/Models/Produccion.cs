using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace pe.com.HyBTextiles.mvc.Models
{
    [Table("produccion")]
    public class Produccion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Código")]
        [Column("codpro")]
        public int codpro { get; set; }

        [Required]
        [Display(Name = "Fecha Producción")]
        [Column("fecpro")]
        public DateTime fecpro { get; set; }

        [Required]
        [Display(Name = "Máquina")]
        [Column("codmaq")]
        public int codmaq { get; set; }

        [Required]
        [Display(Name = "Operario")]
        [Column("codope")]
        public int codope { get; set; }

        [Required]
        [Display(Name = "Tipo Tejido")]
        [Column("codtte")]
        public int codtte { get; set; }

        [Required]
        [Display(Name = "Pedido")]
        [Column("codped")]
        public int codped { get; set; }

        [Required]
        [Display(Name = "Cantidad Producida")]
        [Column("canpro")]
        public decimal canpro { get; set; }

        [Required]
        [Display(Name = "Estado")]
        [Column("estpro")]
        public bool estpro { get; set; }


        // Relaciones
        public virtual Maquina Maquina { get; set; }
        public virtual Operario Operario { get; set; }
        public virtual TipoTejido TipoTejido { get; set; }
        public virtual Pedido Pedido { get; set; }
    }
}