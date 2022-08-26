using DynamicBox.EventManagement;

public class UIDataExistedEvent : GameEvent
{
	public UIData uiData;

	public UIDataExistedEvent(UIData _uiData)
	{
		uiData = _uiData;
	}
}
