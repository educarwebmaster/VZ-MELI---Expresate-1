using UnityEngine;

namespace Recursos.MELI.AI_MELI_MOD1_TELESCOPIO_NUMERICO.Scripts {
    public class Telescope : MonoBehaviour {
        
        
        public float turnSpeed = 100f;
        private float mouse;
 
        public void MoverPersonaje(int axis) {
            if (axis == 1) {
                transform.Rotate(Vector3.forward, -turnSpeed * Time.deltaTime);
            }
            else {
             
                transform.Rotate(Vector3.forward, turnSpeed * Time.deltaTime);
            }
        }
    }
}