using DejandoHuellaW10.Database;
using DejandoHuellaW10.Models;
using Parse;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
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
    public sealed partial class PrincipalPage : Page
    {
        ParseUser usuario;

        Frame rootFrame;
        FundacionParse parseFun;
        EventoParse parseEventos;
        public PrincipalPage()
        {
            this.InitializeComponent();
            rootFrame = Window.Current.Content as Frame;
            parseFun = new FundacionParse();
            parseEventos = new EventoParse();
            usuario = new ParseUser();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;
            gridEventos.SelectedIndex = -1;
            gridFundacion.SelectedIndex = -1;
        }
        private ObservableCollection<Fundacion> fundaciones;

        public ObservableCollection<Fundacion> Fundaciones
        {
            get 
            {
                if (fundaciones == null)
                    obtenerfundaciones();
                return fundaciones;
            }
            set { fundaciones = value; }
        }

        
        private ObservableCollection<Eventos> eventos1;

        public ObservableCollection<Eventos> Eventos1
        {
            get
            {
                if (eventos1 == null)
                    obtenerEventos();
                return eventos1;
            }
            set { eventos1 = value; }
        }

        private async void obtenerfundaciones() {

            fundaciones = new ObservableCollection<Fundacion>();

            var oFundaciones = await parseFun.AllFundaciones();
            if (oFundaciones != null)
            {
                Fundacion fun = new Fundacion();
                for (int i = 0; i < oFundaciones.Count(); i++)
                {
                    fun = new Fundacion();
                    var obj = oFundaciones.ElementAt(i) as ParseObject;
                    fun.Nombre = obj.Get<string>("nombre");
                    fun.Direccion = obj.Get<string>("direccion");
                    fun.Telefono = obj.Get<string>("telefono");
                    fun.Correo = obj.Get<string>("correo");
                    fun.Descripcion = obj.Get<string>("descripcion");
                    if (fun.Descripcion.Length > 100)
                        fun.Descripcion = fun.Descripcion.Substring(0, 100) + "...";
                    fun.Cuenta_bancaria = obj.Get<string>("cuenta_bancaria");
                    var a = obj.Get<ParseFile>("foto");
                    fun.Foto = a.Url.OriginalString;
                    fundaciones.Add(fun);
                    
                }
            }
           

            
        }

        private async void obtenerEventos()
        {

            eventos1 = new ObservableCollection<Eventos>();

            var aux = await parseEventos.AllEventos();
            if (aux != null)
            {
                Eventos evento = new Eventos();
                for (int i = 0; i < aux.Count(); i++)
                {
                    evento = new Eventos();
                    var obj = aux.ElementAt(i) as ParseObject;

                    evento.Nombre = obj.Get<string>("nombre");
                    evento.Fecha = obj.Get<string>("fecha");
                    evento.Hora = obj.Get<string>("hora");
                    evento.Lugar = obj.Get<string>("lugar");
                    evento.Descripcion = obj.Get<string>("descripcion");
                    var a = obj.Get<ParseFile>("foto");
                    evento.Foto = a.Url.OriginalString;
                    eventos1.Add(evento);

                }
            }



        }



        private void verEvento(object sender, SelectionChangedEventArgs e)
        {
            if (gridEventos.SelectedIndex != -1)
            {
                Frame rootFrame = Window.Current.Content as Frame;
                rootFrame.Navigate(typeof(EventoPage), eventos1.ElementAt(gridEventos.SelectedIndex));
            }
        }

        private void verFundacion(object sender, SelectionChangedEventArgs e)
        {
            if (gridFundacion.SelectedIndex != -1)
            {
                Frame rootFrame = Window.Current.Content as Frame;
                rootFrame.Navigate(typeof(FundacionPage), fundaciones.ElementAt(gridFundacion.SelectedIndex));
            }
        }

        private void agregarEvento(object sender, RoutedEventArgs e)
        {

            switch (pivot.SelectedIndex)
            {
                case 0:
                    //Aqui el llamado a la pagina de agregar Evento
                    
                    rootFrame.Navigate(typeof(AddEvento));
                    break;
                case 1:
                    //Aqui el llamado a la pagina de agregar Fundacion. Si ya creo fundacion, deshabilitar el boton
                    rootFrame.Navigate(typeof(AddFundacion));
                    break;
                default:
                    break;
            }

        }

        private void participarEvento(object sender, RoutedEventArgs e)
        {
            //Logica para participar en el evento
        }

        private void seguirFundacion(object sender, RoutedEventArgs e)
        {
            //Logica para seguir fundacion
        }
    }
}
