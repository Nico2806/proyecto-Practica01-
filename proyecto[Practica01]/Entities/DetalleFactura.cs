using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_Practica01_.Entities
{
    public class DetalleFactura
    {
        public int Id { get; set; }

        public Articulo Articulo { get; set; }

        public int Cantidad { get; set; }

        public Factura  Factura { get; set; }



    }
}
