using System.Collections;
using AREAS.LENGUAJE.EXPRESATE.SEPTIMO.VZ_LEN7_IMAGEN_ANIMACION.Scripts.Camera;
using AREAS.LENGUAJE.EXPRESATE.SEPTIMO.VZ_LEN7_IMAGEN_ANIMACION.Scripts.Misc;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

namespace Recursos.EXPRESATE.SEPTIMO.VZ_LEN7_IMAGEN_ANIMACION.Scripts.Videos {
    public class VideoManager : MonoBehaviour {
        [SerializeField] private GameObject _videoGameObject;


        [SerializeField] private CameraVideoRenderer _cameraVideoRenderer;
        private AudioSource _audioSource;
        private VideoPlayer _videoPlayer;
        private RawImage _rawImage;
        public float TimeDelay;
        private GameObject _resetButton;


//        private void OnEnable() {
//            if (_cameraVideoRenderer.IsCameraTextureMode) {
//                StartCoroutine(WaitSeconds());
//            }
//        }

        private void Awake() {
            _videoPlayer = _videoGameObject.GetComponent<VideoPlayer>();
            _audioSource = _videoGameObject.GetComponent<AudioSource>();
            _rawImage = _videoGameObject.GetComponent<RawImage>();
            _cameraVideoRenderer = _cameraVideoRenderer == null
                ? GameObject.FindGameObjectWithTag(Tags.VIDEO_RENDER_CAMERA).GetComponent<CameraVideoRenderer>()
                : null;
            _resetButton = GameObject.FindGameObjectWithTag(Tags.RESET_BUTTON_TAG);
        }

        private void OnMouseDown() {
            if (!_videoPlayer.isPlaying && !_cameraVideoRenderer.IsPlayingVideo) {
                _videoGameObject.SetActive(true);
                _videoPlayer.SetTargetAudioSource(0, _audioSource);
                _resetButton.SetActive(false);

                _videoPlayer.Play();
                _cameraVideoRenderer.IsPlayingVideo = true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void StopVideo() {
            _rawImage.enabled = false;
            _videoGameObject.SetActive(false);
            _resetButton.SetActive(true);
            _videoPlayer.Stop();
            _cameraVideoRenderer.IsPlayingVideo = false;
        }

        /// <summary>
        /// Wait custom seconds if is Camera texture mode
        /// </summary>
        /// <returns></returns>
        private IEnumerator WaitSeconds() {
            yield return new WaitForSeconds(TimeDelay);
            _rawImage.enabled = true;
        }
    }
}