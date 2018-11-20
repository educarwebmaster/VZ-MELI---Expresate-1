using UnityEngine;
using System.Collections;

public class VISTA_OBJETO_LOCAL : MonoBehaviour {

    [Header("Animacion")]
    public bool Animacion;
    public Animator anim;
    public string Animacion_nombre;
    public Vector3 Tamano_inicial;
    public Vector3 Posicion_Inicial;
    public  Vector3 Rotacion_Inicial;
    [HideInInspector]
    public Vector3 Rotacion_Comodin;
    Vector3 dist;
    float posX;
    float posY;
    float n_TAMA = 0;
    bool comodin_agrandar = false;
    public float Speedme = 1500f;// La velocidad. 
    public AudioClip Audio;
    AudioSource AudioControler;
    [Header("Posicion")]
    public float Rotation;
    [HideInInspector]
    public bool arriba;
    [HideInInspector]
    public bool derecha;
    [HideInInspector]
    public bool izquierda;
    [HideInInspector]
    public bool abajo;

    // Use this for initialization
    void Start() {
        arriba = false;
        abajo = false;
        derecha = false;
        izquierda = false;
        AudioControler = GetComponent<AudioSource>();
        Tamano_inicial = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);//Capturar el tamaño inicial del objetoS
        Posicion_Inicial = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z);
        Rotacion_Inicial = new Vector3(transform.localRotation.x, transform.localRotation.y, transform.localRotation.z);
        Rotacion_Comodin = new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z);
        Restaurarme();
    }
	
	// Update is called once per frame
	void Update ()
    {

        if (Input.touchCount == 0)
        {
            Soltar();
        }

        if (Input.touchCount == 2)
        {
            // Si hay dos toques en el dispositivo...
                Vector2 touch0, touch1;
                float distance;
                touch0 = Input.GetTouch(0).position;
                touch1 = Input.GetTouch(1).position;
                float x1 = Input.GetTouch(0).position.x;
                float x2 = Input.GetTouch(1).position.x;
                distance = Vector2.Distance(touch0, touch1);
                float rotacion = (x1 - x2) * 2;
                float TAMA = (distance / 2) / Speedme;
                if (!comodin_agrandar)
                {
                    n_TAMA = TAMA;
                    comodin_agrandar = true;
                }
                transform.localScale = new Vector3(Tamano_inicial.x + ((TAMA) - (n_TAMA)), Tamano_inicial.y + ((TAMA) - (n_TAMA)), Tamano_inicial.z + ((TAMA) - (n_TAMA)));
        }
        else
        {
            comodin_agrandar = false;
        }

        if (arriba)
        {
            Rotation += 0.9f;
            this.transform.Rotate(Rotacion_Comodin.x + Rotation, Rotacion_Comodin.y, Rotacion_Comodin.z);
        }

        if (abajo)
        {
            Rotation += 0.9f;
            this.transform.Rotate(Rotacion_Comodin.x - Rotation, Rotacion_Comodin.y, Rotacion_Comodin.z);
        }

        if (derecha)
        {
            Rotation += 0.9f;
            this.transform.Rotate(Rotacion_Comodin.x, Rotacion_Comodin.y - Rotation, Rotacion_Comodin.z);
        }

        if (izquierda)
        {
            Rotation += 0.9f;
            this.transform.Rotate(Rotacion_Comodin.x, Rotacion_Comodin.y + Rotation, Rotacion_Comodin.z);
        }
    }

    void OnMouseDown()
    {
         dist = Camera.main.WorldToScreenPoint(transform.position);
         posX = Input.mousePosition.x - dist.x;
         posY = Input.mousePosition.y - dist.y;
         if (Animacion)
         {
            anim.Play(Animacion_nombre);
         }
    }

    void OnMouseUp()
    {
        Soltar();
    }

    void OnMouseDrag()
    {
        Vector3 curPos = new Vector3(Input.mousePosition.x - posX, Input.mousePosition.y - posY, dist.z);
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(curPos);
        transform.position = worldPos;
    }

    public void Restaurarme()
    {
        transform.localPosition = Posicion_Inicial;
        transform.localScale = Tamano_inicial;
        transform.localEulerAngles = Rotacion_Inicial;
    }

    public void AudioPlay()
    {
        AudioControler.clip = Audio;
        AudioControler.Play();
    }

    public void Flecha_arriba()
    {
        arriba = true;
    }

    public void Flecha_abajo()
    {
        abajo = true;
    }

    public void Flecha_izquerda()
    {
        izquierda = true;
    }

    public void Flecha_derecha()
    {
        derecha = true;
    }

    public void Soltar()
    { 
        arriba = false;
        abajo = false;
        derecha = false;
        izquierda = false;
        Rotacion_Comodin = new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z);
        Rotation = 1f;
    }
}
