using proyecto_Practica01_.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_Practica01_.Repositories.Implementations
{
    public class FormasDePagoRepository : IFormasDePago

    {
        public List<FormasDePagoRepository> GetAll()
        {
            DataTable dt = DataHelper
                .GetInstance()
                .ExecuteSPQuery("Obtener tipos de forma de pago", null);
            var tiposFormaDePago = new List<FormasDePagoRepository>();

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    var tipoFormaPago = new FormasDePagoRepository();
                    {
                        Id = (int) row["Id"],
                            Nombre = row["Nombre"].ToString()
                    };
                    tipoFormaPago.Add(tipoFormaPago);
                }
            }
            return tiposFormaDePago;
        }
    }

    public interface IFormasDePago
    {
    }
}
