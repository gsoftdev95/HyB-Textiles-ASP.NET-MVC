using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace pe.com.HyBTextiles.mvc.Models
{
    [Table("almacen")]
    public class Almacen
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Código")]
        [Column("codalm")]
        public int codalm { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Nombre Almacén")]
        [Column("nomalm")]
        public string nomalm { get; set; }

        [StringLength(200)]
        [Display(Name = "Dirección")]
        [Column("diralm")]
        public string diralm { get; set; }

        [Required]
        [Display(Name = "Estado")]
        [Column("estalm")]
        public bool estalm { get; set; }
    }
}