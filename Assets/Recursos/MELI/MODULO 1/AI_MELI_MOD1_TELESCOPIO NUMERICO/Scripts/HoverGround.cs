using System.Collections;
using System.Collections.Generic;
using Recursos.MELI.AI_MELI_MOD1_TELESCOPIO_NUMERICO.Scripts;
using UnityEngine;

public class HoverGround : MonoBehaviour {

	
	[SerializeField] private ActivityMaganer _activityMaganer;

	private AudioSource _audioSource;

	private float timeAudio, Duration;
	// Use this for initialization
	void Start ()
	{
		_audioSource = gameObject.GetComponent<AudioSource>();
		
		Duration = _audioSource.clip.length;

	}
	
	// Update is called once per frame
	void Update () {
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
