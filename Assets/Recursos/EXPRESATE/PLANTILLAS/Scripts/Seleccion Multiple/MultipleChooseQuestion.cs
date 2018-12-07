using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Recursos.EXPRESATE.PLANTILLAS.Scripts.Seleccion_Multiple
{
    public class MultipleChooseQuestion : MonoBehaviour
    {
        public bool NotHaveRandom;

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

        private void OnEnable() {
            ResetAnwsers();
        }

        /// <summary>
        /// Busca en los hijos del elemento y los asigna al arreglo
        /// </summary>
        void AssignChildrens() {
            if (gameObject.transform.childCount > 0) {
                _answers = gameObject.GetComponentsInChildren<MultipleChooseAnswer>();
            }
        }

        /// <summary>
        /// Habilita o descativa las respuestas
        /// </summary>
        /// <param name="status"></param>
        public void SetAnswers(bool status) {
            foreach (var ans in _answers) {
                ans.gameObject.GetComponent<Image>().raycastTarget = status;
                //ans.gameObject.GetComponent<Button>().interactable = status;
            }
        }


        public void ResetAnwsers() {
            if (NotHaveRandom == false) {
                List<Vector3> answerPos = new List<Vector3>();
                foreach (var ans in _answers) {
                    answerPos.Add(ans.transform.position);
                }

                foreach (var ans in _answers) {
                    var index = Random.Range(0, answerPos.Count);
                    ans.gameObject.transform.position = answerPos[index];
                    answerPos.Remove(answerPos[index]);
                }
            }
        }
    }
}