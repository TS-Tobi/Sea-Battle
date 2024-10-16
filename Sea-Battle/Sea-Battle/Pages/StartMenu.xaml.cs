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
    /// Interaktionslogik für StartMenu.xaml
    /// </summary>
    public partial class StartMenu : Page
    {
        /*   
         The StartMenu class represents the main menu of the application.
         It contains options to create a game, open settings and exit the application.
         */

        public StartMenu()
        {
            InitializeComponent();
        }

        private async void HostButton_Click(object sender, RoutedEventArgs e)
        {
            /*         
            Handles the event when the "Host" button is clicked.
            Navigates to the create a game page.
            */

            //Button press animation
            HostButtonImage.Source = new BitmapImage(new Uri("/Assets/Images/Buttons/button_host_down.png", UriKind.RelativeOrAbsolute));
            await Task.Delay(300);

            StaticDataService.MainFrame.Navigate(new Uri("/Pages/CreateAGameMenu.xaml", UriKind.Relative));
        }
        private async void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            /*         
            Handles the event when the "Play" button is clicked.
            Navigates to the connection page.
            */

            //Button press animation
            PlayButtonImage.Source = new BitmapImage(new Uri("/Assets/Images/Buttons/button_play_down.png", UriKind.RelativeOrAbsolute));
            await Task.Delay(300);

            StaticDataService.MainFrame.Navigate(new Uri("/Pages/ConnectionMenu.xaml", UriKind.Relative));
        }
        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
            /*
             Handles the event when the "Settings" button is clicked.
             Navigates to the settings page.
             */

            StaticDataService.MainFrame.Navigate(new Uri("/Pages/SettingsMenu.xaml", UriKind.Relative));
        }
        private async void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            /* 
             Handles the event when the "Exit" button is clicked.
             Quits the application.
             */

            //Button press animation
            ExitButtonImage.Source = new BitmapImage(new Uri("/Assets/Images/Buttons/button_exit_down.png", UriKind.RelativeOrAbsolute));
            await Task.Delay(300);

            Application.Current.Shutdown();
        }

    }
}
