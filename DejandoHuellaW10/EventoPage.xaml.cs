using DejandoHuellaW10.Models;
using System;
using System.Collections.Generic;
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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace DejandoHuellaW10
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class EventoPage : Page
    {
        Frame rootFrame;
        Eventos item;

        public EventoPage()
        {
            this.InitializeComponent();
            rootFrame = Window.Current.Content as Frame;
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;

            SystemNavigationManager.GetForCurrentView().BackRequested += EventoPage_BackRequested;
        }

        private void EventoPage_BackRequested(object sender, BackRequestedEventArgs e)
        {
            if (e.Handled == false)
            {
                e.Handled = true;
                
                rootFrame.GoBack();
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            item = e.Parameter as Eventos;
            if (item.Nombre != null)
                nombre.Text = item.Nombre;
            if (item.Fecha != null)
                fecha.Text = item.Fecha;
            if (item.Hora != null)
                hora.Text = item.Hora;
            if (item.Lugar != null)
                lugar.Text = item.Lugar;
            if (item.Descripcion != null)
                descri.Text = item.Descripcion;

            if (item.Foto != null)
            {
                ImageBrush brush = new ImageBrush();
                brush.Stretch = Stretch.UniformToFill;

                BitmapImage image = new BitmapImage(new Uri(item.Foto));
                brush.ImageSource = image;

                foto.Fill = brush;
            }


        }

        private void participarEvento(object sender, RoutedEventArgs e)
        {
            //Logica para participar en Evento
        }

        private void editarEvento(object sender, RoutedEventArgs e)
        {
            rootFrame.Navigate(typeof(EditEvento), item);
        }
    }
}
