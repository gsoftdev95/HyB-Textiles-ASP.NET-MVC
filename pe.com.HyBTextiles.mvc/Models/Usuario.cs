using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace pe.com.HyBTextiles.mvc.Models
{
    [Table("usuario")]
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Código")]
        [Column("codusu")]
        public int codusu { get; set; }


        [Required]
        [StringLength(100)]
        [Display(Name = "Nombre Usuario")]
        [Column("nomusu")]
        public string nomusu { get; set; }


        [Required]
        [StringLength(50)]
        [Display(Name = "Usuario")]
        [Column("userusu")]
        public string userusu { get; set; }


        [Required]
        [StringLength(200)]
        [Display(Name = "Clave")]
        [Column("claveusu")]
        public string claveusu { get; set; }


        [Required]
        [Display(Name = "Código Rol")]
        [Column("codrol")]
        public int codrol { get; set; }


        [Required]
        [Display(Name = "Estado")]
        [Column("estusu")]
        public bool estusu { get; set; }


        // Relación
        public virtual Rol Rol { get; set; }
    }
}