using Sea_Battle.Helpers;
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
    /// Interaktionslogik für TournamentTree_8.xaml
    /// </summary>
    public partial class TournamentTree_8 : Page
    {
        private int maxPlayers = 8;
        private int rows = 4;
        private int columns = 8;

        public TournamentTree_8()
        {
            InitializeComponent();

            //Set all textBlock to an empty string
            for (int i = 0; i < rows; i++)
            {
                int currentplayer = (int)Math.Pow(2, i);
                for (int j = 0; j < currentplayer; j++)
                {
                    TournamentTree.SetTextInGrid(this, i, j, "");
                }
            }
        }
    }
}
