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
    public sealed partial class FundacionPage : Page
    {
        Frame rootFrame;
        Fundacion item;

        public FundacionPage()
        {
            this.InitializeComponent();
            rootFrame = Window.Current.Content as Frame;
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;

            SystemNavigationManager.GetForCurrentView().BackRequested += FundacionPage_BackRequested;
        }

        private void FundacionPage_BackRequested(object sender, BackRequestedEventArgs e)
        {
            if (e.Handled == false)
            {
                e.Handled = true;
                rootFrame.GoBack();
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            item = e.Parameter as Fundacion;
            if (item.Nombre != null)
                nombre.Text = item.Nombre;
            if (item.Direccion != null)
                direccion.Text = item.Direccion;
            if (item.Correo != null)
                correo.Text = item.Correo;
            if (item.Telefono != null)
                telefono.Text = item.Telefono;
            if (item.Cuenta_bancaria != null)
                cuentaBancaria.Text = item.Cuenta_bancaria;

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

        private void seguirFundacion(object sender, RoutedEventArgs e)
        {
            //Logica para seguir a la fundacion
        }

    }
}
