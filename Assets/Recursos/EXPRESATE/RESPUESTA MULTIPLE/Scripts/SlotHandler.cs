using UnityEngine;
using UnityEngine.EventSystems;

namespace Resource.EXPRESATE.RESPUESTA_MULTIPLE.Scripts {
    public class SlotHandler : MonoBehaviour, IDropHandler {
        #region DROP MANAGER

        [Header("Identificador")] public int Id;

        [Header("¿Remplazar nombre?")] [Tooltip("Remplaza el nombre del elemento por la id asignada")] [SerializeField]
        private bool _remplazarNombre;

        private void Start() {
            //Asigna la id como nombre del elemento
            gameObject.name = _remplazarNombre ? Id + "" : gameObject.name;
        }

        #endregion

        #region DROP BEHAVIOUR

        public GameObject Item => transform.childCount > 0 ? transform.GetChild(0).gameObject : null;

        #region OnDrop

        public void OnDrop(PointerEventData eventData) {
            //Si no hay un item en el slot el elemento seleccionado se vuelve hijo del slot sobre el cual se encuentra sobrepuesto.
            if (!Item && DragHandler.CanMove) {
                DragHandler.ItemBeginDragged.transform.SetParent(transform);
                Debug.Log(DragHandler.ItemBeginDragged.gameObject.name);
            }
        }

        #endregion

        #endregion
    }
}