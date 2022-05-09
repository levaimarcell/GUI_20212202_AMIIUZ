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
        IGameModel model;
        public GameController( IGameModel model)
        {
            this.model = model;
        }

        public void KeyDown(Key key)
        {
            if (key == Key.Right)
            {
                model.Character1.Right = true;
            }
            if (key == Key.D)
            {
                model.Character2.Right = true;
            }
            if (key == Key.Left)
            {
                model.Character1.Left = true;
            }
            if (key == Key.A)
            {
                model.Character2.Left = true;
            }
            if(key == Key.Up)
            {
                model.Character1.MoveStart = model.Character1.YPosition;
                model.Character1.Jump = true;
                model.Character1.JumpCount++;
            }
            if (key == Key.W)
            {
                model.Character2.MoveStart = model.Character2.YPosition;
                model.Character2.Jump = true;
                model.Character2.JumpCount++;
            }
            if (key == Key.Down)
            {
                model.Character1.MoveStart = model.Character1.YPosition;
                model.Character1.Down = true;
            }
            if (key == Key.S)
            {
                model.Character2.MoveStart = model.Character2.YPosition;
                model.Character2.Down = true;
            }
            if (key == Key.Enter)
            {
               model.Character1.Shoot = true;
            }
            if (key == Key.Space)
            {
                model.Character2.Shoot = true;
            }

        }

        public void KeyUp(Key key)
        {
            if (key == Key.Right)
            {
                model.Character1.Right = false;
            }
            if (key == Key.D)
            {
                model.Character2.Right = false;
            }
            if (key == Key.Left)
            {
                model.Character1.Left = false;
            }
            if (key == Key.A)
            {
                model.Character2.Left = false;
            }
            if (key == Key.Enter)
            {
                model.Character1.Shoot = false;
            }
            if (key == Key.Space)
            {
                model.Character2.Shoot = false;
            }
        }
    }
}
