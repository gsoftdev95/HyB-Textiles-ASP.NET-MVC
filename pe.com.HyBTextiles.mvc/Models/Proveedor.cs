using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace pe.com.HyBTextiles.mvc.Models
{
    [Table("proveedor")]
    public class Proveedor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Código")]
        [Column("codprv")]
        public int codprv { get; set; }

        [Required]
        [StringLength(11)]
        [Display(Name = "RUC")]
        [Column("rucprv")]
        public string rucprv { get; set; }

        [Required]
        [StringLength(150)]
        [Display(Name = "Razón Social")]
        [Column("razonsocialprv")]
        public string razonsocialprv { get; set; }

        [StringLength(100)]
        [Display(Name = "Contacto")]
        [Column("nomcontactoprv")]
        public string nomcontactoprv { get; set; }

        [StringLength(20)]
        [Display(Name = "Teléfono")]
        [Column("telprv")]
        public string telprv { get; set; }

        [StringLength(100)]
        [EmailAddress]
        [Display(Name = "Email")]
        [Column("emaprv")]
        public string emaprv { get; set; }

        [StringLength(200)]
        [Display(Name = "Dirección")]
        [Column("dirprv")]
        public string dirprv { get; set; }

        [Required]
        [Display(Name = "Estado")]
        [Column("estprv")]
        public bool estprv { get; set; }
    }
}