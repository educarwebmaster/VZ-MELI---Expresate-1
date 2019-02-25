 using Resource.LIBRO_C.AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Scripts.AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Score;
using UnityEngine;
using UnityEngine.UI;

namespace Recursos.MELI.AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Scripts.AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Score
{
    public class MultipleObjectChooseManager : MonoBehaviour
    {
        //Score Manager
        [SerializeField] private ScoreManager _scoreManager;

        private Image[] _buttonsImage;

        //Intentos por actividad
        [Header("Activities Tries")] public int Tries;


        private void Awake() {
            _buttonsImage = GetComponentsInChildren<Image>();
        }

        private void OnEnable() {
            _scoreManager.MultipleActivitiesTries = Tries;
            ResetButtons();
        }

        public void ResetButtons() {
            foreach (var elem in _buttonsImage) {
                elem.raycastTarget = true;
            }
        }
    }
}