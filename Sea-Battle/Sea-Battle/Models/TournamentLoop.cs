using Sea_Battle.Helpers;
using Sea_Battle.Pages;
using Sea_Battle.Pages.TournamentTrees;
using Sea_Battle.Services;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Sea_Battle.Models
{
    public class TournamentLoop
    {
        private Page currentPage;
        private int maxPlayer;
        public Player[] playerArray;
        private int currentPlayerNumber;
        private string[] nextRoundPlayerNamesArray;
        private int rounds;
        

        public TournamentLoop(Page currentPage, int maxPlayer, ConcurrentBag<Player> playerList)
        {
            this.currentPage = currentPage;
            this.maxPlayer = maxPlayer;
            this.playerArray = playerList.ToArray();
            this.rounds = Convert.ToInt32(Math.Log(2, Convert.ToDouble(maxPlayer)));
        }

        public void ServerGameLoop()
        {
            //Has to change to the other Pages 
            var thisPage = currentPage as TournamentTree_2;
            while (rounds > 0)
            {
                nextRoundPlayerNamesArray = AddsPlayerNamesToNextPowOfTwo(maxPlayer);

                //Show playernames in TournamentTree
                for (int i = 0; i < nextRoundPlayerNamesArray.Length; i++)
                {
                    thisPage.SetTextInTournamentTree(rounds - 1, i, nextRoundPlayerNamesArray[i]);
                }
            }
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
    }
}
