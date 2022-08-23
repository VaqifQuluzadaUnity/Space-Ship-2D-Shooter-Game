using UnityEngine;

namespace GalaxyDefenders
{
    public class MusicControl : MonoBehaviour
    {
        [SerializeField] private AudioSource source;
        [SerializeField] internal int pitchChangeSteps = 5;
        [SerializeField] private float maxPitch = 5.25f;

        private readonly float defaultTempo = 1.33f;
        private float pitchChange;
        internal float Tempo { get; private set; }
        internal void StopPlaying() => source.Stop();

        internal void IncreasePitch()
        {
            if (source.pitch == maxPitch)
            {
                Debug.Log("3");
                return;
            }

            source.pitch = Mathf.Clamp(source.pitch + pitchChange, 1, maxPitch);
            Tempo = Mathf.Pow(2, pitchChange) * Tempo;
            Debug.Log("4");
        }

        private void Start()
        {
            source.pitch = 1f;
            Tempo = defaultTempo;
            pitchChange = maxPitch / pitchChangeSteps;
            Debug.Log("5");
        }

    }
}