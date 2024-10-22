using Sea_Battle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Sea_Battle.Services
{
    public class ServerConnection
    {
        private int port;
        private IPAddress serverIP;
        public Socket clientSocket;

        public ServerConnection(string ip, int _port)
        {
            serverIP = IPAddress.Parse(ip);
            port = _port;
            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            clientSocket.Connect(serverIP, port);
        }

        public void SendMsg(Message sendMsgObj)
        {
            string sendMsgString = sendMsgObj.ToJsonString();
            byte[] sendMsgBytes = Encoding.ASCII.GetBytes(sendMsgString);
            clientSocket.Send(sendMsgBytes);
        }
        public Message RecMsg()
        {
            byte[] recMsgBytes = new byte[1024];
            clientSocket.Receive(recMsgBytes);
            string recMsgString = Encoding.ASCII.GetString(recMsgBytes);
            return Message.JsonStringToMessage(recMsgString);
        }
        public void Disconn()
        {
            clientSocket.Close();
        }
    }
}
