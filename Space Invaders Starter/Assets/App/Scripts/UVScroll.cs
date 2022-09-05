using System.Collections;
using UnityEngine;
using GalaxyDefenders.Music_SFX;

namespace GalaxyDefenders
{
    public class UVScroll : MonoBehaviour
    {
        [SerializeField]
        private MusicControl musicControl;

        public Vector2 speed;

        void LateUpdate()
        {
            GetComponent<Renderer>().material.mainTextureOffset = speed * Time.time * musicControl.Tempo;
        }
    }
}