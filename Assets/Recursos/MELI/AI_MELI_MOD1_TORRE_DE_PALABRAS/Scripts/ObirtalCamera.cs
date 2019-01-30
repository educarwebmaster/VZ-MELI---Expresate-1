using UnityEngine;

namespace Recursos.MELI.AI_MELI_MOD1_TORRE_DE_PALABRAS.Scripts {
    public class ObirtalCamera : MonoBehaviour {
        public float _speed = 8f;
        public float _distance = 3f;

        public Transform _target;
        private Vector2 _input;

        // Use this for initialization
        void Start() {
        }

        // Update is called once per frame
        void Update() {
			_input += new Vector2(Input.GetAxis("Mouse X")*_speed,Input.GetAxis("Mouse Y")*_speed);
			Quaternion _rotation = Quaternion.Euler(_input.y, _input.x,0);
			
			Vector3 _position = _target.position - (_rotation * Vector3.forward * _distance);

			transform.localRotation = _rotation;
			transform.localPosition = _position;

           
        }
    }
}