using UnityEngine;

namespace Resource.LIBRO_F.AI_MELI_MOD1_LABERINTO_OCULAR.Scripts {
    public class SinWave : MonoBehaviour {
        public float height = 3.2f;
        public float speed = 2.0f;
        public float timingOffset = 0.0f;
        public float count = 0f;

        void FixedUpdate() {
            //count++;
            var offset = Mathf.Sin(Time.time * speed + timingOffset) * height / 2;
            transform.position = new Vector3(count, offset, 0);
        }
    }
}