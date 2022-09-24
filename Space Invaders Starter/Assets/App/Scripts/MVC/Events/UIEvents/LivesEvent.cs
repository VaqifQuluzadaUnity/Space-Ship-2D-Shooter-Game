using DynamicBox.EventManagement;

public class LivesEvent : GameEvent
{
    public int lives;

    public LivesEvent(int variable)
    {
        lives = variable;
    }
}
