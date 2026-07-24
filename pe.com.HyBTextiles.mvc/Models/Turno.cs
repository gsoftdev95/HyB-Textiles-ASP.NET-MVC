using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pe.com.HyBTextiles.mvc.Models
{
    public class Turno
    {
        public int codigo { get; set; }
        public string nombre { get; set; }
        public TimeSpan horaInicio { get; set; }
        public TimeSpan horaFin { get; set; }
        public bool estado { get; set; }
    }
}