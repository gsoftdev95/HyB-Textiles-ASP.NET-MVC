using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace pe.com.HyBTextiles.mvc.Models
{
    [Table("operario")]
    public class Operario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Código")]
        [Column("codope")]
        public int codope { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Nombre Operario")]
        [Column("nomope")]
        public string nomope { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "Documento")]
        [Column("docope")]
        public string docope { get; set; }

        [StringLength(20)]
        [Display(Name = "Teléfono")]
        [Column("telope")]
        public string telope { get; set; }

        [Required]
        [Display(Name = "Estado")]
        [Column("estope")]
        public bool estope { get; set; }
    }
}