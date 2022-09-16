using DynamicBox.EventManagement;

public class LivesEvent : GameEvent
{
    private int lives = 3;
    public int result;
    public int variable;

    public LivesEvent(int Variable)
    {
        variable = Variable;
        result=lives + variable;
    }
}
