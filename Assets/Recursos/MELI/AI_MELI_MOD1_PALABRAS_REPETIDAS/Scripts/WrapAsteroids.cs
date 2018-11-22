using UnityEngine;

namespace Resource.MELI.AI_MELI_MOD1_PALABRAS_REPETIDAS.Scripts {
    public class WrapAsteroids : MonoBehaviour {
        private Rigidbody _rigidbody;
        [SerializeField] private float _minForce, _maxForce, _minTorque, _maxTorque;



        private void Awake() {
            //Init rigidBody
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void WrapAsteroid() {
            _rigidbody.AddTorque(Vector3.left * Time.deltaTime * Random.Range(_minTorque,_maxTorque));
            _rigidbody.AddForce(Vector3.left * Random.Range(_minForce, _maxForce));
        }

        private void Start() {
            WrapAsteroid();
        }
    }
}