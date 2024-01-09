using UnityEngine;

namespace Meangpu.Audio
{
    public class AudioPlayer : MonoBehaviour
    {
        [SerializeField] SOSound _sound;
        [SerializeField] bool _stopAllSound;
        [SerializeField] bool _playOnStart;

        [SerializeField] bool _useFadeIn;
        [SerializeField] float _fadeInTime = 1.3f;

        private void Start() => DoPlayThisEvent();

        public void DoPlayThisEvent()
        {
            if (_stopAllSound) AudioManager.instance?.StopAllSound();
            if (_playOnStart)
            {
                if (_useFadeIn) AudioManager.instance?.FadeIn(_sound, _fadeInTime);
                else AudioManager.instance?.Play(_sound);
            }
        }
    }
}