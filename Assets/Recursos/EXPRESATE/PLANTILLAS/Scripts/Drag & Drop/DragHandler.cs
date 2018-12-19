using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
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

        [EnableIf("_remplazarImagen", true)] [Tooltip("Imagen a remplazar despues de calificar")]
        private Sprite _estadoAnterior;

        [EnableIf("_remplazarImagen", true)]
        [Tooltip("Imagen a remplazar despues de calificar")]
        [Header("Imagen de Calificación")]
        [SerializeField]
        private Sprite _imgCorrecta;

        [SerializeField] private Sprite _imgErronea;

        public GameObject ElementParent;


        private void Awake() {
//            ElementParent = transform.parent.gameObject;
            _canvasGroup = GetComponent<CanvasGroup>();
        }


        private void OnEnable() {
            SetImgEstadoAnterior();
        }

        private void Start() {
            //Asigna la id como nombre del elemento
            gameObject.name = _remplazarNombre ? Id + "" : gameObject.name;
            _estadoAnterior = GetComponent<Image>().sprite;
        }

        /// <summary>
        /// Cambia la imagen asignada luego de calificar
        /// </summary>
        public void SetImgCalification(bool status) {
            GetComponent<Image>().sprite = status ? _imgCorrecta : _imgErronea;
        }

        public void SetImgEstadoAnterior() {
            if (_estadoAnterior) {
                GetComponent<Image>().sprite = _estadoAnterior;
            }
        }

        #endregion

        #region DRAG & DROP BEHAVIOUR

        public bool CanMove = true;
        public static GameObject ItemBeginDragged;

        [FormerlySerializedAs("_startPosition")]
        public static Vector3 StartPosition;

        [FormerlySerializedAs("_startParent")] public static Transform StartParent;
        private CanvasGroup _canvasGroup;


        #region  BeginDrag

        public void OnBeginDrag(PointerEventData eventData) {
            if (CanMove) {
//                GetComponent<LayoutElement>().ignoreLayout = true;
//                GetComponent<LayoutElement>().layoutPriority += 100;
                ItemBeginDragged = gameObject;
//                ItemBeginDragged.transform.SetParent(transform.parent.parent);
                StartPosition = transform.position;
                StartParent = transform.parent;
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
//            GetComponent<LayoutElement>().ignoreLayout = false;
            if (CanMove) {
                ItemBeginDragged = null;

                _canvasGroup.blocksRaycasts = true;
                if (transform.parent == StartParent) {
                    transform.position = StartPosition;
                }
            }
        }

        #endregion

        #endregion
    }
}