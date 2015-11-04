using DejandoHuellaW10.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace DejandoHuellaW10
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MisEventosPage : Page
    {
        public MisEventosPage()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;
            gridMisEventos.SelectedIndex = -1;
        }

        private ObservableCollection<Eventos> eventos1;

        public ObservableCollection<Eventos> Eventos1
        {
            get
            {
                if (eventos1 == null)
                {
                    eventos1 = new ObservableCollection<Eventos>();

                    Eventos item = new Eventos() { Foto = "http://noticias.com.gt/files/2012/09/LogoAMApeq-400x188.jpg", Nombre = "Dejando Huella", Fecha = "20/11/2015", Lugar = "Parque caldas", Hora = "2:00pm" };
                    Eventos item1 = new Eventos() { Foto = "http://imagenes.tupatrocinio.com/imagenes/8/5/1/7/78517090102452535266516965674557/logo-fundacion.jpg", Fecha = "15/02/2016", Lugar = "Carrera 5 5-78", Hora = "1:00pm" };
                    Eventos item2 = new Eventos() { Foto = "http://www.congresovisible.org/media/uploads/fotos_perfil/4186/vladdo-alto.jpg", Nombre = "xx ", Fecha = "02/01/2016", Lugar = "Calle 4 6n-67", Hora = "4:30pm" };
                    Eventos item3 = new Eventos() { Foto = "https://www.bing.com/images/search?q=fundaciones+animales&view=detailv2&&id=9D8F5B4AFB5E3510BA1640232858AF8A91BADCB3&selectedIndex=1&ccid=3UNk2Rs6&simid=608021255094798556&thid=OIP.Mdd4364d91b3a4509b97585c710ce445eo0", Nombre = "xxx ", Fecha = "20/11/2015", Lugar = "Parque caldas", Hora = "2:00pm" };

                    eventos1.Add(item);
                    eventos1.Add(item1);
                    eventos1.Add(item2);
                    eventos1.Add(item3);


                }
                return eventos1;
            }
            set { eventos1 = value; }
        }

        private void verEvento(object sender, SelectionChangedEventArgs e)
        {

            if (gridMisEventos.SelectedIndex != -1)
            {
                Frame rootFrame = Window.Current.Content as Frame;
                rootFrame.Navigate(typeof(EventoPage), eventos1.ElementAt(gridMisEventos.SelectedIndex));
                //grid.SelectedIndex = -1;
            }
        }

        private void agregarEvento(object sender, RoutedEventArgs e)
        {
            //Aqui llamado a agregar evento
        }
    }
}
