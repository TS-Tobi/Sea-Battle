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

        private Point initialPosition;
        private bool isDragging = false;
        private Point startPoint; //Start point of the drag
        private UIElement draggedElement; //Reference to the element being dragged

        private bool randomPlaced = false;
        private int placeDirection = 2; //Default Vertikal

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

            if (ChecksIfAllShipsPlaced())
            {
                StaticDataService.MainFrame.Navigate(new Uri("/Pages/FightMenu.xaml", UriKind.Relative));
            }
            else
            {
                ReadyButtonImage.Source = new BitmapImage(new Uri("/Assets/Images/Buttons/button_ready.png", UriKind.RelativeOrAbsolute));
            }
            
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

            //Set background of all cells to transparent
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

            //Puts the ships on the grid
            SetShipInGrid(StaticDataService.listOfShips[0]);
            SetShipInGrid(StaticDataService.listOfShips[1]);
            SetShipInGrid(StaticDataService.listOfShips[2]);
            SetShipInGrid(StaticDataService.listOfShips[3]);
            SetShipInGrid(StaticDataService.listOfShips[4]);

            //Output informations
            DisplayPlacementInfomations();

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
        private void ShipMouseDown(object sender, MouseEventArgs e)
        {
            /*
              Handles the event when the left mouse button is pressed to place a ship
              */
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                isDragging = true;
                startPoint = e.GetPosition(myCanvas);
                draggedElement = sender as UIElement;
                draggedElement.CaptureMouse();

                initialPosition = new Point(Canvas.GetLeft(draggedElement), Canvas.GetTop(draggedElement));
            }
        }
        private void ShipMouseMove(object sender, MouseEventArgs e)
        {
            /*
             Handles the event when a selected ship is moved
             */

            if (isDragging && draggedElement != null)
            {
                Point currentPoint = e.GetPosition(myCanvas);

                //Calculate the new position
                var transform = draggedElement.RenderTransform as TransformGroup;
                if (transform == null)
                {
                    transform = new TransformGroup();
                    draggedElement.RenderTransform = transform;
                }

                RotateTransform rotateTransform = transform.Children.OfType<RotateTransform>().FirstOrDefault();
                if (rotateTransform == null)
                {
                    rotateTransform = new RotateTransform();
                    transform.Children.Add(rotateTransform);
                }

                //Console.WriteLine("MouseMove:" + placeDirection);
                if (placeDirection == 1)
                {
                    rotateTransform.Angle = 90; //Rotate 90 degrees
                }
                else if (placeDirection == 2 && rotateTransform.Angle == 90)
                {
                    rotateTransform.Angle = 0; //Set the rotation back to 0 degrees
                }

                var translateTransform = transform.Children.OfType<TranslateTransform>().FirstOrDefault();
                if (translateTransform == null)
                {
                    translateTransform = new TranslateTransform();
                    transform.Children.Add(translateTransform);
                }

                translateTransform.X = currentPoint.X - startPoint.X;
                translateTransform.Y = currentPoint.Y - startPoint.Y;
            }
        }
        private void ShipMouseUp(object sender, MouseEventArgs e)
        {
            /*
             Handles the event when a selected ship is dropped
             */
            if (randomPlaced)
            {
                //Remove all existing ship images from the canvas
                var shipTagsToRemove = new List<string> { "Ship_2", "Ship_3.1", "Ship_3.2", "Ship_4", "Ship_5" };
                var shipImagesToRemove = myCanvas.Children.OfType<System.Windows.Controls.Image>()
                    .Where(img => shipTagsToRemove.Contains(img.Tag?.ToString()))
                    .ToList();

                foreach (var image in shipImagesToRemove)
                {
                    myCanvas.Children.Remove(image);
                }


                //Set background of all cells to transparent
                foreach (var child in gameGrid.Children)
                {
                    if (child is Border border)
                    {
                        border.Background = Brushes.Transparent;
                    }
                }
                grid = new int[10, 10];
                randomPlaced = false;
            }

            isDragging = false;
            ((UIElement)sender).ReleaseMouseCapture();


            //Check if the ship is released over the target grid
            Point dropPosition = e.GetPosition(gameGrid);

            if (gameGrid != null)
            {
                if (dropPosition.X < 0 || dropPosition.Y < 0 ||
                    dropPosition.X > gameGrid.ActualWidth || dropPosition.Y > gameGrid.ActualHeight)
                {
                    Canvas.SetLeft(draggedElement, initialPosition.X);
                    Canvas.SetTop(draggedElement, initialPosition.Y);
                    draggedElement.RenderTransform = null;
                }
                else
                {
                    int columnIndex = (int)(dropPosition.X / (gameGrid.ActualWidth / gameGrid.ColumnDefinitions.Count));
                    int rowIndex = (int)(dropPosition.Y / (gameGrid.ActualHeight / gameGrid.RowDefinitions.Count));

                    string elementName = "";
                    if (draggedElement != null)
                    {
                        // Elementname (sofern gesetzt)
                        elementName = (draggedElement as FrameworkElement)?.Name;
                    }

                    switch (elementName)
                    {
                        case "Ship_2":
                            PlaceShipDragAndDrop(0, columnIndex, rowIndex);
                            break;

                        case "Ship_3_1":
                            PlaceShipDragAndDrop(1, columnIndex, rowIndex);
                            break;

                        case "Ship_3_2":
                            PlaceShipDragAndDrop(2, columnIndex, rowIndex);
                            break;

                        case "Ship_4":
                            PlaceShipDragAndDrop(3, columnIndex, rowIndex);
                            break;

                        case "Ship_5":
                            PlaceShipDragAndDrop(4, columnIndex, rowIndex);
                            break;
                    }
                }
            }
        }

        //Helper methods
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
        private void PlaceShipDragAndDrop(int shipIndex, int columnIndex, int rowIndex)
        {
            /*
             This method places a ship at its index in a grid with a given position
             */

            //Reset previous ships
            RemoveImagesByTag(StaticDataService.listOfShips[shipIndex].name);

            if ((StaticDataService.listOfShips[shipIndex].cords[0, 0] != 0))
            {
                for (int i = 0; i < StaticDataService.listOfShips[shipIndex].cords.GetLength(0); i++)
                {
                    grid[StaticDataService.listOfShips[shipIndex].cords[i, 0] - 1, StaticDataService.listOfShips[shipIndex].cords[i, 1] - 1] = 0;
                }
            }

            if (CanPlaceShip(columnIndex, rowIndex, placeDirection, StaticDataService.listOfShips[shipIndex].length))
            {
                PlaceShip(StaticDataService.listOfShips[shipIndex], columnIndex, rowIndex, placeDirection);
                SetShipInGrid(StaticDataService.listOfShips[shipIndex]);
                draggedElement.RenderTransform = null;
            }
            else
            {
                Canvas.SetLeft(draggedElement, initialPosition.X);
                Canvas.SetTop(draggedElement, initialPosition.Y);
                draggedElement.RenderTransform = null;
            }
        }
        private void RemoveImagesByTag(string tag)
        {
            /*
             This method removes all images of a canvas with the passed tag
             */
            if (string.IsNullOrEmpty(tag))
            {
                return;
            }

            //Find all images in the canvas that have the specified tag
            var imagesToRemove = myCanvas.Children.OfType<System.Windows.Controls.Image>()
                .Where(img => img.Tag?.ToString() == tag)
                .ToList();

            foreach (var image in imagesToRemove)
            {
                myCanvas.Children.Remove(image);
            }
        }
        private bool ChecksIfAllShipsPlaced()
        {
           foreach(Ship ship in StaticDataService.listOfShips)
           {
                for (int i = 0; i < ship.length; i++)
                {
                    if (ship.cords[i, 0] == 0)
                    {
                        ErrorTextBlock.Text = "Not all Ships were placed: " + ship.name;
                        return false;
                    }
                }
           }
            return true;
        }
        public void  Window_KeyDown(object sneder, KeyEventArgs e)
        {
            /*
             This method is called when a key is pressed in the current window
             */

            if (e.Key == Key.D1) //When key “1” is pressed
            {
                //PlaceDirectionTextBlockHorizontal.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#00FF00"));
                PlaceDirectionTextBlockHorizontal.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#00FF00"));
                PlaceDirectionTextBlockVertical.Foreground = Brushes.White;
                placeDirection = 1;
                Console.WriteLine(placeDirection);
            }
            else if (e.Key == Key.D2) //When key “2” is pressed
            {
                PlaceDirectionTextBlockVertical.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#00FF00"));
                PlaceDirectionTextBlockHorizontal.Foreground = Brushes.White;
                placeDirection = 2;
            }
        }
    }
}
