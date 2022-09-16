using DynamicBox.EventManagement;

namespace GalaxyDefenders.MVC
{
    public class UpgradeEvent : GameEvent
    {
        public int number;

        public UpgradeEvent(int Number)
        {
            number = Number;
        }
    }
}
