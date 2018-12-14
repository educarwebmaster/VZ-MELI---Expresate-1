using System.Collections;
using Navegation;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

namespace Recursos.MELI.AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Scripts.AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Navegation
{
    public class NavegationManager : MonoBehaviour
    {
        public bool HasDelay;
        [FormerlySerializedAs("loadedScene")] public bool LoadedScene;


        [Tooltip("Segundos a esperar al cambiar de layout activo en escena")] [EnableIf("HasDelay", true)]
        public float DelaySeconds;

        public GameObject[] _gameElements;


        /// <summary>
        /// Desactiva todos los elementos en el array y activa y reinicia el elemento en index.
        /// Si tiene un Delay
        /// </summary>
        /// <param name="index">Elemento a activar</param>
        public void GoToElement(int index) {
            StartCoroutine(_GoElement(index));
        }

        private IEnumerator _GoElement(int index) {
            yield return new WaitForSeconds(DelaySeconds);
            if (HasDelay) {
                foreach (var elem in _gameElements) elem.SetActive(false);
                StartCoroutine(CustomDelay(DelaySeconds));
                _gameElements[index].SetActive(true);
            }
            else {
                foreach (var elem in _gameElements) elem.SetActive(false);
                StartCoroutine(CustomDelay(DelaySeconds));
                _gameElements[index].SetActive(true);
            }
        }

        /// <summary>
        /// Determina el layaout activo en escena
        /// </summary>
        /// <returns>indice del elemento</returns>
        public int LayoutActual() {
            for (int i = 0; i < _gameElements.Length; i++) {
                if (_gameElements[i].activeSelf) {
                    return i;
                }
            }

            return 0;
        }


        /// <summary>
        /// Devuelve  el elemento como tal del layout actual
        /// </summary>
        /// <returns></returns>
        public GameObject GetLayoutActual() {
            return _gameElements[LayoutActual()];
        }

        public void LoadScene() {
            LoadedScene = true;
        }

        /// <summary>
        /// Activa el siguiente layout
        /// </summary>
        public void Forward() {
            StartCoroutine(_Forward());
        }

        /// <summary>
        /// Activa el siguiente layout pero con Delay
        /// </summary>
        /// <param name="seconds"></param>
        public void Forward(float seconds) {
            StartCoroutine(_Forward(seconds));
        }

        /// <summary>
        /// Activa el anterior layout
        /// </summary>
        public void Backward() {
            StartCoroutine(_Backward());
        }


        /// <summary>
        /// Hace una espera de n segundos
        /// </summary>
        /// <param name="seconds">segundos a a esperar</param>
        /// <returns></returns>
        private IEnumerator CustomDelay(float seconds) {
            yield return new WaitForSeconds(seconds);
        }

        /// <summary>
        /// Dirige al Anterior  Layout sin tiempo especifico
        /// </summary>
        private IEnumerator _Backward() {
            yield return new WaitForSeconds(DelaySeconds);
            var anteriorElemento = LayoutActual() - 1;
            Debug.Log(anteriorElemento + " index");

            if (anteriorElemento < _gameElements.Length && anteriorElemento >= 0) {
                GoToElement(anteriorElemento);
            }
        }

        /// <summary>
        /// Dirige al Anterior Layout con tiempo especifico
        /// </summary>
        private IEnumerator _Backward(float seconds) {
            yield return new WaitForSeconds(seconds);
            var anteriorElemento = LayoutActual() - 1;
            Debug.Log(anteriorElemento + " index");

            if (anteriorElemento < _gameElements.Length && anteriorElemento >= 0) {
                GoToElement(anteriorElemento);
            }
        }

        /// <summary>
        /// Dirige al siguiente Layout sin  tiempo especifico
        /// </summary>
        private IEnumerator _Forward() {
            yield return new WaitForSeconds(DelaySeconds);
            var siguienteElemento = LayoutActual() + 1;
            //Debug.Log(siguienteElemento + " index");
            if (siguienteElemento > 0 && siguienteElemento < _gameElements.Length) {
                StartCoroutine(CustomDelay(DelaySeconds));
                GoToElement(siguienteElemento);
            }
        }

        /// <summary>
        /// Dirige al siguiente Layout con tiempo especifico
        /// </summary>
        /// <param name="seconds"> Tiempo especifico</param>
        /// <returns></returns>
        private IEnumerator _Forward(float seconds) {
            yield return new WaitForSeconds(seconds);
            var siguienteElemento = LayoutActual() + 1;

            if (siguienteElemento > 0 && siguienteElemento < _gameElements.Length) {
                GoToElement(siguienteElemento);
            }
        }


        public void ViewOwnContent() {
            LayoutManager elem = GetLayoutActual().GetComponent<LayoutManager>();
            if (elem != null && elem.Elemento != null) {
                elem.Elemento.SetActive(true);
            }
        }
    }
}