using UnityEngine;
using UnityEngine.Audio;

namespace Meangpu.Audio
{
    public class LoadAudioFromSetting : MonoBehaviour
    {
        ///  <summary>
        /// put this into System prefab in resources like AudioManager
        /// </summary>
        [Header("VolumeMixer")]
        [SerializeField] AudioMixer _mixer;

        [SerializeField] string _masterName = "SoundMaster";
        [SerializeField] string _bgName = "SoundBG";
        [SerializeField] string _sfxName = "SoundFX";

        float saved_Master;
        float saved_FX;
        float saved_BG;

        private void Awake() => DoLoadSoundSetting();

        void UpdateVolume(string name, float newValue) => _mixer.SetFloat(name, Mathf.Log10(newValue) * 20);

        float GetCreateSoundSetting(string settingName, float defaultVal = 0.5f)
        {
            if (PlayerPrefs.HasKey(settingName)) return PlayerPrefs.GetFloat(settingName);
            else return defaultVal;
        }

        public void DoLoadSoundSetting()
        {
            saved_Master = GetCreateSoundSetting(_masterName);
            saved_FX = GetCreateSoundSetting(_sfxName);
            saved_BG = GetCreateSoundSetting(_bgName);

            UpdateVolume(_masterName, saved_Master);
            UpdateVolume(_sfxName, saved_FX);
            UpdateVolume(_bgName, saved_BG);
        }
    }
}