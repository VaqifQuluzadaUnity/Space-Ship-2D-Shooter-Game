using DynamicBox.EventManagement;

namespace GalaxyDefenders.MVC
{
    public class PricesEvent : GameEvent
    {
        public int movementPrice;
        public int bulletPrice;

        public PricesEvent(int MovementPrice, int BulletPrice)
        {
            movementPrice = MovementPrice;
            bulletPrice = BulletPrice;
        }
    }
}
