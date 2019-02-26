using System;
using System.Collections;
using System.Net.Mime;
using AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Audio;
using Recursos.MELI.AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Scripts.AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Navegation;
using Resource.LIBRO_C.AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Scripts.AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Score;
using UnityEngine;
using UnityEngine.UI;

namespace Recursos.MELI.MODULO_2.AI_MELI7_MOD2_LECTURA_MOVIMIENTO1.Scripts
{
    public class Palabra : MonoBehaviour
    {

        public String _respuesta;

        private Text texto;

        private int aciertos, intentos;

        [SerializeField] private Text textoAcierto, textoIntentos;
		
        [SerializeField] [Header("Administrador de puntaje: ")]
        public ScoreManager ScoreManager;

        [Header("Administrador de audios")] [SerializeField]
        public FXAudio _FxAudio;
		
        [SerializeField] private NavegationManager _navegationManager;

        [SerializeField] private InputField _inputField;
		
		
        public FXAudio FxAudio {
            get => _FxAudio;
            set => _FxAudio = value;
        }
		
        // Use this for initialization
        void Start ()
        {
            texto = gameObject.transform.GetChild(1).GetComponent<Text>();	
        }
	
        // Update is called once per frame
        void Update () {
			
        }

        public void ValidateWord()
        {
            if (texto.text == _respuesta)
            {
                aciertos++;
                textoAcierto.text = aciertos.ToString();
                gameObject.transform.GetComponent<InputField>().interactable = false;
                texto.color = new Color32(114,187,0,255);
                ScoreManager.IncreaseScore();
                _FxAudio.PlayAudio(2);
               _navegationManager.Forward();
            }
            else
            {
                intentos++;
                textoIntentos.text = intentos.ToString();
                texto.text = "";
                _FxAudio.PlayAudio(1);
                texto.color = Color.red;
                StartCoroutine(ResetText());

                if (intentos == 3)
                {
                   _navegationManager.Forward();
                }
            }
        }

        IEnumerator ResetText()
        {
            Debug.Log("entre Reset");
            yield return new WaitForSeconds(2);
            gameObject.transform.GetComponent<InputField>().text = "";
            texto.color = Color.black;
        }

        public void CleaActivity()
        {
            /*gameObject.transform.GetComponent<InputField>().text = "";
            texto.color = Color.black;
            aciertos = 0;
            intentos = 0;
            textoAcierto.text = "0";
            textoIntentos.text = "0";*/
        }
        


    }
}