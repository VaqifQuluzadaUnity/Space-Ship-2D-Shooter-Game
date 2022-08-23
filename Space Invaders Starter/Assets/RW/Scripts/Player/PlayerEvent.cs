using DynamicBox.EventManagement;
using UnityEngine.UI;

public class PlayerEvent : GameEvent
{
    private int playerLives;
    private Image image;

    public PlayerEvent(int PlayerLives, Image _image)
    {
        playerLives = PlayerLives;
        image = _image;
    }
}
