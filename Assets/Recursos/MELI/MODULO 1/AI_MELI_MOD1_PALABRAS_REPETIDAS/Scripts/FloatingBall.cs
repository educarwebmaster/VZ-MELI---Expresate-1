using UnityEngine;

namespace Resource.MELI.AI_MELI_MOD1_PALABRAS_REPETIDAS.Scripts {
    public class FloatingBall : MonoBehaviour {
        public bool EnableFloat;
        private Vector3 _startPosition;
        [SerializeField] private float _speed;

        private void Start() {
            _startPosition = transform.position;
        }

        private void FixedUpdate() {
            if (EnableFloat) {
                Vector3 newPosition = transform.position;
                newPosition.y += Mathf.Sin(Time.time) * Time.deltaTime * _speed;
                transform.position = newPosition;
            }
        }
    }
}