using DynamicBox.EventManagement;
using GalaxyDefenders.Data;

namespace GalaxyDefenders.MVC
{
    public class UpgradeElementsDataFetchEvent : GameEvent
    {
        public UpgradeElementsData UpgradeElementsData;

        public UpgradeElementsDataFetchEvent(UpgradeElementsData upgradeElementsData)
        {
            UpgradeElementsData=upgradeElementsData;
        }
    }
}
