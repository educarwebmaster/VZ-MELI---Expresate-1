using AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Audio;
using Boo.Lang;
using Recursos.MELI.AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Scripts.AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Navegation;
using Resource.LIBRO_C.AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Scripts.AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Score;
using UnityEngine;
using UnityEngine.UI;

namespace Recursos.MELI.AI_MELI_MOD1_ALIMENTAR_EL_OJO.Scripts
{
    public class ActivityScore : MonoBehaviour
    {
        //Array para guardar los objetos
        [Header("Objetos Dulces:")] public GameObject[] ArrayDulces;

        [SerializeField] public GameObject _personaje;

        [SerializeField] [Header("Administrador de puntaje: ")]
        public ScoreManager ScoreManager;

        [Header("Administrador de audios")] [SerializeField]
        public FXAudio _FxAudio;

        [SerializeField] public Transform _piso; 
        public int Intentos, Aciertos;

        [SerializeField] private NavegationManager _navegationManager;
        
        public Text AciertoText, IntentosText;

        public bool NotHaveRandom;

        private List<GameObject> ListaRandom = new List<GameObject>(); // Lista para guardar el objeto

        private int correctas, incorrectas = 0;

        [SerializeField] private Text _textoCorrecto, _textoIncorrecto;


        public FXAudio FxAudio
        {
            get => _FxAudio;
            set => _FxAudio = value;
        }

        public void Pause()
        {
            Time.timeScale = 0;
            _personaje.SetActive(false);
            
        }

        public void Resume()
        {
            Time.timeScale = 1;
            _personaje.SetActive(true);
        }


//        private void OnDisable()
//        {
//            Aciertos = incorrectas = correctas = Intentos = 0;
//            ScoreManager.ResetScore();
//            
//        }

//		public void RandomElementos()
//		{
//			if (NotHaveRandom == false) {
//				foreach (var ans in ArrayDulces) {
//					ListaRandom.Add(ans.gameObject);//Guarda la informacion del elemento
//				}
//
//				foreach (var ans in ArrayDulces) {
//					var index = Random.Range(0, ListaRandom.Count);
//					ans.gameObject.transform.position = ListaRandom[index].transform.position; // asigna la posicion del elemento con la posicion del elemenot que está en la lista
//					ans.gameObject.GetComponent<SpriteRenderer>().sprite = ListaRandom[index].GetComponent<SpriteRenderer>().sprite;	 // Muestra un elemento que está en la lista
//					ans.tag = ListaRandom[index].tag;//sobre escribe el tag
//					ListaRandom.Remove(ListaRandom[index]);//Elimna de la lista el elemento que se muestra
//					
//				}
//			}
//		}

        public void Calificar(bool Answer)
        {
            //_FxAudio.PlayAudio(Answer ? 2 : 1);
            if (Answer)
            {
                _FxAudio.PlayAudio(2);
                correctas++;
                _textoCorrecto.text = correctas.ToString();
                ScoreManager.IncreaseScore();
            }
            else
            {
                _FxAudio.PlayAudio(1);
                incorrectas++;
                _textoIncorrecto.text = incorrectas.ToString();
            }
            
            AsignarTexto(correctas,incorrectas);
        }

        public void AsignarTexto(int correctas, int incorrectas)
        {
            if (correctas == Aciertos)
            {
                //Time.timeScale = 0f;
                _navegationManager.Forward(2);
            }
            if (incorrectas == Intentos)
            {    
                //Time.timeScale = 0f;
                _navegationManager.Forward(2);
            }
        }

        public void ResetVariables()
        {
            incorrectas = correctas = 0;
            _textoCorrecto.text = "0";
            _textoIncorrecto.text = "0";
            
            ScoreManager.ResetScore();

            foreach (var dulces in ArrayDulces)
            {
                dulces.SetActive(true);
                dulces.transform.SetPositionAndRotation(_piso.position,Quaternion.identity);
            }
            
        }
    }
}