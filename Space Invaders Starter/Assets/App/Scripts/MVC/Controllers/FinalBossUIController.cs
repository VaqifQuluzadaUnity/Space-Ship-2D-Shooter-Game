using UnityEngine;
using DynamicBox.EventManagement;

namespace GalaxyDefenders.MVC
{
    public class FinalBossUIController : MonoBehaviour
    {
        [SerializeField] private FinalBossUIView view;

        private void OnEnable()
        {
            EventManager.Instance.AddListener<FinalBossEvent>(FinalBossEventHandler);
            EventManager.Instance.AddListener<TriggerGameOverEvent>(TriggerGameOverEventHandler);
            EventManager.Instance.AddListener<LivesEvent>(LivesEventHandler);
        }

        private void OnDisable()
        {
            EventManager.Instance.RemoveListener<FinalBossEvent>(FinalBossEventHandler);
            EventManager.Instance.RemoveListener<TriggerGameOverEvent>(TriggerGameOverEventHandler);
            EventManager.Instance.RemoveListener<LivesEvent>(LivesEventHandler);
        }

        public void FinalBossEventHandler(FinalBossEvent eventdetails)
        {
            view.FinalBossHealthBarController(eventdetails.finalBossHealth);
        }

        public void TriggerGameOverEventHandler(TriggerGameOverEvent eventdetails)
        {
            view.TriggerGameOver(eventdetails.failure);
        }

        public void LivesEventHandler(LivesEvent eventdetails)
        {
            view.Lives(eventdetails.lives);
        }
    }
}
