using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/******************************************************************************
                        SISTEMA DE SELECCION MULTIPLE 
                DESARROLLADO POR HECTOR STIVEN GOMEZ RAMIREZ 
******************************************************************************/

[System.Serializable]
public class Escena
{
    public int pagina;
    public int respuesta;
    public Sprite ImagenPagina;
    public string Pregunta;
    public string Opcion1;
    public string Opcion2;
    public string Opcion3;
}

public class SELECCION_MULTIPLE : MonoBehaviour {
    [Header("Paginas")]
    public Escena[] Pagina;
    [Header("Objectos")]
    public GameObject RetroMala;
    public GameObject RetroBuena;
    public GameObject Retro;
    public GameObject P1;
    public GameObject P2;
    public GameObject P3;
    public Transform PadrePreguntas;
    [Header("Audio")]
    public AudioSource Audio;
    public AudioClip SonidoBueno;
    public AudioClip SonidoMalo;
    [Header("GUI")]
    public Image ImagenFondo;
    public Text Pregunta;
    public Text Opcion1;
    public Text Opcion2;
    public Text Opcion3;
    public Text textoBuenas;
    public Text textoMalas;
    private int PaginaActual;
    [Header("Iniciar")]
    public bool Inicial;
    private int correctos = 0;
    private int incorrecto = 0;
    public GENERAL_INTERFAZ General;

    void Start () {
        ImagenFondo.sprite = Pagina[0].ImagenPagina;
        Pregunta.text = Pagina[0].Pregunta;
        PaginaActual = 0;
        Opcion1.text = Pagina[0].Opcion1;
        Opcion2.text = Pagina[0].Opcion2;
        Opcion3.text = Pagina[0].Opcion3;
        P1.transform.SetSiblingIndex(Random.Range(0, 2));
        P2.transform.SetSiblingIndex(Random.Range(0, 2));
        P3.transform.SetSiblingIndex(Random.Range(0, 2));
        RetroBuena.SetActive(false);
        RetroMala.SetActive(false);
        Retro.SetActive(false);
    }

    void Update()
    {
        if (Inicial)
        {
            General.Abrir_visor_3d();
        }
        textoBuenas.text = "" + correctos;
        textoMalas.text = "" + incorrecto;
    }

    public void Verificar(int Selecion)
    {
        if (Selecion == Pagina[PaginaActual].respuesta)
        {
            RetroBuena.SetActive(true);
            RetroBuena.GetComponent<Animator>().Play("RetroBuena");
            Audio.clip = SonidoBueno;
            Audio.Play();
            StartCoroutine("Next");
            correctos += 1;
        }
        else
        {
            RetroMala.SetActive(true);
            RetroBuena.GetComponent<Animator>().Play("RetroMala");
            Audio.clip = SonidoMalo;
            Audio.Play();
            StartCoroutine("Next");
            incorrecto += 1;
        }
    }

    public IEnumerator Next()
    {
        yield return new WaitForSeconds(3);
        Siguiente();
    }

    public IEnumerator After()
    {
        yield return new WaitForSeconds(3);
        Anterior();
    }

    public void Siguiente()
    {
        if (PaginaActual < Pagina.Length)
        {
            PaginaActual += 1;
        }
        if (PaginaActual == Pagina.Length)
        {
            Retro.SetActive(true);
        }
        if (PaginaActual >= Pagina.Length)
        {
            RetroBuena.SetActive(false);
            RetroMala.SetActive(false);
            ImagenFondo.sprite = Pagina[0].ImagenPagina;
            Pregunta.text = Pagina[0].Pregunta;
            PaginaActual = 0;
            Opcion1.text = Pagina[0].Opcion1;
            Opcion2.text = Pagina[0].Opcion2;
            Opcion3.text = Pagina[0].Opcion3;
            P1.transform.SetSiblingIndex(Random.Range(0, 2));
            P2.transform.SetSiblingIndex(Random.Range(0, 2));
            P3.transform.SetSiblingIndex(Random.Range(0, 2));
        }
        ImagenFondo.sprite = Pagina[PaginaActual].ImagenPagina;
        Pregunta.text = Pagina[PaginaActual].Pregunta;
        Opcion1.text = Pagina[PaginaActual].Opcion1;
        Opcion2.text = Pagina[PaginaActual].Opcion2;
        Opcion3.text = Pagina[PaginaActual].Opcion3;
        P1.transform.SetSiblingIndex(Random.Range(0, 2));
        P2.transform.SetSiblingIndex(Random.Range(0, 2));
        P3.transform.SetSiblingIndex(Random.Range(0, 2));
        RetroBuena.SetActive(false);
        RetroMala.SetActive(false);
    }

    public void Anterior()
    {
        if (PaginaActual > 0)
        {
            PaginaActual -= 1;
        }
        if (PaginaActual > Pagina.Length)
        {
            RetroBuena.SetActive(false);
            RetroMala.SetActive(false);
        }
        ImagenFondo.sprite = Pagina[PaginaActual].ImagenPagina;
        Pregunta.text = Pagina[PaginaActual].Pregunta;
        Opcion1.text = Pagina[PaginaActual].Opcion1;
        Opcion2.text = Pagina[PaginaActual].Opcion2;
        Opcion3.text = Pagina[PaginaActual].Opcion3;
        P1.transform.SetSiblingIndex(Random.Range(0, 2));
        P2.transform.SetSiblingIndex(Random.Range(0, 2));
        P3.transform.SetSiblingIndex(Random.Range(0, 2));
        RetroBuena.SetActive(false);
        RetroMala.SetActive(false);
    }

    public void ReloadVars()
    {
        correctos = 0;
        incorrecto = 0;
        ImagenFondo.sprite = Pagina[0].ImagenPagina;
        Pregunta.text = Pagina[0].Pregunta;
        PaginaActual = 0;
        Opcion1.text = Pagina[0].Opcion1;
        Opcion2.text = Pagina[0].Opcion2;
        Opcion3.text = Pagina[0].Opcion3;
        P1.transform.SetSiblingIndex(Random.Range(0, 3));
        P2.transform.SetSiblingIndex(Random.Range(0, 3));
        P3.transform.SetSiblingIndex(Random.Range(0, 3));
        RetroBuena.SetActive(false);
        RetroMala.SetActive(false);
        Retro.SetActive(false);
    }
}
