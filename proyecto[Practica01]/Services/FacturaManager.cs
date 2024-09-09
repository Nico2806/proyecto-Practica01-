using proyecto_Practica01_.Entities;
using proyecto_Practica01_.Repositories.Contracts;
using proyecto_Practica01_.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_Practica01_.Services
{
    public class FacturaManager
    {
        IFacturaRepository facturaRepository;

        public FacturaManager()
        {
            facturaRepository = new FacturaRepository();
        }

        public List<Factura> GetAllFacturas()
        {
            return facturaRepository.GetAll();
        }

        public bool AddFactura (Factura factura)
        {
            return facturaRepository.Add(factura);
        }

        public List<FormaPago> GetAllFormasPago()
        {
            return formasDePagoRepository.GetAll();
        }


    }
}
