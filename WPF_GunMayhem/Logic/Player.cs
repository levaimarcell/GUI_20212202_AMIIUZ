using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace WPF_GunMayhem.Logic
{
    internal class Player
    {
        public double XPosition { get; set; }
        public double YPosition { get; set; }

        public double MoveStart { get; set; }
        public bool Direction { get; set; }

        public bool Right { get; set; }
        public bool Left { get; set; }
        public bool Down { get; set; }
        public bool Jump { get; set; }
        public int JumpCount { get; set; }
        public bool Fall { get; set; }
        public bool Shoot { get; set; }
        public int Life { get; set; }

        public Player(double xPosition, double yPosition, bool direction)
        {
            XPosition = xPosition;
            YPosition = yPosition;
            MoveStart = 0;
            Direction = direction;
            Jump = false;
            JumpCount = 0;
            Right = false;
            Left = false;
            Down = false;
            Fall = true;
            Shoot = false;
            Life = 2;
        }

        public bool JumpMove(Size area)
        {

            double newX = YPosition - area.Height / 70;
            if (YPosition >= MoveStart - area.Height / 7)
            {
                YPosition = newX;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DownMove(Size area)
        {
            double newX = YPosition + area.Height / 50;
            if (YPosition <= MoveStart + area.Height / 8)
            {
                YPosition = newX;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void FallMove(Size area, List<Platform> Platforms)
        {
            if(YPosition <= area.Height)
            {
                bool falling = true;
                Rect characterRect = new Rect(XPosition, YPosition + area.Height / 10, area.Height / 10, 0);
                foreach (var item in Platforms)
                {
                    Rect platformRect = new Rect(item.XPosition, item.YPosition, item.Width, item.Height);
                    if (characterRect.IntersectsWith(platformRect))
                    {
                        falling = false;
                        JumpCount = 0;
                    }
                }
                if (falling)
                {
                    Fall = true;
                    YPosition += area.Height / 80;
                }
                else
                {
                    Fall = false;
                }
            }
            else
            {
                YPosition = 0;
                XPosition = area.Width / 2;
                Life--;
            }
        }

        public void MoveRigth(Size area)
        {
            XPosition += (area.Width / 200);
            Direction = true;
            Fall = true;
        }

        public void MoveLeft(Size area)
        {
            XPosition -= (area.Width / 200);
            Direction = false;
            Fall = true;
        }
    }
}
