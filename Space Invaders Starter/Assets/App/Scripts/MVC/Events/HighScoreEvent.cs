using DynamicBox.EventManagement;

namespace GalaxyDefenders.MVC
{
    public class HighScoreEvent : GameEvent
    {
        public int BestPoints;

        public HighScoreEvent(int bestPoints)
        {
            BestPoints = bestPoints;
        }
    }
}