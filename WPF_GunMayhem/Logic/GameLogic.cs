using System;
using System.Collections.Generic;
using System.Windows;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_GunMayhem.Logic
{
    internal class GameLogic : IGameModel
    {

        public enum Items
        {
            player, air, platform, wall, end
        }

        public enum Controls
        {
            Left, Right, Up, Down, Shoot
        }

        public Items[,] GameMatrix { get; set; }
        public Player Character1 { get; set; }
        public Player Character2 { get; set; }
        public List<Bullet> Bullets { get; set; }

        public event EventHandler Changed;
        Size area;
       
        public void SetupSizes(Size area)
        {
            this.area = area; 
        }

        public void SetupCharacters()
        {
            Character1 = new Player(new Size(area.Width, area.Height),true);
            Character2 = new Player(new Size(area.Width, area.Height),true);
            Bullets = new List<Bullet>();
        }

        public GameLogic()
        {
            SetupSizes(area);
            SetupCharacters();
        }

        public void Control()
        {
            
            if (Character1.Left)
            {
                Character1.MoveLeft(area);
            }
            if (Character1.Right)
            {
                Character1.MoveRigth(area);
            }
            if (Character1.Jump)
            {
                bool jumping = Character1.JumpMove();
                if (!jumping)
                {
                    Character1.Jump = false;
                }
            }
            if (Character1.Fall)
            {
                Character1.FallMove(area);
            }
            if (Character1.Shoot)
            {
                if (Character1.Direction)
                {
                    Bullets.Add(new Bullet(area.Width / 2 + Character1.XPosition, Character1.YPosition, new Vector(10, 0), true));
                    
                }
                else
                {
                    Bullets.Add(new Bullet(area.Width / 2 + Character1.XPosition, Character1.YPosition, new Vector(-10, 0), false));
                }
                Character1.Shoot = false;
            }
        }

        public void TimeStep()
        {
            Control();
            
            for (int i = 0; i < Bullets.Count; i++)
            {
                bool inside = Bullets[i].Move(area);
                if (!inside)
                {
                    Bullets.RemoveAt(i);
                }
            }

            Changed?.Invoke(this, null);
        }
    }
}
