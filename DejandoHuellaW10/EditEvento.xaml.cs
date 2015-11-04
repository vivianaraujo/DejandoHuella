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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace DejandoHuellaW10
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class EditEvento : Page
    {
        Frame rootFrame;

        Eventos itm;
        public EditEvento()
        {
            this.InitializeComponent();
            rootFrame = Window.Current.Content as Frame;

            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility
                = AppViewBackButtonVisibility.Visible;
            SystemNavigationManager.GetForCurrentView().BackRequested += EditEvento_BackRequested;
        }

        private void EditEvento_BackRequested(object sender, BackRequestedEventArgs e)
        {
            if (e.Handled == false)
            {
                e.Handled = true;
                rootFrame.GoBack();
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            itm = e.Parameter as Eventos;
            nombre.Text = itm.Nombre;
            ImageBrush brush = new ImageBrush();
            brush.Stretch = Stretch.UniformToFill;

            BitmapImage image = new BitmapImage(new Uri(itm.Foto));
            brush.ImageSource = image;

            img.Fill = brush;
            lugar.Text = itm.Lugar;
            date.Text = itm.Fecha;
            descripcion.Text = itm.Descripcion;
            nombre.Text = itm.Nombre;
            hora.Text = itm.Hora;
        }

        private void editEvento(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(lugar.Text) && !string.IsNullOrWhiteSpace(date.Text) && !string.IsNullOrWhiteSpace(hora.Text) && !string.IsNullOrWhiteSpace(descripcion.Text) && !string.IsNullOrWhiteSpace(nombre.Text))
            {
                EventoParse obj = new EventoParse();
                itm.Hora = hora.Text;
                itm.Nombre = nombre.Text;
                itm.Descripcion = descripcion.Text;
                itm.Lugar = lugar.Text;
                itm.Hora = hora.Text;
                itm.Fecha = date.Text;
                itm.ObjectId = "BIeofNnQMk";
                // itm.Foto=
                obj.updateEvento(itm);
                rootFrame.GoBack();
            }
            else
            {
                result.Text = "todos los campos son obligatorios";
            }
        }
    }
}
