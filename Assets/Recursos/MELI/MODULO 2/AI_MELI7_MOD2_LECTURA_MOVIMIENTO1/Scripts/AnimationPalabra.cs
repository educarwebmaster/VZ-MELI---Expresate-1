using System;
using System.Collections;
using System.Collections.Generic;
using Navegation;
using Unity.Collections;
using UnityEngine;
using UnityEngine.UI;

public class AnimationPalabra : MonoBehaviour {

	// Use this for initialization
	private AudioSource _audioSource;
	private Animator _animator;

	private float timeAudio, Duration;
	// Use this for initialization
	void Start ()
	{
		_audioSource = gameObject.GetComponent<AudioSource>();
		//Debug.Log(gameObject.GetComponent<Animator>().gameObject.active);
		Duration = _audioSource.clip.length;

	}
	
	// Update is called once per frame
	void Update () {
		/*timeAudio = _audioSource.time;
		if (Duration == timeAudio)
		{
			Debug.Log("si");
//			_activityMaganer.Resume();
			gameObject.GetComponent<Animator>().enabled = true;


		}
		else
		{
//			_activityMaganer.Pause();
			gameObject.GetComponent<Animator>().enabled= false;
		}*/

		if (_audioSource.isPlaying)
		{
			gameObject.GetComponent<Animator>().enabled= false;
		}
		else
		{
			gameObject.GetComponent<Animator>().enabled = true;
		}
	}
}
