using System.Collections;
using System.Collections.Generic;
using Recursos.MELI.AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Scripts.AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Misc;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Piso : MonoBehaviour {
    // Use this for initialization
    public Transform _techo;

    public Transform _limite1;
    public Transform _limite2;
    public int[] posiciones;
    public float TiempoRegeneracion;
    private float y;
    int range = 0;


    public float _massMin, _massMax, _gravityMin, _gravityMax;
    private IEnumerator coroutine;

    public void OnTriggerExit2D(Collider2D other) {
        StartCoroutine(AssignPosition(other, TiempoRegeneracion));
    }


    private IEnumerator AssignPosition(Collider2D other, float seconds) {
        yield return new WaitForSeconds(seconds);
        if (other.gameObject.CompareTag(TAGS.ESTRELLA)) {
            Debug.Log("Estrella");
            other.transform.SetPositionAndRotation(_techo.position, Quaternion.identity);

            Vector3 tempPosition = other.transform.position;

            switch (range) {
                case 0:
                    tempPosition.x += posiciones[0];
                    tempPosition.y += posiciones[3];
                    range = 1;
                    break;
                case 1:
                    tempPosition.x += posiciones[1];
                    tempPosition.y += posiciones[4];
                    range = 2;
                    break;
                case 2:
                    tempPosition.x += posiciones[2];
                    tempPosition.y += posiciones[5];
                    range = 0;
                    break;
            }

            other.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            other.gameObject.GetComponent<Rigidbody2D>().mass = 1;
            other.gameObject.GetComponent<Rigidbody2D>().gravityScale = (float)1.2;
            other.transform.position = tempPosition;
            TiempoRegeneracion ++;
            // StartCoroutine(WaitAndPrint(6.0f, other, tempPosition));
        }
        else {
            Debug.Log("Dulce");
            other.transform.SetPositionAndRotation(_techo.position, Quaternion.identity);

            Vector3 tempPosition = other.transform.position;

            switch (range) {
                case 0:
                    tempPosition.x += posiciones[0];
                    tempPosition.y += posiciones[3];
                    range = 1;
                    break;
                case 1:
                    tempPosition.x += posiciones[1];
                    tempPosition.y += posiciones[4];
                    range = 2;
                    break;
                case 2:
                    tempPosition.x += posiciones[2];
                    tempPosition.y += posiciones[5];
                    range = 0;
                    break;
            }

            other.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            other.gameObject.GetComponent<Rigidbody2D>().mass = 4;
            other.gameObject.GetComponent<Rigidbody2D>().gravityScale = (float)0.25;
            other.transform.position = tempPosition;
            TiempoRegeneracion ++;
        }
    }
}