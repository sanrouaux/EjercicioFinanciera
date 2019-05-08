using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrestamosPersonales
{
    public class PrestamosDolar : Prestamo
    {
        private PeriodicidadDePago _periodicidad;


        public float Interes
        {
            get
            {
                return this.CalcularInteres();
            }
        }


        public PeriodicidadDePago Periodicidad
        {
            get { return _periodicidad; }
        }

        public PrestamosDolar(float monto, DateTime vencimiento, PeriodicidadDePago periodicidad) : base(monto, vencimiento)
        {
            this._periodicidad = periodicidad;
        }

        public PrestamosDolar(Prestamo prestamo, PeriodicidadDePago periodicidad) : this(prestamo.Monto, prestamo.Vencimiento, periodicidad)
        {

        }

        private float CalcularInteres()
        {
            if(this._periodicidad == PeriodicidadDePago.Mensual)
            {
                return this._monto * (float)0.25;
            }
            else if(this._periodicidad == PeriodicidadDePago.Bimestral)
            {
                return this._monto * (float)0.35;
            }
            else 
            {
                return this._monto * (float)0.4;
            }
        }

        public override void ExtenderPlazo(DateTime nuevoVencimiento)
        {
            this._monto += ((nuevoVencimiento - this.Vencimiento).Days) * (float)2.5;
            base._vencimiento = nuevoVencimiento;
        }

        public override string Mostrar()
        {
            return base.Mostrar() + " - Periodicidad: " + this._periodicidad.ToString() + " - Interes: " + this.Interes.ToString() + "\n";
        }

    }
}
