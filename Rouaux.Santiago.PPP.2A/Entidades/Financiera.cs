using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrestamosPersonales;

namespace EntidadFinanciera
{
    public class Financiera
    {
        //ATRIBUTOS
        private List<Prestamo> listaDePrestamos;
        private string razonSocial;


        //PROPIEDADES
        public float InteresesEnDolares
        {
            get { return this.CalcularInteresGanado(TipoDePrestamos.Dolares); }
        }

        public float InteresesEnPesos
        {
            get { return this.CalcularInteresGanado(TipoDePrestamos.Pesos); ; }
        }

        public float InteresesTotales
        {
            get { return this.CalcularInteresGanado(TipoDePrestamos.Todos); }
        }

        public List<Prestamo> ListaDePrestamos
        {
            get { return this.listaDePrestamos; }
        }

        public string RazonSocial
        {
            get { return this.razonSocial; }
        }


        //CONSTRUCTORES
        private Financiera()
        {
            this.listaDePrestamos = new List<Prestamo>();
        }

        public Financiera(string razonSocial) : this()
        {
            this.razonSocial = razonSocial;
        }
        
        
        //SOBRECARGA DE OPERADORES
        public static bool operator ==(Financiera financiera, Prestamo prestamo)
        {
            bool retorno = false;
            foreach(Prestamo p in financiera.ListaDePrestamos)
            {
                if(p == prestamo)
                {
                    retorno = true;
                }
            }
            return retorno;
        }

        public static bool operator !=(Financiera financiera, Prestamo prestamo)
        {
            return !(financiera == prestamo);
        }

        public static Financiera operator +(Financiera financiera, Prestamo prestamoNuevo)
        {
            if(financiera != prestamoNuevo)
            {
                financiera.ListaDePrestamos.Add(prestamoNuevo);                
            }
            return financiera;      
        }


        //CONVERSION EXPLICITA
        public static explicit operator string(Financiera financiera)
        {
            String retorno = financiera.razonSocial + "\n";
            retorno += "Intereses totales: " + financiera.InteresesTotales + "\n";
            retorno += "Intereses por prestamos en pesos: " + financiera.InteresesEnPesos + "\n";
            retorno += "Intereses por prestamos en dolares: " + financiera.InteresesEnDolares + "\n";
            financiera.OrdenarPrestamos();
            foreach(Prestamo p in financiera.ListaDePrestamos)
            {
                if(p is PrestamosPesos)
                {
                    retorno += ((PrestamosPesos)p).Mostrar();
                }
                else
                {
                    retorno += ((PrestamosDolar)p).Mostrar();
                }
            }
            return retorno;
        }


        //METODOS
        private float CalcularInteresGanado(TipoDePrestamos tipoPrestamos)
        {
            float sumaInteresesPesos = 0;
            float sumaInteresesDolares = 0;
            foreach (Prestamo prest in this.ListaDePrestamos)
            {
                if (prest is PrestamosDolar)
                {
                    sumaInteresesDolares += ((PrestamosDolar)prest).Interes;
                }
                else if (prest is PrestamosPesos)
                {
                    sumaInteresesPesos += ((PrestamosPesos)prest).Interes;
                }
            }
            if (tipoPrestamos == TipoDePrestamos.Dolares)
            {
                return sumaInteresesDolares;
            }
            else if (tipoPrestamos == TipoDePrestamos.Pesos)
            {
                return sumaInteresesPesos;
            }
            else
            {
                return sumaInteresesDolares + sumaInteresesPesos;
            }
        }


        public static string Mostrar(Financiera financiera)
        {
            return (string)financiera;
        }


        public void OrdenarPrestamos()
        {
            this.listaDePrestamos.Sort(Prestamo.OrdenarPorFecha);
        }
    }
}
