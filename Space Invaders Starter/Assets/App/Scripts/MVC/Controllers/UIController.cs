using UnityEngine;
using DynamicBox.EventManagement;
using GalaxyDefenders.Managers;

namespace GalaxyDefenders.MVC
{
    public class UIController : MonoBehaviour
    {
        [SerializeField] private UIView view;

        /*private void OnEnable()
        {
            EventManager.Instance.AddListener<UIEvent>(UIEventHandler);
        }

        private void OnDisable()
        {
            EventManager.Instance.RemoveListener<UIEvent>(UIEventHandler);
        }

        public void UI(int Points,int BestPoints)
        {
            EventManager.Instance.Raise(new UIEvent(Points, BestPoints));
        }

        public void UIEventHandler(UIEvent eventdetails)
        {
            GameManager.Instance.UpdateScore(eventdetails.Points);
            //GameManager.Instance.UpdateBestScore(eventdetails.BestPoints);
        }*/
    }
}
