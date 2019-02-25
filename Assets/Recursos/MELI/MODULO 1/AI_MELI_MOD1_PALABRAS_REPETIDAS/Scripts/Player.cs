using System.Collections;
using UnityEngine;

namespace Resource.MELI.AI_MELI_MOD1_PALABRAS_REPETIDAS.Scripts {
    public class Player : MonoBehaviour {
        [SerializeField] private Transform _explosionEffect;
        [SerializeField] private LevelAndScoreManager _levelAndScoreManager;
        public float x, y, z;
        private void OnCollisionEnter(Collision other) {
            Debug.Log(other.gameObject.name);
            if (other.gameObject.CompareTag(TAG.ALIEN_TAG)) {

                if (_levelAndScoreManager.CheckWord()) {
                    Handheld.Vibrate();
                    Transform explosion = Instantiate(_explosionEffect);
                    explosion.transform.position = transform.position;
                    Destroy(explosion.gameObject, 3);
                    other.gameObject.GetComponent<Animator>().SetBool("Hit", true);
                    StartCoroutine(Delay(3.1f, other));
                    _levelAndScoreManager.SpawnRock();
                }
                else
                {
                    Handheld.Vibrate();
                    Transform explosion = Instantiate(_explosionEffect);
                    explosion.transform.position = transform.position;
                    Destroy(explosion.gameObject, 3);
                    other.gameObject.GetComponent<Animator>().SetBool("Hit", true);
                    StartCoroutine(Delay(3.1f, other));
                    _levelAndScoreManager.SpawnRock();
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