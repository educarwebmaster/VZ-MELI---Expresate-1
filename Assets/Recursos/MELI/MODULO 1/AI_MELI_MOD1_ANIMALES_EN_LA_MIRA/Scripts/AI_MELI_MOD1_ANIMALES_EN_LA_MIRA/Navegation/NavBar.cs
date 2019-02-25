using Audio;
using Recursos.MELI.AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Scripts.AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Misc;
using Recursos.MELI.AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Scripts.AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Navegation;
using UnityEngine;


namespace Navegation {
    public class NavBar : MonoBehaviour {
        [Header("Navegacion")] [SerializeField]
        private NavegationManager _navegationManager;

        [Header("Sonidos")] [SerializeField] private OwnAudios _mainAudios;
        [Header("Botones ")] [SerializeField] private GameObject[] _navbarElements;


        /// <summary>
        /// Reproduce el audio del layaout y muestra el correspondiente elemento
        /// </summary>
        public void InformacionButton() {
            LayoutManager current = _navegationManager._gameElements[_navegationManager.LayoutActual()]
                .GetComponent<LayoutManager>();
            if (current != null)
                if (current.Escena == LayoutManager.TipoEscena.Actividad ||
                    current.Escena == LayoutManager.TipoEscena.Conozco) {
//                    if (current.TieneAudio) _mainAudios.PlayMainAudio(current.AudioIndex);
                    _mainAudios.StopMainAudio();
                    if (current.MuestraInformacion) current.Elemento.SetActive(true);
                }
        }


        /// <summary>
        /// Desactiva todos los elemtnos y se dirige a la portada
        /// </summary>
        public void InicioButton() {
            RestringirElementos(TAGS.SALIR_TAG);
            _navegationManager.GoToElement(0);
        }

        /// <summary>
        /// Busca un elemento con determinado tag y desactiva todos los elemtnos que no tengan ese tag
        /// </summary>
        /// <param name="tag">Tag del elemento que se desea dejar </param>
        public void RestringirElementos(string tag) {
            foreach (var elem in _navbarElements) {
                elem.SetActive(elem.gameObject.tag == tag);
            }
        }

        public void HabilitarBotones() {
            foreach (var elem in _navbarElements) {
                    elem.SetActive(true);
            }
        }
    }
}