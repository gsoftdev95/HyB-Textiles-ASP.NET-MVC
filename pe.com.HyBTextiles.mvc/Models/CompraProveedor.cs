using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pe.com.HyBTextiles.mvc.Models
{
    public class CompraProveedor
    {
        public int codigo { get; set; }
        public string fecha { get; set; }
        public int codProveedor { get; set; }
        public int codMoneda { get; set; }
        public int codUsuario { get; set; }
        public decimal total { get; set; }
        public bool estado { get; set; }
    }
}