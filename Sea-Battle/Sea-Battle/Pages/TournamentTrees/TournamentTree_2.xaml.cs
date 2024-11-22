using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using Sea_Battle.Models;
using Sea_Battle.Services;

namespace Sea_Battle.Pages.TournamentTrees
{
    /// <summary>
    /// Interaktionslogik für TournamentTree_2.xaml
    /// </summary>
    public partial class TournamentTree_2 : Page
    { 

        private Page currentPage;
        private int maxPlayer;
        public Player[] playerArray;
        private int currentPlayerNumber;
        private string[] nextRoundPlayerNamesArray;
        private int rounds;

        public TournamentTree_2()
        {
            InitializeComponent();

            //Initialization of the server variables
            rounds = 1;
            maxPlayer = 2;

            //Set the server to running
            StaticDataService.currentServer.running = true;

            //Send game start message to all clients
            Message gameStartMessage = new Message("Server", DateTimeOffset.Now, 'X');
            StaticDataService.currentServer.SendMessageToAllCLients(gameStartMessage);

            Task.Delay(100).ContinueWith(_ => ServerGameLoop());
        }

        //GameLoop
        public void ServerGameLoop()
        {
            while (rounds > 0)
            {
                nextRoundPlayerNamesArray = AddsPlayerNamesToNextPowOfTwo(maxPlayer);
                //Show playernames in TournamentTree
                for (int i = 0; i < nextRoundPlayerNamesArray.Length; i++)
                {
                    SetTextInTournamentTree(rounds, i, nextRoundPlayerNamesArray[i]);
                }

                //Reset the current enemy from every client
                foreach (Player player in StaticDataService.PlayerList)
                {
                    player.currentEnemy = "";
                }

                //Send new round message to all clients
                Message newRoundMessage = new Message("Server", DateTimeOffset.Now, 'R');
                StaticDataService.currentServer.SendMessageToAllCLients(newRoundMessage);

                //Set the current enemy for every client and send the enemyMessage and reset the status
                AssignEnemyToEveryClient();
                foreach (Player player in StaticDataService.PlayerList)
                {
                    AssignEnemyMessage assignedEnemymessage = new AssignEnemyMessage("server", DateTimeOffset.Now, 'E', player.currentEnemy);
                    player.SendMessageToClient(assignedEnemymessage);
                    player.status = false;
                }

                while (!StaticDataService.PlayerList.All(player => player.status))
                {
                    Console.WriteLine("Wait for players");
                    Thread.Sleep(500); // Warte 500 ms, um CPU-Auslastung zu reduzieren
                }
                Console.WriteLine("All players are ready!");

                //Sende a message to the client which begins
                DecidesWhichPlayerStarts();

                //TODO: Warten wann die nächste Runde beginnen kann

                //Reduce the round number
                rounds--;
            }
        }


        //Helper
        public void SetTextInTournamentTree(int row, int column, string playerName)
        {
            string textBlockName = string.Format("Row{0}Column{1}TextBlock", row, column);

            // Use Dispatcher to ensure UI access
            Application.Current.Dispatcher.Invoke(() =>
            {
                TextBlock textBlockObj = this.FindName(textBlockName) as TextBlock;
                if (textBlockObj != null)
                {
                    textBlockObj.Text = playerName;
                }
            });
        }
        private string[] AddsPlayerNamesToNextPowOfTwo(int shouldPlayerNumber)
        {
            /*
             Adds player names to pad the count to the nearest power of two.
             Returns: An array containing the player names and any additional "computer" placeholders.
             */

            string[] nextRoundPlayerNamesArray = new string[shouldPlayerNumber];

            for (int i = 0; i < playerArray.Length; i++)
            {
                nextRoundPlayerNamesArray[i] = playerArray[i].userName;
            }

            for (int i = 0; i < nextRoundPlayerNamesArray.Length; i++)
            {
                if (nextRoundPlayerNamesArray[i] == null)
                {
                    nextRoundPlayerNamesArray[i] = "Bot";
                }
            }

            return nextRoundPlayerNamesArray;
        }
        private void AssignEnemyToEveryClient()
        {
            /*
             Assigns an opponent to each player on the list.
             */

            Player[] playerArray = StaticDataService.PlayerList.ToArray();
            for (int i = 0; i < playerArray.Length; i += 2)
            {
                Player player1;
                Player player2;
                if (i + 1 < playerArray.Length)
                {
                    player1 = playerArray[i];
                    player2 = playerArray[i + 1];
                }
                else
                {
                    Player Computer = new Player("Bot");

                    player1 = playerArray[i];
                    player2 = Computer;
                }


                player1.currentEnemy = player2.userName;
                player2.currentEnemy = player1.userName;
            }
        }
        private void DecidesWhichPlayerStarts()
        {
            /*
            Checks which player starts and sends them a start message.
            */

            Player[] playerArray = StaticDataService.PlayerList.ToArray();

            //Initialize of an random Object
            Random rndTurn = new Random();

            for (int i = 0; i < playerArray.Length; i += 2)
            {
                Message yourTurnMessage = new Message("Server", DateTimeOffset.Now, 'T');

                Player player1;
                Player player2;
                if (i + 1 < playerArray.Length)
                {
                    player1 = playerArray[i];
                    player2 = playerArray[i + 1];

                    int turn = rndTurn.Next(1, 3);
                    if(turn == 1)
                    {
                        player1.SendMessageToClient(yourTurnMessage);
                    }
                    else
                    {
                        player2.SendMessageToClient(yourTurnMessage);
                    }

                }
                else
                {
                    player1 = playerArray[i];
                    player1.SendMessageToClient(yourTurnMessage);
                }

            }
        }
    }
}
