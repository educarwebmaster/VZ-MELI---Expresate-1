using UnityEngine;

namespace Recursos.MELI.TORRE_DE_PALABRAS.scripts
{
    public class Tower : MonoBehaviour {
        public float speed = 50f;
        
        private BoxCollider[] _colliders;
        
        

        public void RotationPiece(float axis) {
            if (axis == 1) {
                transform.Rotate(0, speed * Time.deltaTime, 0);
            }
            else {
                transform.Rotate(0, -speed * Time.deltaTime, 0);
            }
        }

        public void DisableColliderChildrens(bool op)
        {
            Debug.Log("entre");
            
            if (op)
            {
                Debug.Log("entre2");
                /*_colliders = this.gameObject.GetComponentsInChildren<BoxCollider>();
                foreach (var elem in _colliders)
                {
                    elem.enabled = false;
                }*/
                

            }
            else
            {
                Debug.Log("entre3");
                /*_colliders = this.gameObject.GetComponentsInChildren<BoxCollider>();
                foreach (var elem in _colliders)
                {
                    elem.enabled = true;
                }*/
                 
            }
        }
    }
}