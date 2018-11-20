using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

//-----------------------------------------------------------------------------
//                      SISTEMA DE OBJETOS AR VECTOR Z
//              DESARROLLADO POR HECTOR STIVEN GOMEZ RAMIREZ
//-----------------------------------------------------------------------------

public class OBJETO : MonoBehaviour
{
    [Header("MARCADOR")]
    public int ID;
    [HideInInspector]
    public GameObject Me;

    [Header("VIDEO")]
    public bool Video = false;
    public int Video_index;

    [Header("ROTACIONES Y TRANSFORMACIONES")]
    public bool Elemento_3D,Recurso;
    public float Speedme = 3.0f;// La velocidad.
    public GameObject Objeto_visor;

    [Header("TEXTO INFORMATIVO")]
    public bool Texto_informativo;
    public string Texto;

    [Header("TOUSH")]
    public bool Touch = false;
    public enum Opciones { TouchAfuera, TouchAdentro, Ninguno };
    public Opciones Tipo;
    public Animator anim;
    public Animator anim_GUI;
    public GameObject touch;
    public string AnimacionTouch;
    public string AnimacionTouchGUI;

    [Header("GENERALES")]
    public string AnimacionRestablecer;
    public AudioSource AudioControler;
    public AudioClip AudioRecurso;

    [Header("ARRASTRAR OBJETO")]
    private int EstadoTouchGui;
    private float Alpha;

    [Header("Google")]
    Vector3 dist;
    float posX;
    float posY;
    bool comodin_agrandar = false;
    float n_TAMA = 0;

    [HideInInspector]
    public int video_mos = 0;
    public Vector3 Tamano_inicial;
    public Vector3 Posicion_Inicial;
    public Vector3 Rotacion_Inicial;



    void Start()
    {
        Me = this.gameObject;
        Tamano_inicial = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);//Capturar el tamaño inicial del objeto
        Posicion_Inicial = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z);
        Rotacion_Inicial = new Vector3(transform.localRotation.x, transform.localRotation.y, transform.localRotation.z);

        EstadoTouchGui = 0;
        if (Video)
        {
            video_mos = 0;
        }
        else
        {
            video_mos = 1000;
        }
    }

    void Update()
    {
        Me = this.gameObject;
        GENERAL_INTERFAZ.MEGUI.gameObject.SendMessage("Cambiar_Player", ID);

        if (Elemento_3D)
        {
            if (Recurso)
            {
                Objeto_visor.SetActive(true);
                GENERAL_INTERFAZ.video_llamado = false;
            }
            else
            {

            }
            
        }
        
        if (Video)
        {
            GENERAL_INTERFAZ.video_llamado = true;
            if (Me.activeSelf)//saber si el marcador esta siendo leido para reproducir un video
            {
                if (video_mos == 0)
                {
                    video_mos = 1;
                    Video_reproducir();
                }
                else
                {

                }
            }
        }
        
        if (Input.touchCount == 2)
            {
                // Si hay dos toques en el dispositivo...
                if (Elemento_3D)
                {
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
                    transform.localEulerAngles = new Vector3(transform.localRotation.x, rotacion, transform.localRotation.z);
                }
            }
            else
            {
                comodin_agrandar = false;
            }

        if (Input.touchCount == 1)
        {
            //animacion de ui
            if (Tipo == Opciones.TouchAfuera)
            {
                if (EstadoTouchGui == 0)
                {
                    anim_GUI.Play(AnimacionTouchGUI);
                    EstadoTouchGui = 1;
                    StartCoroutine("DesabilitarTouch");
                }
            }
        }

    }

    void OnMouseDown()
    {
        if (Elemento_3D)
        {
           dist = Camera.main.WorldToScreenPoint(transform.position);
           posX = Input.mousePosition.x - dist.x;
           posY = Input.mousePosition.y - dist.y;
       }

       if (Touch)//si es una animacion al tocar
       { 
            anim.Play(AnimacionTouch);
            //animacion del ui
            if(Tipo == Opciones.TouchAdentro)
            {
                if (EstadoTouchGui == 0)
                {
                    anim_GUI.Play(AnimacionTouchGUI);
                    EstadoTouchGui = 1;
                    StartCoroutine("DesabilitarTouch");
                }
            } 
       }
    }

    void OnMouseDrag()
    {
         if (Elemento_3D)//movimiento del objeto con el dedo
         {
            Vector3 curPos = new Vector3(Input.mousePosition.x - posX, Input.mousePosition.y - posY, dist.z);
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(curPos);
            transform.position = worldPos;
         }
    }

    public void Interfaz()
    {
        if (Texto_informativo)
        {
            GENERAL_INTERFAZ.MEGUI.gameObject.SendMessage("Actualizar_texto", Texto);
        }
    }

    public void Video_reproducir()//reproducir video y quirar AR
    {
        if (Video)
        {
            if (video_mos == 1)
            {
                video_mos = 2;
                GENERAL_INTERFAZ.MEGUI.gameObject.SendMessage("Abrir_reproductor" , Video_index);
            }
        }
    }

    public void Restaurar_video()
    {
        video_mos = 0;
    }

    public void Restaurarme()
    {
        this.gameObject.transform.localPosition = Posicion_Inicial;
        this.gameObject.transform.localScale = Tamano_inicial;
        this.gameObject.transform.localEulerAngles = Rotacion_Inicial;
    }

    public void ReproducirAudio()
    {
        //AudioControler.clip = AudioRecurso;
        //AudioControler.Play();
    }

    public void ReproducirAnimacion(string Animacion)
    {
        anim.Play(Animacion);
    }

    public IEnumerator DesabilitarTouch()//sisve para desabilitar el boton de tocame
    {
        yield return new WaitForSeconds(2f);
        touch.SetActive(false);
    }
}