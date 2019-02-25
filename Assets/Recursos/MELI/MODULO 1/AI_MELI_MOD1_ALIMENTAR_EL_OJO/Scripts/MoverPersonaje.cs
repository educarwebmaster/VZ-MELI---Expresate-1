using Recursos.MELI.AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Scripts.AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Misc;
using UnityEngine;

namespace Recursos.MELI.AI_MELI_MOD1_ALIMENTAR_EL_OJO.Scripts
{
    public class MoverPersonaje : MonoBehaviour
    {
        // Use this for initialization
        public float VelocidadMovimiento = 300;
        public float Xmax;
        public float Xmin;

        [SerializeField] private Rigidbody2D characterBody;
        [SerializeField] private ActivityScore _activityScore;

        private float ScreenWidth;

        //Mueve al personaje de acuerdo a la coordenada establecida 1: derecha, -1: izquierda
        public void Mover(int horizontalInput)
        {
            characterBody.AddForce(new Vector2(horizontalInput * VelocidadMovimiento * Time.deltaTime,0)); // Para mover el personaje en el eje X
        }

        //Detiene la velocidad del personjae
        public void Stop()
        {
            characterBody.velocity = Vector2.zero;
        }

        //Detecta si el personaje choca con el objeto (dulce) 
        private void OnTriggerEnter2D(Collider2D other)
        {


            //Debug.Log(other.gameObject.CompareTag(TAGS.CORRECTA));
            _activityScore.Calificar(other.gameObject.CompareTag(TAGS.CORRECTA));
            other.gameObject.SetActive(false);



        }
    }
}