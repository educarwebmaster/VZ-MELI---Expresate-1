using UnityEngine;

namespace AREAS.LENGUAJE.EXPRESATE.SEPTIMO.VZ_LEN7_IMAGEN_ANIMACION.Scripts.Audios {
	public class UIAudios : MonoBehaviour {

	
		public AudioClip[] _audioClips;
		private AudioSource _audioSource;


		private void Awake() {
			_audioSource = GetComponent<AudioSource>();
		}

	
		/// <summary>
		/// Reproduce el sonido en index
		/// </summary>
		/// <param name="index"></param>
		public void PlaySound(int index) {
			_audioSource.Stop();
			_audioSource.clip = _audioClips[index];
			_audioSource.Play();
		}
	}
}
