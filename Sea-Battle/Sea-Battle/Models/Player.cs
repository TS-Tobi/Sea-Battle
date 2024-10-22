using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Sea_Battle.Services;

namespace Sea_Battle.Models
{
    public class Player
    {
        /*
         The Player class represents a player in the game for the Server.
         */

        public IPAddress ipAddress;
        public string userName;
        public Socket socketconnection;
        public bool status;                  //true or false for ready or waiting, default: waiting
        public int statusCount;
        public int uniqueness;               //indicates how many players in the current round have the same name
        public string currentEnemy;

        public Player(string userName, Socket socketconnection, IPAddress ipAddress)
        {
            this.userName = userName;
            this.socketconnection = socketconnection;
            this.ipAddress = ipAddress;
        }
        public Player(string userName)
        {
            this.userName = userName;
        }

        public void SendMessageToClient(Message message)
        {
            /*
             Sends a message to the client.
             Parameter name="message": The message to send.
             */

            byte[] sendmessage = Encoding.ASCII.GetBytes(message.ToJsonString());
            socketconnection.Send(sendmessage);
            Message.MessageLog(message, "out", userName);
        }
        public void RemovePlayer()
        {
            /*
             Removes the player from the PlayerList in StaticDataService.
             */

            StaticDataService.PlayerList = new ConcurrentBag<Player>(
                StaticDataService.PlayerList.Where(player => player != this));
        }
        public static string GetPlayerEnemy(string player)
        {
            /*
             Parameter name="player": The player's username.
             Returns the player's current Enemy with the specified username.
             */

            foreach (Player playerObj in StaticDataService.PlayerList)
            {
                if (playerObj.userName == player)
                {
                    return playerObj.currentEnemy;
                }
            }
            return null;
        }
    }
}
