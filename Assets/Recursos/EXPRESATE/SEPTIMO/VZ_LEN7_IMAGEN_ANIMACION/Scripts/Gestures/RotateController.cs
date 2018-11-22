using UnityEngine;

namespace AREAS.LENGUAJE.EXPRESATE.SEPTIMO.VZ_LEN7_IMAGEN_ANIMACION.Scripts.Gestures {
    public class RotateController : MonoBehaviour {
        public float _sensitivity = 1f;
        private Vector3 _mouseReference;
        private Vector3 _mouseOffset;
        private Vector3 _rotation = Vector3.zero;
        private bool _isRotating;


        void Update() {
            if (_isRotating) {
                _mouseOffset = (Input.mousePosition - _mouseReference);
                _rotation.y = -(_mouseOffset.x + _mouseOffset.y) * _sensitivity;
                gameObject.transform.Rotate(_rotation);
                _mouseReference = Input.mousePosition;
            }
        }

        void OnMouseDown() {
            _isRotating = true;
            _mouseReference = Input.mousePosition;
        }

        void OnMouseUp() {
            _isRotating = false;
        }
    }
}