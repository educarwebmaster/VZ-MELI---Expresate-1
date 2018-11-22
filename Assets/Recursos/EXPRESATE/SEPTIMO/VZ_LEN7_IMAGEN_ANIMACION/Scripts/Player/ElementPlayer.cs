using AREAS.LENGUAJE.EXPRESATE.SEPTIMO.VZ_LEN7_IMAGEN_ANIMACION.Scripts.Audios;
using AREAS.LENGUAJE.EXPRESATE.SEPTIMO.VZ_LEN7_IMAGEN_ANIMACION.Scripts.Camera;
using AREAS.LENGUAJE.EXPRESATE.SEPTIMO.VZ_LEN7_IMAGEN_ANIMACION.Scripts.Misc;
using UnityEngine;

namespace AREAS.LENGUAJE.EXPRESATE.SEPTIMO.VZ_LEN7_IMAGEN_ANIMACION.Scripts.Player {
    public class ElementPlayer : MonoBehaviour {
        [SerializeField] private int _audioIndex;

        [SerializeField] private CameraVideoRenderer _cameraVideoRenderer;
        [SerializeField] private UIAudios _uiAudios;
        [SerializeField] private Outline _outline;
        [SerializeField] private Animator[] _animator;

        private bool _hasClicked;


        public bool DesactivateSameObjects;


        private void Awake() {
            _cameraVideoRenderer = _cameraVideoRenderer == null
                ? GameObject.FindGameObjectWithTag(Tags.VIDEO_RENDER_CAMERA).GetComponent<CameraVideoRenderer>()
                : null;

            if (_outline == null) {
                _outline = GetComponent<Outline>();
            }

            if (!DesactivateSameObjects) {
                if (_animator[0] == null) {
                    _animator[0] = GetComponent<Animator>();
                    if (_animator[0] == null) {
                        _animator[0] = transform.parent.GetComponent<Animator>();
                    }
                }
            }
        }


        /// <summary>
        /// Desactivate same objects
        /// </summary>
        private void DesactivateSame() {
            foreach (var elem in _animator) elem.enabled = false;
            
        }

        /// <summary>
        /// Al precionar click habilita Outline y reproduce el video en index
        /// </summary>
        private void OnMouseDown() {
            if (!_cameraVideoRenderer.IsPlayingVideo && !_hasClicked) {
                _uiAudios.PlaySound(_audioIndex);
                _outline.enabled = true;
                _hasClicked = true;
                Restore();
            }
        }

        /// <summary>
        /// Deshabilita el outline al soltar el click
        /// </summary>
        private void OnMouseUp() {
            if (_cameraVideoRenderer.IsPlayingVideo && _hasClicked) {
                _outline.enabled = false;

                if (_animator != null) {
                    // DesactivateSame();
                }

                _hasClicked = false;
            }
        }

        private void Restore() {
            foreach (var elem in _animator) elem.SetBool("IsPlaying", false);
        }
    }
}