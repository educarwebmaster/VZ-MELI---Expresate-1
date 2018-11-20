using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PAGINA : MonoBehaviour {
    public Text Texto;

	void Start () {
	
	}
	
	void Update () {
	
	}

    public void Actualizar(string TextoNuevo)
    {
        Texto.text = TextoNuevo;
    }
}
