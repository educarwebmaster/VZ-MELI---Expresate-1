using System.Linq;
using Resource.LIBRO_C.AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Scripts.AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Score;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

namespace Resource.EXPRESATE.RESPUESTA_MULTIPLE.Scripts {
    public class CheckAnswers : MonoBehaviour {
        [SerializeField] private ScoreManager _scoreManager;
        public GameObject[] _drags;
        public GameObject[] _drops;
        private bool _checkTrigger;

        public void CheckAnswer() {
            if (_checkTrigger == false) {
                foreach (var drags in _drags) {
                    foreach (var drops in _drops) {
                        if (drags.gameObject.name == drops.gameObject.name) {
                            if (drags.transform.parent.gameObject.name == drops.gameObject.name) {
                                drags.GetComponent<DragHandler>().ImgCalification();
                            }
                            else {
                                Debug.Log("Respuesta erronea");
                            }
                        }
                    }
                }

                SetAnswersStatus(false);
                _checkTrigger = true;
            }
        }

        /// <summary>
        /// Habilita o deshabilita el drag de los elementos en _drags
        /// </summary>
        public void SetAnswersStatus(bool status) {
            DragHandler.CanMove = status;
        }
    }
}