using DynamicBox.EventManagement;

namespace GalaxyDefenders.MVC
{
    public class ScoreEvent : GameEvent
    {
        public int Points;

        public ScoreEvent(int points)
        {
            Points = points;
        }
    }
}
