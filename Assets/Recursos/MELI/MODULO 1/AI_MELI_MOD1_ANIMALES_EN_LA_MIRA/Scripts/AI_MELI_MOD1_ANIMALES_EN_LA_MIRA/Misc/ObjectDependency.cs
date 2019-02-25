using UnityEngine;

namespace Misc {
    public class ObjectDependency : MonoBehaviour {
        [Tooltip("Arreglo de objetos conformado por las dependencias")] [Header("Dependencias")] [SerializeField]
        private GameObject[] _gameObjects;

        [SerializeField] [Tooltip("Estado inicial de las dependencias (Habilitados/No habilitados)")]
        private bool _dependencyStatus;


        /// <summary>
        /// Activa el estado invertido de los elementos
        /// </summary>
        public void SetActiveElements() {
            if (_dependencyStatus == false) {
                foreach (var elem in _gameObjects) elem.SetActive(!_dependencyStatus);
                _dependencyStatus = !_dependencyStatus;
            }
            else if (_dependencyStatus) {
                foreach (var elem in _gameObjects) elem.SetActive(!_dependencyStatus);
                _dependencyStatus = !_dependencyStatus;
            }
        }

        public void SetActiveElements(bool flag) {
            foreach (var elem in _gameObjects) elem.SetActive(flag);
        }
    }
}