﻿using static WPF_GunMayhem.Logic.CharacterLogic;

namespace WPF_GunMayhem.Logic
{
    internal interface IGameModel
    {
        Items[,] GameMatrix { get; set; }
    }
}