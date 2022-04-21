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
        private string[] maps;
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
            maps = Directory.GetFiles(Path.Combine(Directory.GetCurrentDirectory(), "Levels"), "*.txt");
            LoadMap(maps.First());
            SetupSizes(area);
            SetupCharacters();
        }

        private void LoadMap(string path)
        {
            string[] lines = File.ReadAllLines(path);
            GameMatrix = new Items[int.Parse(lines[1]), int.Parse(lines[0])];
            for (int i = 0; i < GameMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < GameMatrix.GetLength(1); j++)
                {
                    GameMatrix[i, j] = ConvertToEnum(lines[i + 2][j]);
                }
            }
        }

        private Items ConvertToEnum(char v)
        {
            switch (v)
            {
                case 'w': return Items.wall;
                case 'e': return Items.end;
                case 'p': return Items.platform;
                case 'S': return Items.player;
                default: return Items.air;
            }
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
                    Bullets.Add(new Bullet(area.Width / 2 + Character1.XPosition, Character1.YPosition, new Vector(10, 0)));
                    
                }
                else
                {
                    Bullets.Add(new Bullet(area.Width / 2 + Character1.XPosition, Character1.YPosition, new Vector(-10, 0)));
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

            double rectHeight = area.Height / GameMatrix.GetLength(0);

            for (int i = 0; i < GameMatrix.GetLength(0); i++)
            {               
                    if (Character1.YPosition == i * rectHeight)
                    {
                    Character1.Fall = false;
                    }
            }

                    Changed?.Invoke(this, null);
        }
    }
}
