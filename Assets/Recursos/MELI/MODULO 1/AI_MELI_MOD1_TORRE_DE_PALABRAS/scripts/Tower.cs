using UnityEngine;

namespace Recursos.MELI.TORRE_DE_PALABRAS.scripts
{
    public class Tower : MonoBehaviour {
        public float speed = 50f;
        
        private BoxCollider[] _colliders;
        
        

        public void RotationPiece(float axis) {
            if (axis == 1) {
                transform.Rotate(0, speed * Time.deltaTime , 0);
            }
            else {
                transform.Rotate(0, -speed * Time.deltaTime, 0);
            }
        }
    }
}