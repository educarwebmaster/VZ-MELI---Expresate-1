using System.Collections;
using System.Collections.Generic;
using Recursos.MELI.AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Scripts.AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Misc;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Piso : MonoBehaviour
{
    // Use this for initialization
    public Transform _techo;

    public Transform _limite1;
    public Transform _limite2;
    private float x,y;

    
    public float _massMin, _massMax, _gravityMin, _gravityMax;
    private IEnumerator coroutine;

    private void OnTriggerExit2D(Collider2D other)
    {
    
        Vector3 pos = _techo.transform.position;
        x = Random.Range(0f,1f);
        if (x>0 && x<0.3)
        {
            pos.x = 750;
        }
        else
        {
            if (x>=0.3 && x <0.6)
            {
                pos.x = 825;
            }
            else
            {
                pos.x = 900;
            }
        }

        //pos.x = x < 0.5f ? 750 : 900;
        y = Random.Range(0f,1f);
        pos.y += Random.Range(100f, 200f);

        StartCoroutine(WaitAndPrint(2.0f, pos, other));
    }

    private IEnumerator WaitAndPrint(float waitTime, Vector3 pos, Collider2D other)
    {
        yield return new WaitForSeconds(waitTime);
        other.transform.SetPositionAndRotation(pos, Quaternion.identity);
        other.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        other.gameObject.GetComponent<Rigidbody2D>().mass = 4;
            //Random.Range(_massMin, _massMax); //Asigna un vlaor aleatorio para la masa del objeto
        other.gameObject.GetComponent<Rigidbody2D>().gravityScale = (float) 0.25;
            //Random.Range(_gravityMin, _gravityMax); //Asigna un vlaor aleatorio para la masa del objeto
            //Debug.Log("llamado");
    }
}