using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrestamosPersonales
{
    public abstract class Prestamo
    {
        //ATRIBUTOS
        protected float _monto;
        protected DateTime _vencimiento;


        //PROPIEDADES
        public float Monto
        {
            get { return _monto; }
        }
        
        public DateTime Vencimiento
        {
            get { return _vencimiento; }
            set
            {
                if(value > DateTime.Now)
                {
                    this._vencimiento = value;
                }
                else
                {
                    this._vencimiento = DateTime.Now;
                }                
            }
        }


        //CONSTRUCTORES
        public Prestamo(float monto, DateTime vencimiento)
        {
            this._monto = monto;
            this._vencimiento = vencimiento;
        }


        //METODOS
        public virtual string Mostrar()
        {
            return "Monto: " + this._monto.ToString() + " - Vencimiento: " + this._vencimiento.ToString();
        }

        public static int OrdenarPorFecha(Prestamo p1, Prestamo p2)
        {
            return DateTime.Compare(p1._vencimiento, p2._vencimiento);
        }

        public abstract void ExtenderPlazo(DateTime nuevoVencimiento);

    }

    //ENUMERADOS
    public enum TipoDePrestamos
    {
        Pesos,
        Dolares, 
        Todos
    }

    public enum PeriodicidadDePago
    {
        Mensual,
        Bimestral,
        Trimestral
    }

}
