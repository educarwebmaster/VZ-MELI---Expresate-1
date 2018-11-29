using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Recursos.EXPRESATE.RESPUESTA_MULTIPLE.Scripts
{
    public class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
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
        private Sprite _estadoAnterior, _imgCalificacion;

        public GameObject ElementParent;


        private void Start() {
            //Asigna la id como nombre del elemento
            gameObject.name = _remplazarNombre ? Id + "" : gameObject.name;
            _estadoAnterior = GetComponent<Image>().sprite;
        }

        /// <summary>
        /// Cambia la imagen asignada luego de calificar
        /// </summary>
        public void SetImgCalification() {
            GetComponent<Image>().sprite = _imgCalificacion;
        }

        public void SetImgEstadoAnterior() {
            if (_estadoAnterior) {
                GetComponent<Image>().sprite = _estadoAnterior;
            }
        }

        #endregion

        #region DRAG & DROP BEHAVIOUR

        public  bool CanMove = true;
        public static GameObject ItemBeginDragged;
        private Vector3 _startPosition;
        private Transform _startParent;
        private CanvasGroup _canvasGroup;

        private void Awake() {
            ElementParent = transform.parent.gameObject;
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