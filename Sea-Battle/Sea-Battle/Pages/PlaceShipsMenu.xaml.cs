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
using Sea_Battle.Models;
using System.Runtime.CompilerServices;

namespace Sea_Battle.Pages
{
    /// <summary>
    /// Interaktionslogik für PlaceShipsMenu.xaml
    /// </summary>
    public partial class PlaceShipsMenu : Page
    {
        public int[,] grid = new int[10, 10]; //Game field 10x10

        private bool randomPlaced = false;

        public PlaceShipsMenu()
        {
            InitializeComponent();

            //Initialization of the ship objects
            StaticDataService.listOfShips = new Ship[5];
            Ship ship1 = new Ship("Ship_2", 2, "pack://application:,,,/Assets/Images/Icons/icon_2_ship.png");
            Ship ship2 = new Ship("Ship_3.1", 3, "pack://application:,,,/Assets/Images/Icons/icon_3.1_ship.png");
            Ship ship3 = new Ship("Ship_3.2", 3, "pack://application:,,,/Assets/Images/Icons/icon_3.2_ship.png");
            Ship ship4 = new Ship("Ship_4", 4, "pack://application:,,,/Assets/Images/Icons/icon_4_ship.png");
            Ship ship5 = new Ship("Ship_5", 5, "pack://application:,,,/Assets/Images/Icons/icon_5_ship.png");

            StaticDataService.listOfShips[0] = ship1;
            StaticDataService.listOfShips[1] = ship2;
            StaticDataService.listOfShips[2] = ship3;
            StaticDataService.listOfShips[3] = ship4;
            StaticDataService.listOfShips[4] = ship5;
        }

        //User interface methods
        private async void ReadyButton_Click(object sender, RoutedEventArgs e)
        {
            /*
             Handles the event when the "Ready" button is clicked.
            */

            //Button press animation
            ReadyButtonImage.Source = new BitmapImage(new Uri("/Assets/Images/Buttons/button_ready_down.png", UriKind.RelativeOrAbsolute));
            await Task.Delay(300);

            StaticDataService.MainFrame.Navigate(new Uri("/Pages/FightMenu.xaml", UriKind.Relative));
        }
        private async void RandomButton_Click(object sender, RoutedEventArgs e)
        {
            /*
             Handles the event when the "Random" button is clicked.
            */

            //Button press animation
            RandomButtonImage.Source = new BitmapImage(new Uri("/Assets/Images/Buttons/button_random_down.png", UriKind.RelativeOrAbsolute));

            //Place the ships
            PlaceTheShipsRandomly();

            await Task.Delay(300);
            RandomButtonImage.Source = new BitmapImage(new Uri("/Assets/Images/Buttons/button_random.png", UriKind.RelativeOrAbsolute));
        }

        //Random placement
        private void PlaceTheShipsRandomly()
        {
            randomPlaced = true;

            //Remove all existing ship images from the canvas
            var shipTagsToRemove = new List<string> { "Ship_2", "Ship_3.1", "Ship_3.2", "Ship_4", "Ship_5" };
            var shipImagesToRemove = myCanvas.Children.OfType<System.Windows.Controls.Image>()
                .Where(img => shipTagsToRemove.Contains(img.Tag?.ToString()))
                .ToList();

            foreach (var image in shipImagesToRemove)
            {
                myCanvas.Children.Remove(image);
            }

            //Set background of all cells to white
            foreach (var child in gameGrid.Children)
            {
                if (child is Border border)
                {
                    border.Background = Brushes.Transparent;
                }
            }

            grid = new int[10, 10];
            Random random = new Random();

            //Place ships
            foreach (Ship ship in StaticDataService.listOfShips)
            {
                bool placed = false;

                while (!placed)
                {
                    int x = random.Next(1, 11);
                    int y = random.Next(1, 11);
                    int direction = random.Next(1, 3); // 1 = horizontal, 2 = vertical

                    if (CanPlaceShip(x, y, direction, ship.length))
                    {
                        PlaceShip(ship, x, y, direction);
                        placed = true;
                    }
                }
            }

            //Output informations
            DisplayPlacementInfomations();
            

            //Puts the ships on the grid
            SetShipInGrid(StaticDataService.listOfShips[0]);
            SetShipInGrid(StaticDataService.listOfShips[1]);
            SetShipInGrid(StaticDataService.listOfShips[2]);
            SetShipInGrid(StaticDataService.listOfShips[3]);
            SetShipInGrid(StaticDataService.listOfShips[4]);

        }
        private void SetShipInGrid(Ship ship)
        {
            /*
             This method calculates the position of the ship in the grid and passes this on to the DrawShip method
             */

            int column = ship.cords[0, 0];
            int row = ship.cords[0, 1];
            int direction = 0;

            //Calculate the direction of the ship
            if (ship.cords[1, 0] == column) direction = 2; //Vertical
            if (ship.cords[1, 1] == row) direction = 1; //Horizontal

            Border myBorder = (Border)gameGrid.Children
                .OfType<Border>()
                .FirstOrDefault(b => Grid.GetRow(b) == row && Grid.GetColumn(b) == column);

            if (myBorder != null)
            {
                Point positionInGrid = myBorder.TranslatePoint(new Point(0, 0), gameGrid);
                Point positionInCanvas = gameGrid.TranslatePoint(positionInGrid, myCanvas);

                double width = myBorder.ActualWidth;
                double height = myBorder.ActualHeight;

                DrawShip(positionInCanvas, Convert.ToInt32(width), Convert.ToInt32(height), ship, direction);
            }
        }
        private void DrawShip(Point position, int width, int height, Ship ship, int direction)
        {
            /*
             This method creates a Shiff Image Object and adds it to the canvas
             */

            //Creates a new ship image
            System.Windows.Controls.Image shipImage = new System.Windows.Controls.Image
            {
                Source = new BitmapImage(new Uri(ship.path)),
                Width = width,
                Height = height * ship.length,
                Tag = ship.name
            };


            if (direction == 2) //Alignment is vertical
            {
                Canvas.SetLeft(shipImage, position.X);
                Canvas.SetTop(shipImage, position.Y);
            }
            else //Alignment is horizontal
            {
                Canvas.SetLeft(shipImage, position.X + (0.5 * (ship.length - 1) * width));
                Canvas.SetTop(shipImage, position.Y - (0.5 * (ship.length - 1)) * width);

                //90 degrees rotation of the image
                RotateTransform rotateTransform = new RotateTransform(90, width / 2, height * ship.length / 2); 
                shipImage.RenderTransform = rotateTransform;
            }

            //Adds the new image to the canvas
            myCanvas.Children.Add(shipImage);
        }

        //Check ship position
        private bool CanPlaceShip(int x, int y, int direction, int length)
        {
            /*
             This method Checks that the ship fits into the board and does not overlap other ships
             */
            if (direction == 1) //Horizontal
            {
                if (x + length - 1 > 10) return false;
                for (int i = 0; i < length; i++)
                {
                    if (grid[x - 1, y - 1] == 1) return false;
                    x++;
                }
            }
            else if (direction == 2) //Vertical
            {
                if (y + length - 1 > 10) return false;
                for (int i = 0; i < length; i++)
                {
                    if (grid[x - 1, y - 1] == 1) return false;
                    y++;
                }
            }

            return true;
        }
        private void PlaceShip(Ship ship, int x, int y, int direction)
        {
            /*
             Place ship on the game field and save coordinates
             */
            for (int i = 0; i < ship.length; i++)
            {
                ship.cords[i, 0] = x;
                ship.cords[i, 1] = y;
                grid[x - 1, y - 1] = 1;

                if (direction == 1) x++; //Horizontal
                else if (direction == 2) y++; //Vertical
            }
        }

        //Drag and Drop placement

        //Helper
        private void DisplayPlacementInfomations()
        {
            /*
             outputs the information about the placed ships
             */

            // Die Koordinaten ausgeben
            for (int i = 0; i < StaticDataService.listOfShips.Length; i++)
            {
                Console.WriteLine("Schiff " + (i + 1) + ":");
                for (int j = 0; j < StaticDataService.listOfShips[i].cords.GetLength(0); j++)
                {
                    Console.WriteLine("x" + (j + 1) + " = " + StaticDataService.listOfShips[i].cords[j, 0]);
                    Console.WriteLine("y" + (j + 1) + " = " + StaticDataService.listOfShips[i].cords[j, 1]);
                }
            }

            //Grid Ausgeben
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    Console.Write(grid[j, i].ToString());
                }
                Console.WriteLine();
            }

            // Grid ausfüllen
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    if (grid[j, i] == 1)
                    {
                        int row = i + 1;
                        int column = j + 1;

                        foreach (var child in gameGrid.Children)
                        {
                            if (child is Border border && Grid.GetRow(border) == row && Grid.GetColumn(border) == column)
                            {
                                border.Background = Brushes.Yellow;
                                break;
                            }
                        }
                    }
                }
            }
        }
    }
}
