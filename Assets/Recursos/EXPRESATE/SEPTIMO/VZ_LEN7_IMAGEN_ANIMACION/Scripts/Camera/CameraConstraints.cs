using UnityEngine;

namespace AREAS.LENGUAJE.EXPRESATE.SEPTIMO.VZ_LEN7_IMAGEN_ANIMACION.Scripts.Camera {
    public class CameraConstraints : MonoBehaviour {
        [SerializeField] private float LimXLeft, LimXRight, LimYUp, LimYDown, _SpeedLerp;
        private Vector3 currentPosition;

        private void Update() {
            currentPosition = transform.position;

            if (transform.position.x < LimXLeft) {
                currentPosition.x = LimXLeft;
            }
            else if (currentPosition.x > LimXRight) {
                currentPosition.x = LimXRight;
            }

            if (transform.position.y < LimYDown) {
                currentPosition.y = LimYDown;
            }
            else if (currentPosition.y > LimYUp) {
                currentPosition.y = LimYUp;
            }

            transform.position = Vector3.Lerp(transform.position, currentPosition,_SpeedLerp * Time.deltaTime);
        }
    }
}