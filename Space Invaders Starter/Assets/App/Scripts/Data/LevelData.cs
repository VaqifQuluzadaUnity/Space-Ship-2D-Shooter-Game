using System.Collections;
using System.Collections.Generic;

namespace GalaxyDefenders.Data
{
    public class LevelData
    {
        public List<LevelStates> levelStates = new List<LevelStates>();

        public LevelData(int num)
        {
            List<LevelStates> levelStates = new List<LevelStates>(new List<LevelStates>(num));
        }
    }

    [System.Serializable]

    public class LevelStates
    {
        public bool isUnlocked = false;
    }
}
