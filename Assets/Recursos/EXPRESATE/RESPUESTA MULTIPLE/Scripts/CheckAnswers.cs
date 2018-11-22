using AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Audio;
using Resource.EXPRESATE.RESPUESTA_MULTIPLE.Scripts;
using Resource.LIBRO_C.AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Scripts.AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Score;
using Resource.MELI.AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Scripts.AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Navegation;
using UnityEngine;

namespace Recursos.EXPRESATE.RESPUESTA_MULTIPLE.Scripts {
    public class CheckAnswers : MonoBehaviour {
        [SerializeField] private ScoreManager _scoreManager;
        public GameObject[] _drags;
        public GameObject[] _drops;
        private bool _checkTrigger;
        private int _respuestasPositivas;
        [SerializeField] private FXAudio _fxAudio;
        [SerializeField] private NavegationManager _navegationManager;

        /// <summary>
        /// Verifica que el numero de drags sea cero
        /// </summary>
        public void CheckAnswer() {
            _respuestasPositivas = _drags.Length;
            if (_checkTrigger == false) {
                foreach (var drags in _drags) {
                    foreach (var drops in _drops) {
                        //Compara que el padre y el hijo tengan los mismo nombres;
                        if (drags.gameObject.name == drops.gameObject.name) {
                            if (drags.transform.parent.gameObject.name == drops.gameObject.name) {
                                //Asigna el cambio de estado al calificar
                                drags.GetComponent<DragHandler>().ImgCalification();
                                //A medidad que vanyan aumentando la respuestas positivas este numero ira disminuyendo
                                _respuestasPositivas--;
                            }
                        }
                    }
                }

                //Deshabilita 
                SetAnswersStatus(false);
                _checkTrigger = true;
            }

            //Si respuestasPositivas es 0 reproduce sonido de acirto, de lo contrario error, 2 y 1 corresponden a los indices
            _fxAudio.PlayAudio(_respuestasPositivas == 0 ? 2 : 1);
            _navegationManager.Forward();
        }

        /// <summary>
        /// Habilita o deshabilita el drag de los elementos en _drags
        /// </summary>
        public void SetAnswersStatus(bool status) {
            DragHandler.CanMove = status;
        }
    }
}