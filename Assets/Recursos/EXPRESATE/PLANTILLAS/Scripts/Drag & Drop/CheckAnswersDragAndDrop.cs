using System.Collections;
using AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Audio;
using Boo.Lang;
using Recursos.EXPRESATE.PLANTILLAS.Scripts.InputText;
using Recursos.MELI.AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Scripts.AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Navegation;
using Resource.EXPRESATE.RESPUESTA_MULTIPLE.Scripts;
using Resource.LIBRO_C.AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Scripts.AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Score;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Recursos.EXPRESATE.RESPUESTA_MULTIPLE.Scripts
{
    public class CheckAnswersDragAndDrop : MonoBehaviour
    {
        [FormerlySerializedAs("_drags")] public GameObject[] Drags;
        [FormerlySerializedAs("_drops")] public GameObject[] Drops;


        private bool _checkTrigger;


        private int _respuestasPositivas;

        [Header("Audio")] [SerializeField] private FXAudio _fxAudio;

        [Header("Navegacion")] [SerializeField]
        private NavegationManager _navegationManager;

        [Header("Puntaje")] [SerializeField] private ScoreManager _scoreManager;

        [Header("Activa el siguiente layout")] public bool Forward;

        [Header("Delay al activar el sigueinte layout")] [EnableIf("Forward", true)]
        public int Delay;


        [Header("Input question")] public bool HasInputActivity;

        [SerializeField] [EnableIf("HasInputActivity", true)]
        private InputTextQuestion _inputTextQuestion;

        [SerializeField] [Header("Boton Validar:")]
        private Button _validarButton;

        [FormerlySerializedAs("HasNotRandom")] [Header("Random")]
        public bool HasNotDragRandom;

        [FormerlySerializedAs("HasDropRandom")] [FormerlySerializedAs("hasDropRandom")]
        public bool HasDropActivityAndRandom;

        private void OnEnable() {
            ResetDrags();
        }


        /// <summary>
        /// Verifica que el numero de drags sea cero
        /// </summary>
        public void CheckAnswer() {
            Debug.Log("Numero de respuestas positivas " + _respuestasPositivas);
            if (_checkTrigger == false) {
//                if (HasOrder) {
//                    foreach (var drags in _drags) {
//                        foreach (var drops in _drops) {
//                            //Compara que el padre y el hijo tengan los mismo nombres;
//                            if (drags.gameObject.name == drops.gameObject.name) {
//                                if (drags.transform.parent.gameObject.name == drops.gameObject.name) {
//                                    _scoreManager.IncreaseScore();
//                                    drags.GetComponent<DragHandler>().SetImgCalification(true);
//                                    //A medidad que vanyan aumentando la respuestas positivas este numero ira disminuyendo
//                                    _respuestasPositivas--;
//                                    //                                _respuestasPositivas = _respuestasPositivas > 0
//                                    //                                    ? _respuestasPositivas - 1
//                                    //                                    : _respuestasPositivas;
//                                    Debug.Log("Respuestas restantes " + _respuestasPositivas);
//                                }
//                                else {
//                                    drags.GetComponent<DragHandler>().SetImgCalification(false);
//                                }
//                            }
//                        }
//                    }
                _respuestasPositivas = Drops.Length;
//                Debug.Log("Numero de respuestas  " + _respuestasPositivas);
                if (_checkTrigger == false) {
                    foreach (var t1 in Drags) {
                        foreach (var t in Drops) {
                            if (t1.gameObject.name == t.gameObject.name) {
                                if (t1.transform.parent.gameObject == t.gameObject) {
                                    t1.GetComponent<DragHandler>().SetImgCalification(true);
                                    _scoreManager.IncreaseScore();
                                    t.gameObject.GetComponent<SlotHandler>().Calificado = true;
                                    _respuestasPositivas--;
                                }
                            }
                        }
                    }

//                if (HasOrder) {
//                    foreach (var drags in _drags) {
//                        foreach (var drops in _drops) {
//                            //Compara que el padre y el hijo tengan los mismo nombres;
//                            if (drags.gameObject.name == drops.gameObject.name) {
//                                if (drags.transform.parent.gameObject.name == drops.gameObject.name) {
//                                    _scoreManager.IncreaseScore();
//                                    drags.GetComponent<DragHandler>().SetImgCalification(true);
//                                    //A medidad que vanyan aumentando la respuestas positivas este numero ira disminuyendo
//                                    _respuestasPositivas--;
//                                    //                                _respuestasPositivas = _respuestasPositivas > 0
//                                    //                                    ? _respuestasPositivas - 1
//                                    //                                    : _respuestasPositivas;
//                                    Debug.Log("Respuestas restantes " + _respuestasPositivas);
//                                }
//                                else {
//                                    drags.GetComponent<DragHandler>().SetImgCalification(false);
//                                }
//                            }
//                        }
                }


//                Debug.Log("Numero de respuestas positivas " + _respuestasPositivas);
                CheckErrors();
                SetAnswersStatus(false);
                _checkTrigger = true;
            }

            if (_checkTrigger && _inputTextQuestion != null && HasInputActivity) {
                _fxAudio.PlayAudio(_respuestasPositivas == 0 && _inputTextQuestion.CheckInputAnswer() ? 2 : 1);
                //Si permite ir hacia la siguiente layout
                if (Forward && _navegationManager != null) {
                    _navegationManager.Forward(Delay);
                }
            }

            if (HasInputActivity == false && _checkTrigger && _inputTextQuestion == null) {
                _fxAudio.PlayAudio(_respuestasPositivas == 0 ? 2 : 1);
                //Si permite ir hacia la siguiente layout
                if (Forward && _navegationManager != null) {
                    _navegationManager.Forward(Delay);
                }
            }

            //Si respuestasPositivas es 0 reproduce sonido de acirto, de lo contrario error, 2 y 1 corresponden a los indices
        }

        /// <summary>
        /// Habilita o deshabilita el drag de los elementos en _drags
        /// </summary>
        public void SetAnswersStatus(bool status) {
            foreach (var elem in Drags) {
                elem.gameObject.GetComponent<DragHandler>().CanMove = status;
            }

            _validarButton.enabled = status;
        }


        /// <summary>
        /// 
        /// </summary>
        public void ResetDrags() {
            List<GameObject> drags = new List<GameObject>();
            List<GameObject> drops = new List<GameObject>();

            foreach (var elem in Drags) {
                DragHandler dragHandler = elem.GetComponent<DragHandler>();
                drags.Push(dragHandler.ElementParent.gameObject);
                dragHandler.SetImgEstadoAnterior();
            }

            if (HasDropActivityAndRandom) {
                foreach (var elem in Drops) {
                    DragHandler dragHandler = elem.GetComponentInChildren<DragHandler>();
                    drops.Add(dragHandler.ElementParent.gameObject);
                    dragHandler.SetImgEstadoAnterior();
                }

                
            }

            if (HasNotDragRandom == false && HasDropActivityAndRandom == false) {
                foreach (var elem in Drags) {
                    var index = Random.Range(0, drags.Count);
                    elem.gameObject.transform.SetParent(drags[index].transform);
                    drags.Remove(drags[index]);
                }
            }
            else if (HasNotDragRandom && HasDropActivityAndRandom == false) {
                foreach (var elem in Drags) {
                    elem.transform.SetParent(elem.GetComponent<DragHandler>().ElementParent.transform);
                }
            }

            else if (HasDropActivityAndRandom && HasNotDragRandom) {
                foreach (var elem in Drops) {
                    var index = Random.Range(0, drops.Count);
                    elem.gameObject.transform.GetChild(0).SetParent(drops[index].transform);
                    drops.Remove(drops[index]);
                }
            }

//
            SetAnswersStatus(true);
//            _scoreManager.ResetScore();
            _checkTrigger = false;
        }

        public void CheckErrors() {
            foreach (var drop in Drops) {
                if (drop.gameObject.GetComponent<SlotHandler>().Calificado == false) {
                    if (drop.gameObject.transform.childCount > 0) {
                        drop.gameObject.GetComponentInChildren<DragHandler>().SetImgCalification(false);
                    }
                }
            }
        }
    }
}