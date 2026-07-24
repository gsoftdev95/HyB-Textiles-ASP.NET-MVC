using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace pe.com.HyBTextiles.mvc.Models
{
    [Table("pagoproveedor")]
    public class PagoProveedor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Código")]
        [Column("codpgp")]
        public int codpgp { get; set; }

        [Required]
        [Display(Name = "Fecha Pago")]
        [Column("fecpgp")]
        public DateTime fecpgp { get; set; }

        [Required]
        [Display(Name = "Compra")]
        [Column("codcom")]
        public int codcom { get; set; }

        [Required]
        [Display(Name = "Moneda")]
        [Column("codmon")]
        public int codmon { get; set; }

        [Required]
        [Display(Name = "Monto Pago")]
        [Column("montopgp")]
        public decimal montopgp { get; set; }

        [Required]
        [Display(Name = "Estado")]
        [Column("estpgp")]
        public bool estpgp { get; set; }


        // Relaciones
        public virtual CompraProveedor CompraProveedor { get; set; }
        public virtual Moneda Moneda { get; set; }
    }
}