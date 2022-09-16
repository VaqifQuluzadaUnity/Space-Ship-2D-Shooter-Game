namespace GalaxyDefenders.Data
{
    [System.Serializable]
    public class PricesData
    {
        public int movementPrice;
        public int bulletPrice;

        public PricesData(int MovementPrice, int BulletPrice)
        {
            movementPrice = MovementPrice;
            bulletPrice = BulletPrice;
        }
    }
}
