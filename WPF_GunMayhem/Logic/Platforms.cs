using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_GunMayhem.Logic
{
    internal class Platforms
    {
        public double XPosition { get; set; }
        public double YPosition { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }

        public Platforms(double xPosition, double yPosition)
        {
            XPosition = xPosition;
            YPosition = yPosition;
            Width = 200;
            Height = 40;
        }
    }
}
