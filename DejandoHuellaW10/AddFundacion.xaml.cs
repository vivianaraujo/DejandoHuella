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
    public sealed partial class AddFundacion : Page
    {
        Frame rootFrame;
        public AddFundacion()
        {
            this.InitializeComponent();
            rootFrame = Window.Current.Content as Frame;

            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility
                = AppViewBackButtonVisibility.Visible;
            SystemNavigationManager.GetForCurrentView().BackRequested += AddFundacion_BackRequested; ;
        }

        private void AddFundacion_BackRequested(object sender, BackRequestedEventArgs e)
        {
            if (e.Handled == false)
            {
                e.Handled = true;
                rootFrame.GoBack();
            }
        }


        private void goToAdd(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(nombre.Text) && !string.IsNullOrWhiteSpace(direccion.Text) && !string.IsNullOrWhiteSpace(correo.Text) && !string.IsNullOrWhiteSpace(descripcion.Text) && !string.IsNullOrWhiteSpace(cuenta_bancaria.Text))
            {
                agregarEvento();
            }
            else
            {
                result.Text = "todos los campos son obligatorios";
            }
        }

        private void agregarEvento()
        {
            Fundacion ob = new Fundacion();
            FundacionParse obp = new FundacionParse();
            ob.Correo = correo.Text;
            ob.Cuenta_bancaria = cuenta_bancaria.Text;
            ob.Descripcion = descripcion.Text;
            ob.Direccion = direccion.Text;
            ob.Nombre = nombre.Text;
            ob.Telefono = telefono.Text;
            obp.insertFundacion(ob);
            rootFrame.GoBack();
        }
    }
}

