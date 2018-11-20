using AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Audio;
using Resource.LIBRO_C.AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Scripts.AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Score;
using UnityEngine;

//<summary>
//Ball movement controlls and simple third-person-style camera
//</summary>
namespace Resource.LIBRO_C.AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Scripts.AI_MELI_MOD1_LABERINTO_OCULAR {
    public class RollerBall : MonoBehaviour {
        public GameObject ViewCamera = null;
        public AudioClip JumpSound = null;
        public AudioClip HitSound = null;
        public AudioClip CoinSound = null;
        private Rigidbody mRigidBody = null;
        [SerializeField]private ScoreManager _scoreManager;
        private AudioSource _mAudioSource = null;
        private bool mFloorTouched = false;
        private bool isFlat = true;
        [SerializeField] private FXAudio _fxAudio;
        public int Velocity;


        void Awake() {
            mRigidBody = GetComponent<Rigidbody>();
            _mAudioSource = GetComponent<AudioSource>();
            Application.targetFrameRate = 120;
            QualitySettings.vSyncCount = 0;
        }

        void FixedUpdate() {
            if (mRigidBody != null && isFlat) {
                Vector3 filt = Input.acceleration;

                filt = Quaternion.Euler(90f, 0f, -90f) * filt;
                mRigidBody.AddTorque(filt * Velocity);
            }


            if (Input.GetButton("Horizontal")) {
                mRigidBody.AddTorque(Vector3.back * Input.GetAxis("Horizontal") * Velocity);
            }

            if (Input.GetButton("Vertical")) {
                mRigidBody.AddTorque(Vector3.right * Input.GetAxis("Vertical") * Velocity);
            }

            if (Input.GetButtonDown("Jump")) {
                if (_mAudioSource != null && JumpSound != null) {
                    _mAudioSource.PlayOneShot(JumpSound);
                }

                mRigidBody.AddForce(Vector3.up * 200);
            }


            if (ViewCamera != null) {
                Vector3 direction = (Vector3.up * 2 + Vector3.back) * 2;
                RaycastHit hit;
                Debug.DrawLine(transform.position, transform.position + direction, Color.red);
                if (Physics.Linecast(transform.position, transform.position + direction, out hit)) {
                    ViewCamera.transform.position = hit.point;
                }
                else {
                    ViewCamera.transform.position = transform.position + direction;
                }

                ViewCamera.transform.LookAt(transform.position);
            }
        }

        void OnCollisionEnter(Collision coll) {
            if (coll.gameObject.tag.Equals("Floor")) {
                mFloorTouched = true;
                if (_mAudioSource != null && HitSound != null && coll.relativeVelocity.y > .5f) {
                    _mAudioSource.PlayOneShot(HitSound, coll.relativeVelocity.magnitude);
                }
            }
            else {
                if (_mAudioSource != null && coll.relativeVelocity.magnitude > 2f) {
                    //mAudioSource.PlayOneShot(HitSound, coll.relativeVelocity.magnitude);
                    Handheld.Vibrate();
                }
            }
        }

        void OnCollisionExit(Collision coll) {
            if (coll.gameObject.tag.Equals("Floor")) {
                mFloorTouched = false;
            }
        }

        void OnTriggerEnter(Collider other) {
            if (other.gameObject.CompareTag("CoinRight")) {
                _fxAudio.PlayAudio(0);
               // _scoreManager.IncreaseScore();
            }
            else if (other.gameObject.CompareTag("CoinWrong")) {
                _fxAudio.PlayAudio(1);
            }

            Destroy(other.transform.parent.gameObject);
        }
    }
}

