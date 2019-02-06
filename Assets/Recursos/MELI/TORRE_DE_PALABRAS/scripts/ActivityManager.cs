using AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Audio;
using Recursos.MELI.AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Scripts.AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Navegation;
using Resource.LIBRO_C.AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Scripts.AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Score;
using Resource.LIBRO_F.AI_MELI_MOD1_LABERINTO_OCULAR.Scripts;
using UnityEngine;
using UnityEngine.UI;


namespace Recursos.MELI.TORRE_DE_PALABRAS.scripts
{
	public class ActivityManager : MonoBehaviour {

		[SerializeField] [Header("Administrador de puntaje: ")]
		public ScoreManager ScoreManager;
		
		
		[Header("Administrador de audios")] [SerializeField]
		public FXAudio _FxAudio;
		
		public int Intentos, Aciertos, correctas =0,incorrectas=0;

		
		[SerializeField] private PerformanceManager _performanceManager;
		[SerializeField] private NavegationManager _navegationManager;

		
		// Use this for initialization
		void Start () {
		
		}
	
		// Update is called once per frame
		void Update () {
		
		}
		
		public FXAudio FxAudio {
			get => _FxAudio;
			set => _FxAudio = value;
		}
		
		public void Calificar(bool Answer) {
			//_FxAudio.PlayAudio(Answer ? 2 : 1);
			if (Answer) {
				_FxAudio.PlayAudio(2);
				correctas++;
				
				ScoreManager.IncreaseScore();
			}
			else {
				_FxAudio.PlayAudio(1);
				incorrectas++;
				
			}

			AsignarTexto(correctas, incorrectas);
		}
		
		public void AsignarTexto(int correctas, int incorrectas) {
			if (correctas == Aciertos) {
				//Time.timeScale = 0f;
				_navegationManager.Forward(2);
				//_performanceManager.RestartLevel(0);
				
				
				
			}

			if (incorrectas == Intentos) {
				//Time.timeScale = 0f;
				_navegationManager.Forward(2);
				//_performanceManager.RestartLevel(0);
				
				
			}
		}
		public void ResetVariables() {
			incorrectas = correctas = 0;
		

			ScoreManager.ResetScore();

		}
	}
}
