using UnityEngine;
using System.Collections;
using System.Linq;

namespace Meangpu.Audio
{
    public class AudioManager : MonoBehaviour
    {
        // AudioManager.instance?.Play(playName);
        // SoSoundObj.Play();

        [SerializeField] SOSound[] _sounds;
        public static AudioManager instance;
        private AudioSource[] _allAudioSources;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
            }

            _sounds = Resources.LoadAll("SOSound", typeof(SOSound)).Cast<SOSound>().ToArray();

            foreach (SOSound s in _sounds)
            {
                s.source = gameObject.AddComponent<AudioSource>();
                s.SetupSourceWithRandomVolAndPitch();
                s.source.clip = s.Clip;
                s.source.outputAudioMixerGroup = s.mixerGroup;
                s.source.spatialBlend = s.blend;
                s.source.loop = s.loop;
            }
        }

        public void Play(SOSound soObj)
        {
            soObj.SetupSourceWithRandomVolAndPitch();
            soObj.source.Play();
        }

        public void PlayOneShot(SOSound soObj)
        {
            if (soObj.source == null)
            {
                Debug.Log("No Audio SOurce");
                return;
            }
            soObj.SetupSourceWithRandomVolAndPitch();
            soObj.source.PlayOneShot(soObj.Clip);
        }

        public void PlayOneShot(SOSound soObj, float newVolume)
        {
            if (soObj.source == null)
            {
                Debug.Log("No Audio SOurce");
                return;
            }
            soObj.SetupSourceWithRandomVolAndPitch();
            soObj.source.volume = newVolume;
            soObj.source.PlayOneShot(soObj.Clip);
        }

        public void PlayOneShot(SOSound soObj, float newVolume, float newPitch)
        {
            soObj.source.volume = newVolume;
            soObj.source.pitch = newPitch;
            soObj.source.PlayOneShot(soObj.Clip);
        }

        public void StopAllSound()
        {
            _allAudioSources = FindObjectsOfType<AudioSource>();
            foreach (AudioSource audio in _allAudioSources)
            {
                audio.Stop();
            }
        }

        public void MuteSourceByName(SOSound soundName) => soundName.source.volume = 0;
        public void SetSourceVolumeByName(SOSound soundName, int newVol) => soundName.source.volume = newVol;
        public void ResetVolumeByName(SOSound soundName) => soundName.SetupSourceWithRandomVolAndPitch();

        public IEnumerator CoroutineFadeOut(SOSound soObj, float fadeTime = 1.3f)
        {
            float startVolume = soObj.source.volume;
            while (soObj.source.volume > 0)
            {
                soObj.source.volume -= startVolume * Time.deltaTime / fadeTime;
                yield return null;
            }
            soObj.Stop();
        }

        public IEnumerator CoroutineFadeIn(SOSound soObj, float fadeTime = 1.3f)
        {
            soObj.Play();
            soObj.source.volume = 0f;
            float targetVolume = soObj.GetVolume();
            while (soObj.source.volume < targetVolume)
            {
                soObj.source.volume += Time.deltaTime / fadeTime;
                yield return null;
            }
        }

        public void FadeIn(SOSound soObj, float fadeTime = 1.3f)
        {
            StartCoroutine(CoroutineFadeIn(soObj, fadeTime));
        }

        public void FadeOut(SOSound soObj, float fadeTime = 1.3f)
        {
            StartCoroutine(CoroutineFadeOut(soObj, fadeTime));
        }
    }
}