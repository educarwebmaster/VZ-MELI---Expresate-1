using Recursos.MELI.AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Scripts.AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Misc;
using UnityEngine;

namespace Recursos.MELI.AI_MELI_MOD1_TELESCOPIO_NUMERICO.Scripts {
    public class Laser : MonoBehaviour {
        private void OnTriggerStay2D(Collider2D other) {
            if (other.gameObject.CompareTag(TAGS.ESTRELLA)) {
                other.gameObject.GetComponent<Estrella>().OnStay();
            }
        }

        private void OnTriggerExit2D(Collider2D other) {
            if (other.gameObject.CompareTag(TAGS.ESTRELLA)) {
                other.gameObject.GetComponent<Estrella>().IsInside = true;
            }
        }
    }
}