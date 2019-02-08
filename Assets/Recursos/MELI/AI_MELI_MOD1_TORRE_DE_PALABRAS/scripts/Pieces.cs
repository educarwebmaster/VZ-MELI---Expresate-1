using Lean.Touch;
using UnityEngine;
using UnityEngine.UI;

namespace Recursos.MELI.TORRE_DE_PALABRAS.scripts
{
    public class Pieces : MonoBehaviour {
        public bool isTrue,selectPiece, enablePiece;
        [SerializeField] private Text _palabra;
        private Renderer[] _renderers;
        [SerializeField] private ActivityManager _activityMaganer;
        private Quaternion tensor;
        private void OnMouseDown() {
            selectPieces();
        }

        private void selectPieces()
        {
            
            if (enablePiece)
            {
                if (selectPiece == false)
                {
                    selectPiece = true;
                    if (isTrue) {
                        _renderers = gameObject.GetComponentsInChildren<Renderer>();
                        foreach (var elem in _renderers)
                        {
                            elem.GetComponent<Renderer>().material.color = new Color32(114,187,0,255);
                                
                        }
                
                        _palabra.color = new Color32(114,187,0,255);
                        _activityMaganer.Calificar(true);
                    }
                    else {
                        gameObject.SetActive(false);
                        _palabra.color = Color.red;
                        _activityMaganer.Calificar(false);
                    }
                }   
            }           
        }

        private void Start()
        {
            gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        }
    }
}