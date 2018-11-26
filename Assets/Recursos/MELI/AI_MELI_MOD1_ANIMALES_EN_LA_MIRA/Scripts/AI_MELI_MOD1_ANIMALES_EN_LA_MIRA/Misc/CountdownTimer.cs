using System;
using System.Collections;
using Navegation;
using Recursos.MELI.AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Scripts.AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Navegation;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

namespace Misc {
    public class CountdownTimer : MonoBehaviour {
        [Header("Tiempo en segundos a asignar")] [SerializeField]
        private int _timeValue;

        private int _currentTime;

        [Header("Texto a asignar el contador")] [SerializeField]
        private bool _hasText;

        [EnableIf("_hasText", true)] [SerializeField]
        private Text _timeText;

        [Header("Habilita un elemento")]
        [SerializeField]
        [Tooltip("Habilita un elemento (GameObject) al terminar la cuenta regresiva")]
        private bool _enableElement;


        [SerializeField] [EnableIf("_enableElement", true)]
        private GameObject _gameElement;


        [Header("Redirige a otro elemento")]
        [SerializeField]
        [Tooltip("Redirige a otro laypout cuando se acaba el tiempo")]
        private bool _forward;

        [SerializeField] [EnableIf("_forward", true)]
        private NavegationManager _navegationManager;


        private TimeSpan _timeSpan;


        private void OnEnable() {
            _currentTime = _timeValue;
            StartCoroutine(CountDown());
        }


        /// <summary>
        /// Asigna una cuenta regresiva 
        /// </summary>
        /// <returns></returns>
        private IEnumerator CountDown() {
            if (_currentTime > 0) {
                _currentTime--;
                if (_hasText) {
                    _timeSpan = TimeSpan.FromSeconds(_currentTime);
                    var str = _timeSpan.ToString(@"mm\:ss");
                    _timeText.text = str;
                }

                if (_gameElement != null && _enableElement) {
                    _gameElement.SetActive(true);
                }

                yield return new WaitForSeconds(1f);
                StartCoroutine(CountDown());
            }
            else if (_currentTime == 0) {
                if (_forward && _navegationManager != null) {
                    _navegationManager.Forward();
                }

                StopCoroutine(CountDown());
            }
        }
    }
}