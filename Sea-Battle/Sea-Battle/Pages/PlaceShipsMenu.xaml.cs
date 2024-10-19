using Sea_Battle.Services;
using System;
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
    /// Interaktionslogik für PlaceShipsMenu.xaml
    /// </summary>
    public partial class PlaceShipsMenu : Page
    {
        public PlaceShipsMenu()
        {
            InitializeComponent();
        }
        private async void ReadyButton_Click(object sender, RoutedEventArgs e)
        {
            /*
             Handles the event when the "Ready" button is clicked.
             
            */

            //Button press animation
            ReadyButtonImage.Source = new BitmapImage(new Uri("/Assets/Images/Buttons/button_ready_down.png", UriKind.RelativeOrAbsolute));
            await Task.Delay(300);

            StaticDataService.MainFrame.Navigate(new Uri("/Pages/FightMenu.xaml", UriKind.Relative));
        }
    }
}
