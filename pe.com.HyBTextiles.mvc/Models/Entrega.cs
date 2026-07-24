using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pe.com.HyBTextiles.mvc.Models
{
    public class Entrega
    {
        public int codigo { get; set; }
        public string fecha { get; set; }
        public int codPedido { get; set; }
        public string responsable { get; set; }
        public bool estado { get; set; }
    }
}