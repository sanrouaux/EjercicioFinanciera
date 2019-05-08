using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrestamosPersonales
{
    public class PrestamosPesos : Prestamo
    {
        private float _porcentajeInteres;

        public float Interes
        {
            get
            {
                return this.CalcularInteres();
            }
        }

        public PrestamosPesos(float monto, DateTime vencimiento, float interes) : base(monto, vencimiento)
        {
            this._porcentajeInteres = interes;
        }

        public PrestamosPesos(Prestamo prestamo, float porcentajeInteres) : this(prestamo.Monto, prestamo.Vencimiento, porcentajeInteres)
        {

        }

        private float CalcularInteres()
        {
            return (this.Monto * ((this._porcentajeInteres) / 100));
        }

        public override void ExtenderPlazo(DateTime nuevoVencimiento)
        {
            this._porcentajeInteres += ((nuevoVencimiento - this.Vencimiento).Days) * (float)0.25;
            base._vencimiento = nuevoVencimiento;
        }

        public override string Mostrar()
        {
            return base.Mostrar() + " - Porcenta Interes: " + this._porcentajeInteres.ToString() + " - Interes: " + this.Interes.ToString() + "\n";
        }

    }
}
