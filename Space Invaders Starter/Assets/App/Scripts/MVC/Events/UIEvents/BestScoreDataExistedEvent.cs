using DynamicBox.EventManagement;
using GalaxyDefenders.Data;

namespace GalaxyDefenders.MVC
{
	public class BestScoreDataExistedEvent : GameEvent
	{
		public BestScoreData bestScoreData;

		public BestScoreDataExistedEvent(BestScoreData _bestScoreData)
		{
			bestScoreData = _bestScoreData;
		}
	}
}
