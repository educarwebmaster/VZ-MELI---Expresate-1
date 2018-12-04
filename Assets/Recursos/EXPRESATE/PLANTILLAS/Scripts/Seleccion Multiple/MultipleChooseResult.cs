using UnityEngine;
using UnityEngine.UI;

namespace Recursos.EXPRESATE.PLANTILLAS.Scripts.Seleccion_Multiple
{
    public class MultipleChooseResult : MonoBehaviour
    {
        [SerializeField] [Header("Imagen resultado")]
        private Sprite[] _sprites;

        private Image _image;


        private void Awake() {
            _image = GetComponent<Image>();
        }

        private void OnEnable() {
            _image.enabled = false;
        }


        /// <summary>
        /// Asigna una imagen correspondiente al resultado
        /// </summary>
        /// <param name="status">true, positivo; falso, error</param>
        public void AssignResult(bool status) {
            _image.enabled = true;
            _image.sprite = status ? _sprites[0] : _sprites[1];
        }
    }
}