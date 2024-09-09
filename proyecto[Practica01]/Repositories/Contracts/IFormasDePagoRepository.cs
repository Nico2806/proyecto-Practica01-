using proyecto_Practica01_.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_Practica01_.Repositories.Contracts
{
    internal interface IFormasDePagoRepository
    {
       
        List<FormasDePagoRepository> GetAll();
    }
}
