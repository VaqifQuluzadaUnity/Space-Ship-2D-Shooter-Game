using UnityEngine;

namespace GalaxyDefenders
{
    public class SFX_Controller : MonoBehaviour
    {
        internal static SFX_Controller Instance;

        [SerializeField] private AudioSource sfx;
        [SerializeField] private GameObject explosionPrefab;
        [SerializeField] private float explosionTime = 1f;
        [SerializeField] private AudioClip explosionClip;

        internal void CreateExplosion(Vector2 position)
        {
            PlaySfx(explosionClip);

            var explosion = Instantiate(explosionPrefab, position,
                Quaternion.Euler(0f, 0f, Random.Range(-180f, 180f)));
            Destroy(explosion, explosionTime);
        }

        internal void PlaySfx(AudioClip clip) => sfx.PlayOneShot(clip);
    }
}
