using AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Audio;
using UnityEngine;
using UnityEngine.UI;

namespace AI_MELI_MOD1_RULETA_VISUAL.Scripts {
    public class DivElement : MonoBehaviour {
        public Estado _Estado {
            get => _estado;
            set => _estado = value;
        }

        public string Name;
        public GameObject PopUp;
        private bool _popUpStatus;
        private Button _button;
        [SerializeField] private Estado _estado;
        [SerializeField] private FXAudio _fxAudio;
        [SerializeField] private Spinner _wheel;

        public enum Estado {
            Locked,
            None
        }


        void Awake() {
            _button = GetComponent<Button>();
        }

        /// <summary>
        /// Verifica  el estado de la division y de acuerdo a esto reduce los intentos y activa el mensaje de intentar de nuevo
        /// </summary>
        public void CheckElement() {
            if (_estado == Estado.None) {
                _button.interactable = false;
                PopUp.SetActive(false);
                _estado = Estado.Locked;
                _wheel.DecreaseTries();
            }
            else if (_estado == Estado.Locked) {
                PopUp.SetActive(true);
            }
        }
    }
}