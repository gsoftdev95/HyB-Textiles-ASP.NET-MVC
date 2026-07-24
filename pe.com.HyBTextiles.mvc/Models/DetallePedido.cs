using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pe.com.HyBTextiles.mvc.Models
{
    public class DetallePedido
    {
        public int codigo { get; set; }
        public int codPedido { get; set; }
        public int codTipoTejido { get; set; }
        public int codUnidad { get; set; }
        public decimal cantidad { get; set; }
        public decimal precio { get; set; }
        public bool estado { get; set; }
    }
}