using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace pe.com.HyBTextiles.mvc.Models
{
    [Table("maquina")]
    public class Maquina
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Código")]
        [Column("codmaq")]
        public int codmaq { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Nombre Máquina")]
        [Column("nommaq")]
        public string nommaq { get; set; }

        [Display(Name = "Capacidad")]
        [Column("capmaq")]
        public decimal? capmaq { get; set; }

        [Required]
        [Display(Name = "Estado")]
        [Column("estmaq")]
        public bool estmaq { get; set; }
    }
}