using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sea_Battle.Models
{
    public class Ship
    {
        /*
          The Ship class represents a ship with name, length, coordinates, character status and display path.
         */

        public string name;
        public int length;
        public int[,] cords;
        public bool drowend;
        public string path;
        

        public Ship(string name, int length, string path)
        {
            this.name = name;
            this.length = length;
            this.path = path;
            cords = new int[length, 2];
        }
    }
}
