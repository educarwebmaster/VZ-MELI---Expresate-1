using System.Collections;
using System.Collections.Generic;
using Audio;
using Resource.MELI.AI_MELI_MOD1_PALABRAS_REPETIDAS.Scripts;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverGroundAudio : MonoBehaviour,IPointerDownHandler {

    private AudioSource _audioSource;
    
    private float timeAudio, Duration;
    [SerializeField] private LevelAndScoreManager _levelAndScoreManager;

    [SerializeField] private Player _player;
    // Use this for initialization
    void Start ()
    {
        _audioSource = gameObject.GetComponent<AudioSource>();
		
        Duration = _audioSource.clip.length;

    }
	
    // Update is called once per frame
    void Update () {
        if (_audioSource.isPlaying)
        {
            Time.timeScale = 0;
            
            Debug.Log("Pause");
            
        }
        else
        {
            Debug.Log("Resume");
            Time.timeScale = 1;
            
        }
        

        /*timeAudio = _audioSource.time;
        if (Duration == timeAudio)
        {
            
                Debug.Log("Resume");
            Time.timeScale = 1;
			
        }
        else
        {
            Time.timeScale = 0;
            
                Debug.Log("Pause");
        }*/
    }

    private void OnMouseDown()
    {
        
    }
    
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("si");
        _audioSource.Play();
        
    }
}