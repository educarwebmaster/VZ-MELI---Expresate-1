using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Recursos.EXPRESATE.PLANTILLAS.Scripts.Seleccion_Multiple
{
    public class MultipleChooseAnswer : MonoBehaviour
    {
        [FormerlySerializedAs("isRight")] public bool IsRight;
        [FormerlySerializedAs("isChoosed")] public bool IsChoosed;
        private Button _buttonComponent;
        private MultipleChooseQuestion _parent;
        public ToDoAnswer Answer;

        //Estados de la respuesta al calificar
        [FormerlySerializedAs("_calificacionSprites")]
        [DisableIf("Answer", ToDoAnswer.MuestraResultado)]
        [SerializeField]
        private Sprite _correctoSprites;

        [DisableIf("Answer", ToDoAnswer.MuestraResultado)] [SerializeField]
        private Sprite _erroneoSprites;

        private Sprite _previusSprite;
        private SpriteState _rightState, _wrongState, _disableSprite;


        public enum ToDoAnswer
        {
            MuestraResultado,
            RemplazaResultado
        }


        private void Awake() {
            //Inicializa el componente button y el padre
            _buttonComponent = GetComponent<Button>();
            _parent = gameObject.transform.parent.GetComponent<MultipleChooseQuestion>();
            _previusSprite = GetComponent<Image>().sprite;
            _disableSprite = GetComponent<Button>().spriteState;
//            gameObject.GetComponent<Image>().SetNativeSize();
        }

        private void Start() {
            _rightState = new SpriteState {disabledSprite = _correctoSprites};
            _wrongState = new SpriteState {disabledSprite = _erroneoSprites};
        }


        private void OnEnable() {
            //Deselecciona las respuesta
            IsChoosed = false;
            //AssignImgCalification(false);
            AssignOriginalStatus();
        }


        /// <summary>
        /// Busca el padre y el arreglo de los hijos de este, reasigna su tamaño, y los habilita para poder ser seleccionados
        /// </summary>
        public void ChooseAnswer() {
            if (_parent != null) {
                foreach (var elem in _parent.Answers) {
                    elem.gameObject.GetComponent<Button>().interactable = true;
                    elem.transform.localScale = Vector3.one;
                    elem.gameObject.GetComponent<MultipleChooseAnswer>().IsChoosed = false;
//                    elem.gameObject.GetComponent<Image>().SetNativeSize();
                }
            }


            gameObject.transform.parent.GetComponentInParent<MultipleChooseManager>().FxAudio.PlayAudio(0);
            IsChoosed = true;
            _buttonComponent.interactable = false;
//            transform.localScale = Vector3.one * 1.2f;  //Aumenta la escala del elemento
        }

        public void AssignImgCalification(bool status) {
            gameObject.GetComponent<Button>().spriteState = status ? _rightState : _wrongState;
//            gameObject.GetComponent<Image>().SetNativeSize();
        }

        public void AssignOriginalStatus() {
            gameObject.GetComponent<Image>().sprite = _previusSprite;
//            gameObject.GetComponent<Image>().SetNativeSize();
            gameObject.GetComponent<Button>().spriteState = _disableSprite;
            gameObject.GetComponent<Button>().interactable = true;
        }
    }
}