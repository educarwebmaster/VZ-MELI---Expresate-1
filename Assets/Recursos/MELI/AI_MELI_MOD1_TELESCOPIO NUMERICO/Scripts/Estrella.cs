using UnityEngine;

namespace Recursos.MELI.AI_MELI_MOD1_TELESCOPIO_NUMERICO.Scripts {
    public class Estrella : MonoBehaviour {
        // Use this for initialization
        public Vector2 inicialScale, scale, ElementScale;
        public float lim = 0.5f, range = 1f;
        public bool IsInside { get; set; }
        public bool isTrue;
        private LineLife _lineLife;
        void Start() {
            _lineLife = GetComponentInChildren<LineLife>();
            Debug.Log(_lineLife);
            ObtenerScale();
        
        }

        // Update is called once per frame
        void Update() {
        
            OnExit();
        }

        public void ObtenerScale() {
            inicialScale = transform.localScale;
            Debug.Log("Estrella - " + inicialScale);
        }

        public void OnStay() {
            scale = transform.localScale;
            if (scale.x < lim && scale.y < lim) {
                scale.x += Time.deltaTime * range;
                scale.y += Time.deltaTime * range;
                transform.localScale = scale;
                _lineLife.IsInside = true;
            
            }
        }

  

        public void OnExit() {
            if (IsInside) {
                Vector2 temp = inicialScale;
                ElementScale = transform.localScale;
                if (ElementScale.x > inicialScale.x && ElementScale.y > inicialScale.y) {
                    ElementScale.x -= Time.deltaTime * range;
                    ElementScale.y -= Time.deltaTime * range;
                    transform.localScale = ElementScale;
                }

                else if (transform.localScale.x <= inicialScale.x) {
                    IsInside = false;
                    _lineLife.IsInside = false;
                }
            }
        }
    }
}