using UnityEngine;

namespace Meangpu.Audio
{
    public class AudioStopper : MonoBehaviour
    {
        [SerializeField] SOSound[] _soundToStop;

        public void StopSoundInArray()
        {
            foreach (SOSound sound in _soundToStop) sound.Stop();
        }

        public void PlaySoundInArray()
        {
            foreach (SOSound sound in _soundToStop) sound.Play();
        }

        public void PlayOneShotSoundInArray()
        {
            foreach (SOSound sound in _soundToStop) sound.PlayOneShot();
        }

        public void PauseSoundInArray()
        {
            foreach (SOSound sound in _soundToStop) sound.Pause();
        }
    }
}