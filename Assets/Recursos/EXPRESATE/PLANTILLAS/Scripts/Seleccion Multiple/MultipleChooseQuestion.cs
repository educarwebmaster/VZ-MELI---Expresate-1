using UnityEngine;

namespace Recursos.EXPRESATE.PLANTILLAS.Scripts.Seleccion_Multiple
{
    public class MultipleChooseQuestion : MonoBehaviour
    {
        //Arreglo con las respuestas
        private MultipleChooseAnswer[] _answers;

        /// <summary>
        /// Getter & Setter for _answers
        /// </summary>
        public MultipleChooseAnswer[] Answers {
            get => _answers;
            set => _answers = value;
        }


        private void Awake() {
            AssignChildrens();
        }

        /// <summary>
        /// Busca en los hijos del elemento y los asigna al arreglo
        /// </summary>
        void AssignChildrens() {
            if (gameObject.transform.childCount > 0) {
                _answers = gameObject.GetComponentsInChildren<MultipleChooseAnswer>();
            }
        }
    }
}