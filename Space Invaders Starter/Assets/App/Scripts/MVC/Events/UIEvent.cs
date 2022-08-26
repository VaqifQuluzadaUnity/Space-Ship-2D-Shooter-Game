using DynamicBox.EventManagement;

namespace GalaxyDefenders.MVC
{
    public class UIEvent : GameEvent
    {
        public int Points;
        public int BestPoints;

        public UIEvent(int points, int bestPoints)
        {
            Points = points;
            BestPoints = bestPoints;
        }
    }
}
