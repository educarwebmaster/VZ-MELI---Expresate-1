using System.Collections;
using AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Audio;
using Recursos.MELI.AI_MELI_11_MOD1_OJO_VELOZ.Scripts;
using Recursos.MELI.AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Scripts.AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Navegation;
using Resource.LIBRO_C.AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Scripts.AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Score;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EstadoSlider : MonoBehaviour
{

	public Sprite imagenactual;
	public Sprite imagencambio;
	private bool seleccion;
	private Slider _slider;
	private GameObject _child,_child1;
	void Start ()
	{
	}
	
	
	void Update () 
	{
		_slider = gameObject.GetComponent<Slider>();

		if (_slider.value <= 21.2f)
		{
			GetChildSlider(imagencambio);
		}
		else
		{
			
			GetChildSlider(imagenactual);
		}
	}

	public void GetChildSlider(Sprite imagen)
	{
		_child = gameObject.transform.Find("Handle Slide Area").gameObject;

		if (_child != null)
		{
			Debug.Log("Si");
			_child1 = _child.gameObject.transform.Find("Handle").gameObject;
			if (_child1 != null)
			{
				Debug.Log("Si-si");
				_child1.gameObject.GetComponent<Image>().sprite = imagen;
			}
			else
			{
				Debug.Log("No-no");
			}
		}
		else
		{
			Debug.Log("No");
		}
	}


}
