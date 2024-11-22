using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sea_Battle.Services;

namespace Sea_Battle.Models
{
    public class Server
    {
        /*
         The Server class represents a server and provides methods for managing players and sending messages.
         */

        public string serverName;
        public int maxPlayers;
        public string gameType;
        public bool running = false;

        public Server(string serverName, int maxPlayers, string gameType)
        {
            this.serverName = serverName;
            this.maxPlayers = maxPlayers;
            this.gameType = gameType;
        }

        public static void CheckUniquePlayerName(Player playerToCheck)
        {
            /*
             Checks whether a player's username is unique and updates the player's uniqueness property accordingly.
             Parameter name="playerToCheck": The player to check
             */

            int counter = 1;

            foreach (Player player in StaticDataService.PlayerList)
            {
                if (player.userName == playerToCheck.userName)
                {
                    counter++;
                }
            }
            playerToCheck.uniqueness = counter;
        }
        public void SendMessageToAllCLients(Message message)
        {
            /*
             Sends a message to all clients connected to the server.
             Parameter name="message": The message to send.
             */

            foreach (Player player in StaticDataService.PlayerList)
            {
                player.SendMessageToClient(message);
            }
        }
    }
}
