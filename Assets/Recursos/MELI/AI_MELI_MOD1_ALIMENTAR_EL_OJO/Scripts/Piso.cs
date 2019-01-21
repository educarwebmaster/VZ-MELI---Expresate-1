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

    public float _massMin, _massMax, _gravityMin, _gravityMax;
    private IEnumerator coroutine;

    private void OnTriggerExit2D(Collider2D other)
    {
        Vector3 pos = _techo.transform.position;
        pos.x = Random.Range(_limite1.transform.position.x, _limite2.transform.position.x);
        pos.y += Random.Range(-20f, 20f);

        StartCoroutine(WaitAndPrint(2.0f, pos, other));
    }

    private IEnumerator WaitAndPrint(float waitTime, Vector3 pos, Collider2D other)
    {
        yield return new WaitForSeconds(waitTime);
        other.transform.SetPositionAndRotation(pos, Quaternion.identity);
        other.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        other.gameObject.GetComponent<Rigidbody2D>().mass =
            Random.Range(_massMin, _massMax); //Asigna un vlaor aleatorio para la masa del objeto
        other.gameObject.GetComponent<Rigidbody2D>().gravityScale =
            Random.Range(_gravityMin, _gravityMax); //Asigna un vlaor aleatorio para la masa del objeto
        //Debug.Log("llamado");
    }
}