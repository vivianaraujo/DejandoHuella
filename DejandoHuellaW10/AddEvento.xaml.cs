using DejandoHuellaW10.Database;
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
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace DejandoHuellaW10
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddEvento : Page
    {
        Frame rootFrame;
        public AddEvento()
        {
            this.InitializeComponent();
            rootFrame = Window.Current.Content as Frame;

            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility
                = AppViewBackButtonVisibility.Visible;
            SystemNavigationManager.GetForCurrentView().BackRequested += AddEvento_BackRequested;
        }

        private void AddEvento_BackRequested(object sender, BackRequestedEventArgs e)
        {
            if (e.Handled == false)
            {
                e.Handled = true;
                rootFrame.GoBack();
            }
        }

        public void agregarEvento()
        {
            EventoParse ep = new EventoParse();
            Eventos e = new Eventos();
            e.Lugar = lugar.Text;
            e.Nombre = nombre.Text;
            e.Descripcion = descripcion.Text;
            e.Hora = hora.Text;
            e.Fecha = date.Text;
            e.Id_Fundacion = "1";
            e.Foto = "foto";
            ep.insertEvento(e);
            rootFrame.GoBack();


        }

        private void ok(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(lugar.Text) && !string.IsNullOrWhiteSpace(date.Text) && !string.IsNullOrWhiteSpace(hora.Text) && !string.IsNullOrWhiteSpace(descripcion.Text) && !string.IsNullOrWhiteSpace(nombre.Text))
            {
                agregarEvento();
            }
            else
            {
                result.Text = "todos los campos son obligatorios";
            }
        }
    }
}
