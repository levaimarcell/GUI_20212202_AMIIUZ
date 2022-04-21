using System;
using static WPF_GunMayhem.Logic.CharacterLogic;

namespace WPF_GunMayhem.Logic
{
    internal interface IGameModel
    {
        Items[,] GameMatrix { get; set; }

        Player Character1 { get; set; }
        Player Character2 { get; set; }
    }
}