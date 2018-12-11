using Lean.Touch;
using UnityEngine;

namespace AREAS.LENGUAJE.EXPRESATE.SEPTIMO.VZ_LEN7_IMAGEN_ANIMACION.Scripts.Misc {
    public class ResetSettigns : MonoBehaviour {
        private Vector3 _mainCameraPosition;
        private GameObject _mainCamera;
        private float CameraDistance;
        private GameObject _playerCamera;


        private void Awake() {
            _mainCamera = GameObject.FindGameObjectWithTag(Tags.MAIN_CAMERA);
            _playerCamera = GameObject.FindGameObjectWithTag(Tags.PLAYER_CAMERA);
//            _gameElements[0] = GameObject.FindGameObjectWithTag(Tags.CILINDROS_TAG);
//            _gameElements[1] = GameObject.FindGameObjectWithTag(Tags.CAJA_TAG);
//            _gameElements[2] = GameObject.FindGameObjectWithTag(Tags.PLANO_TAG);
        }

        private void Start() {
            CameraDistance = _mainCamera.GetComponent<LeanCameraZoom>().Zoom;
            _mainCameraPosition = _mainCamera.transform.position;
        }


        /// <summary>
        /// Restore the original camera position
        /// </summary>
        public void RestoreCamera() {
            _mainCamera.GetComponent<LeanCameraZoom>().Zoom = CameraDistance;
            _mainCamera.transform.position = _mainCameraPosition;
            _playerCamera.transform.rotation = Quaternion.Euler(0,80,0);
        }
    }
}