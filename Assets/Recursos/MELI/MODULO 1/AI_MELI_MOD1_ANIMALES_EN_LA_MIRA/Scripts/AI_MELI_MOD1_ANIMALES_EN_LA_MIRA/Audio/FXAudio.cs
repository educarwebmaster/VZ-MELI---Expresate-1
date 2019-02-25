using System.Collections;
using Sirenix.OdinInspector;
using UnityEngine;

namespace AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Audio {
    public class FXAudio : MonoBehaviour {
        private AudioSource _audioSource; //Componente de audio
        [Header("FX")] [SerializeField] private AudioClip[] _audioClips; //Audios a reproducir


        [SerializeField] private float delay;
        //Delay al reproducir un audio


        private void Awake() {
            _audioSource = GetComponent<AudioSource>(); // Inicializa el componente
        }

        /// <summary>
        /// Reproduce el sonido en index una sola vez
        /// </summary>
        /// <param name="index">Indice del audio</param>
        public void PlayAudio(int index) {
            StartCoroutine(PlayAudiowithDelay(index));
        }

        /// <summary>
        /// Reproduce un sonido con delay
        /// </summary>
        /// <param name="index">indice del audio</param>
        /// <returns></returns>

        private IEnumerator PlayAudiowithDelay(int index) {
            //Verifica que el audio a repoducir no sea sonido de pop
            _audioSource.Stop();
            if (index == 0) {
                _audioSource.PlayOneShot(_audioClips[index]);
            }
            //Resto de sonidos
            else {
                yield return new WaitForSeconds(delay);
                _audioSource.PlayOneShot(_audioClips[index]);
            }
        }

        /// <summary>
        /// Detiene el sonido del AudioSource en este componente
        /// </summary>
        public void StopAudio() {
            _audioSource.Stop();
        }
    }
}