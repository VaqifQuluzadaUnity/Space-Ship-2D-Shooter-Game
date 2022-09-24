using DynamicBox.EventManagement;
using GalaxyDefenders.Data;

namespace GalaxyDefenders.MVC
{
    public class CheckFetchEvent : GameEvent
    {
        public PointData PointData;

        public CheckFetchEvent(PointData pointData)
        {
            PointData = pointData;
        }
    }
}
