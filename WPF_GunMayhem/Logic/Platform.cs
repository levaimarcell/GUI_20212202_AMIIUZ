using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_GunMayhem.Logic
{
    internal class Platform
    {
        public double XPosition { get; set; }
        public double YPosition { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }

        public Platform(double xPosition, double yPosition, double width, double height)
        {
            XPosition = xPosition;
            YPosition = yPosition;
            Width = width;
            Height = height;
        }
    }
}
