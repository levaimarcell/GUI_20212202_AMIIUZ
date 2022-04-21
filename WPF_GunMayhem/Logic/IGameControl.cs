using static WPF_GunMayhem.Logic.CharacterLogic;

namespace WPF_GunMayhem.Logic
{
    internal interface IGameControl
    {
        void Control(Controls control, int player);
    }
}