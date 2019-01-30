using UnityEngine;

namespace Recursos.MELI.AI_MELI_MOD1_TORRE_DE_PALABRAS.Scripts {
    public class Tower : MonoBehaviour {
        public float speed = 50f;


        public void RotationPiece(float axis) {
            if (axis == 1) {
                transform.Rotate(0, speed * Time.deltaTime, 0);
            }
            else {
                transform.Rotate(0, -speed * Time.deltaTime, 0);
            }
        }
    }
}