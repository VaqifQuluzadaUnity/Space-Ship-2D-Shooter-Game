using System.Collections.Generic;

namespace GalaxyDefenders.Data
{
	public class LevelData
	{
		public List<LevelStates> levelStates = new List<LevelStates>();

		//public LevelData(int num)
		//{
		//	levelStates = new List<LevelStates>()
		//}
	}

	[System.Serializable]

	public class LevelStates
	{
		public bool isUnlocked = false;
	}
}
