using DynamicBox.EventManagement;

public class UIDataEvent : GameEvent
{
    public int bestScore;

    public UIDataEvent(int BestScore)
    {
        bestScore = BestScore;
    }
}
