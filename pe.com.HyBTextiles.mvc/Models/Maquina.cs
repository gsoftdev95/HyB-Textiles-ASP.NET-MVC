using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pe.com.HyBTextiles.mvc.Models
{
    public class Maquina
    {
        public int codigo { get; set; }
        public string nombre { get; set; }
        public decimal capacidad { get; set; }
        public bool estado { get; set; }
    }
}