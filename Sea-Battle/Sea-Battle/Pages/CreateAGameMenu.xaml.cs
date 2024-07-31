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
    /// Interaktionslogik für CreateAGameMenu.xaml
    /// </summary>
    public partial class CreateAGameMenu : Page
    {
        /*
         The CreateAGameMenu class allows the user to create a new game by selecting the game name, maximum player count, and game type.
         */

        public CreateAGameMenu()
        {
            InitializeComponent();
        }
        private async void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            /*
             Handles the event when the "Create" button is clicked.
             Creates a new server object with the information entered and navigates to the waiting menu page.
             */

            //Creates a new Server Object
            String serverName = NameInputField.Text;
            int maxPlayers = Convert.ToInt32(MaxPlayerDropdownText.Text);
            string gameType = TypeDropdownText.Text;

            StaticDataService.currentServer = new Models.Server(serverName, maxPlayers, gameType);
            if (StaticDataService.connection == null)
            {
                StaticDataService.connection = new ClientConnection();
            }

            //Button press animation
            CreateButtonImage.Source = new BitmapImage(new Uri("/Assets/Images/Buttons/button_create_down.png", UriKind.RelativeOrAbsolute));
            await Task.Delay(300);

            StaticDataService.MainFrame.Navigate(new Uri("/Pages/WaitingMenu.xaml", UriKind.Relative));
        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            /*
             Handles the event when the back button is clicked.
             Resets the current server object, clears the player list and navigates to the previous page.
             */

            //Reset the current serverobject
            StaticDataService.currentServer = null;
            StaticDataService.PlayerList = new ConcurrentBag<Models.Player>();
            StaticDataService.MainFrame.GoBack();
        }

        //Dropdown menu max players
        private void DDMaxPlayers(object sender, RoutedEventArgs e)
        {
            /*
             This method handles the event when an entry is selected in the maximum player count drop-down menu.
             It updates the text of the drop-down text box according to the selected option.
             */

            Button button = sender as Button;
            MaxPlayerDropdownText.Text = button.Content.ToString();
        }

        //Dropdown menu type
        private void DDtype(object sender, RoutedEventArgs e)
        {
            /*
             This method handles the event when an entry is selected in the game type drop-down menu. 
             It updates the text of the drop-down text box according to the selected option.
             */

            Button button = sender as Button;
            TypeDropdownText.Text = button.Content.ToString();
        }
    }
}
