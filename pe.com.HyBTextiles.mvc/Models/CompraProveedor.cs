using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace pe.com.HyBTextiles.mvc.Models
{
    [Table("compraproveedor")]
    public class CompraProveedor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Código")]
        [Column("codcom")]
        public int codcom { get; set; }

        [Required]
        [Display(Name = "Fecha Compra")]
        [Column("feccom")]
        public DateTime feccom { get; set; }

        [Required]
        [Display(Name = "Proveedor")]
        [Column("codprv")]
        public int codprv { get; set; }

        [Required]
        [Display(Name = "Moneda")]
        [Column("codmon")]
        public int codmon { get; set; }

        [Required]
        [Display(Name = "Usuario")]
        [Column("codusu")]
        public int codusu { get; set; }

        [Required]
        [Display(Name = "Total Compra")]
        [Column("totcom")]
        public decimal totcom { get; set; }

        [Required]
        [Display(Name = "Estado")]
        [Column("estcom")]
        public bool estcom { get; set; }


        // Relaciones
        public virtual Proveedor Proveedor { get; set; }
        public virtual Moneda Moneda { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}