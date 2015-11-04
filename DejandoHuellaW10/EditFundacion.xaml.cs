using DejandoHuellaW10.Database;
using DejandoHuellaW10.Models;
using Parse;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Pickers;
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
    public sealed partial class EditFundacion : Page
    {
        Frame rootFrame;
        Fundacion itm;
        StorageFile file;
        public EditFundacion()
        {
            this.InitializeComponent();
            rootFrame = Window.Current.Content as Frame;
        
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility
                = AppViewBackButtonVisibility.Visible;
            SystemNavigationManager.GetForCurrentView().BackRequested += EditFundacion_BackRequested;
        }

        private void EditFundacion_BackRequested(object sender, BackRequestedEventArgs e)
        {
            if (e.Handled == false)
            {
                e.Handled = true;
                rootFrame.GoBack();
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            itm = e.Parameter as Fundacion;
            nombre.Text = itm.Nombre;
            ImageBrush brush = new ImageBrush();
            brush.Stretch = Stretch.UniformToFill;


            BitmapImage image = new BitmapImage(new Uri(itm.Foto));
            brush.ImageSource = image;

            img.Fill = brush;
            direccion.Text = itm.Direccion;
            descripcion.Text = itm.Descripcion;
            cuenta_bancaria.Text = itm.Cuenta_bancaria;
            correo.Text = itm.Correo;
            telefono.Text = itm.Telefono;
     }

        private void goToEdit(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(nombre.Text) && !string.IsNullOrWhiteSpace(direccion.Text) && !string.IsNullOrWhiteSpace(correo.Text) && !string.IsNullOrWhiteSpace(descripcion.Text) && !string.IsNullOrWhiteSpace(cuenta_bancaria.Text))
            {
                FundacionParse obj = new FundacionParse();
                itm.Nombre = nombre.Text;
                itm.ObjectId = "Cic5apx3U3";
                itm.Descripcion = descripcion.Text;
                itm.Direccion = direccion.Text;
                itm.Correo = correo.Text;
                itm.Cuenta_bancaria = cuenta_bancaria.Text;
                itm.Telefono = telefono.Text;
                result.Text = "entra a cuardar";
                //if (file != null)
                //result.Text = itm.Foto;
                itm.ArchivoImg = file;
                obj.updateFundacion(itm);
                //rootFrame.GoBack();
            }
            else
            {
                result.Text = "Todos los campos son obligatorios";
            }

        }

        private async void selectPicture(object sender, RoutedEventArgs e)
        {
            FileOpenPicker picker = new FileOpenPicker();
            picker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            picker.FileTypeFilter.Add(".jpg");
            picker.FileTypeFilter.Add(".jpeg");
            picker.FileTypeFilter.Add(".png");
            file = await picker.PickSingleFileAsync();
            BitmapImage image = new BitmapImage();
            using (var stream = await file.OpenAsync(FileAccessMode.Read))
            {
                await image.SetSourceAsync(stream);
            }


            ImageBrush brush = new ImageBrush();
            brush.Stretch = Stretch.UniformToFill;


            // BitmapImage image = new BitmapImage(new Uri(file.Path, UriKind.Absolute));
            brush.ImageSource = image;

            img.Fill = brush;



            //var dlg = new Windows.UI.Popups.MessageDialog("Por favor ingrese todos los campos.");

        }
    }
}
