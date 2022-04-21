using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_GunMayhem.Logic
{
    internal class CharacterLogic : IGameModel, IGameControl
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

        private string[] maps;
        System.Windows.Size area;
       
        public void SetupSizes(System.Windows.Size area)
        {
            this.area = area; 
        }

        public void SetupCharacters()
        {
            Character1 = new Player(new System.Windows.Size(area.Width, area.Height), 20, true);
            Character2 = new Player(new System.Windows.Size(area.Width, area.Height), 20, true);
        }

      
        public CharacterLogic()
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
                        Character1.Speed -= 4;
                        Character1.Direction = false;
                    }
                    else if(player == 2)
                    {
                        Character2.Speed -= 4;
                        Character2.Direction = false;
                    }
                    break;
                case Controls.Right:
                    if (player == 1)
                    {
                        Character1.Speed += 4;
                        Character1.Direction = true;
                    }
                    else if (player == 2)
                    {
                        Character2.Speed += 4;
                        Character2.Direction = true;
                    }
                    break;
                case Controls.Up:
                   
                    break;
                case Controls.Down:
                  
                    break;
                case Controls.Shoot:
                    break;
            }
        }
    }
}
