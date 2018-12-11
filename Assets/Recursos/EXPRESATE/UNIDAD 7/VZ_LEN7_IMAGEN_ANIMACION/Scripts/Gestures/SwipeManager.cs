using System;
using UnityEngine;

namespace AREAS.LENGUAJE.EXPRESATE.SEPTIMO.VZ_LEN7_IMAGEN_ANIMACION.Scripts.Gestures {
    [Flags]
    public enum SwipeDirection {
        None = 0,
        Left = 1,
        Right = 2,
        Up = 4,
        Down = 8
    }

    public class SwipeManager : MonoBehaviour {
        public static SwipeManager Instance { get; private set; }
        private Vector3 _touchPosition;
        public float swipeResistenceX = 25f;
        public float swipeResistenceY = 50f;
        public SwipeDirection Direction { get; set; }


        private void Start() {
            Instance = this;
        }

        private void Update() {
            Direction = SwipeDirection.None;
            if (Input.GetMouseButtonDown(0)) {
                _touchPosition = Input.mousePosition;
            }
            else if (Input.GetMouseButtonUp(0)) {
                Vector2 deltaSwipePosition = _touchPosition - Input.mousePosition;
                if (Mathf.Abs(deltaSwipePosition.x) > swipeResistenceX) {
                    Direction |= deltaSwipePosition.x > 0 ? SwipeDirection.Right : SwipeDirection.Left;
                }

                if (Mathf.Abs(deltaSwipePosition.y) > swipeResistenceY) {
                    Direction |= deltaSwipePosition.y > 0 ? SwipeDirection.Down : SwipeDirection.Up;
                }
            }
        }

        public bool IsSwiping(SwipeDirection dir) {
            return dir == Direction;
        }
    }
}