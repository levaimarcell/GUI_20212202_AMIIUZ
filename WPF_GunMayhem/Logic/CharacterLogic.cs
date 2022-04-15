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
        private string[] maps;

        public CharacterLogic()
        {
            maps = Directory.GetFiles(Path.Combine(Directory.GetCurrentDirectory(), "Levels"), "*.txt");
            LoadMap(maps.First());
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

        public void Control(Controls control)
        {
            var coords = WhereAmI();
            int i = coords[0];
            int j = coords[1];
            int old_i = i;
            int old_j = j;
            switch (control)
            {
                case Controls.Left:
                    j -= 1;
                    break;
                case Controls.Right:
                    j += 1;
                    break;
                case Controls.Up:
                    i -= 1;
                    break;
                case Controls.Down:
                    i += 1;
                    break;
                case Controls.Shoot:
                    break;
            }

            if (GameMatrix[i, j] == Items.air)
            {
                GameMatrix[i, j] = Items.player;
                GameMatrix[old_i, old_j] = Items.air;
            }
            else if (GameMatrix[i, j] == Items.end)
            {

            }
        }


        private int[] WhereAmI()
        {
            for (int i = 0; i < GameMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < GameMatrix.GetLength(1); j++)
                {
                    if (GameMatrix[i, j] == Items.player)
                    {
                        return new int[] { i, j };
                    }
                }
            }
            return new int[] { -1, -1 };
        }
    }
}
