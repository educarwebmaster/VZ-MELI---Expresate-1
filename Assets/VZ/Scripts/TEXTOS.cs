using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TEXTOS : MonoBehaviour {
    public GameObject[] Textos;
    public Sprite Desabilitado;
    public Sprite Abilitado;
    private bool Activado;
	void Start () {
        Aparecer();
        Activado = true;
    }
	
	void Update () {
	
	}

    public void Activador(Image Cambiador)
    {
        if (Activado)
        {
            Cambiador.sprite = Desabilitado;
            Activado = false;
            Desaparecer();
        }
        else
        {
            Cambiador.sprite = Abilitado;
            Activado = true;
            Aparecer();
        }
    }

    public void Desaparecer()
    {
        for (int i = 0; i < Textos.Length; i++)
        {
            Textos[i].SetActive(false);
        }
    }

    public void Aparecer()
    {
        for (int i = 0; i < Textos.Length; i++)
        {
            Textos[i].SetActive(true);
        }
    }
}
