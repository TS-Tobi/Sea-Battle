using Sea_Battle.Models;
using Sea_Battle.Services;
using Sea_Battle.Styles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
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
    /// Interaktionslogik für WaitingMenu.xaml
    /// </summary>
    public partial class WaitingMenu : Page
    {
        /*
         The WaitingMenu class represents a page waiting for players to join a game.
         It shows the IP address of the server, sets the maximum number of players and regularly updates the player list.
         */
        public WaitingMenu()
        {
            InitializeComponent();

            //Shows the IP address of the server and sets the number of maximum players
            ServerIPAddress.Text = GetLocalIPAddress();
            MaxPlayerNumber.Text = StaticDataService.currentServer.maxPlayers.ToString();

            //Updates the player list and check the client connection
            UpdatePlayerList();
            StaticDataService.connection.CheckClientConnectionStart();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            /*
             Handles the click on the back button. Sets the current server to null and navigates to the previous page.
             */
            StaticDataService.currentServer = null;
            StaticDataService.MainFrame.GoBack();
        }
        private async void StartButton_Click(object sender, RoutedEventArgs e)
        {
            /*
             Handles the click on the start button. Stops checking the client connection,
             shows a button animation and navigates to the TournamentMenu page.
             */

            //Ends the thread that checks the connection to the clients
            StaticDataService.connection.CheckClientConnectionEnd();

            //Button press animation
            StartButtonImage.Source = new BitmapImage(new Uri("/Assets/Images/Buttons/button_start_down.png", UriKind.RelativeOrAbsolute));
            await Task.Delay(300);

            StaticDataService.MainFrame.Navigate(new Uri("/Pages/TournamentMenu.xaml", UriKind.Relative));
        }
        private string GetLocalIPAddress()
        {
            /*
             Gets the local IP address of the server.
             Returns: The local IP address of the server as a string
             */

            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress localIpAddress = host.AddressList.FirstOrDefault(ip => ip.AddressFamily == AddressFamily.InterNetwork);

            if (localIpAddress != null)
            {
                return localIpAddress.ToString();
            }
            else
            {
                return "Error";
            }
        }
        private async void UpdatePlayerList()
        {
            /*
             Regularly updates the list of players.
             */

            while (true)
            {
                PlayerContainer.Children.Clear();

                if (StaticDataService.PlayerList.Count > 0)
                {
                    foreach (Player player in StaticDataService.PlayerList)
                    {
                        if (player.uniqueness > 1)
                        {
                            AddPlayer(player.userName + player.uniqueness.ToString(), player.status);
                        }
                        else
                        {
                            AddPlayer(player.userName, player.status);
                        }
                    }
                }
                CurrentPlayerNumber.Text = StaticDataService.PlayerList.Count.ToString();

                await Task.Delay(3000);
            }
        }
        private void AddPlayer(string playerName, bool status)
        {
            /*
             Adds a player to the UI.
             Parameter name="playerName": The player's name.
             Parameter name="status": The status of the player (ready or waiting).
             */

            PlayerBox playerBox = new PlayerBox();
            playerBox.SetPlayerName(playerName);
            playerBox.SetPlayerStatus(status);

            //Add the UserControl to the user inferface
            PlayerContainer.Children.Add(playerBox);

            playerBox.Margin = new Thickness(6, 0, 6, 6);
        }
    }
}
