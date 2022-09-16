using UnityEngine;
using UnityEngine.UI;
using GalaxyDefenders.Music_SFX;
using GalaxyDefenders.Data;

namespace GalaxyDefenders.MVC
{
    public class UIView : MonoBehaviour
    {
        [Header("Controller reference")]
        [SerializeField] private UIController controller;

        [Header("View references")]
        [SerializeField] private Text livesLabel;
        [SerializeField] private MusicControl music;
        [SerializeField] private Text scoreLabel;
        [SerializeField] private Text highScoreLabel;
        [SerializeField] private GameObject gameOver;
        [SerializeField] private GameObject allClear;

        private int score;
        public int bestScore;

        public void GetBestPoints()
        {
            if (bestScore < score)
            {
                bestScore = score;
                controller.GetBestPoints();
            }
        }

		internal void UpdateScore(int value)
		{
			score += value;
			scoreLabel.text = $"Score: {score}";
		}

		internal void UpdateBestScore(BestScoreData bestScoreData)
		{
			bestScore = bestScoreData.bestScore;
			highScoreLabel.text = $"High Score: {bestScore}";
		}

		internal void TriggerGameOver(bool failure = true)
		{
			GetBestPoints();
			gameOver.SetActive(failure);
			allClear.SetActive(!failure);

			Time.timeScale = 0f;
			music.StopPlaying();
		}

		internal void Lives(int lives)
        {
			livesLabel.text = $"Lives: {lives}";
			if (lives <= 0)
			{
				TriggerGameOver();
			}
		}
	}
}
