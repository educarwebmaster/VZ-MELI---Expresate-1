using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Resource.EXPRESATE.RESPUESTA_MULTIPLE.Scripts {
    public class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {
        #region DRAG MANAGER

        [Header("Identificador")] public int Id;

        [Header("¿Remplazar nombre?")] [Tooltip("Remplaza el nombre del elemento por la id asignada")] [SerializeField]
        private bool _remplazarNombre;

        [Tooltip("Permite remplazar la imagen por otra al ser calificado")] [SerializeField]
        private bool _remplazarImagen;

        [EnableIf("_remplazarImagen", true)]
        [Tooltip("Imagen a remplazar despues de calificar")]
        [Header("Imagen de Calificación")]
        [SerializeField]
        private Sprite _imgCalificacion;

        /// <summary>
        /// Cambia la imagen asignada luego de calificar
        /// </summary>
        public void ImgCalification() {
            if (_imgCalificacion) {
                GetComponent<Image>().sprite = _imgCalificacion;
            }
        }

        private void Start() {
            //Asigna la id como nombre del elemento
            gameObject.name = _remplazarNombre ? Id + "" : gameObject.name;
        }

        #endregion

        #region DRAG & DROP BEHAVIOUR

        public static bool CanMove = true;
        public static GameObject ItemBeginDragged;
        private Vector3 _startPosition;
        private Transform _startParent;
        private CanvasGroup _canvasGroup;

        private void Awake() {
            _canvasGroup = GetComponent<CanvasGroup>();
        }


        #region  BeginDrag

        public void OnBeginDrag(PointerEventData eventData) {
            if (CanMove) {
                ItemBeginDragged = gameObject;
                _startPosition = transform.position;
                _startParent = transform.parent;
                _canvasGroup.blocksRaycasts = false;
            }
        }

        #endregion

        #region OnDrag Handler

        public void OnDrag(PointerEventData eventData) {
            if (CanMove)
                transform.position = eventData.position;
        }

        #endregion

        #region OnEndDrag

        public void OnEndDrag(PointerEventData eventData) {
            if (CanMove) {
                ItemBeginDragged = null;
                _canvasGroup.blocksRaycasts = true;
                if (transform.parent == _startParent) {
                    transform.position = _startPosition;
                }
            }
        }

        #endregion

        #endregion
    }
}