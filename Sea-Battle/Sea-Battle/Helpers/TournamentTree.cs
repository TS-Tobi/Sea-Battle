using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace Sea_Battle.Helpers
{
    public static class TournamentTree
    {
        public static void SetTextInGrid(FrameworkElement parent, int row, int column, string playerName)
        {
            string textBlockName = string.Format("Row{0}Column{1}TextBlock", row, column);

            TextBlock textBlockObj = parent.FindName(textBlockName) as TextBlock;

            if (textBlockObj != null)
            {
                textBlockObj.Text = playerName;
            }
        }

    }
}
