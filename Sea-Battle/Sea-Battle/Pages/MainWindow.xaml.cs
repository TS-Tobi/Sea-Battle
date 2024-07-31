using Sea_Battle.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

namespace Sea_Battle
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /*
         The MainWindow class is the main window of the application.
         It contains the start and overlay frames as well as the initialization of the home page.
         */

        public MainWindow()
        {
            InitializeComponent();
            StaticDataService.MainFrame = StartFrame;
            StaticDataService.OverlayFrame = OverFrame;

            StaticDataService.MainFrame.Navigate(new Uri("/Pages/StartMenu.xaml", UriKind.Relative));
        }
        public void OnKeyDown(object sender, KeyEventArgs e)
        {
            /*
             Handles the event when a key is pressed.
             When the escape key is pressed, the overlay screen is displayed.
             */

            if (e.Key == Key.Escape)
            {
                ShowEscapeScreen();
            }
        }

        public void ShowEscapeScreen()
        {
            /*
             Shows or hides the overlay screen depending on its current state.
             */

            if (StaticDataService.OverlayFrame.Visibility == Visibility.Visible && StaticDataService.OverlayFrame.Content is Pages.EscapeScreen)
            {
                StaticDataService.OverlayFrame.Visibility = Visibility.Collapsed;
                StaticDataService.OverlayFrame.Content = null;
            }
            else
            {
                StaticDataService.OverlayFrame.Visibility = Visibility.Visible;
                StaticDataService.OverlayFrame.Navigate(new Uri("/Pages/EscapeScreen.xaml", UriKind.Relative));
            }
        }
    }
}
