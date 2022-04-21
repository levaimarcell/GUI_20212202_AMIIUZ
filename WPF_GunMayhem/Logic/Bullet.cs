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
        public double XPosition { get; set; }
        public double YPosition { get; set; }
        public Vector Speed { get; set; }

        public Bullet(double xPosition, double yPosition, Vector speed)
        {
            XPosition = xPosition;
            YPosition = yPosition;
            Speed = speed;
        }

        public bool Move(Size area)
        {

            double newX = XPosition + Speed.X;
            if(newX >= 0 && newX <= area.Width)
            {
                XPosition = newX;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
