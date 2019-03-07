using System.Collections;
using System.Collections.Generic;
using Recursos.MELI.MODULO_2.AI_MELI2_MOD2_BAUL_RECUERDOS.Scrips;
using UnityEngine;
using UnityEngine.EventSystems;

public class Select_Elemet : MonoBehaviour, IPointerClickHandler {

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
}
