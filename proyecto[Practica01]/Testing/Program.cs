// See https://aka.ms/new-console-template for more information


using proyecto_Practica01_.Entities;
using proyecto_Practica01_.Services;

FacturaManager serviceManager = new FacturaManager();


Console.WriteLine("Formas de pago:");
var formasDePago = serviceManager.GetAllFormasPago();


var nuevaFactura = new Factura
{
    NroFactura = 2505,
    Fecha = DateTime.Now,
    FormaPago = formasDePago[0],

}


