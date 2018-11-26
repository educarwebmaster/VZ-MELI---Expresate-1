using System.Collections;
using Recursos.MELI.AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Scripts.AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Navegation;
using Resource.LIBRO_C.AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Scripts.AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Score;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

namespace Resource.MELI.AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Scripts.AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Score {
    public class QuestWork : MonoBehaviour {
        #region Attributes

        [Header("Evaluable")] [Tooltip("Verifica que la respuesta se evaluable")]
        public bool IsValuable;
        //Verifica si los resultados de la actividad son evaluables

        public bool CareTries;
        private Image _localImage;
        private Button _localButton;
        [EnableIf("IsValuable", true)] public bool HasRightAnswer;
        [Header("Delay entre Actividad")] public int CustomAmountDelay;


        /// <summary>
        /// Verifica si los intentos valen, y habilita la opcion HasRightAnswer, si la actividades es evaluable,
        /// ademas añade un tiempo de delay si se desea
        /// </summary>
        [SerializeField] [EnableIf("CareTries", true)] [Tooltip("Componente de navegacion")]
        private NavegationManager _navegationManager;

        /// <summary>
        /// Habilita el Score manager si en la activiad los intentos se van a utllizar
        /// </summary>
        [Header("Desactiva los botones")]
        [Tooltip("Al activar esta casilla al precionar los elementos, estos son desactivados automaticamente.")]
        public bool DisableButton;

        /// <summary>
        /// Se utliza con el objetivo de desactivar algunos elementos determinados al ejecutar la accion.
        /// </summary>

        #region "Tipo de respuesta"

        public bool OnceAnswer;

        [SerializeField] [EnableIf("OnceAnswer", true)]
        private GameObject _answersElement;

        #endregion

        #endregion

        #region "Preload (Awake)"

        private void Awake() {
            _localButton = GetComponent<Button>();
            _localImage = GetComponent<Image>();
        }

        #endregion


        #region "Opciones de respuesta"

        [SerializeField] [Tooltip("Valor de la respuesta")]
        public AnswerStatus AnswerValue;


        /// <summary>
        /// Estados corrrespondientes a las respuestas
        /// </summary>
        public enum AnswerStatus {
            Locked,
            None
        }

        [SerializeField] [EnableIf("IsValuable", true)]
        private ScoreManager _scoreManager;

        #endregion


        /// <summary>
        /// Verifica que el elemento se evaluable y no este bloqueado, al precionar click desactiva el raycast target y lo vuelve interactable para grupos
        /// </summary>
        public void CheckPartyAnswer() {
            if (IsValuable && AnswerValue == AnswerStatus.None) {
                if (HasRightAnswer) {
                    _scoreManager.IncreaseScore();
                }
                else {
                    _scoreManager.ReduceScore();
                }


            }

            if (DisableButton) {
                _scoreManager.DecreaseTries();
                _localButton.interactable = !_localButton.interactable;
                AnswerValue = AnswerStatus.Locked;
            }

            if (OnceAnswer) {
                CheckOnceAnswer(false);
                _localButton.interactable = !_localButton.interactable;
                AnswerValue = AnswerStatus.Locked;
                StartCoroutine(CustomDelay(CustomAmountDelay));
            }

            if (_scoreManager.TestTries == 0 || _scoreManager.ActivitiesTries == 0) {
                _scoreManager.DisableActivities();
                StartCoroutine(CustomDelay(CustomAmountDelay));
            }
        }

        /// <summary>
        /// Verifica la calificacion de solamente un elemento
        /// </summary>
        public void CheckOnceAnswer(bool value) {
            Graphic[] raycastTarget = _answersElement.GetComponentsInChildren<Graphic>();
            foreach (var image in raycastTarget) {
                image.raycastTarget = value;
            }
        }


        /// <summary>
        /// Tiempo de espera añadido 
        /// </summary>
        /// <param name="delay">tiempo</param>
        /// <returns></returns>
        private IEnumerator CustomDelay(float delay) {
            yield return new WaitForSeconds(delay);
            Debug.Log(delay + " Seconds");
            _navegationManager.Forward();
        }
    }
}