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
    internal class ViewModelsIngresos : INotifyPropertyChang
    {
        public ViewModelsIngresos()
        {

            AbrirArchivo();


            CrearIngreso = new Command(() => {

                Ingresos i1 = new Ingresos()
                {
                    tipo_ingreso=this.tipo,
                    cantidad_ingreso= this.cantidad,
                    fecha_ingreso=this.fecha_ingreso

                };
                
                p.lista_ingresos.Add(i1);

                BinaryFormatter formatter = new BinaryFormatter();
                string ruta = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),
                    "info.aut");
                Stream archivo = new FileStream(ruta, FileMode.Create, FileAccess.Write, FileShare.None);
                formatter.Serialize(archivo, p);
                archivo.Close();

                Resultado = "";

                foreach (Ingresos c in p.lista_ingresos)
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

                foreach (Ingresos x in p.lista_ingresos)
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


        DateTime fecha_ingreso = DateTime.Today;

        public DateTime Fecha_ingreso
        {

            get => fecha_ingreso;
            set
            {

                fecha_ingreso = value;
                var args = new PropertyChangedEventArgs(nameof(Fecha_ingreso));
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

        public Command CrearIngreso { get; }



        public event PropertyChangedEventHandler PropertyChanged;

    }

    internal interface INotifyPropertyChang
    {
    }
}
