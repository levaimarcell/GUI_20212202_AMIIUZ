using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WPF_GunMayhem.Logic
{
    internal class Player
    {
        public Point Center { get; set; }
        public double XPosition { get; set; }
        public bool Direction { get; set; } 

        public Player(Size area, double xPosition, bool direction)
        {
            XPosition = xPosition;
            Center = new Point((int)area.Width, (int)area.Height);
            Direction = direction;
        }
    }
}
