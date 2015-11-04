using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace DejandoHuellaW10.Models
{
    public class Fundacion : INotifyPropertyChanged
    {

        private StorageFile archivoImg;

        public StorageFile ArchivoImg
        {
            get { return archivoImg; }
            set {
                archivoImg = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("ArchivoImg"));
            }
        }


        private string foto;
        public string Foto
        {
            get { return foto; }
            set
            {
                foto = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Foto"));
            }
        }

        private string nombre;
        public string Nombre
        {
            get { return nombre; }
            set
            {
                nombre = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Nombre"));
            }
        }

        private string direccion;

        public string Direccion
        {
            get { return direccion; }
            set { direccion = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Direccion"));
            }
        }

        private string descripcion;

        public  string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Descripcion"));
            }
        }

        private string cuenta_bancaria;

        public string Cuenta_bancaria
        {
            get { return cuenta_bancaria; }
            set { cuenta_bancaria = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Cuenta_bancaria"));
            }
        }

        private string correo;

        public string Correo
        {
            get { return correo; }
            set { correo = value; if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Correo"));
            }
        }

        private string telefono;

        public string Telefono
        {
            get { return telefono; }
            set { telefono = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Telefono"));
            }
        }

       
        public string Id_usuario { get; set; }
        public string ObjectId { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
