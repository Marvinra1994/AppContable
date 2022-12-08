using APP_CONTABLE.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using Xamarin.Forms;

namespace APP_CONTABLE.ViewModels
{
    public class ViewModelsBalance : INotifyPropertyChanged
    {
        public ViewModelsBalance()
        {

            AbrirArchivo();


            CrearBalance = new Command(() => {

                Balance c1 = new Balance()
                {
                    saldo_final = this.saldo_final,
                    saldo_inicial = this.saldo_inicial

                };

                c1.calcula_balance();
                p.lista_balance.Add(c1);

                BinaryFormatter formatter = new BinaryFormatter();
                string ruta = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),
                    "info.aut");
                Stream archivo = new FileStream(ruta, FileMode.Create, FileAccess.Write, FileShare.None);
                formatter.Serialize(archivo, p);
                archivo.Close();

                Resultado = "";

                foreach (Balance c in p.lista_balance)
                {

                    Resultado += c.toString();

                }


            });


        }

        private void AbrirArchivo()
        {

          

            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                string ruta = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),
                    "info.aut");
                Stream archivo = new FileStream(ruta, FileMode.Open, FileAccess.Read, FileShare.None);

                p = (Persona)formatter.Deserialize(archivo);
                archivo.Close();

                Resultado = "";

                foreach (Balance x in p.lista_balance)
                {

                    Resultado += x.toString();

                }


            }
            catch (Exception e)
            {


            }



        }


        string resultado;

        public string Resultado
        {

            get => resultado;
            set
            {

                resultado = value;
                var args = new PropertyChangedEventArgs(nameof(Resultado));
                PropertyChanged?.Invoke(this, args);

            }

        }

        Persona p = new Persona();

        double saldo_inicial;

        public double Saldo_inicial
        {

            get => saldo_inicial;
            set
            {

                saldo_inicial = value;
                var args = new PropertyChangedEventArgs(nameof(Saldo_inicial));
                PropertyChanged?.Invoke(this, args);

            }

        }
        double saldo_final;
        public double Saldo_final
        {

            get => saldo_final;
            set
            {

                saldo_final = value;
                var args = new PropertyChangedEventArgs(nameof(Saldo_final));
                PropertyChanged?.Invoke(this, args);

            }

        }


        public Command CrearBalance { get; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
