using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace pe.com.HyBTextiles.mvc.Models
{
    [Table("tipodocumento")]
    public class TipoDocumento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Código")]
        [Column("codtdo")]
        public int codtdo { get; set; }


        [Required]
        [StringLength(50)]
        [Display(Name = "Nombre Documento")]
        [Column("nomtdo")]
        public string nomtdo { get; set; }


        [Required]
        [Display(Name = "Estado")]
        [Column("esttdo")]
        public bool esttdo { get; set; }
    }
}