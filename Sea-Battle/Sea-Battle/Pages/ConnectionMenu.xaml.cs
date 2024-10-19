using Sea_Battle.Services;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Sea_Battle.Pages
{
    /// <summary>
    /// Interaktionslogik für ConnectionMenu.xaml
    /// </summary>
    public partial class ConnectionMenu : Page
    {
        public ConnectionMenu()
        {
            InitializeComponent();
        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            /*
             Handles the event when the back button is clicked.
             */

            //Change the current Frame
            StaticDataService.MainFrame.GoBack();
        }
        private async void ConnectButton_Click(object sender, RoutedEventArgs e)
        {
            /*
             Handles the event when the "Connect" button is clicked.
             
            */

            //Button press animation
            ConnectButtonImage.Source = new BitmapImage(new Uri("/Assets/Images/Buttons/button_connect_down.png", UriKind.RelativeOrAbsolute));
            await Task.Delay(300);

            StaticDataService.MainFrame.Navigate(new Uri("/Pages/PlaceShipsMenu.xaml", UriKind.Relative));
        }
    }
}
