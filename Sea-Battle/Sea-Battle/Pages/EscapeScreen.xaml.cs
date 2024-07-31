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
    /// Interaktionslogik für EscapeScreen.xaml
    /// </summary>
    public partial class EscapeScreen : Page
    {
        /*
         The EscapeScreen class represents the screen that appears when the user pauses or exits the game.
         It includes options to continue playing, open settings, return to the start menu, and exit the game.
         */

        public EscapeScreen()
        {
            InitializeComponent();
        }
        private async void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            /*
             Handles the event when the "Exit" button is clicked.
             Ends the game.
             */

            //Button press animation
            ExitButtonImage.Source = new BitmapImage(new Uri("/Assets/Images/Buttons/button_exit_down.png", UriKind.RelativeOrAbsolute));
            await Task.Delay(200);
            MainWindow mainWindow = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
            mainWindow.ShowEscapeScreen();
        }
        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
            /*
             Handles the event when the "Settings" button is clicked.
             Navigates to the settings page and hides the overlay screen.
             */

            StaticDataService.MainFrame.Navigate(new Uri("/Pages/SettingsMenu.xaml", UriKind.Relative));
            StaticDataService.OverlayFrame.Visibility = Visibility.Collapsed;
        }
        private async void ContinueButton_Click(object sender, RoutedEventArgs e)
        {
            /*
             Handles the event when the "Next" button is clicked.
             Calls the ShowEscapeScreen method in the MainWindow class to hide the escape screen.
             */

            //Button press animation
            ContinueButtonImage.Source = new BitmapImage(new Uri("/Assets/Images/Buttons/button_continue_down.png", UriKind.RelativeOrAbsolute));
            await Task.Delay(200);
            MainWindow mainWindow = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
            mainWindow.ShowEscapeScreen();
        }
        private async void StartMenuButton_Click(object sender, RoutedEventArgs e)
        {
            /*
             Handles the event when the "Start Menu" button is clicked.
             Resets the current server object and navigates back to the start menu, hiding the overlay screen.
             */

            StartMenuButtonImage.Source = new BitmapImage(new Uri("/Assets/Images/Buttons/button_start_menu_down.png", UriKind.RelativeOrAbsolute));
            await Task.Delay(200);

            //Reset the current serverobject
            StaticDataService.currentServer = null;
            StaticDataService.PlayerList = new ConcurrentBag<Models.Player>();

            StaticDataService.MainFrame.Navigate(new Uri("/Pages/StartMenu.xaml", UriKind.Relative));
            StaticDataService.OverlayFrame.Visibility = Visibility.Collapsed;
        }
        private void LeaveButton_Click(object sender, RoutedEventArgs e)
        {
            /*
             Handles the event when the "Exit" button is clicked.
             Ends the game.
             */

            Application.Current.Shutdown();
        }
    }
}
