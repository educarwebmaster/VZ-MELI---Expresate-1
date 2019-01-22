using AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Audio;
using AREAS.LENGUAJE.EXPRESATE.SEPTIMO.VZ_LEN7_IMAGEN_ANIMACION.Scripts.Misc;
using Recursos.EXPRESATE.RESPUESTA_MULTIPLE.Scripts;
using Recursos.MELI.AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Scripts.AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Misc;
using Resource.MELI.AI_MELI_MOD1_PALABRAS_REPETIDAS.Scripts;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Resource.EXPRESATE.RESPUESTA_MULTIPLE.Scripts
{
    public class SlotHandler : MonoBehaviour, IDropHandler
    {
        #region DROP MANAGER

        [Header("Identificador")] public int Id;

        [Header("¿Remplazar nombre?")] [Tooltip("Remplaza el nombre del elemento por la id asignada")] [SerializeField]
        private bool _remplazarNombre;

        public bool Calificado;
        public FXAudio _FxAudio;


        private void Awake() {
            if (_FxAudio != null) {
                _FxAudio = GameObject.FindGameObjectWithTag(GENERAL_TAG.FXAUDIO).GetComponent<FXAudio>();
            }
        }

        private void Start() {
            //Asigna la id como nombre del elemento
            gameObject.name = _remplazarNombre ? Id + "" : gameObject.name;
            
        }

        private void OnEnable() {
            Calificado = false;
        }

        #endregion

        #region DROP BEHAVIOUR

        public GameObject Item => transform.childCount > 0 ? transform.GetChild(0).gameObject : null;

        #region OnDrop

        public void OnDrop(PointerEventData eventData) {
            //Si no hay un item en el slot el elemento seleccionado se vuelve hijo del slot sobre el cual se encuentra sobrepuesto.
            if (!Item && DragHandler.ItemBeginDragged.GetComponent<DragHandler>().CanMove) {
                DragHandler.ItemBeginDragged.transform.SetParent(transform);
                //Debug.Log(DragHandler.ItemBeginDragged.gameObject.name);
            }
            else {
                DragHandler.ItemBeginDragged.transform.SetParent(transform);
                Item.transform.SetParent(DragHandler.StartParent);
                Item.transform.position = DragHandler.StartPosition;
                if (_FxAudio) {
                    _FxAudio.PlayAudio(0);
                }
            }
        }

        #endregion

        #endregion
    }
}