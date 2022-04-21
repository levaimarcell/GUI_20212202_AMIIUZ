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
        bool left1, left2, right1, right2;

        public GameController(IGameControl control)
        {
            this.control = control;
        }

        public void KeyDown(Key key)
        {

            
            if (key == Key.Right)
            {
                right1 = true;
                control.Control(CharacterLogic.Controls.Right, 1);
            }
            if (key == Key.D)
            {
                right2 = true;
                control.Control(CharacterLogic.Controls.Right, 2);
            }
            if (key == Key.Left)
            {
                left1 = true;
                control.Control(CharacterLogic.Controls.Left, 1);
            }
            if (key == Key.A)
            {
                left2 = true;
                control.Control(CharacterLogic.Controls.Left, 2);
            }

            /*switch (key)
            {
                case Key.Up:
                    control.Control(CharacterLogic.Controls.Up, 1);
                    break;
                case Key.W:
                    control.Control(CharacterLogic.Controls.Up, 2);
                    break;
                case Key.Down:
                    control.Control(CharacterLogic.Controls.Down, 1);
                    break;
                case Key.S:
                    control.Control(CharacterLogic.Controls.Down, 2);
                    break;
                case Key.Left:
                    control.Control(CharacterLogic.Controls.Left, 1);
                    break;
                case Key.A:
                    control.Control(CharacterLogic.Controls.Left, 2);
                    break;
                case Key.Right:
                    control.Control(CharacterLogic.Controls.Right, 1);
                    break;
                case Key.D:
                    control.Control(CharacterLogic.Controls.Right, 2);
                    break;

            }*/
        }
        public void KeyUp(Key key)
        {


            if (key == Key.Right)
            {
                right1 = false;
                
            }
            if (key == Key.D)
            {
                right2 = false;
                
            }
            if (key == Key.Left)
            {
                left1 = false;
                
            }
            if (key == Key.A)
            {
                left2 = false;
                
            }
        }
    }
}
