using System.Collections;
using AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Audio;
using Resource.LIBRO_C.AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Scripts.AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Score;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Resource.LIBRO_C.AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Scripts.AI_MELI_MOD1_LABERINTO_OCULAR {
    public class CoinRecolector : MonoBehaviour {
        //Al habilitar este valor se activa la posibilidad de evaluar los resultados
        [Tooltip("Al activar esta opcion la actividad se vuelve evaluable")]
        public bool IsEvaluable;

        [EnableIf("IsEvaluable", true)] [Tooltip("Elemento a activar cuando se acabe los intentos")] [SerializeField]
        private GameObject _desempeno;

        [Tooltip("Tiempo en habilitar el elemento")] [SerializeField] [EnableIf("IsEvaluable", true)]
        private int _EnableDelay;


        [EnableIf("IsEvaluable", true)] public int Tries;

        [Tooltip("Añade el administrador de puntaje")] [EnableIf("IsEvaluable", true)] [SerializeField]
        private ScoreManager _scoreManager;

        [SerializeField] private FXAudio _fxAudio;


        private IEnumerator LoadDesmepeno(int seconds) {
            yield return new WaitForSeconds(seconds);
            _desempeno.SetActive(true);
        }

        /// <summary>
        /// On Trigger enter
        /// </summary>
        /// <param name="other">Collision</param>
        private void OnTriggerEnter(Collider other) {
            ///Check if other.tag is CoinRight and play CoinRight Sound

            //Reversed "if" to reduce nesting
            if (Tries > 0) {
                if (other.gameObject.CompareTag(TAGS.COIN_RIGHT)) {
                    _fxAudio.PlayAudio(0);
                    if (IsEvaluable) {
                        _scoreManager.IncreaseScore();
                        Tries--;
                        other.transform.parent.gameObject.SetActive(false);
                    }

                    other.gameObject.SetActive(false);
                }
                ///Check if other.tag is CoinWrong and play CoinWrong Sound 
                else if (other.gameObject.CompareTag(TAGS.COIN_WRONG)) {
                    _fxAudio.PlayAudio(1);
                    if (IsEvaluable) {
                        _scoreManager.ReduceScore();
                        other.transform.parent.gameObject.SetActive(false);
                        Tries--;
                    }
                }
            }
        }

        private void Update() {
            if (Tries <= 0) {
                StartCoroutine(LoadDesmepeno(_EnableDelay));
                _scoreManager.AsignScore();
            }
        }
    }
}