using proyecto_Practica01_.Entities;
using proyecto_Practica01_.Repositories.Contracts;
using proyecto_Practica01_.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_Practica01_.Repositories.Implementations
{
    public class FacturaRepository : IFacturaRepository
    {
        public bool Add(Factura factura)
        {
            var parametros = new List<ParameterSQL>
            {
                new ParameterSQL("NroFactura", factura.NroFactura),
                new ParameterSQL("@Fecha", factura.Fecha),
                new ParameterSQL("FormaPagoID", factura.FormaPago),
                new ParameterSQL("Cliente_ID", factura.Cliente)
                

            };
            int filasAfectadas = DataHelper
                .GetInstance()
                .ExecuteSPIF("InsertarFactura", parametros);

            return filasAfectadas > 0;


         }

        public bool Delete(int nroFactura)
        {
            throw new NotImplementedException();
        }

        public List<Factura> Get()
        {
            throw new NotImplementedException();
        }

        public List<Factura> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Update(Factura factura)
        {
            throw new NotImplementedException();
        }
    }
}
