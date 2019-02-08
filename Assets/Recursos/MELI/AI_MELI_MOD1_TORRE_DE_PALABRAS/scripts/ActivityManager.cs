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
		[SerializeField] private Tower _tower;
		private Pieces[] _pieceses;
		private Rigidbody[] _rigidbodies;
		public float scaleRichter;

		
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
				_rigidbodies = _tower.GetComponentsInChildren<Rigidbody>();
				foreach (var elem in _rigidbodies)
				{
					elem.constraints = RigidbodyConstraints.None;
					
				}
				incorrectas++;
				Quaternion temp = _tower.transform.rotation;
				temp.z += scaleRichter * Time.deltaTime;
				_tower.transform.rotation = temp;
				scaleRichter+=0.2f;

			}

			AsignarTexto(correctas, incorrectas);
		}
		
		public void AsignarTexto(int correctas, int incorrectas) {
			if (correctas == Aciertos) {
				DisablePieces();
			}

			if (incorrectas == Intentos) {
				DisablePieces();
			}

			if (incorrectas == 2)
			{
				scaleRichter = 10f;
			}

		}
		public void ResetVariables() {
			incorrectas = correctas = 0;
//			ScoreManager.ResetScore();

		}

		public void DisablePieces()
		{
			_pieceses = _tower.GetComponentsInChildren<Pieces>();
			foreach (var elem in _pieceses)
			{
				elem.enablePiece = false;
			}
			_navegationManager.Forward(2);
		}
	}
}
