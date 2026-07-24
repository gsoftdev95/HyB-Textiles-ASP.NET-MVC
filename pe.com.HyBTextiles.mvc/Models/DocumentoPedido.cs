using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace pe.com.HyBTextiles.mvc.Models
{
    [Table("documentopedido")]
    public class DocumentoPedido
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Código")]
        [Column("coddoc")]
        public int coddoc { get; set; }


        [Required]
        [Display(Name = "Pedido")]
        [Column("codped")]
        public int codped { get; set; }


        [Required]
        [Display(Name = "Tipo Documento")]
        [Column("codtdo")]
        public int codtdo { get; set; }


        [Required]
        [StringLength(30)]
        [Display(Name = "Número Documento")]
        [Column("numdoc")]
        public string numdoc { get; set; }


        [Required]
        [Display(Name = "Fecha Documento")]
        [Column("fecdoc")]
        public DateTime fecdoc { get; set; }


        [Required]
        [Display(Name = "Estado")]
        [Column("estdoc")]
        public bool estdoc { get; set; }



        // Relaciones

        public virtual Pedido Pedido { get; set; }

        public virtual TipoDocumento TipoDocumento { get; set; }
    }
}