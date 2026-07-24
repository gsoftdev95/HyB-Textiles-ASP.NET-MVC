using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pe.com.HyBTextiles.mvc.Models
{
    public class AsistenciaOperario
    {
        public int codigo { get; set; }
        public int codOperario { get; set; }
        public int codTurno { get; set; }
        public string fecha { get; set; }
        public string horaIngreso { get; set; }
        public string horaSalida { get; set; }
        public bool estado { get; set; }
    }
}