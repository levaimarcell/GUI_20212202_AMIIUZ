using System;
using System.Collections.Generic;
using System.Windows;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_GunMayhem.Logic
{
    internal class GameLogic : IGameModel, IGameControl
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
            Character1 = new Player(new Size(area.Width, area.Height), 20, true);
            Character2 = new Player(new Size(area.Width, area.Height), 20, true);
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


        public void Control(Controls control, int player)
        {
            
            switch (control)
            {
                case Controls.Left:
                    if(player == 1)
                    {
                        Character1.XPosition -= 4;
                        Character1.Direction = false;
                    }
                    else if(player == 2)
                    {
                        Character2.XPosition -= 4;
                        Character2.Direction = false;
                    }
                    break;
                case Controls.Right:
                    if (player == 1)
                    {
                        Character1.XPosition += 4;
                        Character1.Direction = true;
                    }
                    else if (player == 2)
                    {
                        Character2.XPosition += 4;
                        Character2.Direction = true;
                    }
                    break;
                case Controls.Up:
                   
                    break;
                case Controls.Down:
                  
                    break;
                case Controls.Shoot:
                    NewShoot();
                    break;
                default:
                    break;
            }
            Changed?.Invoke(this, null);
        }

        private void NewShoot()
        {
            if (Character1.Direction)
            {
                Bullets.Add(new Bullet(new Point(area.Width / 2 + Character1.XPosition, area.Height / 2), new Vector(10, 0)));
            }
            else
            {
                Bullets.Add(new Bullet(new Point(area.Width / 2 + Character1.XPosition, area.Height / 2), new Vector(-10, 0)));
            }
            
        }

        public void TimeStep()
        {
            for(int i = 0; i < Bullets.Count; i++)
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
