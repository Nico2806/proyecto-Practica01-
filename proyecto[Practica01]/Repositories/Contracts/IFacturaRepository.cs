using proyecto_Practica01_.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_Practica01_.Repositories.Contracts
{
     interface IFacturaRepository
    {
        bool Add(Factura factura);
        List<Factura> Get();
        bool Update(Factura factura);
        bool Delete(int nroFactura);
        List<Factura> GetAll();
    }
}
