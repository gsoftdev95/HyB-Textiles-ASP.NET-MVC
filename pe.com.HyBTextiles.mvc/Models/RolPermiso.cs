using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace pe.com.HyBTextiles.mvc.Models
{
    [Table("rolpermiso")]
    public class RolPermiso
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Código")]
        [Column("codrolper")]
        public int codrolper { get; set; }


        [Required]
        [Display(Name = "Código Rol")]
        [Column("codrol")]
        public int codrol { get; set; }


        [Required]
        [Display(Name = "Código Permiso")]
        [Column("codper")]
        public int codper { get; set; }


        [Required]
        [Display(Name = "Estado")]
        [Column("estrolper")]
        public bool estrolper { get; set; }


        // Relaciones
        public virtual Rol Rol { get; set; }

        public virtual Permiso Permiso { get; set; }
    }
}