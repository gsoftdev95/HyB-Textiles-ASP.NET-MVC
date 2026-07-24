using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pe.com.HyBTextiles.mvc.Models
{
    public class Produccion
    {
        public int codigo { get; set; }
        public string fecha { get; set; }
        public int codMaquina { get; set; }
        public int codOperario { get; set; }
        public int codTipoTejido { get; set; }
        public int codPedido { get; set; }
        public decimal cantidad { get; set; }
        public bool estado { get; set; }
    }
}