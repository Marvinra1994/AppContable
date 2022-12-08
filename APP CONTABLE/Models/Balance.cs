using System;
using System.Collections.Generic;
using System.Text;

namespace APP_CONTABLE.Models
{
    [Serializable]
    internal class Balance
    {
        public double total_ingresos { get; set; }
        public double total_egresos { get; set; }
        public double saldo { get; set; }

    }
}
