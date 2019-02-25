using System.Collections;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Resource.MELI.AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Scripts.GENERAL {
    public class DisableElement : MonoBehaviour {
        [Tooltip("Al habilitar o deshabilitar activa o desactiva los elementos almacenados en los siguientes vectores")]
        public bool Enable;

        public int Delay;

        [SerializeField] [EnableIf("Enable", true)]
        private GameObject[] _onloadElements;

        /// <summary>
        /// Al iniciar este GameObject
        /// </summary>
        private void OnEnable() {
            StartCoroutine(DisableElements());
        }

        /// <summary>
        /// Al desactivar este GameObject
        /// </summary>
        private void OnDisable() {
            if (Enable && _onloadElements != null) {
                CheckArray(true, _onloadElements);
            }
        }

        /// <summary>
        /// Asigan el estado activo de los elementos almacenados en elems
        /// </summary>
        /// <param name="status">Estado</param>
        /// <param name="elems">Arreglo o vector a modificar su estado</param>
        private void CheckArray(bool status, GameObject[] elems) {
            foreach (var elem in elems) elem.SetActive(status);
        }

        private IEnumerator DisableElements() {
            yield return new WaitForSeconds(Delay);
            if (Enable && _onloadElements != null) {
                CheckArray(false, _onloadElements);
            }
        }
    }
}