using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace pe.com.HyBTextiles.mvc.Models
{
    [Table("cliente")]
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Código")]
        [Column("codcli")]
        public int codcli { get; set; }

        [Required]
        [StringLength(11)]
        [Display(Name = "RUC")]
        [Column("ruccli")]
        public string ruccli { get; set; }

        [Required]
        [StringLength(150)]
        [Display(Name = "Razón Social")]
        [Column("razonsocialcli")]
        public string razonsocialcli { get; set; }

        [StringLength(100)]
        [Display(Name = "Contacto")]
        [Column("nomcontactocli")]
        public string nomcontactocli { get; set; }

        [StringLength(20)]
        [Display(Name = "Teléfono")]
        [Column("telcli")]
        public string telcli { get; set; }

        [StringLength(100)]
        [EmailAddress]
        [Display(Name = "Email")]
        [Column("emacli")]
        public string emacli { get; set; }

        [StringLength(200)]
        [Display(Name = "Dirección")]
        [Column("dircli")]
        public string dircli { get; set; }

        [Required]
        [Display(Name = "Estado")]
        [Column("estcli")]
        public bool estcli { get; set; }
    }
}