using DynamicBox.EventManagement;

public class TriggerGameOverEvent : GameEvent
{
    public bool failure;

    public TriggerGameOverEvent(bool Failure)
    {
        failure = Failure;
    }
}
