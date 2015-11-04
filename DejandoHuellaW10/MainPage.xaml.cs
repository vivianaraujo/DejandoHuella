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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace DejandoHuellaW10
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            this.Loaded += MainPage_Loaded;
            
        }

        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            menu.SelectedIndex = 0;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;

        }


        private ObservableCollection<MenuItem> menuList;

        public ObservableCollection<MenuItem> MenuList
        {
            get
            {
                if (menuList == null)
                {
                    menuList = new ObservableCollection<MenuItem>();

                    MenuItem item = new MenuItem() { Name = "Inicio", Icon = "Home" };
                    MenuItem item1 = new MenuItem() { Name = "Mis Eventos", Icon = "Calendar" };
                    MenuItem item2 = new MenuItem() { Name = "Mi Fundacion", Icon = "ContactInfo" };
                    MenuItem item3 = new MenuItem() { Name = "Cerrar Sesion", Icon = "Emoji2" };


                    menuList.Add(item);
                    menuList.Add(item1);
                    menuList.Add(item2);
                    menuList.Add(item3);
                }

                return menuList;
            }
            set { menuList = value; }
        }



        private void showMenu(object sender, RoutedEventArgs e)
        {
            if (split.IsPaneOpen)
                split.IsPaneOpen = false;
            else
                split.IsPaneOpen = true;

        }

        private void putContent(object sender, SelectionChangedEventArgs e)
        {
            switch (menu.SelectedIndex)
            {
                case 0:
                    Contenido.Navigate(typeof(PrincipalPage));
                    break;

                case 1:
                    Contenido.Navigate(typeof(MisEventosPage));
                    break;

                case 2:
                    Contenido.Navigate(typeof(MiFundacionPage));
                    break;

                case 3:
                    //Logica para cerrar sesion 
                    break;
            }
        }
    }
}
