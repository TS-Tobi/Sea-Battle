﻿using Sea_Battle.Services;
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
    /// Interaktionslogik für FightMenu.xaml
    /// </summary>
    public partial class FightMenu : Page
    {
        public FightMenu()
        {
            InitializeComponent();

            SetGameInformation();
        }

        private void SetGameInformation()
        {
            /*
             This method displays the game information such as player name and opponent name
             */

            PlayerName.Text = StaticDataService.userName;
            if(StaticDataService.currentEnemyName != string.Empty)
            {
                EnemyName.Text = StaticDataService.currentEnemyName;
            }
            else
            {
                EnemyName.Text = "Name not Found";
            }

        }
    }
}
