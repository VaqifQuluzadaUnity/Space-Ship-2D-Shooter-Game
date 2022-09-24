using DynamicBox.EventManagement;
using GalaxyDefenders.Data;

namespace GalaxyDefenders.MVC
{
    public class PricesDataFetchEvent : GameEvent
    {
        public PricesData PricesData;

        public PricesDataFetchEvent(PricesData pricesData)
        {
            PricesData = pricesData;
        }
    }
}
