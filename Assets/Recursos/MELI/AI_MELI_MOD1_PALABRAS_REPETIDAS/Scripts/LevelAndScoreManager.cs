using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Resource.MELI.AI_MELI_MOD1_PALABRAS_REPETIDAS.Scripts {
    public class LevelAndScoreManager : MonoBehaviour {
        [SerializeField] private Transform _enemyPrefab;
        [SerializeField] private GameObject _rockPrefab;
        [SerializeField] private GameObject _screenLifes;
        [SerializeField] private string[] wordList;
        [SerializeField] private Text aciertosText, errorText, _screenText;
        public Vector3 InitRockPosition;
        public int Aciertos, Errores, MaxErrores;

        ArrayList _diccionary = new ArrayList();

        private void Start() {
            foreach (var word in wordList) {
                _diccionary.Add(word);
            }

            Debug.Log("Number of words " + _diccionary.Count);
            ChooseWord();
        }

        public void IncreaseScore() {
            Aciertos++;
            aciertosText.text = Aciertos + "";
            //TODO Add sound manager
        }

        public void ReduceScore() {
            if (Errores < MaxErrores) {
                Errores++;
                errorText.text = Errores + "";
            }

            //TODO Add sound manager
        }

        public bool CheckWord() {
            for (int i = 0; i < 5; i++) {
                if (_screenText.text == wordList[i]) {
                    IncreaseScore();
                    return true;
                }
            }

            ReduceScore();
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
            int index = Random.Range(0, _diccionary.Count);
            _screenText.text = (string) _diccionary[index];
            _diccionary.Remove(index);
        }
    }
}