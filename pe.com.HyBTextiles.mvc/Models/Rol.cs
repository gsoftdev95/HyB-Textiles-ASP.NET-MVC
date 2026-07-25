using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace pe.com.HyBTextiles.mvc.Models
{
    [Table("rol")]
    public class Rol
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Código")]
        [Column("codrol")]
        public int codrol { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Nombre")]
        [Column("nomrol")]
        public string nomrol { get; set; }

        [Required]
        [Display(Name = "Estado")]
        [Column("estrol")]
        public bool estrol { get; set; }
    }
}