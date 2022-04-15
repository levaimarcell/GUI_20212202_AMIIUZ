using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF_GunMayhem.Logic;

namespace WPF_GunMayhem.Controller
{
    internal class GameController
    {
        IGameControl control;

        public GameController(IGameControl control)
        {
            this.control = control;
        }

        public void KeyPressed(Key key)
        {
            switch (key)
            {
                case Key.Up:
                    control.Control(CharacterLogic.Controls.Up);
                    break;
                case Key.Down:
                    control.Control(CharacterLogic.Controls.Down);
                    break;
                case Key.Left:
                    control.Control(CharacterLogic.Controls.Left);
                    break;
                case Key.Right:
                    control.Control(CharacterLogic.Controls.Right);
                    break;
            }
        }
    }
}
