using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pe.com.HyBTextiles.mvc.Models
{
    public class MantenimientoMaquina
    {
        public int codigo { get; set; }
        public int codMaquina { get; set; }
        public string fecha { get; set; }
        public string descripcion { get; set; }
        public decimal? costo { get; set; }
        public bool estado { get; set; }
    }
}