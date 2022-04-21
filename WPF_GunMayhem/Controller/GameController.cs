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

        public void KeyDown(Key key)
        {

            
            if (key == Key.Right)
            {
                control.Control(GameLogic.Controls.Right, 1);
            }
            if (key == Key.D)
            {
                control.Control(GameLogic.Controls.Right, 2);
            }
            if (key == Key.Left)
            {
                control.Control(GameLogic.Controls.Left, 1);
            }
            if (key == Key.A)
            {
                control.Control(GameLogic.Controls.Left, 2);
            }
            if (key == Key.Space)
            {
                control.Control(GameLogic.Controls.Shoot, 1);
            }
        }
    }
}
