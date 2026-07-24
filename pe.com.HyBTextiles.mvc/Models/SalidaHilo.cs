using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pe.com.HyBTextiles.mvc.Models
{
    public class SalidaHilo
    {
        public int codigo { get; set; }
        public string fecha { get; set; }
        public int codProduccion { get; set; }
        public int codTipoHilo { get; set; }
        public int codUnidad { get; set; }
        public decimal cantidad { get; set; }
        public bool estado { get; set; }
    }
}