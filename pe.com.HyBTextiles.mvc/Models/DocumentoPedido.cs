using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pe.com.HyBTextiles.mvc.Models
{
    public class DocumentoPedido
    {
        public int codigo { get; set; }
        public int codPedido { get; set; }
        public int codTipoDocumento { get; set; }
        public string numero { get; set; }
        public string fecha { get; set; }
        public bool estado { get; set; }
    }
}