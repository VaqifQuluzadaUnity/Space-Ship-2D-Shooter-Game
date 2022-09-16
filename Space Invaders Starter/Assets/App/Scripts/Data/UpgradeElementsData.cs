namespace GalaxyDefenders.Data
{
    [System.Serializable]

    public class UpgradeElementsData 
    {
        public int speed;
        public float coolDownTime;

        public UpgradeElementsData(int Speed, float CoolDownTime)
        {
            speed = Speed;
            coolDownTime = CoolDownTime;
        }
    }
}