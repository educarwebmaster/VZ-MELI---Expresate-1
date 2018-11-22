using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AI_MELI_MOD1_RULETA_VISUAL.Scripts {
    public class Needle : MonoBehaviour {
        public Spinner Spinner;
        private bool Lock;
        public Text Scoretext;
        [SerializeField] private GameObject _Popup;
        private List<GameObject> _savedElements = new List<GameObject>();

        public List<GameObject> SavedElements {
            get => _savedElements;
            set => _savedElements = value;
        }


        void OnTriggerStay2D(Collider2D col) {
//        Debug.Log("Spinner " + Spinner.IsStoped);
            if (Spinner.IsStoped) {
                DivElement elem = col.gameObject.GetComponent<DivElement>();
                Scoretext.text = elem.Name;
                if (Spinner.Lock == false) {
                    elem.CheckElement();
                    Spinner.Lock = true;
                
                }
            }

            _savedElements.Add(col.gameObject);
        }


        //Scoretext.text = col.gameObject.name;


        void ResetElements() {
            foreach (var elm in SavedElements) {
                elm.GetComponent<Button>().interactable = true;
            }

// _savedElements.Clear();
        }
    }
}