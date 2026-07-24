using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace pe.com.HyBTextiles.mvc.Models
{
    [Table("permiso")]
    public class Permiso
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Código")]
        [Column("codper")]
        public int codper { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Nombre Permiso")]
        [Column("nomper")]
        public string nomper { get; set; }

        [StringLength(200)]
        [Display(Name = "Descripción")]
        [Column("descper")]
        public string descper { get; set; }

        [Required]
        [Display(Name = "Estado")]
        [Column("estper")]
        public bool estper { get; set; }
    }
}