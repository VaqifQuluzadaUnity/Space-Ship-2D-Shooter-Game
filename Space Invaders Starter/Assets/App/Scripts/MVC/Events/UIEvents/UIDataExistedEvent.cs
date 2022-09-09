using DynamicBox.EventManagement;
using GalaxyDefenders.Data;

namespace GalaxyDefenders.MVC
{
	public class UIDataExistedEvent : GameEvent
	{
		public UIData uiData;

		public UIDataExistedEvent(UIData _uiData)
		{
			uiData = _uiData;
		}
	}
}
