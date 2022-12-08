using System;
using System.Collections.Generic;
using System.Text;

namespace APP_CONTABLE.Models
{
    [Serializable]
    public class Egresos
    {
        public string tipo_egreso { get; set; }
        public double cantidad_egreso { get; set; }
        public DateTime fecha_egreso { get; set; }

        public string toString()
        {
            return "El egreso de " + tipo_egreso + " por el valor de L." + cantidad_egreso +  " fue ingresado de forma correcta";
        }

    }
}
