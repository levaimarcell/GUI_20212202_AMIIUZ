using static WPF_GunMayhem.Logic.GameLogic;

namespace WPF_GunMayhem.Logic
{
    internal interface IGameControl
    {
        void Control(Controls control, int player);
    }
}