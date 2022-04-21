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
        public System.Drawing.Point Center { get; set; }
        public double Speed { get; set; }
        public bool Direction { get; set; } 

        public Player(Size area, double speed, bool direction)
        {
            Speed = speed;
            Center = new System.Drawing.Point((int)area.Width, (int)area.Height);
            Direction = direction;
        }
    }
}
