using System;
using System.Collections.Generic;
using System.Text;

namespace APP_CONTABLE.Models
{
    [Serializable]
    public class Ingresos
    {
        public string tipo_ingreso { get; set; }
        public double cantidad_ingreso { get; set; }
        public DateTime fecha_ingreso { get; set; }

        public string toString()
        {
            return "El ingreso de "+ tipo_ingreso + " por el valor de L."+ cantidad_ingreso+ " fue ingresado de forma correcta";
        }

        
    }
}
