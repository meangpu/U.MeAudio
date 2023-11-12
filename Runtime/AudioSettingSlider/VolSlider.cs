using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

namespace Meangpu.Audio
{
    [System.Serializable]
    class VolSlider : MonoBehaviour
    {
        public Slider _slider;
        public TMP_Text _volumeAmountText;
        public string _mixerGroupName;

        public void UpdateSliderTextVolumeValue(float newVal, AudioMixer mixer)
        {
            _slider.value = newVal;
            UpdateTextAndVolume(newVal, mixer);
        }

        public void UpdateTextAndVolume(float newVal, AudioMixer mixer)
        {
            mixer.SetFloat(_mixerGroupName, Mathf.Log10(newVal) * 20);

            if (_volumeAmountText == null) return;
            _volumeAmountText.SetText((newVal * 10).ToString("0"));
        }
    }
}