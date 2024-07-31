using Sea_Battle.Helpers;
using Sea_Battle.Models;
using Sea_Battle.Services;
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
    /// Interaktionslogik für TournamentMenu.xaml
    /// </summary>
    public partial class TournamentMenu : Page
    {
        /*
         The TournamentMenu class represents a page that displays the tournament menu and tournament tree.
         It manages players, assigns opponents and generates a visual representation of the tournament tree.
         */

        public string[] playerNamesArray;
        private int currentPlayerNumber;
        private int treeWidth;
        private int treeHeight;
        private StackPanel stackPanel;

        private List<TextBlockInfo> textBlockInfos = new List<TextBlockInfo>();

        public TournamentMenu()
        {
            playerNamesArray = AddsPlayerNamesToNextPowOfTwo();
            currentPlayerNumber = playerNamesArray.Length;

            //Send game start Message to all Clients
            Models.Message gameStartMessage = new Models.Message("Server", DateTimeOffset.Now, 'X');
            StaticDataService.currentServer.SendMessageToAllCLients(gameStartMessage);

            //Assign every client an enemy
            AssignEnemyToEveryClient();

            //Send every Client his assigned enemy
            foreach (Player player in StaticDataService.PlayerList)
            {
                Models.AssignEnemyMessage assignEnemyMessage = new Models.AssignEnemyMessage("Server", DateTimeOffset.Now, 'E', player.currentEnemy);
                player.SendMessageToClient(assignEnemyMessage);
            }

            InitializeComponent();

            //Generate the visual toutnament tree
            GenerateTournamentTree();
            RowNameUpdaten(treeHeight - 1, playerNamesArray);
        }

        private string[] AddsPlayerNamesToNextPowOfTwo()
        {
            /*
             Adds player names to pad the count to the nearest power of two.
             Returns: An array containing the player names and any additional "computer" placeholders.
             */

            //Get the player number
            foreach (Models.Player player in StaticDataService.PlayerList)
            {
                currentPlayerNumber++;
            }

            int shouldPlayerNumber = NextPowerOfTwo(currentPlayerNumber);
            playerNamesArray = StaticDataService.PlayerList
                   .Select(player => player.uniqueness > 1
                       ? $"{player.userName}{player.uniqueness}"
                       : player.userName)
                   .ToArray();

            int missingNamesCount = shouldPlayerNumber - playerNamesArray.Length;

            string[] updatedPlayerNamesArray = new string[shouldPlayerNumber];

            for (int i = 0; i < playerNamesArray.Length; i++)
            {
                updatedPlayerNamesArray[i] = playerNamesArray[i];
            }

            for (int i = playerNamesArray.Length; i < shouldPlayerNumber; i++)
            {
                updatedPlayerNamesArray[i] = "Computer";
            }
            return updatedPlayerNamesArray;
        }

        //Game loop
        private void AssignEnemyToEveryClient()
        {
            /*
             Assigns an opponent to each player on the list.
             */

            Player[] playerArray = StaticDataService.PlayerList.ToArray();
            for (int i = 0; i < playerArray.Length; i += 2)
            {
                Player player1;
                Player player2;
                if (i + 1 < playerArray.Length)
                {
                    player1 = playerArray[i];
                    player2 = playerArray[i + 1];
                }
                else
                {
                    Player Computer = new Player("Computer");

                    player1 = playerArray[i];
                    player2 = Computer;
                }


                player1.currentEnemy = player2.userName;
                player2.currentEnemy = player1.userName;
            }
        }

        //Visualization of the tournamnet Tree
        private void GenerateTournamentTree()
        {
            /*
             Generates the visual tournament tree.
            */

            //Calculate Width and Height
            treeWidth = NextPowerOfTwo(currentPlayerNumber);

            treeHeight = (int)Math.Ceiling(Math.Log(treeWidth, 2)) + 1;

            //Generate Page-Grid
            GenerateGrid(treeHeight, treeWidth);

        }
        private int NextPowerOfTwo(int number)
        {
            /*      
             Calculates the next power of two.
             Parameter name="number": The number to convert. 
             Returns: The next power of two
             */

            int exponent = (int)Math.Ceiling(Math.Log(number, 2));
            return (int)Math.Pow(2, exponent);
        }
        private void GenerateGrid(int treeHeight, int treeWidth)
        {
            /*
             Generates the grid layout for the tournament tree.
             Parameter name="treeHeight": The height of the tree.
             Parameter name="treeWidth": The width of the tree.
             */

            stackPanel = new StackPanel();
            stackPanel.HorizontalAlignment = HorizontalAlignment.Stretch;
            stackPanel.VerticalAlignment = VerticalAlignment.Stretch;

            //Set the background image for the stack panel
            ImageBrush backgroundBrush = new ImageBrush();
            backgroundBrush.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Assets/Images/Backgrounds/background_waves.png", UriKind.Absolute));
            stackPanel.Background = backgroundBrush;

            for (int rowIndex = 0; rowIndex < treeHeight; rowIndex++)
            {
                Grid myGrid = new Grid();
                myGrid.HorizontalAlignment = HorizontalAlignment.Stretch;
                myGrid.VerticalAlignment = VerticalAlignment.Stretch;

                RowDefinition rowDef = new RowDefinition();
                myGrid.RowDefinitions.Add(rowDef);

                int columnsInThisRow = (int)Math.Pow(2, rowIndex);

                for (int colIndex = 0; colIndex < columnsInThisRow; colIndex++)
                {
                    ColumnDefinition colDef = new ColumnDefinition();
                    myGrid.ColumnDefinitions.Add(colDef);
                    myGrid.ColumnDefinitions[colIndex].Width = new GridLength(1.0 / columnsInThisRow, GridUnitType.Star);
                }

                Border rowBorder = new Border();
                rowBorder.BorderBrush = Brushes.Black;
                rowBorder.BorderThickness = new Thickness(1);
                rowBorder.Child = myGrid;

                stackPanel.Children.Add(rowBorder);

                for (int col = 0; col < columnsInThisRow; col++)
                {
                    Border cellBorder = new Border();
                    cellBorder.BorderBrush = Brushes.Black;
                    cellBorder.BorderThickness = new Thickness(1);

                    Grid.SetRow(cellBorder, 0);
                    Grid.SetColumn(cellBorder, col);
                    myGrid.Children.Add(cellBorder);

                    TextBlock cellContent = new TextBlock
                    {
                        HorizontalAlignment = HorizontalAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Center,
                        Background = new ImageBrush
                        {
                            ImageSource = new BitmapImage(new Uri("pack://application:,,,/Assets/Images/Backgrounds/Input_fields/input_field_raw.png", UriKind.Absolute)),
                            Stretch = Stretch.Fill
                        },
                        Width = 100,
                        Height = 50,
                        TextAlignment = TextAlignment.Center,
                        Foreground = Brushes.White,
                        FontSize = 15,
                        Margin = new Thickness(5),
                        Padding = new Thickness(15)
                    };

                    //Set id for the textblock
                    string blockId = $"TextBlock_{rowIndex}_{col}";

                    TextBlockInfo blockInfo = new TextBlockInfo { Id = blockId, TextBlock = cellContent };
                    textBlockInfos.Add(blockInfo);

                    Grid.SetRow(cellContent, 0);
                    Grid.SetColumn(cellContent, col);
                    myGrid.Children.Add(cellContent);
                }
            }

            this.Content = stackPanel;

            this.Loaded += (sender, e) => UpdateRowHeights();

            this.SizeChanged += (sender, e) => UpdateRowHeights(e.NewSize.Height);
        }
        private void AccessTextBlock(string id, string text)
        {
            /*
             Accesses a TextBlock in the tournament tree and sets its text.
             Parameter name="id": The ID of the TextBlock.
             Parameter name="text": The text to display.
            */

            TextBlockInfo blockInfo = textBlockInfos.Find(info => info.Id == id);
            if (blockInfo != null)
            {
                blockInfo.TextBlock.Text = text;
            }
        }
        private void UpdateRowHeights(double newHeight = 0)
        {
            /*
             Updates the height of the rows in the tournament tree.
             Parameter name="newHeight": The new height of the window.
             */

            double rowHeight;

            if (newHeight > 0)
            {
                rowHeight = (newHeight - SystemParameters.WindowCaptionHeight) / stackPanel.Children.Count;
            }
            else
            {
                rowHeight = (stackPanel.ActualHeight - SystemParameters.WindowCaptionHeight) / stackPanel.Children.Count;
            }

            foreach (Border rowBorder in stackPanel.Children)
            {
                if (rowBorder.Child is Grid rowGrid)
                {
                    rowGrid.RowDefinitions[0].Height = new GridLength(rowHeight, GridUnitType.Pixel);
                }
            }
        }
        private void RowNameUpdaten(int row, string[] rowPlayerNames)
        {
            /*          
             Updates the names of players in a specific row of the tournament tree.
             Parameter: name="row": The row to be updated.
             Parameter: name="rowPlayerNames": The player names array for this row.
             */

            for (int i = 0; i < rowPlayerNames.Length; i++)
            {
                string id = $"TextBlock_{row}_{i}";
                AccessTextBlock(id, rowPlayerNames[i]);
            }
        }
    }
}
