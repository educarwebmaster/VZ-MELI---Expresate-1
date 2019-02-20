using Audio;
using Recursos.MELI.AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Scripts.AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Misc;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Recursos.MELI.MODULO_2.AI_MELI7_MOD2_LECTURA_MOVIMIENTO1.Scripts
{
    public class Numero : MonoBehaviour,IPointerDownHandler
    {


        public bool isTrue;

        public bool active,seleccionado;

        private Transform child;

        [SerializeField] private MainActivity _mainActivity;
        // Use this for initialization
        void Start () {
            
        }
	
        // Update is called once per frame
        void Update () {
       
        }
	
        public void OnPointerDown(PointerEventData eventData)
        {
            child = gameObject.transform.GetChild(0);
            
            if (seleccionado == false)
            {
                if (active)
                {
                    if (isTrue)
                    {
                        _mainActivity.Calificar(isTrue);
                        active = false;
                        seleccionado = true;
                        Debug.Log(child.name);
                        ChangeColor(child,2);

                    }
                    else
                    {
                        _mainActivity.Calificar(isTrue);
                        active = false;
                        seleccionado = true;
                        Debug.Log(child.name);
                        ChangeColor(child,3);
                    }
                }	
            }

			
        }
		
        private void OnTriggerStay2D(Collider2D other)
        {
            child = gameObject.transform.GetChild(0);
            if (seleccionado == false)
            {
                if (other.gameObject.CompareTag(TAGS.REGLETA))
                {
                
                   // Debug.Log("si");
                    active = true;
                    ChangeColor(child,0);
                
                }
                else
                {
                    active = false;
                }
            }

            

        }

        private void OnTriggerExit2D(Collider2D other)
        {

            child = gameObject.transform.GetChild(0);
            if (seleccionado == false)
            {
                active = false;
                ChangeColor(child,1);

            }

            
        }

        public void ChangeColor(Transform child, int id)
        {
            if (id == 0)
            {
                //Activo
                child.GetComponent<Text>().color = new Color32(255,121,0,255);
            }

            if (id == 1)
            {
                // No activo
                child.GetComponent<Text>().color = new Color(0,0,0, 255);
            }
            if (id == 2)
            {
                // Correcto
                child.GetComponent<Text>().color = new Color(0, 255, 0, 255);
            }
            if (id == 3)
            {
                // Incorrecto
                child.GetComponent<Text>().color = new Color(255, 0, 0, 255);
            }
        }
    }
}