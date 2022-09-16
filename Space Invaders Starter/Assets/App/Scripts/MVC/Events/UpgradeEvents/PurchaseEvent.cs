using DynamicBox.EventManagement;

namespace GalaxyDefenders.MVC
{
    public class PurchaseEvent : GameEvent
    {
        public int num;

        public PurchaseEvent(int Num)
        {
            num = Num;
        }
    }
}
