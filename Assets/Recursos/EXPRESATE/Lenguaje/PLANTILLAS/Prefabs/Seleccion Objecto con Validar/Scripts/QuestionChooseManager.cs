using AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Audio;
using Boo.Lang;
using Recursos.MELI.AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Scripts.AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Misc;
using Recursos.MELI.AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Scripts.AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Navegation;
using Resource.LIBRO_C.AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Scripts.AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Score;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;


namespace Recursos.EXPRESATE.Lenguaje.PLANTILLAS.Prefabs.Seleccion_Objecto_con_Validar.Scripts
{
    public class QuestionChooseManager : MonoBehaviour
    {
        [Header("Tiempo de espera para redirigir al siguiente Layout")]
        public bool HaveDelay;

        private bool _scored;

        [SerializeField] [EnableIf("HaveDelay")]
        private float _delay;

        [Header("Random")] [Tooltip("Verifica si la actividad tiene o no random")]
        public bool HaveRandom;

        [Header("Número de respuestas")] [Tooltip("Numero de opciones a seleccionar")]
        public int AnswerOptions;

        private int _numAnswer;

        [Header("Los siguientes atributos a asignar son opcionales")] [SerializeField]
        private NavegationManager _navegationManager;

        [SerializeField] private ScoreManager _scoreManager;
        [SerializeField] private AnwserChooseManager[] _Answers;
        [SerializeField] private FXAudio _fxAudio;


        private void Awake() {
            FillAnswerArray();
        }

        private void OnEnable() {
            ResetQuestion();
        }

        private void Start() {
            _numAnswer = AnswerOptions;
        }


        /// <summary>
        /// Rellena un arreglo con elementos que tienen el Script AnswerChooseManager
        /// Busca e inicializa sino ha sido añadida el Navegation Manager
        /// </summary>
        private void FillAnswerArray() {
            _Answers = GetComponentsInChildren<AnwserChooseManager>();
            _navegationManager = _navegationManager == null
                ? GameObject.FindGameObjectWithTag(TAGS.NAVEGATION_MANAGER)
                    .GetComponent<NavegationManager>()
                : _navegationManager;
            _scoreManager = _scoreManager == null
                ? GameObject.FindGameObjectWithTag(TAGS.SCORE_MANAGER).GetComponent<ScoreManager>()
                    .GetComponent<ScoreManager>()
                : _scoreManager;
            _fxAudio = _fxAudio == null
                ? GameObject.FindGameObjectWithTag(TAGS.FXAUDIO).GetComponent<FXAudio>()
                : _fxAudio;
        }

        /// <summary>
        /// Verifica las respuesta, reproduce el sonido de acierto o error y redirige al siguiente elemento
        /// </summary>
        public void CheckAnswer() {
            if (_scored == false) {
                int rightAnswer = 0;
                int wrongAnswer = 0;
                foreach (var ans in _Answers) {
                    if (ans.status == AnwserChooseManager.Status.Choosed && ans.IsRight) {
                        ans.AssignSprite(ans.Right);
                        rightAnswer++;
                    }
                    else if (ans.status == AnwserChooseManager.Status.Choosed && ans.IsRight == false) {
                        ans.AssignSprite(ans.Wrong);
                        wrongAnswer++;
                    }
                }

                Debug.Log("Respuestas incorrectas " + wrongAnswer);
                Debug.Log("Respuestas correctas " + rightAnswer);
                if (wrongAnswer == 0 && rightAnswer == _numAnswer) {
                    _scoreManager.IncreaseScore(rightAnswer); //Aumenta el score por el numero de aciertos
                    //Deshabilita todos los botones
                    _fxAudio.PlayAudio(2); //Reproduce el audio de acierto
                    _navegationManager.Forward();
                }
                else {
                    _fxAudio.PlayAudio(1);
                }

                SetAnswerStatus(false);
                _navegationManager.Forward(_delay);
                _scored = true;
            }
        }


        /// <summary>
        /// Restablece las preguntas 
        /// </summary>
        public void ResetQuestion() {
            SetAnswerStatus(true);
            RandomizeElements();
            _scored = false;
        }

        /// <summary>
        /// Ubica aleatoriamente los elementos en en posiciones almacenadas en sua arreglo
        /// </summary>
        private void RandomizeElements() {
            if (HaveRandom) {
                var answerPos = new List<Vector3>();
                foreach (var ans in _Answers) {
                    answerPos.Add(ans.transform.position);
                }

                foreach (var ans in _Answers) {
                    var index = Random.Range(0, answerPos.Count);
                    ans.gameObject.transform.position = answerPos[index];
                    answerPos.Remove(answerPos[index]);
                }
            }
        }

        /// <summary>
        /// Activa o desactiva la interactividad con los botones
        /// </summary>
        /// <param name="status">estado</param>
        private void SetAnswerStatus(bool status) {
            foreach (var ans in _Answers) {
                ans.gameObject.GetComponent<Image>().raycastTarget = status;
            }
        }
    }
}