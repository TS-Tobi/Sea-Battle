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
    /// Interaktionslogik für SettingsMenu.xaml
    /// </summary>
    public partial class SettingsMenu : Page
    {
        /*
         The SettingsMenu class represents the application settings menu.
         It allows the user to change the application language and switch between full screen and windowed mode.
         */

        private bool isFullscreen = false;
        public SettingsMenu()
        {
            InitializeComponent();
            CheckFullscreen();
        }
        private async void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            /*
             Handles the event when the "Exit" button is clicked.
             Navigates back to the previous screen.
             */

            //Button press animation
            ExitButtonImage.Source = new BitmapImage(new Uri("/Assets/Images/Buttons/button_exit_down.png", UriKind.RelativeOrAbsolute));
            await Task.Delay(200);

            NavigationService.GoBack();
        }

        //Dropdown menu language
        private void DDLanguage(object sender, RoutedEventArgs e)
        {
            /*
             This method is called when an option is selected in the language drop-down menu.
             It updates the displayed text in the current language.
             */
            Button button = sender as Button;
            CurrentLanguageText.Text = button.Content.ToString();
        }

        //Fullscreen
        private void FullscreenToggle(object sender, RoutedEventArgs e)
        {
            /*
             This method is called when the full screen button is clicked. 
             It switches between full screen and windowed mode and updates the icon accordingly.
             */

            if (Application.Current.MainWindow is MainWindow mainWindow)
            {
                if (!isFullscreen)
                {
                    mainWindow.WindowStyle = WindowStyle.None;
                    mainWindow.WindowState = WindowState.Maximized;
                    isFullscreen = true;
                }
                else
                {
                    mainWindow.WindowState = WindowState.Normal;
                    mainWindow.WindowStyle = WindowStyle.ThreeDBorderWindow;
                    isFullscreen = false;
                }
                UpdateFullscreenIcon();
            }
        }
        private void UpdateFullscreenIcon()
        {
            /*
             This method updates the full screen mode icon based on the current state.
             */

            if (isFullscreen)
            {
                FullscreenToggleImage.Source = new BitmapImage(new Uri("/Assets/Images/Icons/icon_toggle_on.png", UriKind.RelativeOrAbsolute));
            }
            else
            {
                FullscreenToggleImage.Source = new BitmapImage(new Uri("/Assets/Images/Icons/icon_toggle_off.png", UriKind.RelativeOrAbsolute));
            }
        }
        private void CheckFullscreen()
        {
            /*
             This method checks the current full screen mode and updates the icon accordingly.
             */

            if (Application.Current.MainWindow is MainWindow mainWindow)
            {
                if (mainWindow.WindowState == WindowState.Maximized)
                {
                    isFullscreen = true;
                }
            }
            UpdateFullscreenIcon();
        }
    }
}
