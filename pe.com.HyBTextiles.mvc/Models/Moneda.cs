using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace pe.com.HyBTextiles.mvc.Models
{
    [Table("moneda")]
    public class Moneda
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Código")]
        [Column("codmon")]
        public int codmon { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "Nombre Moneda")]
        [Column("nommon")]
        public string nommon { get; set; }

        [Required]
        [StringLength(5)]
        [Display(Name = "Símbolo")]
        [Column("simbmon")]
        public string simbmon { get; set; }

        [Required]
        [Display(Name = "Estado")]
        [Column("estmon")]
        public bool estmon { get; set; }
    }
}