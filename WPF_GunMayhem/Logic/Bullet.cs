using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WPF_GunMayhem.Logic
{
    internal class Bullet
    {
        public Point Center { get; set; }
        public Vector Speed { get; set; }

        public Bullet(Point center, Vector speed)
        {
            Center = center;
            Speed = speed;
        }

        public bool Move(Size area)
        {
            Point newCenter = new Point((int)Center.X + (int)Speed.X, (int)Center.Y);
            if(newCenter.X >= 0 && newCenter.X <= area.Width)
            {
                Center = newCenter;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
