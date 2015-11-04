using Parse;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
    public sealed partial class InicioSesionPage : Page
    {
        Frame rootFrame;
        public InicioSesionPage()
        {
            this.InitializeComponent();
            rootFrame = Window.Current.Content as Frame;
        }

        private async void goToIniciarSesion(object sender, RoutedEventArgs e)
        {
            try
            {
                await ParseUser.LogInAsync(user.Text, password.Password);
                result.Text = "entro";
                rootFrame.Navigate(typeof(MainPage));
            }
            catch (Exception)
            {
                result.Text = "Usuario y/o Contraseña Incorrectos";

            }

        }
    }
}
