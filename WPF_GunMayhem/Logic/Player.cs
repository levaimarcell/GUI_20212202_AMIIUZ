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
        public double XPosition { get; set; }
        public double YPosition { get; set; }

        public bool Direction { get; set; } 

        public Player(Size area, double xPosition, double yPosition, bool direction)
        {
            XPosition = xPosition;
            YPosition = yPosition;
            //Center = new Point((int)area.Width, (int)area.Height);
            Direction = direction;
        }
    }
}
