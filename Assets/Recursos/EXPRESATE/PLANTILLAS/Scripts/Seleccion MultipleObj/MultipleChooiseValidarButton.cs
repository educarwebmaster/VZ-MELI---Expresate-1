using UnityEngine;
using UnityEngine.UI;

namespace Recursos.EXPRESATE.PLANTILLAS.Scripts.Seleccion_MultipleObj
{
    public class MultipleChooiseValidarButton : MonoBehaviour
    {
        [SerializeField] [Header("Boton Validar")]
        private Button _validarButton;


        private void OnEnable() {
            _validarButton.enabled = true;
        }
    }
}