using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_GunMayhem.Logic
{
    internal class CharacterLogic : IGameModel
    {
        public enum Controls
        {
            Left, Right, Up, Down, Shoot
        }
        public double MovementX { get; set; }
        public double MovementY { get; set; }

        public void Control(Controls control)
        {
            switch (control)
            {
                case Controls.Left:
                    MovementX -= 2;
                    break;
                case Controls.Right:
                    MovementX += 2;
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
