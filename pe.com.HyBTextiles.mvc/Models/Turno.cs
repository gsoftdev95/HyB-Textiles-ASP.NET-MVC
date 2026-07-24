using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace pe.com.HyBTextiles.mvc.Models
{
    [Table("turno")]
    public class Turno
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Código")]
        [Column("codtur")]
        public int codtur { get; set; }


        [Required]
        [StringLength(50)]
        [Display(Name = "Nombre Turno")]
        [Column("nomtur")]
        public string nomtur { get; set; }


        [Required]
        [Display(Name = "Hora Inicio")]
        [Column("horainitur")]
        public TimeSpan horainitur { get; set; }


        [Required]
        [Display(Name = "Hora Fin")]
        [Column("horafintur")]
        public TimeSpan horafintur { get; set; }


        [Required]
        [Display(Name = "Estado")]
        [Column("esttur")]
        public bool esttur { get; set; }
    }
}