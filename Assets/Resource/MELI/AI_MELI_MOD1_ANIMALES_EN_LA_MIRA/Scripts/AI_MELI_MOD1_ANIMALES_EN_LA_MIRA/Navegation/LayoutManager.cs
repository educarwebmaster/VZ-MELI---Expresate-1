using Audio;
using Resource.LIBRO_C.AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Scripts.AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Score;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Navegation {
    public class LayoutManager : MonoBehaviour {
        #region "Tipo de escena"

        public enum TipoEscena {
            Ninguna,
            Inicio,
            Conozco,
            Desempeño,
            Actividad,
            PopUp
        }

        [Header("Tipo de Escena")] [SerializeField]
        private TipoEscena _escena;

        public TipoEscena Escena => _escena;

        #endregion

        #region "Opciones de audio"

        [Header("Boton Informacion")] public bool TieneAudio;

        [Tooltip("Indice del audio en el arreglo de Sonidos (NO FX)")] [EnableIf("TieneAudio", true)]
        public int AudioIndex;

        [EnableIf("TieneAudio", true)] [SerializeField]
        private OwnAudios _ownAudios;

        #endregion

        #region "Informacion adicional"

        /// <summary>
        /// Informacion adicional del elemento, Audio, Puntaje, Elementos
        /// </summary>
        public bool MuestraInformacion;


        [Header("Elemento")] [SerializeField] [EnableIf("MuestraInformacion", true)]
        private GameObject _elemento;

        public GameObject Elemento => _elemento;
        [SerializeField] private NavBar _navbar;

        #endregion

        #region "Puntaje"

        /// <summary>
        /// Administra el puntaje del elemento, si es evaluable o no,
        /// </summary>
        [SerializeField] //[EnableIf("_escena", TipoEscena.Desempeño)] 
        private ScoreManager _scoreManager;

        #endregion

        #region Enable

        /// <summary>
        /// Opciones predeterminadas del layout
        /// </summary>
        private void OnEnable() {
            if (TieneAudio && _ownAudios != null) {
//                Debug.Log(_ownAudios.Audios[AudioIndex]);
                _ownAudios.PlayMainAudio(AudioIndex);
            }

            //Si esta la opcion activada y el elemento es distinto a vacio, lo activa
            else if (MuestraInformacion && _elemento != null) {
                _elemento.SetActive(true);
            }

            // Habilita o deshabilita los componentes del navvar dependiendo del tipo de escena.
            switch (_escena) {
                case TipoEscena.Desempeño:
                    _navbar.HabilitarBotones();
                    _scoreManager.AsignScore();

                    break;

                case TipoEscena.PopUp:
                    _navbar.RestringirElementos("Popup");
                    break;

                case TipoEscena.Inicio:
                    _navbar.RestringirElementos(TAGS.SALIR_TAG);
                    break;

                case TipoEscena.Conozco:
                    _navbar.HabilitarBotones();
                    break;
            }
        }
    }

    #endregion
}