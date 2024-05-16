using UnityEngine;
using UnityEngine.EventSystems;

namespace Meangpu.Audio
{
    public class AudioOnMouseHoverClick : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    {
        [SerializeField] SOSound _hoverSound;
        [SerializeField] SOSound _clickSound;
        [SerializeField] SOSound _exitSound;

        public void OnPointerClick(PointerEventData eventData) => _clickSound?.PlayOneShot();
        public void OnPointerEnter(PointerEventData eventData) => _hoverSound?.PlayOneShot();
        public void OnPointerExit(PointerEventData eventData) => _exitSound?.PlayOneShot();
    }
}