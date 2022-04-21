using System;
using System.Collections.Generic;
using static WPF_GunMayhem.Logic.GameLogic;

namespace WPF_GunMayhem.Logic
{
    internal interface IGameModel
    {
        Items[,] GameMatrix { get; set; }

        event EventHandler Changed;
        Player Character1 { get; set; }
        Player Character2 { get; set; }
        List<Bullet> Bullets { get; set; }
    }
}