using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pe.com.HyBTextiles.mvc.Models
{
    public class Operario
    {
        public int codigo { get; set; }
        public string nombre { get; set; }
        public string documento { get; set; }
        public string telefono { get; set; }
        public bool estado { get; set; }
    }
}