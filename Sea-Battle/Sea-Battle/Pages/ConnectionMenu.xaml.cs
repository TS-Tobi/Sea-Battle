using Sea_Battle.Models;
using Sea_Battle.Services;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
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
    /// Interaktionslogik für ConnectionMenu.xaml
    /// </summary>
    public partial class ConnectionMenu : Page
    {
        public string UserName;
        public IPAddress IPAddress;
        public bool CorrectIPAddress;
        public bool CorrectUserName;

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

            //Reset the server connection
            StaticDataService.serverConnection = null;

        }
        private async void ConnectButton_Click(object sender, RoutedEventArgs e)
        {
            /*
             Handles the event when the "Connect" button is clicked.
             Checks the IPAddress and saves the user name
            */

            ErrorTextBlock.Text = string.Empty;
            string errorMessage = string.Empty;

            //Button press animation
            ConnectButtonImage.Source = new BitmapImage(new Uri("/Assets/Images/Buttons/button_connect_down.png", UriKind.RelativeOrAbsolute));
            await Task.Delay(300);

            //Check if it is a correct IP address
            if (IPAddress.TryParse(IPAddressInputField.Text, out IPAddress ipAddress))
            {
                CorrectIPAddress = true;
                IPAddress = ipAddress;
            }
            else
            {
                CorrectIPAddress = false;
                errorMessage += "No correct IP address.\n";
                ConnectButtonImage.Source = new BitmapImage(new Uri("/Assets/Images/Buttons/button_connect.png", UriKind.RelativeOrAbsolute));
            }

            //Check if it is a correct user name
            if (!string.IsNullOrWhiteSpace(NameInputField.Text))
            {
                CorrectUserName = true;
                //Save the user name
                UserName = NameInputField.Text;
            }
            else
            {
                CorrectUserName = false;
                errorMessage += "Name is empty.\n";
                ConnectButtonImage.Source = new BitmapImage(new Uri("/Assets/Images/Buttons/button_connect.png", UriKind.RelativeOrAbsolute));
            }

            

            //If both IP address ans username are valid
            if (CorrectIPAddress && CorrectUserName)
            {
                System.Console.WriteLine("Try to connect");

                //Create connection to the server
                try
                {
                    StaticDataService.serverConnection = new ServerConnection(IPAddress.ToString(), 50000);

                    //Send join message to the server
                    Message JoinMessage = new Message(UserName, DateTimeOffset.Now, 'J');
                    StaticDataService.serverConnection.SendMsg(JoinMessage);
                }
                catch (Exception ex)
                {
                    ErrorTextBlock.Text = "Connection to server failed. \n";
                    ConnectButtonImage.Source = new BitmapImage(new Uri("/Assets/Images/Buttons/button_connect.png", UriKind.RelativeOrAbsolute));
                    return;
                }

                //Wait for message from server
                Message recMessage = StaticDataService.serverConnection.RecMsg();
                if (recMessage.msgType == 'C')
                {
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        StaticDataService.MainFrame.Navigate(new Uri("/Pages/WaitingMenuClient.xaml", UriKind.Relative));
                    });
                }
                else if (recMessage.msgType == 'F')
                {
                    ErrorTextBlock.Text = "The server does not allow the connection. \n";
                    ConnectButtonImage.Source = new BitmapImage(new Uri("/Assets/Images/Buttons/button_connect.png", UriKind.RelativeOrAbsolute));
                    return;
                }
            }

            //Show error message if exists
            if (!string.IsNullOrEmpty(errorMessage))
            {
                ErrorTextBlock.Text = errorMessage;
            }
        }
    }
}
