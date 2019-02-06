using UnityEngine;
using UnityEngine.EventSystems;

namespace Recursos.MELI.AI_MELI_MOD1_TELESCOPIO_NUMERICO.Scripts {
   public class Boton : MonoBehaviour , IPointerDownHandler, IPointerUpHandler{

      public int axis;
      private bool op;
      [SerializeField] private Telescope _moverPersonaje;
      void Update()
      {
         if (op) _moverPersonaje.MoverPersonaje(axis);
      }

      //detecta el clic del mouse (Press)
      public void OnPointerDown(PointerEventData eventData)
      {
         op = true;
         //Debug.Log(op);
      }

      //detecta el release del mouse
      public void OnPointerUp(PointerEventData eventData)
      {
         op = false;
         Debug.Log(op);
      
      }
   }
}