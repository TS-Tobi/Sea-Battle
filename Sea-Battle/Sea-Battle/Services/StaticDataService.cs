using Sea_Battle.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Sea_Battle.Services
{
    public static class StaticDataService
    {
        /*
         The StaticDataService class provides static data and objects to the application.
         This includes frames for navigation, current server and connection objects,
         a SoundPlayer for music, and lists for player objects.
         */

        //Frames
        public static Frame MainFrame;
        public static Frame OverlayFrame;

        //Set in CreateAGameMenu.xaml.cs in CreatButton_Click
        public static Server currentServer;
        //Set in CreateAGameMenu.xaml.cs in CreatButton_Click
        public static ClientConnection connection;

        //Music
        public static SoundPlayer soundPlayer;

        public static readonly object lockObject = new object();
        public static ConcurrentBag<Player> PlayerList = new ConcurrentBag<Player>();
        public static ConcurrentBag<Player> NextRoundPlayerList = new ConcurrentBag<Player>();
    }
}
