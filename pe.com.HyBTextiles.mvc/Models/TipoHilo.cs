using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace pe.com.HyBTextiles.mvc.Models
{
    [Table("tipohilo")]
    public class TipoHilo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Código")]
        [Column("codthi")]
        public int codthi { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Nombre")]
        [Column("nomthi")]
        public string nomthi { get; set; }

        [StringLength(200)]
        [Display(Name = "Descripción")]
        [Column("descthi")]
        public string descthi { get; set; }

        [Required]
        [Display(Name = "Estado")]
        [Column("estthi")]
        public bool estthi { get; set; }
    }
}