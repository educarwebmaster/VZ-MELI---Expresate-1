using UnityEngine;

namespace Resource.MELI.AI_MELI_MOD1_PALABRAS_REPETIDAS.Scripts {
    public class RotateAlien : MonoBehaviour {
        [SerializeField] private float _rotationSpeed, _rotationForce;
   

        // Update is called once per frame
        void Update() {
            _rotationSpeed += _rotationForce * Time.deltaTime;
            transform.rotation = Quaternion.Euler(new Vector3(0, _rotationSpeed, 0));
        }
    }
}