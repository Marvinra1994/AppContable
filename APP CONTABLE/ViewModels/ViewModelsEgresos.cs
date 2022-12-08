using APP_CONTABLE.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using Xamarin.Forms;

namespace APP_CONTABLE.View_Models
{
    internal class ViewModelsEgresos
    {
        public ViewModelsEgresos()
        {

            AbrirArchivo();


            CrearEgreso = new Command(() => {

                Egresos e1 = new Egresos()
                {
                    tipo_egreso = this.tipo,
                    cantidad_egreso = this.cantidad,
                    fecha_egreso = this.fecha_egreso

                };

                p.lista_egresos.Add(e1);

                BinaryFormatter formatter = new BinaryFormatter();
                string ruta = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),
                    "info.aut");
                Stream archivo = new FileStream(ruta, FileMode.Create, FileAccess.Write, FileShare.None);
                formatter.Serialize(archivo, p);
                archivo.Close();

                Resultado = "";

                foreach (Egresos c in p.lista_egresos)
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

                foreach (Egresos x in p.lista_egresos)
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

        string ingreso;

        public string Ingreso
        {

            get => ingreso;
            set
            {

                ingreso = value;
                var args = new PropertyChangedEventArgs(nameof(Ingreso));
                PropertyChanged?.Invoke(this, args);

            }

        }


        DateTime fecha_egreso = DateTime.Today;

        public DateTime Fecha_egreso
        {

            get => fecha_egreso;
            set
            {

                fecha_egreso = value;
                var args = new PropertyChangedEventArgs(nameof(Fecha_egreso));
                PropertyChanged?.Invoke(this, args);

            }

        }

        DateTime fechaMin = DateTime.Today;

        public DateTime FechaMin
        {
            get => fechaMin;
            set
            {

                fechaMin = value;
                var arg = new PropertyChangedEventArgs(nameof(FechaMin));
                PropertyChanged?.Invoke(this, arg);

            }
        }

        string tipo;

        public string Tipo
        {

            get => tipo;
            set
            {

                tipo = value;
                var args = new PropertyChangedEventArgs(nameof(Tipo));
                PropertyChanged?.Invoke(this, args);

            }

        }

        double cantidad;

        public double Cantidad
        {

            get => cantidad;
            set
            {

                cantidad = value;
                var args = new PropertyChangedEventArgs(nameof(Cantidad));
                PropertyChanged?.Invoke(this, args);

            }

        }

        public Command CrearEgreso { get; }



        public event PropertyChangedEventHandler PropertyChanged;
    }
}
