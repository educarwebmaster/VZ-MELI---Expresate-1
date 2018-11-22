using UnityEngine;
using UnityEngine.EventSystems;

namespace Resource.LIBRO_F.AI_MELI_MOD1_LABERINTO_OCULAR.Scripts {
    public class FixedButton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler {
        [HideInInspector] public bool Pressed;

        public void OnPointerDown(PointerEventData eventData) {
            Pressed = true;
        }

        public void OnPointerUp(PointerEventData eventData) {
            Pressed = false;
        }
    }
}