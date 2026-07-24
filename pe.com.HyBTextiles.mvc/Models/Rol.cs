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
        [Column("codigo")]
        public int codrol { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Nombre")]
        [Column("nombre")]
        public string nomrol { get; set; }

        [Required]
        [Display(Name = "Estado")]
        [Column("estado")]
        public bool estrol { get; set; }
    }
}