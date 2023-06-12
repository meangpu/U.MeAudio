using UnityEngine;

namespace Meangpu.Audio
{
    public class AudioPlayer : MonoBehaviour
    {
        [SerializeField] SOSound sound;
        [SerializeField] bool stopAllSound;
        [SerializeField] bool playOnStart;

        private void Start()
        {
            if (stopAllSound) AudioManager.instance?.StopAllSound();
            if (playOnStart) AudioManager.instance?.Play(sound);
        }
    }
}