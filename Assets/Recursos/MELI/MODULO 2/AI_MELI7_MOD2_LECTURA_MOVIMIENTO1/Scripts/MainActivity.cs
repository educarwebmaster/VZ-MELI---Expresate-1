using System.Collections;
using System.Net.Mime;
using AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Audio;
using Audio;
using Recursos.MELI.AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Scripts.AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Navegation;
using Resource.LIBRO_C.AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Scripts.AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Score;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.UI;

namespace Recursos.MELI.MODULO_2.AI_MELI7_MOD2_LECTURA_MOVIMIENTO1.Scripts
{
    public class MainActivity : MonoBehaviour {
        [SerializeField] [Header("Administrador de puntaje: ")]
        public ScoreManager ScoreManager;

        [Header("Administrador de audios")] [SerializeField]
        public FXAudio _FxAudio;

        public GameObject[] Columnas;
        public GameObject[] Regletas;
        
        [Header("Para comparar")]
        public int IntentosTotal, AciertosTotal, IntentosColumna, AciertosColumna; 

        [SerializeField] private NavegationManager _navegationManager;

        public Text AciertoText, IntentosText;
        
        [Header("Aumentan")]
        public int correctasTotal, incorrectasTotal,correctasColumna,incorrectasColumna = 0;
        
        [SerializeField] private Text _textoCorrecto, _textoIncorrecto;
        public int apuntador,next=0;

        

        

        
        private void Start()
        {
            IntentosColumna = Columnas[0].transform.GetComponent<Columna>().intentos;
            AciertosColumna = Columnas[0].transform.GetComponent<Columna>().correctas;
            
            Debug.Log(transform.parent.GetChild(11).name);
            
        }

        private void Update()
        {
            
            if (apuntador == 3)
            {
               
                StartCoroutine(NextPage1( correctasColumna,  incorrectasColumna));
            }
            
        }

        public FXAudio FxAudio {
            get => _FxAudio;
            set => _FxAudio = value;
        }
        
        
        public void Calificar(bool Answer) {
            //_FxAudio.PlayAudio(Answer ? 2 : 1);
            if (Answer) {
                _FxAudio.PlayAudio(2);
                
                correctasColumna++;
                correctasTotal++;
                _textoCorrecto.text = correctasColumna.ToString();
                ScoreManager.IncreaseScore();
                
            }
            else {
                _FxAudio.PlayAudio(1);
                incorrectasTotal++;
                incorrectasColumna++;
                _textoIncorrecto.text = incorrectasColumna.ToString();
                
            }
            NextPage(correctasTotal,incorrectasTotal);
            ValidateAnswers(correctasColumna,incorrectasColumna);
            
            
        }

        public void ValidateAnswers(int correctasColumna, int incorrectasColumna)
        {
          
            if (correctasColumna == AciertosColumna)
            {
                Debug.Log("si");
                StartCoroutine(NextColumn());
            }
            if (incorrectasColumna == IntentosColumna)
            {
                Debug.Log("si-si");
                StartCoroutine(NextColumn());
            }
        }


        IEnumerator NextColumn()
        {
            yield return new WaitForSeconds(1);
            correctasColumna = 0;
            incorrectasColumna = 0;
            Columnas[apuntador].active = false;
            Regletas[apuntador].active = false;
            next++;
            //Debug.Log("apuntador antes "+apuntador);
            if (apuntador < 3)
            {
                
                apuntador++;
                Columnas[apuntador].active = true;
                Regletas[apuntador].active = true;
                _textoCorrecto.text = "0";
                _textoIncorrecto.text = "0";
                Columnas[apuntador].transform.parent.parent.GetComponentInParent<ScrollRect>().content = Columnas[apuntador].transform.GetComponent<RectTransform>();
                IntentosColumna = Columnas[apuntador].transform.GetComponent<Columna>().intentos;
                AciertosColumna = Columnas[apuntador].transform.GetComponent<Columna>().correctas;
               // Debug.Log("apuntador despues "+apuntador);
            }
            if (apuntador == 1)
            {
                Vector3 temp = new Vector3(-234f,97f,0);
                transform.parent.GetChild(11).transform.localPosition = temp;
            }
            if (apuntador == 2)
            {
                Vector3 temp = new Vector3(54,97f,0);
                transform.parent.GetChild(11).transform.localPosition = temp;
            }
            if (apuntador == 3)
            {
                Vector3 temp = new Vector3(345f,96.1f,0);
                transform.parent.GetChild(11).transform.localPosition= temp;
                NextPage1(AciertosColumna,IntentosColumna);
            }
            

        }


        public void NextPage(int correctasTotal, int incorrectasTotal)
        {
            //Debug.Log("Total C: "+correctasTotal+" Total I: "+incorrectasTotal);
            if (correctasTotal == AciertosTotal)
            {
                _navegationManager.GoToElement(11);
            }
            if (incorrectasTotal == IntentosTotal)
            {
                //_navegationManager.Forward(2);
                _navegationManager.GoToElement(11);
            }

        }

        IEnumerator NextPage1(int correctasColumna, int incorrectasColumna)
        {
            //Debug.Log("Entre next1");
            yield return new WaitForSeconds(1);
            if (incorrectasColumna == 3)
            {
                //_navegationManager.Forward(2);
                _navegationManager.GoToElement(11);
            }

            if (correctasColumna == 1)
            {
                //_navegationManager.Forward(2);
                _navegationManager.GoToElement(11);
            }
        }
    }
}