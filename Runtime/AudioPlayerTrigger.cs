using UnityEngine;

namespace Meangpu.Audio
{
    public class AudioPlayerTrigger : MonoBehaviour
    {
        [SerializeField] string _targetTag = "Player";
        [SerializeField] SOSound _sound;
        [SerializeField] bool _stopAllSound = true;
        [SerializeField] bool _useFadeIn = true;
        [SerializeField] float _fadeInTime = 1.3f;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag(_targetTag)) PlayAudio();
        }

        private void PlayAudio()
        {
            if (_stopAllSound) AudioManager.instance?.StopAllSound();
            if (_useFadeIn) AudioManager.instance?.FadeIn(_sound, _fadeInTime);
            else AudioManager.instance?.Play(_sound);
        }
    }
}