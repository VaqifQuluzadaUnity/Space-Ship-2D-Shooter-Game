using UnityEngine;
using UnityEngine.UI;
using GalaxyDefenders.Music_SFX;

namespace GalaxyDefenders.MVC
{
    public class FinalBossUIView : MonoBehaviour
    {
        [Header("Controller reference")]
        [SerializeField] private FinalBossUIController controller;

        [Header("View references")]
        [SerializeField] private Text livesLabel;
        [SerializeField] private MusicControl music;
        [SerializeField] private Image healthBarImage;
        [SerializeField] private GameObject gameOver;
        [SerializeField] private GameObject allClear;

        internal void FinalBossHealthBarController(int FinalBossHealth)
        {
            healthBarImage.fillAmount = FinalBossHealth / 100f;
            if(healthBarImage.fillAmount == 0)
            {
                TriggerGameOver(false);
            }
        }

        internal void TriggerGameOver(bool failure = true)
        {
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
