using System.Collections;
using AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Audio;
using Recursos.MELI.AI_MELI_11_MOD1_OJO_VELOZ.Scripts;
using Recursos.MELI.AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Scripts.AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Navegation;
using Resource.LIBRO_C.AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Scripts.AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Score;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class Evaluador : MonoBehaviour, IPointerDownHandler
{
    public int Id;
    public int Grupo;

    public bool seleccionado, habilitado, verificado;
    private Image imagenActual;
    public Sprite imagenSeleccion, imagenRespuesta, imagenInicial;
    [SerializeField] ActivityManager activityManager;
    public FXAudio _FxAudio;
    void Start()
    {
        //imagenUI = GameObject.Find("").GetComponent<Image>();
        imagenActual = gameObject.GetComponent<Image>();
    }

    private void Update()
    {
        if (seleccionado == false)
        {
            imagenActual.sprite = imagenInicial;
            habilitado = true;
        }

        if (verificado)
        {
            imagenActual.sprite = imagenRespuesta;
            enabled = false;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        seleccionado = true;
        SeleccionarImagen(seleccionado);
        
    }

    public void SeleccionarImagen(bool select)
    {
        if (habilitado)
        {
            if (select)
            {
                _FxAudio.PlayAudio(0);
                imagenActual.sprite = imagenSeleccion;
                habilitado = false;
                activityManager.AdicionarElementos(gameObject);
                
            }
        }
    }
}