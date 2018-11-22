using Sirenix.OdinInspector;
using UnityEngine;

namespace GENERAL {
    public class OnLoadDependency : MonoBehaviour {
        [Tooltip(
            "Al habilitar esta opcion el elemento anidado se deshabilita y se habilita al activar o desactivar el elemento")]
        public bool EnableDependency, DisableDependency;


        [EnableIf("EnableDependency", true)] [SerializeField]
        private GameObject _Enabledependency;

        [EnableIf("DisableDependency", true)] [SerializeField]
        private GameObject _DisableDependency;

        /// <summary>
        /// Getter & Setter
        /// </summary>
        public GameObject Dependency {
            get => _Enabledependency;
            set => _Enabledependency = value;
        }


        /// <summary>
        /// Deshabilita el elemento al iniciar el elemento
        /// </summary>
        private void OnEnable() {
            if (_Enabledependency != null && EnableDependency)
                _Enabledependency.SetActive(false);
            if (DisableDependency && _DisableDependency != null) {
                _DisableDependency.SetActive(true);
            }
        }

        /// <summary>
        /// Habilita el elemento al iniciar el elemento
        /// </summary>
        private void OnDisable() {
            if (_Enabledependency != null && EnableDependency)
                _Enabledependency.SetActive(true);

            if (DisableDependency && _DisableDependency != null) {
                _DisableDependency.SetActive(false);
            }
        }
    }
}