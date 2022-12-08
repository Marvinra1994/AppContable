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
    internal class ViewModelsPersona : INotifyPropertyChanged
    {
        public ViewModelsPersona()
        {

            AbrirArchivo();


            CrearPersona = new Command(() => {

                p = new Persona()
                {

                    nombre = this.nombre,
                    genero = this.genero,
                    id= this.id


                };
                //Rutina de Serializacion
                BinaryFormatter formatter = new BinaryFormatter();
                string ruta = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),
                    "info.aut");
                Stream archivo = new FileStream(ruta, FileMode.Create, FileAccess.Write, FileShare.None);
                formatter.Serialize(archivo, p);
                archivo.Close();

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

                Nombre = p.nombre;
                genero= p.genero;
                id=p.id;

            }
            catch (Exception e)
            {


            }



        }

        Persona p = new Persona();

        string nombre;

        public string Nombre
        {
            get => nombre;
            set
            {
                nombre = value;
                var arg = new PropertyChangedEventArgs(nameof(Nombre));
                PropertyChanged?.Invoke(this, arg);

            }
        }

       

        string genero;

        public string Genero
        {
            get => genero;
            set
            {
                genero = value;
                var arg = new PropertyChangedEventArgs(nameof(Genero));
                PropertyChanged?.Invoke(this, arg);

            }
        }

        string id;

        public string Id
        {
            get => id;
            set
            {
                id = value;
                var arg = new PropertyChangedEventArgs(nameof(Genero));
                PropertyChanged?.Invoke(this, arg);

            }
        }


        public Command CrearPersona { get; }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
