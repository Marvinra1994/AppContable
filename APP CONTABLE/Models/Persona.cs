using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace APP_CONTABLE.Models
{
    [Serializable]
    public class Persona
    {
        public string nombre { get; set; }
        public string genero { get; set; }
        public string id { get; set; }

        public ObservableCollection<Ingresos> lista_ingresos { get; set; } = new ObservableCollection<Ingresos>();
        public ObservableCollection<Egresos> lista_egresos { get; set; } = new ObservableCollection<Egresos>();
        public ObservableCollection<Balance> lista_balance { get; set; } = new ObservableCollection<Balance>();

       

    }
}
