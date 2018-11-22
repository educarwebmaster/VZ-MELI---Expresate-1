using UnityEngine;

namespace Audio {
    public class MainAudios : MonoBehaviour {
        [Header("Audios del recurso")][SerializeField]
        private AudioClip[] _audios;
        private AudioSource _audioSource;


        private void Awake() {
            _audioSource = GetComponent<AudioSource>();
        }


        /// <summary>
        /// Reproduce un audio principal del recurso en index
        /// </summary>
        /// <param name="index"> index del audio a reprducir</param>
        public void PlayMainAudio(int index) {
            _audioSource.PlayOneShot(_audios[index]);
        }
    }
}