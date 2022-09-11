using DynamicBox.EventManagement;

namespace GalaxyDefenders.MVC
{
    public class BestScoreDataEvent : GameEvent
    {
        public int bestScore;

        public BestScoreDataEvent(int BestScore)
        {
            bestScore = BestScore;
        }
    }
}
