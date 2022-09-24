using UnityEngine;
using GalaxyDefenders.Managers;
using DynamicBox.EventManagement;

namespace GalaxyDefenders.Music_SFX
{
    public class MusicControl : MonoBehaviour
    {
        [SerializeField] private AudioSource source;
        [SerializeField] internal int pitchChangeSteps = 5;
        [SerializeField] private float maxPitch = 5.25f;
        [SerializeField] public int enemyCount;
        [SerializeField] public int coolDownTime;

        internal static MusicControl Instance;

        public int killCount;
        private int tempKillCount;
        private float timer;

        private readonly float defaultTempo = 1.33f;
        private float pitchChange;

        internal float Tempo { get; private set; }

        internal void StopPlaying() => source.Stop();

        void Update()
        {
            timer += Time.deltaTime;

            if(timer>coolDownTime)
            {
                IncreasePitch();
            }
        }

        internal void IncreasePitch()
        {
            if (source.pitch == maxPitch)
            {
                return;
            }

            source.pitch = Mathf.Clamp(source.pitch + pitchChange, 1, maxPitch);
            Tempo = Mathf.Pow(2, pitchChange) * Tempo;

            timer = 0;
        }

        internal void IncreaseDeathCount()
        {
            killCount++;
            if (killCount == enemyCount)
            {
                EventManager.Instance.Raise(new TriggerGameOverEvent(false));
                return;
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