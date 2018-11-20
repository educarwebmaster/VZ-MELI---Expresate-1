using UnityEngine;
using System.Collections;

public class DADO : MonoBehaviour {
    public Animator anim;
    public Vector2 RotarArriva;
    public Vector2 RotarLado;
    float i;
    float j;

    void Start()
    {
        i = RotarArriva.x;
        j = RotarLado.x;
    }

    public void AnimacionArriva()
    {
        if (RotarArriva.x < RotarArriva.y)
        {
            RotarArriva.x += 1.0f;
            anim.Play("" + RotarArriva.x);
        }
        else
        {
            RotarArriva.x = i;
            anim.Play("" + RotarArriva.x);
        }
    }

    public void AnimacionLado()
    {
        if (RotarLado.x < RotarLado.y)
        {
            RotarLado.x += 1.0f;
            anim.Play("" + RotarLado.x);
        }
        else
        {
            RotarLado.x = j;
            anim.Play("" + RotarLado.x);
        }
    }
}





