using UnityEngine;


namespace Resource.MELI.AI_MELI_MOD1_PALABRAS_REPETIDAS.Scripts {
    public class ObjectPooling : MonoBehaviour {
        [SerializeField] private Transform _spawnPosition;

        private void OnTriggerEnter(Collider other) {
            if (other.gameObject.CompareTag(TAG.ASTEROID_TAG)) {
                other.gameObject.transform.position = _spawnPosition.position;
            }
        }
    }
}