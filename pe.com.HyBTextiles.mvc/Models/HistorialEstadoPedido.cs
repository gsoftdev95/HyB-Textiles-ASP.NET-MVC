using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pe.com.HyBTextiles.mvc.Models
{
    public class HistorialEstadoPedido
    {
        public int codigo { get; set; }
        public int codPedido { get; set; }
        public int codEstado { get; set; }
        public string fecha { get; set; }
        public bool estado { get; set; }
    }
}