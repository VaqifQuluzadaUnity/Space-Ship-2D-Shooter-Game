using UnityEngine;
using DynamicBox.EventManagement;

namespace GalaxyDefenders.MVC
{
    public class UIController : MonoBehaviour
    {
        [SerializeField] private UIView view;

        public void GetBestPoints()
        {
            EventManager.Instance.Raise(new BestScoreDataEvent(view.bestScore));
        }

        private void OnEnable()
        {
            EventManager.Instance.AddListener<ScoreEvent>(ScoreEventHandler);
            EventManager.Instance.AddListener<BestScoreDataExistedEvent>(BestScoreDataExistedEventHandler);
            EventManager.Instance.AddListener<TriggerGameOverEvent>(TriggerGameOverEventHandler);
            EventManager.Instance.AddListener<LivesEvent>(LivesEventHandler);
        }

        private void OnDisable()
        {
            EventManager.Instance.RemoveListener<ScoreEvent>(ScoreEventHandler);
            EventManager.Instance.RemoveListener<BestScoreDataExistedEvent>(BestScoreDataExistedEventHandler);
            EventManager.Instance.RemoveListener<TriggerGameOverEvent>(TriggerGameOverEventHandler);
            EventManager.Instance.RemoveListener<LivesEvent>(LivesEventHandler);
        }

        public void ScoreEventHandler(ScoreEvent eventdetails)
        {
            view.UpdateScore(eventdetails.Points);
        }

        public void BestScoreDataExistedEventHandler(BestScoreDataExistedEvent eventdetails)
        {
            view.UpdateBestScore(eventdetails.bestScoreData);
        }

        public void TriggerGameOverEventHandler(TriggerGameOverEvent eventdetails)
        {
            view.TriggerGameOver(eventdetails.failure);
        }

        public void LivesEventHandler(LivesEvent eventdetails)
        {
            view.Lives(eventdetails.result);
        }
    }
}
