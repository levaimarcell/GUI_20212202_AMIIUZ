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
                
            }
            if (key == Key.Left)
            {
                model.Character1.Left = true;
            }
            if (key == Key.A)
            {
                
            }
            if(key == Key.Up)
            {
                model.Character1.JumpStart = model.Character1.YPosition;
                model.Character1.Jump = true;
            }
            if (key == Key.Space)
            {
               model.Character1.Shoot = true;
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
               
            }
            if (key == Key.Left)
            {
                model.Character1.Left = false;
            }
            if (key == Key.A)
            {
                
            }
            if (key == Key.Up)
            {
                //model.Character1.Jump = false;
            }
            if (key == Key.Space)
            {
                model.Character1.Shoot = false;
            }
        }
    }
}
