using Recursos.MELI.AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Scripts.AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Misc;
using UnityEngine;

namespace Recursos.MELI.AI_MELI_MOD1_TELESCOPIO_NUMERICO.Scripts {
	public class Techo : MonoBehaviour {

		// Use this for initialization
		void Start() {

		}

		// Update is called once per frame
		void Update() {

		}

		private void OnTriggerExit2D(Collider2D other) {
			if (other.gameObject.CompareTag(TAGS.ESTRELLA)) {
				other.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.one;
			}
//			else {
//				other.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.one;
//			}
		}
	}
}
