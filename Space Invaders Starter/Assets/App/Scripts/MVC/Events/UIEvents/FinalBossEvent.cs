using DynamicBox.EventManagement;

public class FinalBossEvent : GameEvent
{
    public int finalBossHealth = 100;

    public FinalBossEvent(int FinalBossHealth)
    {
        finalBossHealth += FinalBossHealth;
    }
}
