using Sea_Battle.Models;
using Sea_Battle.Services;
using Sea_Battle.Styles;
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
    /// Interaktionslogik für WaitingMenuClient.xaml
    /// </summary>
    public partial class WaitingMenuClient : Page
    {
        public WaitingMenuClient()
        {
            InitializeComponent();

            CheckServerResponse();
        }
        private async void CheckServerResponse()
        {
            while (true)
            {
                try
                {
                    byte[] message = new byte[1024];

                    await Task.Run(() =>
                    {
                        StaticDataService.serverConnection.clientSocket.Receive(message);
                    });

                    Message recMessage = Message.JsonStringToMessage(Encoding.ASCII.GetString(message));

                    switch (recMessage.msgType)
                    {
                        case 'U':
                            PlayerListMessage recPlayerListMessage = PlayerListMessage.JsonStringToPlayerListMessage(Encoding.ASCII.GetString(message));

                            PlayerContainer.Children.Clear();
                            Application.Current.Dispatcher.Invoke(() =>
                            {
                                for (int i = 0; i < recPlayerListMessage.playerList.Length; i++)
                                {
                                    AddPlayer(recPlayerListMessage.playerList[i], true);
                                }
                            });
                            break;

                        case 'X':
                            Application.Current.Dispatcher.Invoke(() =>
                            {
                                StaticDataService.MainFrame.Navigate(new Uri("/Pages/PlaceShipsMenu.xaml", UriKind.Relative));
                            });
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error receiving server response: {ex.Message}");
                }
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
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            /*
             Handles the click on the back button. Sets the current server connnection to null and navigates to the previous page.
             */
            StaticDataService.serverConnection = null;
            StaticDataService.MainFrame.GoBack();
        }
    }
}
