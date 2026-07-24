using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pe.com.HyBTextiles.mvc.Models
{
    public class CobranzaPedido
    {
        public int codigo { get; set; }
        public string fecha { get; set; }
        public int codPedido { get; set; }
        public int codMoneda { get; set; }
        public decimal monto { get; set; }
        public bool estado { get; set; }
    }
}