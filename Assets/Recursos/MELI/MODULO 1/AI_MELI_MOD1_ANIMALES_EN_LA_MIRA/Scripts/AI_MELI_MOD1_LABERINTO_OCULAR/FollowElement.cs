using UnityEngine;

namespace Resource.LIBRO_C.AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Scripts.AI_MELI_MOD1_LABERINTO_OCULAR {
    public class FollowElement : MonoBehaviour {
        [SerializeField] private GameObject _elementToFollow;


        [SerializeField] private float _offsetZ;

        private void LateUpdate() {
            if (_elementToFollow != null) {
                Vector3 pos = _elementToFollow.transform.position;
                pos.y += _offsetZ;
//                transform.position = pos;
                transform.SetPositionAndRotation(pos, _elementToFollow.transform.rotation);
            }
            else {
                transform.parent.gameObject.SetActive(false);
            }
        }
    }
}