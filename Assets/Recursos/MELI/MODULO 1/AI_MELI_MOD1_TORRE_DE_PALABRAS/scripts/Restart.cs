using UnityEngine;
using UnityEngine.SceneManagement;

namespace Recursos.MELI.TORRE_DE_PALABRAS.scripts
{
	public class Restart: MonoBehaviour {

		// Use this for initialization
		
		[SerializeField] private GameObject _portada;

		
		public void ResetScene(int index)
		{
			SceneManager.LoadScene(index);
			_portada.SetActive(true);
            
		}
	}
}
