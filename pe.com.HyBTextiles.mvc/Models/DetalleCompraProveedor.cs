using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pe.com.HyBTextiles.mvc.Models
{
    public class DetalleCompraProveedor
    {
        public int codigo { get; set; }
        public int codCompra { get; set; }
        public int codTipoHilo { get; set; }
        public int codUnidad { get; set; }
        public decimal cantidad { get; set; }
        public decimal precio { get; set; }
        public bool estado { get; set; }
    }
}