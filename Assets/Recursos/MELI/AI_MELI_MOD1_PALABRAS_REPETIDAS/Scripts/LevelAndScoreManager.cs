using System.Collections;
using System.Linq;
using System.Net.Mime;
using System.Runtime.InteropServices;
using AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Audio;
using Recursos.MELI.AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Scripts.AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Navegation;
using Resource.LIBRO_C.AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Scripts.AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Score;
using Resource.LIBRO_F.AI_MELI_MOD1_LABERINTO_OCULAR.Scripts;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Resource.MELI.AI_MELI_MOD1_PALABRAS_REPETIDAS.Scripts {
    public class LevelAndScoreManager : MonoBehaviour {
        [SerializeField] private Transform _enemyPrefab;
        [SerializeField] private GameObject _rockPrefab;
        [SerializeField] private GameObject _screenLifes;
        [SerializeField] public string[] wordList;
        [SerializeField] private Text aciertosText, errorText, _screenText;

        
        // lo nuevo 
        [SerializeField] private GameObject[] _diccionario;
        [SerializeField] private GameObject PalabraMostrar;

        private Word[] _words;

        private GameObject[] _gameObjects;
        [SerializeField] [Header("Administrador de puntaje: ")]
        public ScoreManager ScoreManager;
        
        [Header("Administrador de audios")] [SerializeField]
        public FXAudio _FxAudio;
        
        [SerializeField] private PerformanceManager _performanceManager;
        [SerializeField] private NavegationManager _navegationManager;
        
        //lo nuevo
        
        public Vector3 InitRockPosition;
        public int Aciertos, Errores, MaxErrores,x,y,z;

        ArrayList _diccionary = new ArrayList();
        
        
        public FXAudio FxAudio {
            get => _FxAudio;
            set => _FxAudio = value;
        }
        

        private void Start() {
            /*foreach (var word in wordList) {
                _diccionary.Add(word);
            }
*/

            //Debug.Log("Number of words " + _diccionary.Count);
            ChooseWord();
            PositionChild();

            

        }

        public void IncreaseScore() {
            Aciertos++;
            aciertosText.text = Aciertos + "";
            ScoreManager.IncreaseScore();
            if (Aciertos == 6)
            {
                _navegationManager.Forward(2);
            }

            //TODO Add sound manager
        }

        public void ReduceScore() {
            if (Errores < MaxErrores) {
                Errores++;
                errorText.text = Errores + "";
            }
            if (Errores == 6)
            {
                _navegationManager.Forward(2);
            }

            //TODO Add sound manager
        }

        public bool CheckWord() {
            /*for (int i = 0; i < 5; i++) {
                if (_screenText.text == wordList[i]) {
                    IncreaseScore();
                    return true;
                }
            }*/

            _words = PalabraMostrar.GetComponentsInChildren<Word>();
            foreach (var elem in _words)
            {
                if (elem.isTrue)
                {
                    _FxAudio.PlayAudio(2);
                    IncreaseScore();
                    deleteChild();
                    ChooseWord();
                    PositionChild();
                    return true;  
                }
                else
                {
                    _FxAudio.PlayAudio(1);
                    ReduceScore();
                    deleteChild();
                    ChooseWord();
                    PositionChild();
                    return false;
                }
            }

            
            return false;
        }

        public void SpawnEnemy() {
            throw new System.NotImplementedException();
        }

        public void SpawnRock() {
            _rockPrefab.transform.position = InitRockPosition;
            _rockPrefab.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }

        public void ChooseWord() {
            /*int index = Random.Range(0, _diccionary.Count);
            _screenText.text = (string) _diccionary[index];
            _diccionary.Remove(index);*/
            Debug.Log("diccionario tam: "+_diccionario.Length);
            int index = Random.Range(0,_diccionario.Length);
            _diccionario[index].transform.SetParent(PalabraMostrar.transform);
            Debug.Log("En palabra Mostrar: "+ _diccionario[index]);
      
            _diccionario = _diccionario.Where((val, idx) => idx != index).ToArray();// Para eliminar GO de una lista
        }

        public void PositionChild()
        {
            foreach (Transform elem in PalabraMostrar.transform)
            {
                elem.transform.position = elem.transform.parent.TransformPoint(5,7,z);
            }
        }

        public void deleteChild()
        {
            foreach (Transform child in PalabraMostrar.transform)
            {
                Destroy(child.gameObject);
            }
        }
    }
}
