using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace pe.com.HyBTextiles.mvc.Models
{
    [Table("unidadmedida")]
    public class UnidadMedida
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Código")]
        [Column("codund")]
        public int codund { get; set; }


        [Required]
        [StringLength(30)]
        [Display(Name = "Nombre Unidad")]
        [Column("nomund")]
        public string nomund { get; set; }


        [Required]
        [StringLength(10)]
        [Display(Name = "Abreviatura")]
        [Column("abrund")]
        public string abrund { get; set; }


        [Required]
        [Display(Name = "Estado")]
        [Column("estund")]
        public bool estund { get; set; }
    }
}