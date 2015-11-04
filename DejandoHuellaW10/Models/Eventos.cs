using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DejandoHuellaW10.Models
{
    public class Eventos: INotifyPropertyChanged
    {
        
        private string fecha;

        public string Fecha
        {
            get { return fecha; }
            set { fecha = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Fecha"));
            }
        }
        private string hora;

        public string Hora
        {
            get { return hora; }
            set { hora = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Hora"));
            }
        }
        private string lugar;

        public string Lugar
        {
            get { return lugar; }
            set { lugar = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Lugar"));
            }
        }

        private string descripcion;

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Descripcion"));
            }
        }

        private string foto;

        public string Foto
        {
            get { return foto; }
            set { foto = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Foto"));
            }
        }

        private string nombre;
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Nombre"));
            }
        }
        public string ObjectId { get; set; }
        public string Id_Fundacion { get; set;}

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
