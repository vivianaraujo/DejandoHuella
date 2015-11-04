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
    public sealed partial class MiFundacionPage : Page
    {
        Frame rootFrame;
        public MiFundacionPage()
        {
            this.InitializeComponent();
            rootFrame = Window.Current.Content as Frame;
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;

            SystemNavigationManager.GetForCurrentView().BackRequested += MiFundacionPage_BackRequested;
        }
        private void MiFundacionPage_BackRequested(object sender, BackRequestedEventArgs e)
        {
            if (e.Handled == false)
            {
                e.Handled = true;
                rootFrame.GoBack();
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;
            base.OnNavigatedTo(e);
        }

        private Fundacion miFundacion;

        public Fundacion MiFundacion
        {
            get
            {
                if (miFundacion == null)
                {
                    miFundacion = new Fundacion() { Foto = "http://noticias.com.gt/files/2012/09/LogoAMApeq-400x188.jpg", Nombre = "Dejando Huella", Direccion = "xxx", Cuenta_bancaria = "xxx", Descripcion = "La fundación OPAM es una fundación animalista y ambientalista que vela por los derechos y el bienestar de los animales.", Correo="uncorreounicauca.edu.co", Telefono="76 257 980" };

                }
                return miFundacion;
            }
            set { miFundacion = value; }
        }

        private void editarFundacion(object sender, RoutedEventArgs e)
        {
            rootFrame.Navigate(typeof(EditFundacion), miFundacion);
        }
    }
}
