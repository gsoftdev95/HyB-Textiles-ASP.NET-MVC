using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pe.com.HyBTextiles.mvc.Models
{
    public class RolPermiso
    {
        public int codigo { get; set; }
        public int codRol { get; set; }
        public int codPermiso { get; set; }
        public bool estado { get; set; }
    }
}