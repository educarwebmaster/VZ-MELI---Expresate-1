using UnityEngine;

namespace Recursos.MELI.TORRE_DE_PALABRAS.scripts
{
	public class Hover_Ground : MonoBehaviour
	{
		private AudioSource _audioSource;
		[SerializeField] private Tower _tower;
		private Pieces[] _pieceses;

		private float duration, actualTime;
		// Use this for initialization
		void Start ()
		{
			_audioSource = gameObject.GetComponent<AudioSource>();
			duration = _audioSource.clip.length;
		}
	
		// Update is called once per frame
		void Update ()
		{
			_pieceses = _tower.GetComponentsInChildren<Pieces>();
			actualTime = _audioSource.time;
			if (actualTime == duration)
			{
				gameObject.SetActive(false);
				foreach (var elem in _pieceses)
				{
					elem.enablePiece = true;
				}
				
			}
			else
			{
				
				gameObject.SetActive(true);
				foreach (var elem in _pieceses)
				{
					elem.enablePiece = false;
				}
				
			}
		}
	}
}
