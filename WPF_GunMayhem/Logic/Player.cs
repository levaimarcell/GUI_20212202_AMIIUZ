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

        public double JumpStart { get; set; }
        public bool Direction { get; set; }

        public bool Right { get; set; }
        public bool Left { get; set; }
        public bool Jump { get; set; }
        public bool Fall { get; set; }
        public bool Shoot { get; set; }

        public Player(Size area, bool direction)
        {
            XPosition = 0;
            YPosition = 0;
            JumpStart = 0;
            Direction = direction;
            Jump = false;
            Right = false;
            Left = false;
            Fall = true;
            Shoot = false;
        }

        public bool JumpMove()
        {
            double newX = YPosition - 4;
            if (YPosition >= JumpStart - 20)
            {
                YPosition = newX;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void FallMove(Size area)
        {
            if(YPosition <= area.Height)
            {
                YPosition += 4;
            }
            else
            {
                YPosition = 0;
            }
            
        }

        public void MoveRigth(Size area)
        {
            XPosition += (area.Width / 200);
            Direction = true;
        }

        public void MoveLeft(Size area)
        {
            XPosition -= (area.Width / 200);
            Direction = false;
        }
    }
}
