using UnityEngine;
using UnityEngine.UI;

namespace Recursos.EXPRESATE.PLANTILLAS.Scripts.InputText
{
    public class InputTextQuestion : MonoBehaviour
    {
        public string Texto;
        [SerializeField] private InputField _inputText;

        [SerializeField] private Color _rightColor, _wrongColor;


        private void OnEnable() {
            _inputText.interactable = true;
            _inputText.text = "";
        }


        public bool CheckInputAnswer() {
            if (_inputText.text.ToLower() == Texto) {
                 _inputText.interactable = false;
                _inputText.textComponent.color = _rightColor;
                
                //_inputText.text.
                return true;
            }

            _inputText.textComponent.color = _wrongColor;
            return false;
        }
    }
}