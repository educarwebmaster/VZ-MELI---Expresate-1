using System;
using UnityEngine;
using UnityEngine.UI;

namespace Recursos.MELI.MODULO_2.AI_MELI7_MOD2_LECTURA_MOVIMIENTO1.Scripts
{
	public class Palabra : MonoBehaviour
	{

		public String _respuesta;
		// Use this for initialization
		void Start () {
		
		}
	
		// Update is called once per frame
		void Update () {
			Debug.Log(gameObject.transform.GetChild(1).GetComponent<Text>().text);
		}

		public void ValidateWord()
		{
			if (gameObject.transform.GetChild(1).GetComponent<Text>().text == _respuesta)
			{
				Debug.Log("Si");
				gameObject.transform.GetComponent<InputField>().interactable = false;
				gameObject.transform.GetChild(1).GetComponent<Text>().color = Color.green;
			}
			else
			{
				Debug.Log("No");
				gameObject.transform.GetChild(1).GetComponent<Text>().text = "";
			}
		}
	}
}
