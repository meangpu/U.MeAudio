using UnityEngine;
using UnityEngine.Audio;
using EasyButtons;

namespace Meangpu.Audio
{
    public class SoundSettingSlider : MonoBehaviour
    {
        [Header("VolumeMixer")]
        [SerializeField] AudioMixer _mixer;

        [Header("Volume")]
        [SerializeField] VolSlider _master;
        [SerializeField] VolSlider _fx;
        [SerializeField] VolSlider _bg;

        [Header("ExposeName")]
        [SerializeField] string _masterName = "SoundMaster";
        [SerializeField] string _sfxName = "SoundFX";
        [SerializeField] string _bgName = "SoundBG";

        [Header("Setting")]
        [SerializeField] bool _isLoadFromSave = true;

        [Button]
        private void SetupMixerName()
        {
            static void SetMixerName(ref VolSlider _targetGroup, string newName)
            {
                if (_targetGroup != null) _targetGroup._mixerGroupName = newName;
            }

            SetMixerName(ref _master, _masterName);
            SetMixerName(ref _fx, _sfxName);
            SetMixerName(ref _bg, _bgName);
            UnityEditor.EditorUtility.SetDirty(this);
        }

        private void Start()
        {
            SetSliderVolume(_master);
            SetSliderVolume(_fx);
            SetSliderVolume(_bg);

            if (_isLoadFromSave) LoadSoundSetting();
        }

        void SetSliderVolume(VolSlider sliderGroup)
        {
            sliderGroup._slider.onValueChanged.AddListener((v) => UpdateVolumeValue(sliderGroup, v));
        }

        void UpdateVolumeValue(VolSlider sliderGroup, float value)
        {
            sliderGroup.UpdateTextAndVolume(value, _mixer);
            PlayerPrefs.SetFloat(sliderGroup._mixerGroupName, value);
        }

        float GetCreateSoundSetting(string settingName, float defaultVal = 0.5f)
        {
            if (PlayerPrefs.HasKey(settingName)) return PlayerPrefs.GetFloat(settingName);
            else return defaultVal;
        }

        void LoadSoundSetting()
        {
            float saved_Master;
            float saved_FX;
            float saved_BG;

            saved_Master = GetCreateSoundSetting(_master._mixerGroupName);
            saved_FX = GetCreateSoundSetting(_fx._mixerGroupName);
            saved_BG = GetCreateSoundSetting(_bg._mixerGroupName);

            _master.UpdateSliderTextVolumeValue(saved_Master, _mixer);
            _fx.UpdateSliderTextVolumeValue(saved_FX, _mixer);
            _bg.UpdateSliderTextVolumeValue(saved_BG, _mixer);
        }
    }
}