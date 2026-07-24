using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pe.com.HyBTextiles.mvc.Models
{
    public class Proveedor
    {
        public int codigo { get; set; }
        public string ruc { get; set; }
        public string razonSocial { get; set; }
        public string nombreContacto { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }
        public string direccion { get; set; }
        public bool estado { get; set; }
    }
}