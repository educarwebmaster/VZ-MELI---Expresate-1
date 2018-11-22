using UnityEngine;

namespace Resource.LIBRO_F.AI_MELI_MOD1_LABERINTO_OCULAR.Scripts {
    public class AnimationManager : MonoBehaviour {
        [SerializeField] private Animator _animator;


        /// <summary>
        /// Reproduce la animacion de abrir menu pausa
        /// </summary>
        public void OpenPauseMenuAnimation() {
            if (_animator != null) {
                _animator.SetBool("Resume", false);
                _animator.SetBool("Pause", true);
            }
        }

        /// <summary>
        /// Reproduce la animacion de cerrar menu pausa.
        /// </summary>
        public void ClosePauseMenuAnimation() {
            if (_animator != null) {
                _animator.SetBool("Pause", false);
                _animator.SetBool("Resume", true);
            }
        }
    }
}