using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Recursos.MELI.AI_MELI_MOD1_TELESCOPIO_NUMERICO.Scripts;
using  Recursos.MELI.AI_MELI_11_MOD1_OJO_VELOZ.Scripts;

public class popup : MonoBehaviour {

	// Use this for initialization
	
	private AudioSource _audioSource;
	[SerializeField] private ActivityManager _activityMaganer;

	private float timeAudio, Duration;
	// Use this for initialization
	void Start ()
	{
		_audioSource = gameObject.GetComponent<AudioSource>();
		
		Duration = _audioSource.clip.length;

	}
	
	// Update is called once per frame
	void Update()
	{
		timeAudio = _audioSource.time;
		if (Duration == timeAudio)
		{
			Debug.Log("si");
			_activityMaganer.Resume();
			gameObject.SetActive(false);
		}
		else
		{
			_activityMaganer.Pause();
		}
	}
}
