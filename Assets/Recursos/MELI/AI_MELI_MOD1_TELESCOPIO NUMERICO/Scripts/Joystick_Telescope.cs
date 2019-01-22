using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joystick_Telescope : MonoBehaviour {
    
    public float speed = 5.0f;
    public float moveSpeed = 10f;
    public float turnSpeed = 50f;
    private float mouse;

    public GameObject _btnIzquierdo;
    public GameObject _btnDerecho;
    //public Transform _player;   

    private void Update() {
        //MoveCharacter(new Vector2(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical")));
        if(Input.GetKey(KeyCode.LeftArrow))
            transform.Rotate(Vector3.forward, -turnSpeed * Time.deltaTime);
        
        if(Input.GetKey(KeyCode.RightArrow))
            transform.Rotate(Vector3.forward, turnSpeed * Time.deltaTime);
        
        
  
    }

//    void MoveCharacter(Vector2 direction) {
//        
//        _player.Translate(direction*speed*Time.deltaTime);
//        
//    }

}
