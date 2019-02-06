using AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Audio;
using Recursos.MELI.AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Scripts.AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Navegation;
using Resource.LIBRO_C.AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Scripts.AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Score;
using UnityEngine;
using UnityEngine.UI;
using AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Audio;
    using Recursos.MELI.AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Scripts.AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Navegation;
using Resource.LIBRO_C.AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Scripts.AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Score;
using UnityEngine;
using UnityEngine.UI;


namespace Recursos.EXPRESATE.PLANTILLAS.Scripts.Seleccion_Multiple
{
    public class MultipleChooseManager : MonoBehaviour
    {
        //Arreglo donde se almacenan los grupos de las preguntas
        [SerializeField]
        [Header("Preguntas:")]
        [Tooltip("Arrastra el elemento que tiene el arrgelo de preguntas las preguntas")]
        private MultipleChooseQuestion[] Questions;

        //Numero de preguntas
        [SerializeField] [Header("Administrador de puntaje: ")]
        private ScoreManager _scoreManager;

        [Header("Administrador de audios")] [SerializeField]
        private FXAudio _fxAudio;

        public FXAudio FxAudio {
            get => _fxAudio;
            set => _fxAudio = value;
        }

        [SerializeField] [Header("Navegacion: ")]
        private NavegationManager _navegationManager;

        [Header("Tiempo de retraso para revisar la actividad")] [SerializeField]
        private float _forwardDelay;

        [SerializeField] [Header("Boton validar:")]
        private Button _validarButton;

        private void OnEnable() {
            ResetQuestion(true);
        }

        private void Start() {
            AssignQuestions();
        }

        /// <summary>
        /// Restablece el grupo de preguntas ubicados en el index
        /// </summary>
        /// <param name="index">Indice del grupo donde se almacenan las preguntas</param>
        void ResetQuestion(bool status) {
            foreach (var question in Questions) {
                question.SetAnswers(status);
            }

            _validarButton.enabled = status;
        }

        /// <summary>
        /// Califica 
        /// </summary>
        public void CheckAnswers() {
            int rightAnswer = 0;
            foreach (MultipleChooseQuestion question in Questions) {
                //Deshabilita las preguntas
                question.SetAnswers(false);
                MultipleChooseAnswer[] answer = question.gameObject.GetComponentsInChildren<MultipleChooseAnswer>();
                foreach (var currentAnswer in answer) {
                    if (currentAnswer.Answer == MultipleChooseAnswer.ToDoAnswer.MuestraResultado) {
                        if (currentAnswer.IsChoosed) {
                            if (currentAnswer.IsRight) {
//                                rightAnswer++;
                                _scoreManager.IncreaseScore();
                                currentAnswer.gameObject.GetComponentInChildren<MultipleChooseResult>()
                                    .AssignResult(true);
                            }
                            else {
                                currentAnswer.gameObject.GetComponentInChildren<MultipleChooseResult>()
                                    .AssignResult(false);
                            }
                        }
                    }
                    else if (currentAnswer.Answer == MultipleChooseAnswer.ToDoAnswer.RemplazaResultado) {
                        if (currentAnswer.IsChoosed) {
                            if (currentAnswer.IsRight) {
                                currentAnswer.AssignImgCalification(true);
                                _scoreManager.IncreaseScore();
                                rightAnswer++;
                            }
                            else {
                                currentAnswer.AssignImgCalification(false);
                            }
                        }
                    }
                }
            }

            _validarButton.enabled = false;
            //Reproduce audio si el numero de respuestas positivas coincide con el numero de preguntas
            _fxAudio.PlayAudio(rightAnswer == Questions.Length ? 2 : 1);
            //Aumenta el puntaje
            //_scoreManager.IncreaseScore();
            //Espera n segundos y dirige al siguiente layout en el navegationManager
            _navegationManager.Forward(_forwardDelay);
        }


        void AssignQuestions() {
            Questions = gameObject.transform.GetComponentsInChildren<MultipleChooseQuestion>();
        }
    }
}