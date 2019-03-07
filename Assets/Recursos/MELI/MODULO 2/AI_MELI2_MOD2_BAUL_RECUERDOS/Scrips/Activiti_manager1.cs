using System.Collections;
using System.Collections.Generic;
using AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Audio;
using Recursos.MELI.AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Scripts.AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Navegation;
using Resource.LIBRO_C.AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Scripts.AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Score;
using UnityEngine;
using UnityEngine.UI;

namespace Recursos.MELI.MODULO_2.AI_MELI2_MOD2_BAUL_RECUERDOS.Scrips
{
    public class Activiti_manager1 : MonoBehaviour {

        // Use this for initialization
        [SerializeField] private FXAudio _audio;
        [SerializeField] private ScoreManager _scoreManager;
        [SerializeField] private NavegationManager _navegationManager;
        [SerializeField] private Text _intentos, _aciertos;
        private int _correctas, _incorrectas;

        public List<GameObject> _people;

        // Use this for initialization
        void Start () {
		
        }
	
        // Update is called once per frame
        void Update () 
        {
            _intentos.transform.GetComponent<Text>().text = _incorrectas.ToString();
            _aciertos.transform.GetComponent<Text>().text = _correctas.ToString();
            
		      
        }

        public void Calificar(bool respuesta, GameObject people)
        {
            for (int i = 0; i < _people.Count; i++)
            {
                _people[i].GetComponent<Select_people>()._enable = false;
            }
		
            if (respuesta)
            {
                people.GetComponent<Image>().sprite = people.GetComponent<Select_people>()._spriteTrue;
                _audio.PlayAudio(2);
                _scoreManager.IncreaseScore();
                _correctas = _correctas + 1;
                // StartCoroutine(showImageAnswer(respuesta));

            }
            else
            {
               people.GetComponent<Image>().sprite = people.GetComponent<Select_people>()._spriteTrue;
                _audio.PlayAudio(1);
                _incorrectas = _incorrectas + 1;
                //StartCoroutine(showImageAnswer(respuesta));
            }
        }
	
        /*IEnumerator showImageAnswer(bool respuesta)
        {
            yield return new WaitForSeconds(1);
		
            if (respuesta)
            {
                _navegationManager.Forward(2);
            }
            else
            {
                _navegationManager.Forward(2);
            }
        }*/
    }


}