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
            EventManager.Instance.AddListener<Event>(EventHandler);
        }

        private void OnDisable()
        {
            EventManager.Instance.RemoveListener<Event>(EventHandler);
        }

        public void EventHandler(Event eventdetails)
        {
            
        }*/
    }
}
