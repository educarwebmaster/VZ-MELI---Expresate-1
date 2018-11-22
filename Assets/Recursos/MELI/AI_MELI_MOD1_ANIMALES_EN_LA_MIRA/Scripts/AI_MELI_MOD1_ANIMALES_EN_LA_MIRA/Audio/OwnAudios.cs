using AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Audio;
using Navegation;
using Resource.MELI.AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Scripts.AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Navegation;
using UnityEngine;

namespace Audio {
    public class OwnAudios : MonoBehaviour {
        [Header("Audios del recurso")] public AudioClip[] Audios;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private NavegationManager _navegationManager;
        [SerializeField] private FXAudio _fxAudio;


        /// <summary>
        /// Inicializa el componente
        /// </summary>
        private void Awake() {
            _audioSource = _audioSource == null ? GetComponent<AudioSource>() : _audioSource;
        }


        /// <summary>
        /// Detiene todos los audios principales y secundarios
        /// </summary>
        public void StopMainAudio() {
            if (_audioSource != null) {
                _audioSource.Stop();
                _fxAudio.StopAudio();
            }
        }

        /// <summary>
        /// Reproduce un audio principal del recurso en index
        /// </summary>
        /// <param name="index"> index del audio a reprducir</param>
        public void PlayMainAudio(int index) {
            _audioSource.Stop();
            _audioSource.PlayOneShot(Audios[index]);
        }

        /// <summary>
        /// Reproduce el audio anidado en el elemento
        /// </summary>
        public void PlayOwnAudio() {
            if (_navegationManager.GetLayoutActual() != null &&
                _navegationManager.GetLayoutActual().GetComponent<LayoutManager>() != null &&
                _navegationManager.GetLayoutActual().GetComponent<LayoutManager>().TieneAudio) {
                int audioIndex = _navegationManager.GetLayoutActual().GetComponent<LayoutManager>().AudioIndex;
                PlayMainAudio(audioIndex);
            }

            else {
                _fxAudio.PlayAudio(0);
            }
        }
    }
}