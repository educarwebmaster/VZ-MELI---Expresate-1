using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

namespace Resource.LIBRO_F.AI_MELI_MOD1_LABERINTO_OCULAR.Scripts {
    public class ThirdPersonInput : MonoBehaviour {
        public Joystick LeftJoystick;

        public FixedButton Button;

//    public FixedTouchField TouchField;
        protected ThirdPersonUserControl Control;

        protected float CameraAngle;
        protected float CameraAngleSpeed = 0.2f;

        // Use this for initialization
        void Start() {
            Control = GetComponent<ThirdPersonUserControl>();
        }

        // Update is called once per frame
        void Update() {
            Control.m_Jump = Button.Pressed;
            Control.Hinput = LeftJoystick.Horizontal;

            Control.Vinput = LeftJoystick.Vertical;
//            Debug.Log("Axis " + Control.Hinput + Control.Vinput);
//        CameraAngle += TouchField.TouchDist.x * CameraAngleSpeed;

//        Camera.main.transform.position = transform.position + Quaternion.AngleAxis(CameraAngle, Vector3.up) * new Vector3(0, 3, 4);
//        Camera.main.transform.rotation = Quaternion.LookRotation(transform.position + Vector3.up * 2f - Camera.main.transform.position, Vector3.up);
        }
    }
}