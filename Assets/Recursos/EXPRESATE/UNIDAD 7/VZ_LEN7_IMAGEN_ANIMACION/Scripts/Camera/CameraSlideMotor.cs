using AREAS.LENGUAJE.EXPRESATE.SEPTIMO.VZ_LEN7_IMAGEN_ANIMACION.Scripts.Gestures;
using UnityEngine;

namespace AREAS.LENGUAJE.EXPRESATE.SEPTIMO.VZ_LEN7_IMAGEN_ANIMACION.Scripts.Camera {
    public class CameraMotor : MonoBehaviour {

        public Transform LookAt;
        private Vector3 desiredPosition;
        private Vector3 Offset;

        public float smoothSpeed = 7.5f;
        public float distance = 5.0f;
        public float yOffset = 0.0f;


        private void Start() {
            //Camera offset
            Offset = new Vector3(0,yOffset,-1 * distance);
    
        }

        private void FixedUpdate() {
            desiredPosition = LookAt.position + Offset;
            transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
            transform.LookAt(LookAt.position + Vector3.up);
        }


        private void Update() {
            if (SwipeManager.Instance.IsSwiping(SwipeDirection.Left)) {
                SlideCamera(Vector3.up * 90);
            }
            else if (SwipeManager.Instance.IsSwiping(SwipeDirection.Right)) {
                SlideCamera(Vector3.down * 90);
            }
            else if (SwipeManager.Instance.IsSwiping(SwipeDirection.Down)) {
                SlideCamera(Vector3.left * 90);
            }
            else if (SwipeManager.Instance.IsSwiping(SwipeDirection.Up)) {
                SlideCamera(Vector3.right * 90);
            }

        


        
        
        }


        private void SlideCamera(Vector3 rotation) {
            Offset = Quaternion.Euler(rotation) * Offset;
        }
    }
}
