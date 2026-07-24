using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace pe.com.HyBTextiles.mvc.Models
{
    [Table("entrega")]
    public class Entrega
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Código")]
        [Column("codent")]
        public int codent { get; set; }

        [Required]
        [Display(Name = "Fecha Entrega")]
        [Column("fecent")]
        public DateTime fecent { get; set; }

        [Required]
        [Display(Name = "Pedido")]
        [Column("codped")]
        public int codped { get; set; }

        [StringLength(150)]
        [Display(Name = "Responsable Entrega")]
        [Column("respent")]
        public string respent { get; set; }

        [Required]
        [Display(Name = "Estado")]
        [Column("estent")]
        public bool estent { get; set; }


        // Relación
        public virtual Pedido Pedido { get; set; }
    }
}