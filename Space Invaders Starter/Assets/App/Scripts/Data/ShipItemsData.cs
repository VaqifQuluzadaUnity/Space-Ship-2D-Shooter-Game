using System.Collections;
using System.Collections.Generic;

namespace GalaxyDefenders.Data
{
    public class ShipItemsData
    {
        public List<ShipState> shipStates = new List<ShipState>();
    }

    [System.Serializable]

    public class ShipState
    {
        public bool isBuy;

        public bool isSelect;
    }
}
