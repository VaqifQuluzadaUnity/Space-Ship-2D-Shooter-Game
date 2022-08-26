using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using GalaxyDefenders.Music_SFX;

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

        internal void UpdateScore(int value)
        {
            score += value;
            scoreLabel.text = $"Score: {score}";
        }

        internal void UpdateBestScore(int value)
        {
            bestScore += value;
            highScoreLabel.text = $"Score: {bestScore}";
        }

        internal void TriggerGameOver(bool failure=true)
        {
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