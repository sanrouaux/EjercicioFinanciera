using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadFinanciera;
using PrestamosPersonales;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Financiera financiera = new Financiera("Mi Financiera");

            PrestamosPersonales.PrestamosDolar pd1 = new PrestamosPersonales.PrestamosDolar(1500, new DateTime(2017, 11, 01), PrestamosPersonales.PeriodicidadDePago.Mensual);
            PrestamosPersonales.PrestamosDolar pd2 = new PrestamosPersonales.PrestamosDolar(2000, new DateTime(2017, 12, 05), PrestamosPersonales.PeriodicidadDePago.Bimestral);
            PrestamosPersonales.PrestamosDolar pd3 = new PrestamosPersonales.PrestamosDolar(2500, new DateTime(2018, 01, 01), PrestamosPersonales.PeriodicidadDePago.Trimestral);
            PrestamosPersonales.PrestamosPesos pp1 = new PrestamosPersonales.PrestamosPesos(8000, new DateTime(2018, 01, 01), 20);
            PrestamosPersonales.PrestamosPesos pp2 = new PrestamosPersonales.PrestamosPesos(7000, new DateTime(2001, 10, 01), 25);
            PrestamosPersonales.PrestamosPesos pp3 = new PrestamosPersonales.PrestamosPesos(5000, new DateTime(2017, 11, 20), 20);

            financiera = financiera + pd1; financiera = financiera + pd2;
            financiera = financiera + pd3; financiera = financiera + pd3; //Préstamo repetido
            financiera = financiera + pp1; financiera = financiera + pp2;
            financiera = financiera + pp3; financiera = financiera + pp3; //Préstamo repetido

            Console.WriteLine((String)financiera);
            pd1.ExtenderPlazo(new DateTime(2017, 12, 01));

            pp1.ExtenderPlazo(new DateTime(2018, 02, 01));
            financiera.OrdenarPrestamos();
            Console.WriteLine("\n ********************ORDENADOS POR FECHA**************************");
            Console.WriteLine(Financiera.Mostrar(financiera));
            Console.ReadKey();
        }
    }
}
