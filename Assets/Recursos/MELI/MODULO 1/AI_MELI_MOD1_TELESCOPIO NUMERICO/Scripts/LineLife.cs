using UnityEngine;
using UnityEngine.UI;

namespace Recursos.MELI.AI_MELI_MOD1_TELESCOPIO_NUMERICO.Scripts {
    public class LineLife : MonoBehaviour {
        public Image _healthBar;
        [SerializeField] private ActivityMaganer _activityMaganer;
        [SerializeField] private Transform _parent;
        public float  range = 0.1f;
        public bool IsInside { get; set; }
        // Use this for initialization

        private void Awake() {
            _healthBar = GetComponent<Image>();
        }

        private void Update() {
            SubtractLife(range);
        }


        public void SubtractLife(float range) {
            if (IsInside && _healthBar.fillAmount > 0) {
                _healthBar.fillAmount -= Time.deltaTime * range;
            }
            else if ( _healthBar.fillAmount <= 0f) {
                IsInside = false;
                
                _parent.gameObject.SetActive(false);

                if (_parent.GetComponent<Estrella>().isTrue) {
                    Debug.Log("yes");
                    _activityMaganer.Calificar(true);
                }
                else {
                    _activityMaganer.Calificar(false);
                }
            }
        }
    
    }
}