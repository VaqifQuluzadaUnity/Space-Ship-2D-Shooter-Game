using UnityEngine;
using GalaxyDefenders.Managers;

namespace GalaxyDefenders.Music_SFX
{
    public class MusicControl : MonoBehaviour
    {
        [SerializeField] private AudioSource source;
        [SerializeField] internal int pitchChangeSteps = 5;
        [SerializeField] private float maxPitch = 5.25f;

        internal static MusicControl Instance;

        private int killCount;
        private int enemyCount = 20;
        private int tempKillCount;

        private readonly float defaultTempo = 1.33f;
        private float pitchChange;

        internal float Tempo { get; private set; }

        internal void StopPlaying() => source.Stop();

        internal void IncreasePitch()
        {
            if (source.pitch == maxPitch)
            {
                return;
            }

            source.pitch = Mathf.Clamp(source.pitch + pitchChange, 1, maxPitch);
            Tempo = Mathf.Pow(2, pitchChange) * Tempo;
        }

        internal void IncreaseDeathCount()
        {
            killCount++;
            if (killCount == enemyCount)
            {
                GameManager.Instance.TriggerGameOver(false);
                return;
            }
            tempKillCount++;

            if (tempKillCount < (enemyCount / pitchChangeSteps))
            {
                return;
            }
            else
            {
                IncreasePitch();
                tempKillCount = 0;
            }
        }

        private void Start()
        {
            source.pitch = 1f;
            Tempo = defaultTempo;
            pitchChange = maxPitch / pitchChangeSteps;
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
        }

    }
}