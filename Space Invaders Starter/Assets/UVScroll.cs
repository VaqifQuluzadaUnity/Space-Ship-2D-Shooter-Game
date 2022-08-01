using UnityEngine;
using System.Collections;

namespace RayWenderlich.SpaceInvadersUnity
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