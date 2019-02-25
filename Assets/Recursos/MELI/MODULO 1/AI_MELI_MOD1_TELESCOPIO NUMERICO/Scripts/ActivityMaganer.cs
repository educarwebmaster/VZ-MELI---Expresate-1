using AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Audio;
using Boo.Lang;
using Recursos.MELI.AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Scripts.AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Navegation;
using Resource.LIBRO_C.AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Scripts.AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Score;
using UnityEngine;
using UnityEngine.UI;


namespace Recursos.MELI.AI_MELI_MOD1_TELESCOPIO_NUMERICO.Scripts {
	public class ActivityMaganer : MonoBehaviour {

	 [Header("Objetos Estrellas:")] public GameObject[] ArrayDulces;

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

        List<Vector3> positions = new List<Vector3>();

        public FXAudio FxAudio {
            get => _FxAudio;
            set => _FxAudio = value;
        }

        public void Pause() {
            Debug.Log("pause");
            Time.timeScale = 0;
            _personaje.SetActive(false);
        }

        public void Resume() {
            Debug.Log("resume");
            Time.timeScale = 1;
            _personaje.SetActive(true);
        }


        private void SavePosition() {
            foreach (var elem in ArrayDulces) {
                positions.Add(elem.transform.localPosition);
            }
        }

//        private void getPositions() {
//            foreach (var posicionDulces in positions) {
//                foreach (var _ElemDulces in ArrayDulces) {
//                    _ElemDulces.transform.position = posicionDulces;
//                }
//            }
//        }

        private void Start() {
            SavePosition();
        }


        private void OnDisable() {
            Time.timeScale = 1;
            _personaje.SetActive(true);
        }

        public void Calificar(bool Answer) {
            //_FxAudio.PlayAudio(Answer ? 2 : 1);
            if (Answer) {
                _FxAudio.PlayAudio(2);
                correctas++;
                _textoCorrecto.text = correctas.ToString();
                ScoreManager.IncreaseScore();
            }
            else {
                _FxAudio.PlayAudio(1);
                incorrectas++;
                _textoIncorrecto.text = incorrectas.ToString();
            }

            AsignarTexto(correctas, incorrectas);
        }

        public void AsignarTexto(int correctas, int incorrectas) {
            if (correctas == Aciertos) {
                //Time.timeScale = 0f;
                _navegationManager.Forward(2);
            }

            if (incorrectas == Intentos) {
                //Time.timeScale = 0f;
                _navegationManager.Forward(2);
            }
        }

        public void ResetVariables() {
            incorrectas = correctas = 0;
            _textoCorrecto.text = "0";
            _textoIncorrecto.text = "0";

            ScoreManager.ResetScore();

            for (int i = 0; i < positions.Count; i++) {
                ArrayDulces[i].transform.localPosition = positions[i];
                ArrayDulces[i].SetActive(true);
            }
        }
    }
}
