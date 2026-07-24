using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace pe.com.HyBTextiles.mvc.Models
{
    [Table("tipotejido")]
    public class TipoTejido
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Código")]
        [Column("codtte")]
        public int codtte { get; set; }


        [Required]
        [StringLength(100)]
        [Display(Name = "Nombre")]
        [Column("nomtte")]
        public string nomtte { get; set; }


        [StringLength(200)]
        [Display(Name = "Descripción")]
        [Column("desctte")]
        public string desctte { get; set; }


        [Required]
        [Display(Name = "Estado")]
        [Column("esttte")]
        public bool esttte { get; set; }
    }
}