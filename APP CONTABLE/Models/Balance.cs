using System;
using System.Collections.Generic;
using System.Text;

namespace APP_CONTABLE.Models
{
    [Serializable]
    public class Balance : Egresos
    {

        public double saldo_inicial {get; set; }
        public double saldo_final {get; set; }



        public void calcula_balance()
        {
            saldo_final = saldo_inicial + cantidad_ingreso - (cantidad_egreso);
        }

        public new string toString()
        {

            return "Su saldo final es: " + saldo_final;
        }


    }
}
