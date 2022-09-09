using DynamicBox.EventManagement;

namespace GalaxyDefenders.MVC
{
    public class UIDataEvent : GameEvent
    {
        public int bestScore;

        public UIDataEvent(int BestScore)
        {
            bestScore = BestScore;
        }
    }
}
