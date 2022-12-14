using DynamicBox.EventManagement;
using GalaxyDefenders.Music_SFX;
using GalaxyDefenders.MVC;
using UnityEngine;
using UnityEngine.UI;

namespace GalaxyDefenders.Managers
{
	public class GameManager : MonoBehaviour
	{
		internal static GameManager Instance;

		[SerializeField] private int maxLives = 3;
		[SerializeField] private Text livesLabel;
		[SerializeField] private MusicControl music;
		[SerializeField] private Text scoreLabel;
		[SerializeField] private Text highScoreLabel;
		[SerializeField] private GameObject gameOver;
		[SerializeField] private GameObject allClear;
		[SerializeField] private Button restartButton;

		private int lives;
		private int score;
		private int bestScore;
		private int points = 0;
		private int bestPoints = 0;

		public void GetPoints()
		{
			points++;
		}

		public void GetBestPoints()
		{

			Debug.Log("Score is written");

			if (bestPoints <= score)
			{
				bestPoints = points;
				EventManager.Instance.Raise(new UIDataEvent(score));
			}
		}

		private void OnEnable()
		{
			EventManager.Instance.AddListener<ScoreEvent>(ScoreEventHandler);
			EventManager.Instance.AddListener<UIDataExistedEvent>(UIDataExistedEventHandler);
		}

		private void OnDisable()
		{
			EventManager.Instance.RemoveListener<ScoreEvent>(ScoreEventHandler);
			EventManager.Instance.RemoveListener<UIDataExistedEvent>(UIDataExistedEventHandler);
		}

		public void ScoreEventHandler(ScoreEvent eventdetails)
		{
			UpdateScore(eventdetails.Points);
		}

		public void UIDataExistedEventHandler(UIDataExistedEvent eventdetails)
		{
			UpdateBestScore(eventdetails.uiData);
		}

		internal void UpdateScore(int value)
		{
			score += value;
			scoreLabel.text = $"Score: {score}";
		}

		internal void UpdateBestScore(UIData uiData)
		{
			bestScore = uiData.bestScore;
			highScoreLabel.text = $"High Score: {bestScore}";
		}

		internal void TriggerGameOver(bool failure = true)
		{
			GetBestPoints();
			gameOver.SetActive(failure);
			allClear.SetActive(!failure);
			restartButton.gameObject.SetActive(true);

			Time.timeScale = 0f;
			music.StopPlaying();
		}

		internal void AddLives()
		{
			lives++;
		}

		internal void UpdateLives()
		{
			lives--;
			livesLabel.text = $"Lives: {lives}";
			if (lives > 0)
			{
				return;
			}
			TriggerGameOver();
		}

		private void Awake()
		{
			if (Instance == null)
			{
				Instance = this;
			}
			else if (Instance != this)
			{
				Destroy(gameObject);
			}

			lives = maxLives;
			livesLabel.text = $"Lives: {lives}";
			score = 0;
			scoreLabel.text = $"Score: {score}";
		}
	}
}