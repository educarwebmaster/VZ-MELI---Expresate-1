using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System;


/************************************************************************

                     SISTEMA DE GUI VECTOR Z
              DESARROLLADO POR HECTOR STIVEN GOMEZ RAMIREZ 

*************************************************************************/

[System.Serializable]
public class Marcador
{
    public OBJETO Marcadores_Script;
    public string Marcadores_Paginas;
    public GameObject GUI;
    public GameObject ELEMENTO_3D;
    public AudioSource AUDIO;
}

public class GENERAL_INTERFAZ : MonoBehaviour {
    [Header("Pagina")]
    public Marcador[] Marcador;
    public Transform Padre;
    public GameObject Hijo;
    public string Descripccion;
    [Header("Elementos")]
    public GameObject vcr;
    public GameObject Video;
    public GameObject MENU;
    public GameObject SPLACH;
    public GameObject Objeto_tuto;
    public GameObject Informacion_Objeto;
    public GameObject camera_normal;
    public GameObject camera_visor_3d;
    public GameObject SalirMensage;
    public GameObject CameraQuit;
    public GameObject PopUp;
    public float tiempo;
    public Camera CamaraGUI;
    public Camera CamaraVideo;
    public Camera CamaraVisor3D;
    [Header("CONDICIONALES")]
	public bool Splach;
    [Header("Interfas")]
    public GameObject[] tutorial_objetos;
    public Image[] BotonesMenu;
    public Image DesplegableMenu;
    public Image VideoBackground;
    public Image VisorVideo3d;
    public Sprite MenuActivado;
    public Sprite MenuDesactivado;
    public Sprite MenuPaginadoActivado;
    public Sprite MenuPaginadoDesactivado;
    public Sprite VideoActivado;
    public Sprite VideoDesactivado;
    public Text Pagina_texto;
    public Text Descripccion_Libro;
    public Color BotonSeleccionado;
    [Header("Animaciones")]
    public Animator Reproductor;
    public Animator AnimMenu;
    public Animator menu_paginado;
    public AudioClip Clip;
    public EasyAR.CameraDeviceBehaviour ARCamara;
    string URL = "http://www.educar.com.co/publicidadvz/pop_up.php";
    ///////////////// PRIVADAS //////////////////
    private bool Menu_estado;
    private bool VideoQuit = false;
    private int estado_animacion_paginado;
    private int contador_tuto;
    private WWW www;
    private OBJETO Player;
    private AudioSource Audio;
    ///////////////// STATICOS //////////////////
    public static GameObject MEGUI;
    public static bool visor_3d;
    public static bool video_llamado = false;
    private bool video3Dopen = false;


    void Awake()
    {
        IniciarPaginas();
    }

    void Start()
    {
        StartCoroutine("Promocion");
        Descripccion_Libro.text = Descripccion;
        CamaraGUI.depth = 2;
        CamaraVisor3D.depth = 0;
        CamaraVideo.depth = -1;
        for (int i = 0; i < Marcador.Length; i++)
        {
            if (Marcador[i].Marcadores_Script.Elemento_3D)
            {
                Marcador[i].GUI.SetActive(false);
                Marcador[i].GUI.GetComponent<Camera>().depth = 1;
            }
        }
        
        Audio = GetComponent<AudioSource>();
        Player = Marcador[0].Marcadores_Script;
        contador_tuto = 0;
        tutorial_objetos[0].SetActive(true);
        MEGUI = this.gameObject;
        Menu_estado = false;
        Menu();
        if (PlayerPrefs.HasKey("tutorial"))//TUTORIAL
        {
            Objeto_tuto.SetActive(false);
        }
        else
        {
           Objeto_tuto.SetActive(true);
           PlayerPrefs.SetInt("tutorial", 1);
        }
    }

    void Update()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;

        if (Input.GetKeyDown(KeyCode.Escape)) {
            Application.CancelQuit();
            SalirMensage.SetActive(true);
        }

        if (video3Dopen)
        {
//            vcr.gameObject.SendMessage("OnPauseButton");
            Video.SetActive(false);
            CamaraVideo.depth = -1;
            if (Player.Elemento_3D && Marcador[Player.ID].ELEMENTO_3D.activeSelf && Player.transform.parent.gameObject.activeSelf)//VERIFICAR SI EL MARCADOR ES VISUALIZADO
            {
                for (int i = 0; i < Marcador.Length; i++)
                {
                    if (Marcador[i].Marcadores_Script.Elemento_3D)
                    {
                        Marcador[i].GUI.SetActive(false);
                    }
                    if(Marcador[i].Marcadores_Script.Recurso){
                        Marcador[Player.ID].GUI.SetActive(true);
                        
                    }
                    else if(Player.transform.parent.gameObject.activeSelf){
                        Marcador[Player.ID].GUI.SetActive(true);
                    }
                }
            }
        }

        /*
        if (Player.video_mos == 2)
        {
            if (barra_tiempo_video.value >= 1.0f)
            {
                //Video_final.SetActive(true);
            }
            else
            {
                //Video_final.SetActive(false);
            }
        }*/

        if (Player.Me.activeSelf)
        {
            //Pagina.text = Marcador[Player.ID].Marcadores_Paginas;
            if (Player.Elemento_3D)
            {
                VisorVideo3d.color = new Color(1, 1, 1, 1f);
                visor_3d = true;
            }
            else
            {
                VisorVideo3d.color = new Color(1, 1, 1, 0.5f);
                visor_3d = false;
            }
        }
        else
        {
            //Pagina.text = "--";
            VisorVideo3d.color = new Color(1, 1, 1, 0.5f);
            visor_3d = false;
        }
    }
    public void IniciarPaginas()
    {
        int array = 0;
        for (int i = 0; i < Marcador.Length;i++)
        {
            Marcador[i].Marcadores_Script.ID = array;
            Marcador[i].Marcadores_Script.enabled = true;
            array++;
            var NewPagina = Instantiate(Hijo) as GameObject;
            NewPagina.transform.SetParent(Padre,false);
            NewPagina.SetActive(true);
            NewPagina.GetComponent<PAGINA>().Actualizar(Marcador[i].Marcadores_Paginas);
            
        }
    }

    public void Animacion_paginado(Image Img)
    {
        if (estado_animacion_paginado == 0)
        {
            estado_animacion_paginado = 1;
            menu_paginado.Play("AbrirPaginado");
            Img.sprite = MenuPaginadoActivado;
        }
        else
        {
            estado_animacion_paginado = 0;
            menu_paginado.Play("CerrarPaginado");
            Img.sprite = MenuPaginadoDesactivado;
        }
    }

    public void Actualizar_texto(string texto_recurso)
    {
        Pagina_texto.text = texto_recurso;
    }

    public void Menu()//animaciones del menu principal de cerrar y abrir
    {
        if (Menu_estado)
        {
            Menu_estado = false;
            AnimMenu.Play("Cerrar");
            DesplegableMenu.sprite = MenuDesactivado;
        }
        else
        {
            Menu_estado = true;
            AnimMenu.Play("Abrir");
            DesplegableMenu.sprite = MenuActivado;
        }
    }

    public void EstadosBotones(int ID)
    {
        for (int i = 0; i < BotonesMenu.Length; i++)
        {
            if(BotonesMenu[i].color.a == 1)
            {
                BotonesMenu[i].color = Color.white;
            }
        }
        BotonesMenu[ID].color = BotonSeleccionado;
        click();
    }

    public void click()
    {
        Audio.PlayOneShot(Clip);
    }

    public void tuto_siguiente()
    {
        if (contador_tuto < tutorial_objetos.Length - 1)
        {
            for (int i = 0;i < tutorial_objetos.Length; i++)
            {
                tutorial_objetos[i].SetActive(false);
            }
            contador_tuto += 1;
            tutorial_objetos[contador_tuto].SetActive(true);
        }
        else
        {
            Objeto_tuto.SetActive(false);
            Informacion_Objeto.SetActive(false);
            contador_tuto = 0;
        }
    }

    public void tuto_atras()
    {
        if (contador_tuto > 0)
        {
            for (int i = 0; i < tutorial_objetos.Length; i++)
            {
                tutorial_objetos[i].SetActive(false);
            }
            contador_tuto -= 1;
            //tutorial.sprite = tutorial_imagenes[contador_tuto];
            tutorial_objetos[contador_tuto].SetActive(true);
        }
    }

    public void abrir_tuto()
    {
        for (int i = 0; i < tutorial_objetos.Length; i++)
        {
            tutorial_objetos[i].SetActive(false);
        }
        Objeto_tuto.SetActive(true);
        contador_tuto = 0;
        //tutorial.sprite = tutorial_imagenes[contador_tuto];
        tutorial_objetos[contador_tuto].SetActive(true);
    }

    public void link(string URL)// abrir url
    {
        Application.OpenURL("" + URL);
    }

    public void video()//llamar video de reproduccion
    {
        //Player.Video_reproducir_otravez();
    }

    public void Reload_Scene()
    {
        Marcador[Player.ID].Marcadores_Script.Restaurarme();
        Debug.Log("" + Player.ID);
    }

    public void Cerrar_reproductor()//cerrar menu que sale desues de un video
    {
        Video.SetActive(false);
        //Video_final.SetActive(false);
        StartCoroutine("ActivarVideoNuevamente");
        
        CamaraVideo.depth = -1;
        for (int i = 0;i < Marcador.Length;i++)
        {
            Marcador[i].Marcadores_Script.video_mos = 0;
        }
    }

    void Abrir_reproductor(int index)//abrir menu que sale despues de reporducir un video
    {
        if (video_llamado)
        {
            Video.SetActive(true);
            vcr.gameObject.SendMessage("OnOpenVideoFileIndex", index);
            vcr.gameObject.SendMessage("OnPlayButton");
            CamaraVideo.depth = 6;
            Abrir_Controles_Video();
        }   
    }

    public void Cerrar_visor_3d()//cerrar menu que sale desues de un video
    {

      //  vcr.gameObject.SendMessage("OnPauseButton");

        Cerrar_reproductor();

        if (Marcador[Player.ID].Marcadores_Script.Elemento_3D)
        {
            Marcador[Player.ID].ELEMENTO_3D.GetComponent<VISTA_OBJETO_LOCAL>().Restaurarme();
            
        }
        
        for (int i = 0; i < Marcador.Length; i++)
        {
            Marcador[i].Marcadores_Script.video_mos = 0;
            if (Marcador[i].Marcadores_Script.Recurso == false && Marcador[i].Marcadores_Script.Elemento_3D == true)
            {
                Marcador[i].Marcadores_Script.transform.GetChild(0).gameObject.GetComponent<MOSTRAR_RECURSO_GUI>().Activado = false;
            }
        }

        for (int i = 0; i < Marcador.Length; i++)
        {
            if (Marcador[i].Marcadores_Script.Elemento_3D)
            {
                Marcador[i].GUI.SetActive(false);
                Marcador[i].ELEMENTO_3D.SetActive(false);
                Marcador[i].AUDIO.enabled = true;
                Marcador[i].GUI.GetComponent<Camera>().depth = 1;
            }
        }
        video3Dopen = false;
        CamaraVisor3D.depth = 0;
        camera_normal.tag = "MainCamera";
        camera_visor_3d.tag = "Untagged";
        camera_visor_3d.SetActive(false);
    }

    public void Abrir_visor_3d()//abrir menu que sale despues de reporducir un video
    {
        if (visor_3d)
        {
            //vcr.gameObject.SendMessage("OnPauseButton");

            Cerrar_reproductor();
            for (int i = 0; i < Marcador.Length; i++)
            {
                if (Marcador[i].Marcadores_Script.Elemento_3D)
                {
                    Marcador[i].ELEMENTO_3D.SetActive(false);
                    Marcador[i].AUDIO.enabled = true;
                    Marcador[i].GUI.GetComponent<Camera>().depth = 5;
                    Marcador[i].GUI.SetActive(false);
                    
                }
            }
            if (Marcador[Player.ID].Marcadores_Script.Elemento_3D)
            {
                if (!Marcador[Player.ID].Marcadores_Script.Recurso)
                {
                    Marcador[Player.ID].Marcadores_Script.transform.GetChild(0).gameObject.GetComponent<MOSTRAR_RECURSO_GUI>().Activado = true;
                }
            }
            video3Dopen = true;
            Marcador[Player.ID].ELEMENTO_3D.GetComponent<VISTA_OBJETO_LOCAL>().Restaurarme();
            Marcador[Player.ID].GUI.SetActive(true);
            CamaraVisor3D.depth = 4;
            camera_normal.tag = "Untagged";
            camera_visor_3d.tag = "MainCamera";
            camera_visor_3d.SetActive(true);
        }
    }

    public void VisorGUI3d()
    {
        if (video3Dopen)
        {
            for (int i = 0; i < Marcador.Length; i++)
            {
                if (Marcador[i].Marcadores_Script.Elemento_3D)
                {
                    Marcador[i].GUI.SetActive(false);
                }
                Marcador[Player.ID].ELEMENTO_3D.GetComponent<VISTA_OBJETO_LOCAL>().Restaurarme();
                Marcador[Player.ID].GUI.SetActive(true);
            }
        }
    }

    void EstadosBotonesPrivado(int ID)
    {
        for (int i = 0; i < BotonesMenu.Length; i++)
        {
            if (BotonesMenu[i].color.a == 1)
            {
                BotonesMenu[i].color = Color.white;
            }
        }
        Color myColor = new Color();
        ColorUtility.TryParseHtmlString("#B6EC00FF", out myColor);
        BotonesMenu[ID].color = myColor;
    }

    void Cambiar_Player(int ID)
    {
        Player = Marcador[ID].Marcadores_Script;
        Player.Interfaz();
    }

    public void Abrir_Controles_Video()
    {
        StopCoroutine("Cerrar_controles_video");
        Reproductor.Play("Mostrar_reproductor");
        StartCoroutine("Cerrar_controles_video");
    }

    public void Permanecer_video()
    {
        StopCoroutine("Cerrar_controles_video");
        StartCoroutine("Cerrar_controles_video");
    }

    public void QuitarVideo(Image img)
    {
        if (!VideoQuit)
        {
            img.sprite = VideoDesactivado;
            
            CameraQuit.SetActive(true);
            VideoQuit = true;
        }
        else
        {
            img.sprite = VideoActivado;
            CameraQuit.SetActive(false);
            VideoQuit = false;
        }
    }

    public IEnumerator Cerrar_controles_video()
    {
        yield return new WaitForSeconds(4f);
        Reproductor.Play("Ocultar_reproductor");
    }          

    public IEnumerator ActivarVideoNuevamente()
    {
        yield return new WaitForSeconds(1f);
        Player.Restaurar_video();
    }

    public IEnumerator IniciarAR()
    {
        yield return new WaitForSeconds(5f);
        IniciarPaginas();
    }

    //cerrar la aplicacion
    public void QuitarApp()
    {
        Application.Quit();
    }

    public void Saltar(string scena)
    {
        PlayerPrefs.SetString("ScenaActual", scena);
        SceneManager.LoadScene("Transcicion");
    }

    IEnumerator Promocion()
    {
        string[] s;
        www = new WWW(URL);
        yield return www;
        s = www.text.Split(new string[] { "+" }, StringSplitOptions.None);
        if (s[0] == "correcto")
        {
            PopUp.SetActive(true);
        }
        else
        {
            PopUp.SetActive(false);
        }
    }
}

