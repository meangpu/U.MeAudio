using UnityEngine;
using UnityEngine.EventSystems;

namespace Meangpu.Audio
{
    public class SliderDragEndPlaySound : MonoBehaviour, IPointerUpHandler
    {
        [SerializeField] SOSound _soundPlayAfterReleaseSlider;
        public void OnPointerUp(PointerEventData eventData) => _soundPlayAfterReleaseSlider?.Play();
    }
}