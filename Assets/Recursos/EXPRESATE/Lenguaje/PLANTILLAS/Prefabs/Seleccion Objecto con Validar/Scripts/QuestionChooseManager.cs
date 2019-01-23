using Boo.Lang;
using Recursos.MELI.AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Scripts.AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Misc;
using Recursos.MELI.AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Scripts.AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Navegation;
using Resource.LIBRO_C.AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Scripts.AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Score;
using UnityEngine;
using UnityEngine.UI;

namespace Recursos.EXPRESATE.Lenguaje.PLANTILLAS.Prefabs.Seleccion_Objecto_con_Validar.Scripts
{
    public class QuestionChooseManager : MonoBehaviour
    {
        //Verifica si la actividad tiene o no random
        public bool HaveRandom;

        [SerializeField] private NavegationManager _navegationManager;
        [SerializeField] private ScoreManager _scoreManager;
        [SerializeField] private AnwserChooseManager[] _Answers;

        private void Awake() {
            FillAnswerArray();
        }

        private void OnEnable() {
            ResetQuestion();
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
        }

        private void CheckAnswer() {
            foreach (var ans in _Answers) {
                if (ans.status == AnwserChooseManager.Status.Choosed) {
                    if (ans.IsRight) {
                        _scoreManager.IncreaseScore();
                        
                    }
                }
            }
        }


        /// <summary>
        /// Restablece las preguntas 
        /// </summary>
        public void ResetQuestion() {
            SetAnswerStatus(true);
            RandomizeElements();
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