using Sea_Battle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sea_Battle.Services
{
    public class ClientConnection
    {
        /*
         The ClientConnection class manages the connection and communication with clients.
         It accepts new client connections, processes incoming messages, and monitors the connection status of clients.
         */

        private int port = 50000;
        private Socket serverSocket;
        private Thread listenerThread;
        private Thread waitThread;
        private bool stopWaitThread = false;

        public ClientConnection()
        {
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            serverSocket.Bind(new IPEndPoint(IPAddress.Any, port));
            serverSocket.Listen(10);

            listenerThread = new Thread(new ThreadStart(ListenForClients));
            listenerThread.Start();
        }

        private void ListenForClients()
        {
            /*
             Waits for incoming client connections and starts a new thread for communication for each connection.
             */
            while (true)
            {
                Socket clientSocket = serverSocket.Accept();
                Thread clientThread = new Thread(new ParameterizedThreadStart(HandleClientCommunication));

                clientThread.Start(clientSocket);
            }
        }
        private void HandleClientCommunication(object clientObj)
        {
            /*
             Handles communication with the connected client.
             Receives messages from the client, interprets them and takes appropriate actions.
             */

            Socket clientSocket = (Socket)clientObj;
            byte[] message = new byte[1024];

            while (true)
            {
                try
                {
                    clientSocket.Receive(message);

                    string receivedJsonString = Encoding.ASCII.GetString(message);
                    Message receivedMessage = Message.JsonStringToMessage(receivedJsonString);

                    switch (receivedMessage.msgType)
                    {
                        case 'J':
                            IPAddress clientIP = ((IPEndPoint)clientSocket.RemoteEndPoint).Address;
                            Player joinedPlayer = new Player(receivedMessage.user, clientSocket, clientIP);
                            Message.MessageLog(receivedMessage, " in", receivedMessage.user);

                            if (StaticDataService.PlayerList.Count == StaticDataService.currentServer.maxPlayers)
                            {
                                //Send back connection failed to the client
                                Message connectionFailedMessage = new Message("Server", DateTimeOffset.Now, 'F');
                                Message.MessageLog(connectionFailedMessage, "out", receivedMessage.user);
                                joinedPlayer.SendMessageToClient(connectionFailedMessage);
                                break;
                            }

                            //Add player to the waiting list and if necessary with an adapted name
                            Server.CheckUniquePlayerName(joinedPlayer);

                            StaticDataService.PlayerList.Add(joinedPlayer);
                            joinedPlayer.status = true;

                            //Send back connection confirmation to the client
                            Message connectedMessage = new Message("Server", DateTimeOffset.Now, 'C');
                            Message.MessageLog(connectedMessage, "out", receivedMessage.user);
                            joinedPlayer.SendMessageToClient(connectedMessage);
                            break;
                        case 'K':
                            Message.MessageLog(receivedMessage, " in", receivedMessage.user);
                            foreach (Player player in StaticDataService.PlayerList)
                            {
                                if (receivedMessage.user == player.userName)
                                {
                                    player.statusCount = 0;
                                    player.status = true;
                                }
                            }
                            break;
                        case 'D':
                            Message.MessageLog(receivedMessage, " in", receivedMessage.user);
                            foreach (Player player in StaticDataService.PlayerList)
                            {
                                if (receivedMessage.user == player.userName)
                                {
                                    player.RemovePlayer();
                                }
                            }
                            break;
                        default:
                            break;
                    }
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                    break;
                }
            }
            clientSocket.Close();
        }

        public void CheckClientConnectionStart()
        {
            /*
              Starts the monitoring thread that periodically checks the connection status of clients.
             */
            stopWaitThread = true;
            waitThread = new Thread(CheckClientConnection);
            waitThread.Start();
        }
        public void CheckClientConnectionEnd()
        {
            /*
             Ends the monitoring thread that checks the connection status of clients.
             */
            stopWaitThread = false;
            waitThread.Join();
        }
        private async void CheckClientConnection()
        {
            /*
             Regularly checks the connection status of clients.
             Sends a list of connected players to each client and removes clients that no longer respond.
             */

            while (stopWaitThread)
            {
                //Creates an array with the names of players from the list of player objects
                string[] playerNamesArray = StaticDataService.PlayerList
                    .Select(player => player.uniqueness > 1
                        ? $"{player.userName}{player.uniqueness}"
                        : player.userName)
                    .ToArray();

                PlayerListMessage currentPlayerListMessage = new PlayerListMessage("Server", DateTimeOffset.Now, 'U', playerNamesArray);

                foreach (Player player in StaticDataService.PlayerList)
                {
                    try
                    {
                        player.SendMessageToClient(currentPlayerListMessage);
                        Message.MessageLog(currentPlayerListMessage, "out", player.userName);
                    }
                    catch (Exception)
                    {
                        player.statusCount++;
                        player.status = false;
                    }
                }

                //Checks if a player hasn't responded 3 times and remove the, from the list
                foreach (Player player in StaticDataService.PlayerList.ToList())
                {
                    if (player.statusCount >= 3)
                    {
                        player.RemovePlayer();
                    }

                }

                await Task.Delay(4000);
            }
        }
    }
}
