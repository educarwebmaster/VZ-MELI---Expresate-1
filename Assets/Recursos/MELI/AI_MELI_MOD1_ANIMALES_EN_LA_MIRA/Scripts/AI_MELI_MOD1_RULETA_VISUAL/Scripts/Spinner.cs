using Navegation;
using Resource.MELI.AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Scripts.AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Navegation;
using UnityEngine;
using UnityEngine.UI;

namespace AI_MELI_MOD1_RULETA_VISUAL.Scripts {
    public class Spinner : MonoBehaviour {
        [SerializeField] private NavegationManager _navegationManager;
        public float Multiplier = 1;
        private bool _round1, HasInitBefore;
        public bool Lock;
        public bool IsStoped;
        public GameObject PopUp;
        public int Tries;
        private int _savedTries;


        private void Start() {
            _savedTries = Tries;
            HasInitBefore = true;
        }

        private void OnEnable() {
            if (_savedTries > 0 && HasInitBefore) {
                ResetSettings();
            }
        }

        // Rotacion de la ruleta
        void FixedUpdate() {
            if (Multiplier > 0 && IsStoped == false && Tries > 0) {
                transform.Rotate(Vector3.back, Time.deltaTime * Multiplier);
            }
            else {
                IsStoped = true;
            }

//        if (multiplier < maxForce && !round1) {
//            multiplier += 0.1f;
//        }
//        else {
//            round1 = true;
//        }
//
//        if (round1 && multiplier > 0) {
//            multiplier -= reducer;
//        }
        }

        /// <summary>
        /// Reajustas las opciones, solo si el numero de intentos restantes es mayor que cero.
        /// </summary>
        public void Reset() {
            if (Tries > 0) {
                PopUp.SetActive(false);
                _round1 = !_round1;
                Lock = false;
                IsStoped = !IsStoped;
            }
            else if (Tries == 0) {
                _navegationManager.Forward();
            }
        }

        public void DecreaseTries() {
            if (Tries > 0) {
                Tries--;
                Debug.Log("Tries left " + Tries);
            }
            else if (Tries == 0) {
                Lock = true;
                IsStoped = true;
            }
        }

        /// <summary>
        /// Resetea los ajustes a los establecidos al inicio del juego
        /// </summary>
        public void ResetSettings() {
            
            Tries = _savedTries;
            ResetWheel();
            Lock = false;
            IsStoped = false;
            PopUp.SetActive(false);
            Debug.Log("Reset wheel");
        }

        public void ResetWheel() {
            var wheel = GetComponentsInChildren<DivElement>();
            var buttonsWheel = GetComponentsInChildren<Button>();
            foreach (var div in wheel) div._Estado = DivElement.Estado.None;
            foreach (var button in buttonsWheel) button.interactable = true;
        }
    }
}