using System.Collections;
using System.Collections.Generic;
using AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Audio;
using Recursos.MELI.AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Scripts.AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Navegation;
using Resource.LIBRO_C.AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Scripts.AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Score;
using UnityEngine;
using UnityEngine.UI;

namespace Recursos.MELI.MODULO_2.AI_MELI2_MOD2_BAUL_RECUERDOS.Scrips
{
	public class Activiti_manager : MonoBehaviour {

		[SerializeField] private FXAudio _audio;
		[SerializeField] private ScoreManager _scoreManager;
		[SerializeField] private NavegationManager _navegationManager;

		public List<GameObject> _people;

		// Use this for initialization
		void Start () {
		
		}
	
		// Update is called once per frame
		void Update () {
		
		}

		public void Calificar(bool respuesta, GameObject people)
		{
			for (int i = 0; i < _people.Count; i++)
			{
				_people[i].GetComponent<Select_people>()._enable = false;
			}
		
			if (respuesta)
			{
				people.GetComponent<Image>().sprite = people.GetComponent<Select_people>()._spriteTrue;
				_audio.PlayAudio(2);
				_scoreManager.IncreaseScore();
				StartCoroutine(showImageAnswer(respuesta));

			}
			else
			{
				people.GetComponent<Image>().sprite = people.GetComponent<Select_people>()._spriteTrue;
				_audio.PlayAudio(1);
				StartCoroutine(showImageAnswer(respuesta));
			}
		}
	
		IEnumerator showImageAnswer(bool respuesta)
		{
			yield return new WaitForSeconds(1);
		
			if (respuesta)
			{
				transform.parent.FindChild("People").FindChild("True").gameObject.active = true;
				_navegationManager.Forward(2);
			}
			else
			{
				transform.parent.FindChild("People").FindChild("False").gameObject.active = true;
			
				_navegationManager.Forward(2);
			}
		}
	}
}
