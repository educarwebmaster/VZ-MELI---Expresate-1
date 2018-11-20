using System.Collections;
using UnityEngine;

namespace Resource.MELI.AI_MELI_MOD1_PALABRAS_REPETIDAS.Scripts {
    public class Player : MonoBehaviour {
        [SerializeField] private Transform _explosionEffect;
        [SerializeField] private LevelAndScoreManager _levelAndScoreManager;

        private void OnCollisionEnter(Collision other) {
            Debug.Log(other.gameObject.name);
            if (other.gameObject.CompareTag(TAG.ALIEN_TAG)) {

                if (_levelAndScoreManager.CheckWord()) {
                    Handheld.Vibrate();
                    Transform explosion = Instantiate(_explosionEffect);
                    explosion.transform.position = transform.position;
                    Destroy(explosion.gameObject, 2);
                    other.gameObject.GetComponent<Animator>().SetBool("Hit", true);
                    StartCoroutine(Delay(2.1f, other));
                }
             

            }
        }

        private void OnTriggerEnter(Collider other) {
            if (other.gameObject != null) {
                if (other.gameObject.CompareTag(TAG.BOUND_TAG)) {
                    _levelAndScoreManager.SpawnRock();
                }
            }
        }

        private IEnumerator Delay(float seconds, Collision other) {
            yield return new WaitForSeconds(seconds);
            other.gameObject.GetComponent<Animator>().SetBool("Hit", false);
        }
    }
}