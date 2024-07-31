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

namespace Sea_Battle.Styles
{
    /// <summary>
    /// Interaktionslogik für PlayerBox.xaml
    /// </summary>
    public partial class PlayerBox : UserControl
    {
        /*
         The PlayerBox class is a custom UserControl that displays a player's name and status.
         It contains methods for setting the player name and player status, as well as a method for getting the player name.
         */
        public PlayerBox()
        {
            InitializeComponent();
        }
        public void SetPlayerName(string playerName)
        {
            PlayerNameLabel.Text = playerName;
        }

        public void SetPlayerStatus(bool ready)
        {
            StatusLabel.Text = ready ? "Ready" : "Waiting";
            StatusLabel.Foreground = ready ? new SolidColorBrush((Color)ColorConverter.ConvertFromString("#00ff00")) : new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff0000"));
        }
        public string GetPlayerName()
        {
            return PlayerNameLabel.Text;
        }
    }
}
