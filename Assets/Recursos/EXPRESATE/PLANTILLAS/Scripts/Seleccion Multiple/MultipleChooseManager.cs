using AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Audio;
using Recursos.EXPRESATE.PLANTILLAS.Scripts.Seleccion_Multiple;
using Resource.LIBRO_C.AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Scripts.AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Score;
using UnityEngine;

namespace Recursos.EXPRESATE.PLANTILLAS.Scripts
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


        private void Start() {
            AssignQuestions();
        }

        /// <summary>
        /// Restablece el grupo de preguntas ubicados en el index
        /// </summary>
        /// <param name="index">Indice del grupo donde se almacenan las preguntas</param>
        void ResetQuestion(int index) { }

        /// <summary>
        /// Califica 
        /// </summary>
        void CheckAnswers() { }


        void AssignQuestions() {
            Questions = gameObject.transform.GetComponentsInChildren<MultipleChooseQuestion>();
        }
    }
}