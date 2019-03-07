using System.Collections;
using System.Collections.Generic;
using AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Audio;
using EasyAR;
using Recursos.MELI.AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Scripts.AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Navegation;
using Recursos.MELI.MODULO_2.AI_MELI2_MOD2_BAUL_RECUERDOS.Scrips;
using Resource.LIBRO_C.AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Scripts.AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Score;
using UnityEngine;
using UnityEngine.EventSystems;
using Image = UnityEngine.UI.Image;

public class Select_people : MonoBehaviour, IPointerClickHandler
{

[SerializeField] public Sprite _spriteTrue;
[SerializeField] private Activiti_manager1 _activitiManager1;
private Sprite _actualImage;
public bool _true, _enable;

	public void OnPointerClick(PointerEventData eventData)
	{	
		
		if (_enable)
		{
			_activitiManager1.Calificar(_true, gameObject);	
		}
	}

	private void OnMouseDown()
	{
		
	}
}
