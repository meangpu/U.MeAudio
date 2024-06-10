using UnityEngine;

namespace Meangpu.Audio
{
    public class AudioPitchByTimeScale : MonoBehaviour
    {
        [SerializeField] float _minPitch = 0.4f;
        [SerializeField] float _maxPitch = 1.2f;
        [SerializeField] SOSound[] _soundToChangePitch;
        [Tooltip("Add time scale ref here")]
        [SerializeField] FloatReference _timeScale;

        float _audioPitch;
        float _lastFrameAudio;

        private void Update()
        {
            _audioPitch = Mathf.Clamp(_timeScale, _minPitch, _maxPitch);

            if (_lastFrameAudio == _audioPitch) return;
            foreach (SOSound sound in _soundToChangePitch) sound.SetPitchToNewValue(_audioPitch);

            _lastFrameAudio = _audioPitch;
        }

    }
}